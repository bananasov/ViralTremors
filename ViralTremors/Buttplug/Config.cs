using BepInEx;
using BepInEx.Configuration;

namespace ViralTremors.Buttplug
{
    internal class Config
    {
        private static ConfigFile ConfigFile { get; set; }

        internal static ConfigEntry<string> ServerUri { get; set; }

        #region Player related config entries
        internal static ConfigEntry<bool> DamageTakenEnabled { get; set; }
        internal static ConfigEntry<float> DamageTakenDuration { get; set; }
        
        internal static ConfigEntry<bool> DeathEnabled { get; set; }
        internal static ConfigEntry<float> DeathDuration { get; set; }
        internal static ConfigEntry<float> DeathStrength { get; set; }
        
        internal static ConfigEntry<bool> ReviveEnabled { get; set; }
        internal static ConfigEntry<float> ReviveDuration { get; set; }
        internal static ConfigEntry<float> ReviveStrength { get; set; }
        #endregion

        #region Enemy related config entries

        #region Weeping config entries
        internal static ConfigEntry<bool> WeepingEnemyCaptureEnabled { get; set; }
        internal static ConfigEntry<float> WeepingEnemyCaptureDuration { get; set; }
        internal static ConfigEntry<float> WeepingEnemyCaptureStrength { get; set; }
        #endregion
        
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

            #region Player stuff
            DamageTakenEnabled = ConfigFile.Bind("Vibrations.Damage", "Enabled", true, "Vibrate when you receive damage");
            DamageTakenDuration = ConfigFile.Bind("Vibrations.Damage", "Duration", 1.0f, "Length of time to vibrate for");
            
            DeathEnabled = ConfigFile.Bind("Vibrations.Death", "Enabled", true, "Vibrate when you die");
            DeathDuration = ConfigFile.Bind("Vibrations.Death", "Duration", 1.0f, "Length of time to vibrate for");
            DeathStrength = ConfigFile.Bind("Vibrations.Death", "Strength", 1.0f, "The strength of the vibration (value from 0.0 to 1.0)");
            
            ReviveEnabled = ConfigFile.Bind("Vibrations.Revive", "Enabled", true, "Vibrate when you get revived");
            ReviveDuration = ConfigFile.Bind("Vibrations.Revive", "Duration", 1.0f, "Length of time to vibrate for");
            ReviveStrength = ConfigFile.Bind("Vibrations.Revive", "Strength", 1.0f, "The strength of the vibration (value from 0.0 to 1.0)");
            #endregion

            #region Enemy stuff

            #region Weeping bot
            WeepingEnemyCaptureEnabled = ConfigFile.Bind("Vibrations.WeepingEnemy.Capture", "Enabled", true, "Vibrate when you get captured by the weeping enemy");
            WeepingEnemyCaptureDuration = ConfigFile.Bind("Vibrations.WeepingEnemy.Capture", "Duration", 1.0f, "Length of time to vibrate for");
            WeepingEnemyCaptureStrength = ConfigFile.Bind("Vibrations.WeepingEnemy.Capture", "Strength", 1.0f, "The strength of the vibration (value from 0.0 to 1.0)");
            #endregion
            
            #endregion
        }
    }
}
