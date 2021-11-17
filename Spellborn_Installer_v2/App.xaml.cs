﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.CodeDom.Compiler;
using System.Diagnostics;
using AutoUpdaterDotNET;

namespace Spellborn_Installer_v2
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private dynamic launcher;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            AutoUpdater.RunUpdateAsAdmin = false;
            AutoUpdater.Start("https://files.spellborn.org/launcher/launcher2-updates.xml");
            new MainWindow().Show();
        }

        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            base.Startup += Application_Startup;
        }

        [STAThread]
        [DebuggerNonUserCode]
        [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {

            App appp = new App();
            appp.InitializeComponent();
            appp.Run();
        }
    }
}
