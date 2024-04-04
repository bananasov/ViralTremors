using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

internal static class PlayerPatches
{
    [HarmonyPatch(typeof(Player), "TakeDamage")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void TakeDamage(Player __instance, float damage)
    {
        if (!__instance.IsLocal)
            return;

        ViralTremors.Mls?.LogDebug($"TakeDamage got called: {damage} ({damage / 100f})");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Player.DamageTaken.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration((damage / 100f),
                Config.Player.DamageTaken.Duration!.Value);
        }
    }

    [HarmonyPatch(typeof(Player), "Die")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void Die(Player __instance)
    {
        if (!__instance.IsLocal)
            return;

        ViralTremors.Mls?.LogDebug($"Die got called");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Player.Death.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Death.Strength!.Value,
                Config.Player.Death.Duration!.Value);
        }
    }

    [HarmonyPatch(typeof(Player), "CallRevive")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void CallRevive(Player __instance)
    {
        if (!__instance.IsLocal)
            return;

        ViralTremors.Mls?.LogDebug($"CallRevive got called");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Player.Revive.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Revive.Strength!.Value,
                Config.Player.Revive.Duration!.Value);
        }
    }

    [HarmonyPatch(typeof(Player), "Heal")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void Heal(Player __instance)
    {
        if (!__instance.IsLocal)
            return;

        ViralTremors.Mls?.LogDebug($"Heal got called");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Player.Heal.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Heal.Strength!.Value,
                Config.Player.Heal.Duration!.Value);
        }
    }
}