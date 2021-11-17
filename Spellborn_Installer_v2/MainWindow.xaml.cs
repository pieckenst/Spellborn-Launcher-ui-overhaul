using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using Ionic.Zip;
using log4net;
using log4net.Config;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using Microsoft.Win32;
using Ookii.Dialogs.Wpf;

namespace Spellborn_Installer_v2
{
    public partial class MainWindow : Window
    {
        private string installedVersion;

        private dynamic jsonLatest;

        private MessageBoxResult dialogResult;

        private string installPath = registryManipulation.getKeyValue("installPath");

        private bool downloadFinished;

        private int totalFiles;

        private int filesExtracted;

        private string currentVersion;

        private dynamic updateJson;

        private bool enableLaunch;

        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /*internal Label versionLabel;

        internal Label lbl_installedVersion;

        internal ProgressBar progressBar;

        internal Image logoBottom;

        internal TabControl contentBox;

        internal TabItem welcome;

        internal WebView2 browser;

        internal TabItem settings;

        internal Grid grStep11;

        internal TextBlock lbl_installLocationx;

        internal TextBlock lbl_downloadProgressx;

        internal Button btn_ForceRedownload;

        internal Button btnClosex;

        internal Button btn_ResetinstallationPath;

        internal Button btn_BackToMain;

        internal TabItem install;

        internal Grid grStep1;

        internal Button btn_confirmInstallationLocation;

        internal TextBlock lbl_installLocation;

        internal TextBlock lbl_downloadProgress;

        internal Button btn_selectInstallDir;

        internal Button btnClose;

        internal Button btn_Settings;

        internal Button btn_CloseForm;

        internal Button lbl_progressBar;

        internal Button btn_Minimize;*/

        //private bool _contentLoaded;

        public MainWindow()
        {
            XmlConfigurator.Configure();
            _log.Info("Launcher initializing");
            InitializeComponent();
            _log.Info("Initializing async browser");
            //InitializeAsync();
            if (!registryManipulation.detectInstallation())
            {
                _log.Info("Clean install detected/no registry installpath key found");
                contentBox.SelectedItem = install;
                installPath = "C:\\Games\\Spellborn";
                lbl_progressBar.Content = "No installation found - please choose an installation path.";
            }
            else
            {
                _log.Info("Starting startupRoutine thread");
                new Thread(startupRoutine).Start();
            }
        }

        private async void InitializeAsync()
        {
            CoreWebView2Environment environment = await CoreWebView2Environment.CreateAsync(null, Path.Combine(Path.GetTempPath(), "SpellbornLauncher"));
            await browser.EnsureCoreWebView2Async(environment);
        }

