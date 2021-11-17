using Microsoft.Win32;
using System;
using System.Windows;

namespace Spellborn_Installer_v2
{
    internal class registryManipulation
    {
        private static object keyValue;

        public static string getKeyValue(string keyName)
        {
            try
            {
                using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\The Chronicles of Spellborn");
                if (registryKey != null)
                {
                    try
                    {
                        if (registryKey.GetValue(keyName) != null)
                        {
                            return registryKey.GetValue(keyName).ToString();
                        }
                    }
                    catch
                    {
                        return "false";
                    }
                    return "false";
                }
                return "false";
            }
            catch (Exception)
            {
                return "false";
            }
        }

        public static void updateKeyValue(string keyName, string keyValue)
        {
            try
            {
                using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\The Chronicles of Spellborn", writable: true);
                if (registryKey != null)
                {
                    registryKey.SetValue(keyName, keyValue);
                    return;
                }
                using RegistryKey registryKey2 = Registry.CurrentUser.CreateSubKey("Software\\The Chronicles of Spellborn", writable: true);
                registryKey2.SetValue(keyName, keyValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void deleteKeyValue(string keyName)
        {
            try
            {
                using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\The Chronicles of Spellborn", writable: true);
                registryKey.DeleteValue(keyName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static bool detectInstallation()
        {
            try
            {
                using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\The Chronicles of Spellborn");
                if (registryKey != null)
                {
                    try
                    {
                        if (registryKey.GetValue("installPath") != null)
                        {
                            return true;
                        }
                        return false;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
