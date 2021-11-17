using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;

namespace Spellborn_Installer_v2
{
    internal class updateHandler
    {
        internal static dynamic getJsonItem(string file)
        {
            return JsonConvert.DeserializeObject<object>(new StreamReader(new WebClient().OpenRead("https://files.spellborn.org/" + file)).ReadToEnd());
        }

        internal static bool checkIfChecksumMatches(string file, string checksum)
        {
            using MD5 mD = MD5.Create();
            using FileStream inputStream = File.OpenRead(file);
            if (BitConverter.ToString(mD.ComputeHash(inputStream)).Replace("-", "").ToLowerInvariant() == checksum)
            {
                return true;
            }
            return false;
        }

        internal static dynamic fetchUpdates()
        {
            return JsonConvert.DeserializeObject<List<UpdateJson>>(new StreamReader(new WebClient().OpenRead("https://files.spellborn.org/updates.json")).ReadToEnd());
        }
    }
}