        public void startupRoutine()
        {
            _log.Info("Trying to fetch the launcher checkpage");
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    using (webClient.OpenRead("https://files.spellborn.org/launcher/launcher-new.html"))
                    {
                    }
                }
                _log.Info("Fetched the launcher checkpage, OK");
            }
            catch
            {
                base.Dispatcher.Invoke(delegate
                {
                    Hide();
                });
                MessageBox.Show("We could not reach our file server - this most likely means that you are not connected to the internet, you are not able to connect to our server or our file server is down. Please check our Discord if there is any maintenance ongoing.", "File server could not be reached", MessageBoxButton.OK, MessageBoxImage.Hand);
                _log.Error("ERROR: Failure fetching the checkpage - this most likely means internet issues or not being able to reach server. Or the server is down, also an option.");
            }
            browser.Dispatcher.Invoke(() => browser.Source = new Uri("https://files.spellborn.org/launcher/launcher-new.html"));
            _log.Info("Requested to change the browser webpage");
            _log.Info("Fetching the latest installed version from the registry");
            updateProgressBar("Checking the currently installed version.");
            installedVersion = registryManipulation.getKeyValue("installedVersion");
            _log.Info("Latest installed version is " + installedVersion.ToString());
            updateVersionLabel(installedVersion.ToString());
            updateProgressBar("Checking the latest available version.");
            _log.Info("Fetching latest version from the file server");
            jsonLatest = updateHandler.getJsonItem("latest.json");
            _log.Info("Managed to get the latest.json file");
            if (installedVersion != jsonLatest.version.ToString())
            {
                _log.Info("Currently installed version does not match with latest.json");
                if (installedVersion == "false")
                {
                    _log.Info("Found nothing in the registry, this is most likely a clean install. Go forwards with full install.");
                    updateProgressBar("Nothing found, full install pending.");
                    browser.Dispatcher.Invoke(() => browser.Source = new Uri("https://files.spellborn.org/launcher/welcome.html"));
                    _log.Info("Requested browser to load the launcher welcome/install page ");
                    _log.Info("Calling download function to download newest versions. Information passed through is: filename: " + jsonLatest.file + " checksum: " + jsonLatest.checksum + " version: " + jsonLatest.version);
                    downloadFile(jsonLatest.file, jsonLatest.checksum, jsonLatest.version);
                }
                else
                {
                    _log.Info("Version doesn't match, but registry tells that we are installed. Proceeding with fetching updates.");
                    updateProgressBar("Checking for updates");
                    checkUpdates();
                }
            }
            else
            {
                _log.Info("Version doesn't match, so check for updates.");
                updateProgressBar("Checking for updates");
                checkUpdates();
            }
            _log.Info("Versions seem to match");
        }

        public void unzipFile(string file, string version)
        {
            _log.Info("Starting with unzipping ZIP file. Filename: " + file + " version: " + version);
            using (ZipFile zipFile = ZipFile.Read(file))
            {
                totalFiles = zipFile.Count;
                filesExtracted = 0;
                zipFile.ExtractProgress += ZipExtractProgress;
                zipFile.ExtractAll(installPath, ExtractExistingFileAction.OverwriteSilently);
            }
            _log.Info("Unzipping completed, storing new version " + version + " in the registry");
            registryManipulation.updateKeyValue("installedVersion", version);
            _log.Info("Stored new version in registry, new value is " + version);
            updateVersionLabel(version);
            _log.Info("Delete ZIP-file " + file);
            File.Delete(file);
            _log.Info("Deleted, now check for updates again.");
            checkUpdates();
        }

        private bool checkUpdates()
        {
            currentVersion = registryManipulation.getKeyValue("installedVersion");
            _log.Info("Getting installed version from registry. It is " + installedVersion);
            _log.Info("Fetch the updates.json file from file server");
            dynamic updates = updateHandler.fetchUpdates();
            int i;
            for (i = 0; i < updates.Count; i++)
            {
                if (updates[i].Update.appliesTo == currentVersion)
                {
                    _log.Info("We found an update applicable to us");
                    if (updates[i].Update.enabled == "false")
                    {
                        _log.Info("Update is applicable to us, but not yet enabled. Take no action and enable play button");
                        enablePlayButton();
                        return false;
                    }
                    _log.Info("Update found that is applicable to us and it is enabled. Set progressbar to fixed value of 0 and stop it from looping. Update the label.");
                    setProgressBarToLoop(value: false);
                    updateProgressBarValue(0.0);
                    updateProgressBar("Update found, preparing to install update.");
                    _log.Info("Fetch the patchnotes in the browser window");
                    browser.Dispatcher.Invoke(() => browser.Source = new Uri(("https://files.spellborn.org/patchnotes/" + updates[i].Update.patchnotes).ToString()));
                    _log.Info("Calling download function to download update. Information passed through is: filename: " + updates[i].Update.file + " checksum: " + updates[i].Update.checksum + " version: " + updates[i].Update.version);
                    downloadFile(updates[i].Update.file, updates[i].Update.checksum, updates[i].Update.version);
                    return true;
                }
            }
            _log.Info("All seems OK, enable the play button.");
            enablePlayButton();
            return false;
        }

        private void enablePlayButton()
        {
            updateProgressBar("Launch The Game");
            updateProgressBarValue(100.0);
            _log.Info("Play button enabled");
            enableLaunch = true;
        }

        private void ZipExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry)
            {
                filesExtracted++;
                updateProgressBarValue(100 * filesExtracted / totalFiles);
                updateProgressBar("Extracting files: " + filesExtracted + " out of " + totalFiles);
            }
        }

        private void downloadFile(dynamic file, dynamic checksum, dynamic version)
        {
            try
            {
                _log.Info("Test if we have write access - if this fails, remove registry key and ask for different install location. Remove test file afterwards.");
                File.WriteAllText(Path.Combine(installPath, "testfile.txt"), "This is a testfile");
                File.Delete(installPath + "\\testfile.txt");
            }
            catch
            {
                _log.Error("That did not go according to plan, writing seems to have failed.");
                base.Dispatcher.Invoke(delegate
                {
                    MessageBox.Show("You have tried to install The Chronicles of Spellborn in a location that requires administrator access. Since Spellborn is so old, this is not recommended. We will open up a file browser so you can reset your installation location. To keep your current install location, please restart this launcher as administrator.", "There is an issue with the install location", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                });
                _log.Error("Removed installpath in registry to allow picking new path.");
                registryManipulation.deleteKeyValue("installpath");
                base.Dispatcher.BeginInvoke((Action)delegate
                {
                    contentBox.SelectedItem = install;
                });
                _log.Info("Closing this window, installpath has been removed - restarting application");
            }
            string uriString = "https://files.spellborn.org/" + file;
            _log.Info("Check if the file already exists");
            if (File.Exists(installPath + "/" + file))
            {
                _log.Info("File with same name already found (" + file + "). Checking if checksum matches.");
                updateProgressBar("Found existing file, verifying file.");
                setProgressBarToLoop(value: true);
                _log.Info("Calculating MD5 checksum of the downloaded file " + file);
                if (CalculateMD5(installPath + "/" + file) != checksum.ToString())
                {
                    _log.Info("Checksum calculated and compared - file does not match, download again.");
                    updateProgressBar("Existing file is incomplete, download again.");
                    setProgressBarToLoop(value: false);
                    _log.Info("Restarting download");
                    using WebClient webClient = new WebClient();
                    webClient.DownloadProgressChanged += wc_DownloadProgressChanged;
                    webClient.DownloadFileCompleted += wc_DownloadFileCompleted;
                    webClient.QueryString.Add("file", file.ToString());
                    webClient.QueryString.Add("checksum", checksum.ToString());
                    webClient.QueryString.Add("version", version.ToString());
                    webClient.DownloadFileAsync(new Uri(uriString), installPath + "/" + file);
                }
                else
                {
                    _log.Info("File matches checksum, starting extraction");
                    updateProgressBar("Extracting download.");
                    setProgressBarToLoop(value: false);
                    unzipFile((installPath + "\\" + file).ToString(), version.ToString());
                }
            }
            else
            {
                _log.Info("File not found, downloading");
                using WebClient webClient2 = new WebClient();
                webClient2.DownloadProgressChanged += wc_DownloadProgressChanged;
                webClient2.DownloadFileCompleted += wc_DownloadFileCompleted;
                webClient2.QueryString.Add("file", file.ToString());
                webClient2.QueryString.Add("checksum", checksum.ToString());
                webClient2.QueryString.Add("version", version.ToString());
                webClient2.DownloadFileAsync(new Uri(uriString), installPath + "/" + file);
            }
        }

        private void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            updateProgressBarValue(e.ProgressPercentage);
            updateProgressBar("Downloading file, " + e.ProgressPercentage + " % complete");
        }

        private void wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            updateProgressBarValue(0.0);
            if (e.Error != null)
            {
                MessageBox.Show("An error ocurred while trying to download file:" + e.Error.Message);
                _log.Error("Something went wrong during the download: " + e.Error.Message);
                return;
            }
            _log.Info("Download completed");
            updateProgressBar("Download completed, verifying download.");
            setProgressBarToLoop(value: true);
            string text = ((WebClient)sender).QueryString["file"];
            string checksum = ((WebClient)sender).QueryString["checksum"];
            string version = ((WebClient)sender).QueryString["version"];
            _log.Info("Verifying checksum of downloaded file.");
            if (updateHandler.checkIfChecksumMatches(installPath + "/" + text, checksum))
            {
                _log.Info("File checksum matches");
                updateProgressBar("File valid, proceeding!");
                setProgressBarToLoop(value: false);
                unzipFile((installPath + "\\" + text).ToString(), version);
            }
            else
            {
                _log.Error("File checksum does not match, download invalid. Restart launcher to try again.");
                updateProgressBar("File download invalid!");
                MessageBox.Show("The download looks to be invalid, please relaunch the launcher to try again.");
            }
        }

        private static string CalculateMD5(string filename)
        {
            using MD5 mD = MD5.Create();
            using FileStream inputStream = File.OpenRead(filename);
            return BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant();
        }

        public void updateProgressBar(string text)
        {
            base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                lbl_progressBar.Content = text;
            });
        }

        public void updateVersionLabel(string text)
        {
            base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                lbl_installedVersion.Content = text;
            });
        }

        public void updateProgressBarValue(double value)
        {
            base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                progressBar.Value = value;
            });
        }

        public void setProgressBarToLoop(bool value)
        {
            base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (ThreadStart)delegate
            {
                progressBar.IsIndeterminate = value;
            });
        }

        private void Lbl_progressBar_Click(object sender, RoutedEventArgs e)
        {
            if (enableLaunch)
            {
                Process.Start(installPath + "\\bin\\client\\Sb_client.exe");
                Close();
            }
        }

        private void Btn_Minimize_Click(object sender, RoutedEventArgs e)
        {
            base.WindowState = WindowState.Minimized;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                using RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Spellborn\\The Chronicles of Spellborn\\Settings", writable: true);
                if (registryKey != null)
                {
                    registryKey.SetValue("language", cbx_gameLanguage.SelectedValue);
                    return;
                }
                using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("SOFTWARE\\WOW6432Node\\Spellborn\\The Chronicles of Spellborn\\Settings", writable: true);
                registryKey2.SetValue("language", cbx_gameLanguage.SelectedValue);
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong - have you launched the launcher as administrator?");
            }
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }

        private void Btn_selectInstallDir_OnClick(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            vistaFolderBrowserDialog.Description = "Choose the installation location for The Chronicles of Spellborn.";
            vistaFolderBrowserDialog.UseDescriptionForTitle = true;
            vistaFolderBrowserDialog.ShowDialog(this);
            installPath = vistaFolderBrowserDialog.SelectedPath + "\\The Chronicles of Spellborn";
            lbl_installLocation.Text = installPath.ToString();
            try
            {
                Directory.CreateDirectory(installPath);
                btn_confirmInstallationLocation.IsEnabled = true;
            }
            catch (Exception)
            {
                _log.Error("Path not writeable");
                MessageBox.Show("This path is not writeable - please select another one.", "Path not writeable", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void btn_confirmInstallationLocation_Click(object sender, RoutedEventArgs e)
        {
            if (installPath.Contains(":\\"))
            {
                registryManipulation.updateKeyValue("installpath", installPath);
                _log.Info("New installation path chosen; " + installPath);
                startupRoutine();
                contentBox.SelectedItem = welcome;
            }
            else
            {
                MessageBox.Show("Sorry, but this is not a valid installation path. Please pick a correct path.", "Invalid installation path", MessageBoxButton.OK, MessageBoxImage.Hand);
                _log.Error("Invalid path chosen; " + installPath);
            }
        }

        private void btn_ForceRedownload_Click(object sender, RoutedEventArgs e)
        {
            registryManipulation.deleteKeyValue("installedVersion");
            _log.Info("Removed currently installed version from registry");
            MessageBox.Show("The current version has been reset and the launcher will re-download the game from scratch on the next launch.", "Force redownload activated", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void btn_ResetinstallationPath_Click(object sender, RoutedEventArgs e)
        {
            registryManipulation.deleteKeyValue("installPath");
            _log.Info("Removed installation path from registry");
            MessageBox.Show("The installation path has been removed. Make sure to move your game files to the new location, or choose to redownload the game, otherwise the launcher will crash.", "Installation path removed", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            contentBox.SelectedItem = install;
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            contentBox.SelectedItem = settings;
        }

        private void btn_BackToMain_Click(object sender, RoutedEventArgs e)
        {
            contentBox.SelectedItem = welcome;
        }

        private void contentBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnClose1_Click(object sender, RoutedEventArgs e)
        {

        }

        /*[DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (!_contentLoaded)
            {
                _contentLoaded = true;
                Uri resourceLocator = new Uri("/launcher;component/mainwindow.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }*/

        /*[DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    ((MainWindow)target).MouseDown += MainWindow_OnMouseDown;
                    break;
                case 2:
                    versionLabel = (Label)target;
                    break;
                case 3:
                    lbl_installedVersion = (Label)target;
                    break;
                case 4:
                    progressBar = (ProgressBar)target;
                    break;
                case 5:
                    logoBottom = (Image)target;
                    break;
                case 6:
                    contentBox = (TabControl)target;
                    break;
                case 7:
                    welcome = (TabItem)target;
                    break;
                case 8:
                    browser = (WebView2)target;
                    break;
                case 9:
                    settings = (TabItem)target;
                    break;
                case 10:
                    grStep11 = (Grid)target;
                    break;
                case 11:
                    lbl_installLocationx = (TextBlock)target;
                    break;
                case 12:
                    lbl_downloadProgressx = (TextBlock)target;
                    break;
                case 13:
                    btn_ForceRedownload = (Button)target;
                    btn_ForceRedownload.Click += btn_ForceRedownload_Click;
                    break;
                case 14:
                    btnClosex = (Button)target;
                    btnClosex.Click += BtnClose_Click;
                    break;
                case 15:
                    btn_ResetinstallationPath = (Button)target;
                    btn_ResetinstallationPath.Click += btn_ResetinstallationPath_Click;
                    break;
                case 16:
                    btn_BackToMain = (Button)target;
                    btn_BackToMain.Click += btn_BackToMain_Click;
                    break;
                case 17:
                    install = (TabItem)target;
                    break;
                case 18:
                    grStep1 = (Grid)target;
                    break;
                case 19:
                    btn_confirmInstallationLocation = (Button)target;
                    btn_confirmInstallationLocation.Click += btn_confirmInstallationLocation_Click;
                    break;
                case 20:
                    lbl_installLocation = (TextBlock)target;
                    break;
                case 21:
                    lbl_downloadProgress = (TextBlock)target;
                    break;
                case 22:
                    btn_selectInstallDir = (Button)target;
                    btn_selectInstallDir.Click += Btn_selectInstallDir_OnClick;
                    break;
                case 23:
                    btnClose = (Button)target;
                    btnClose.Click += BtnClose_Click;
                    break;
                case 24:
                    btn_Settings = (Button)target;
                    btn_Settings.Click += btn_Settings_Click;
                    break;
                case 25:
                    btn_CloseForm = (Button)target;
                    btn_CloseForm.Click += BtnClose_Click;
                    break;
                case 26:
                    lbl_progressBar = (Button)target;
                    lbl_progressBar.Click += Lbl_progressBar_Click;
                    break;
                case 27:
                    btn_Minimize = (Button)target;
                    btn_Minimize.Click += Btn_Minimize_Click;
                    break;
                default:
                    _contentLoaded = true;
                    break;
            }
        }*/
    }
}
