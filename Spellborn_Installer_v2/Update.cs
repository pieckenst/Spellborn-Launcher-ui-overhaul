using Newtonsoft.Json;

namespace Spellborn_Installer_v2
{
    public class Update
    {
        [JsonProperty("applies_to")]
        public string appliesTo { get; set; }

        [JsonProperty("version")]
        public string version { get; set; }

        [JsonProperty("file")]
        public string file { get; set; }

        [JsonProperty("patchnotes")]
        public string patchnotes { get; set; }

        [JsonProperty("checksum")]
        public string checksum { get; set; }

        [JsonProperty("server")]
        public string files { get; set; }

        [JsonProperty("enabled")]
        public string enabled { get; set; }
    }
}
