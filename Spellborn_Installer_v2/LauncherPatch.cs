using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;

namespace Spellborn_Installer_v2
{
    public partial class LauncherPatch : Window
    {
        private dynamic launcher;

        //private bool _contentLoaded;

        public LauncherPatch()
        {
            InitializeComponent();
            launcher = updateHandler.getJsonItem("launcher.json");
            File.Move(Assembly.GetEntryAssembly().Location, Assembly.GetEntryAssembly().Location + ".old");
            _ = ((Assembly.GetExecutingAssembly().GetName().Version.ToString() != launcher.version.ToString()) ? true : false);
        }

        /*[DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (!_contentLoaded)
            {
                _contentLoaded = true;
                Uri resourceLocator = new Uri("/launcher;component/launcherpatch.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }*/

        /*[DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            _contentLoaded = true;
        }*/
    }
}
