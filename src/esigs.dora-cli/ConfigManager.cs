using System.IO;
using System.Text.Json;

namespace esigs.dora_cli
{
    public static class ConfigManager
    {
        private static readonly string ConfigDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".config", "esigs", "dora-cli");
        private static readonly string ConfigFilePath = Path.Combine(ConfigDirectory, "config.json");
        private static readonly string DefaultDataDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), ".dora-cli", "data");
        private static readonly string DefaultDataFilePath = Path.Combine(DefaultDataDirectory, "dora_metrics.json");

        public static DoraCliConfig LoadConfig()
        {
            if (!Directory.Exists(ConfigDirectory))
            {
                Directory.CreateDirectory(ConfigDirectory);
            }

            if (!File.Exists(ConfigFilePath))
            {
                var defaultConfig = new DoraCliConfig { FilePath = DefaultDataFilePath };
                SaveConfig(defaultConfig);
                return defaultConfig;
            }

            var json = File.ReadAllText(ConfigFilePath);
            return JsonSerializer.Deserialize<DoraCliConfig>(json) ?? new DoraCliConfig();
        }

        public static void SaveConfig(DoraCliConfig config)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(config, options);
            File.WriteAllText(ConfigFilePath, json);
        }

        public static string GetDataFilePath()
        {
            var config = LoadConfig();
            if (string.IsNullOrEmpty(config.FilePath))
            {
                // If config.json exists but filePath is empty, use default and save it.
                config.FilePath = DefaultDataFilePath;
                SaveConfig(config);
            }

            // Ensure the data directory exists
            var dataDir = Path.GetDirectoryName(config.FilePath);
            if (!string.IsNullOrEmpty(dataDir) && !Directory.Exists(dataDir))
            {
                Directory.CreateDirectory(dataDir);
            }

            return config.FilePath;
        }
    }
}
