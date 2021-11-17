using Ookii.Dialogs.Wpf;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace Spellborn_Installer_v2
{
    public partial class Window1 : Window
    {
        private string installPath = string.Empty;

        /*internal Grid grStep1;

        internal TextBlock lbl_installLocation;

        internal TextBlock lbl_downloadProgress;

        internal Button btnClose;

        private bool _contentLoaded;*/

        public Window1()
        {
            InitializeComponent();
        }

        public void btn_SelectLocation(object sender, RoutedEventArgs e)
        {
            VistaFolderBrowserDialog vistaFolderBrowserDialog = new VistaFolderBrowserDialog();
            vistaFolderBrowserDialog.Description = "Choose the installation location for The Chronicles of Spellborn.";
            vistaFolderBrowserDialog.UseDescriptionForTitle = true;
            vistaFolderBrowserDialog.ShowDialog(this);
            installPath = vistaFolderBrowserDialog.SelectedPath + "\\The Chronicles of Spellborn";
            lbl_installLocation.Text = installPath.ToString() + "\\The Chronicles of Spellborn";
        }

        public void btn_ConfirmLocation(object sender, RoutedEventArgs e)
        {
            if (installPath.Contains(":\\"))
            {
                registryManipulation.updateKeyValue("installpath", installPath);
                new MainWindow().Show();
                Close();
            }
            else
            {
                MessageBox.Show("Sorry, but this is not a valid installation path. Please pick a correct path.", "Invalid installation path", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*[DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (!_contentLoaded)
            {
                _contentLoaded = true;
                Uri resourceLocator = new Uri("/launcher;component/installationwizard.xaml", UriKind.Relative);
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
                    grStep1 = (Grid)target;
                    break;
                case 2:
                    ((Button)target).Click += btn_ConfirmLocation;
                    break;
                case 3:
                    lbl_installLocation = (TextBlock)target;
                    break;
                case 4:
                    lbl_downloadProgress = (TextBlock)target;
                    break;
                case 5:
                    ((Button)target).Click += btn_SelectLocation;
                    break;
                case 6:
                    btnClose = (Button)target;
                    btnClose.Click += BtnClose_Click;
                    break;
                default:
                    _contentLoaded = true;
                    break;
            }
        }*/
    }
}
