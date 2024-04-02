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
        
        ViralTremors.Mls.LogDebug($"TakeDamage got called: {damage} ({damage / 100f})");

        if (ViralTremors.DeviceManager.IsConnected() && Config.DamageTakenEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration((damage / 100f), Config.DamageTakenDuration.Value);
        }
    }
    
    [HarmonyPatch(typeof(Player), "Die")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void Die(Player __instance)
    {
        if (!__instance.IsLocal)
            return;
        
        ViralTremors.Mls.LogDebug($"Die got called");

        if (ViralTremors.DeviceManager.IsConnected() && Config.DeathEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DeathStrength.Value, Config.DeathDuration.Value);
        }
    }
}