using Newtonsoft.Json;
using Pixeler.Net.Models;

namespace Pixeler.Net.Classes;

internal static class ConfigurationManager
{
    private const string ConfigFile = "Pixeler.Net.config.json";

    private static readonly string AppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    private static readonly string ConfigPath = Path.Combine(AppData, ConfigFile);

    public static CanvasConfiguration LoadConfigFromFile(string? file = null)
    {
        file ??= ConfigPath;

        if (!File.Exists(file))
        {
            Pixeler.StaticLogMessage("No configuration file was found. Proceeding with default values.");
            return new();
        }

        try
        {
            var config = JsonConvert.DeserializeObject<CanvasConfiguration>(File.ReadAllText(file));

            if (config is null)
            {
                Pixeler.StaticLogMessage("Configuration was null when loading from file. Reconfiguration is needed.");
                return new();
            }

            return config;
        }
        catch (Exception e)
        {
            Pixeler.StaticLogMessage($"Failed to load settings.\n{e.GetType().Name}: {e.Message}\n{e.StackTrace}\nReconfiguration required.");
            return new();
        }
    }

    public static void SaveConfigToFile(this CanvasConfiguration config, string? file = null)
    {
        file ??= ConfigPath;

        try
        {
            var serialized = JsonConvert.SerializeObject(config);

            if (string.IsNullOrWhiteSpace(serialized) || serialized is "{}")
            {
                Pixeler.StaticLogMessage("Failed to serialize configuration to Json : Aborting file save to preserve previous configurations.");
                return;
            }

            File.WriteAllText(file, serialized);
        }
        catch (Exception e)
        {
            Pixeler.StaticLogMessage($"Failed to save settings.\n{e.GetType().Name}: {e.Message}\n{e.StackTrace}");
        }
    }
}
