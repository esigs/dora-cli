using System.Text.Json.Serialization;

namespace esigs.dora_cli
{
    public class DoraCliConfig
    {
        [JsonPropertyName("filePath")]
        public string FilePath { get; set; } = string.Empty;
    }
}
