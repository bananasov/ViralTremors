using BepInEx;
using BepInEx.Configuration;

namespace ViralTremors.Buttplug;

internal static class Config
{
    private static ConfigFile ConfigFile { get; set; }

    internal static ConfigEntry<string> ServerUri { get; set; }

    internal static class Player
    {
        internal static class DamageTaken
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
        }

        internal static class Death
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }

        internal static class Revive
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }

        internal static class Heal
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }
    }

    internal static class Enemy
    {
        internal static class Weeping
        {
            internal static class Capture
            {
                internal static ConfigEntry<bool>? Enabled { get; set; }
                internal static ConfigEntry<float>? Duration { get; set; }
                internal static ConfigEntry<float>? Strength { get; set; }
            }
        }
    }

    internal static class Item
    {
        internal static class ShockStick
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }
    }

    internal static class DivingBell
    {
        internal static class Returning
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }

        internal static class Traveling
        {
            internal static ConfigEntry<bool>? Enabled { get; set; }
            internal static ConfigEntry<float>? Duration { get; set; }
            internal static ConfigEntry<float>? Strength { get; set; }
        }
    }

    internal static class MoneyAdded
    {
        internal static ConfigEntry<bool>? Enabled { get; set; }
        internal static ConfigEntry<float>? Duration { get; set; }
        internal static ConfigEntry<float>? Strength { get; set; }
    }

    internal static class Jumpscare
    {
        internal static ConfigEntry<bool>? Enabled { get; set; }
        internal static ConfigEntry<float>? Duration { get; set; }
        internal static ConfigEntry<float>? Strength { get; set; }
    }

    internal static class BombExplosion
    {
        internal static ConfigEntry<bool>? Enabled { get; set; }
        internal static ConfigEntry<float>? Duration { get; set; }
        internal static ConfigEntry<float>? Strength { get; set; }
    }

    internal static class Comments
    {
        internal static ConfigEntry<bool>? Enabled { get; set; }
    }

    static Config()
    {
        ConfigFile = new ConfigFile(Paths.ConfigPath + "\\ViralTremors.cfg", true);

        ServerUri = ConfigFile.Bind("Devices", "Server Uri", "ws://localhost:12345", "URI of the Intiface server.");

        #region Player binding

        #region Damage Taken binding

        Player.DamageTaken.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Damage", "Enabled"), true,
            new ConfigDescription("Vibrate when you receive damage"));
        Player.DamageTaken.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.Damage", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));

        #endregion

        #region Death binding

        Player.Death.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Death", "Enabled"), true,
            new ConfigDescription("Vibrate when you die"));
        Player.Death.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.Death", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        Player.Death.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.Death", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Revive binding

        Player.Revive.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Revive", "Enabled"), true,
            new ConfigDescription("Vibrate when you get revived"));
        Player.Revive.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.Revive", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        Player.Revive.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.Revive", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Heal binding

        Player.Heal.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Heal", "Enabled"), true,
            new ConfigDescription("Vibrate when you get hugged"));
        Player.Heal.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.Heal", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        Player.Heal.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.Heal", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #endregion

        #region Enemy binding

        #region Weeping binding

        Enemy.Weeping.Capture.Enabled =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.WeepingEnemy.Capture", "Enabled"), true,
                new ConfigDescription("Vibrate when you get captured by the weeping enemy"));
        Enemy.Weeping.Capture.Duration =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.WeepingEnemy.Capture", "Duration"), 1.0f,
                new ConfigDescription("Length of time to vibrate for"));
        Enemy.Weeping.Capture.Strength =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.WeepingEnemy.Capture", "Strength"), 1.0f,
                new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #endregion

        #region Diving Bell

        #region Traveling binding

        DivingBell.Traveling.Enabled =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Travelling", "Enabled"), true,
                new ConfigDescription("Vibrate when you go to the underworld"));
        DivingBell.Traveling.Duration =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Travelling", "Duration"), 1.0f,
                new ConfigDescription("Length of time to vibrate for"));
        DivingBell.Traveling.Strength =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Travelling", "Strength"), 1.0f,
                new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Returning binding

        DivingBell.Returning.Enabled =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Returning", "Enabled"), true,
                new ConfigDescription("Vibrate when you go to the surface"));
        DivingBell.Returning.Duration =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Returning", "Duration"), 1.0f,
                new ConfigDescription("Length of time to vibrate for"));
        DivingBell.Returning.Strength =
            ConfigFile.Bind(new ConfigDefinition("Vibrations.DivingBell.Returning", "Strength"), 1.0f,
                new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #endregion

        #region Items

        #region Shock Stick

        Item.ShockStick.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.ShockStick", "Enabled"), true,
            new ConfigDescription("Vibrate when you shock something/someone"));
        Item.ShockStick.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.ShockStick", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        Item.ShockStick.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.ShockStick", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #endregion

        #region Money

        MoneyAdded.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.MoneyAdded", "Enabled"), true,
            new ConfigDescription("Vibrate when you get money"));
        MoneyAdded.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.MoneyAdded", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        MoneyAdded.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.MoneyAdded", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Jumpscares

        Jumpscare.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Jumpscare", "Enabled"), true,
            new ConfigDescription("Vibrate when you get jumpscared"));
        Jumpscare.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.Jumpscare", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        Jumpscare.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.Jumpscare", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Bomb item explosion

        BombExplosion.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.BombExplosion", "Enabled"), true,
            new ConfigDescription("Vibrate when a bomb explodes"));
        BombExplosion.Duration = ConfigFile.Bind(new ConfigDefinition("Vibrations.BombExplosion", "Duration"), 1.0f,
            new ConfigDescription("Length of time to vibrate for"));
        BombExplosion.Strength = ConfigFile.Bind(new ConfigDefinition("Vibrations.BombExplosion", "Strength"), 1.0f,
            new ConfigDescription("The strength of the vibration (value from 0.0 to 1.0)"));

        #endregion

        #region Comment bindings

        BombExplosion.Enabled = ConfigFile.Bind(new ConfigDefinition("Vibrations.Comments", "Enabled"), true,
            new ConfigDescription("Register a comment when your toy gets vibrated"));

        #endregion
    }
}