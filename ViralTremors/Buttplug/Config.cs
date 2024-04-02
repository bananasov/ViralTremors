using BepInEx;
using BepInEx.Configuration;

namespace ViralTremors.Buttplug
{
    internal class Config
    {
        private static ConfigFile ConfigFile { get; set; }

        internal static ConfigEntry<string> ServerUri { get; set; }

        #region Player related config files
        internal static ConfigEntry<bool> DamageTakenEnabled { get; set; }
        internal static ConfigEntry<float> DamageTakenDuration { get; set; }
        #endregion

        static Config()
        {
            ConfigFile = new ConfigFile(Paths.ConfigPath + "\\ViralTremors.cfg", true);

            ServerUri = ConfigFile.Bind(
                "Devices",
                "Server Uri",
                "ws://localhost:12345",
                "URI of the Intiface server."
            );
            
            DamageTakenEnabled = ConfigFile.Bind("Vibrations.DamageReceived", "Enabled", true, "Vibrate when you receive damage");
            DamageTakenDuration = ConfigFile.Bind("Vibrations.DamageReceived", "Duration", 1.0f, "Length of time to vibrate for");
        }
    }
}
