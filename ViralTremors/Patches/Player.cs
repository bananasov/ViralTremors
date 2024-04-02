using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

internal static class PlayerPatches
{
    [HarmonyPatch(typeof(Player), "TakeDamage")]
    [HarmonyPostfix]
    private static void TakeDamage(Player __instance, float damage)
    {
        if (!__instance.IsLocal)
            return;
        
        ViralTremors.Mls.LogDebug($"TakeDamage got called: {damage} ({damage / 100f})");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.DamageTakenEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration((damage / 100f), Config.DamageTakenDuration.Value);
        }
    }
}