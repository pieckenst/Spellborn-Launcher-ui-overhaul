using Newtonsoft.Json;

namespace Spellborn_Installer_v2
{
    public class UpdateJson
    {
        [JsonProperty("update")]
        public Update Update { get; set; }
    }
}
