using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

public class DivingBellPatches
{
    [HarmonyPatch(typeof(DivingBell), "GoUnderground")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void GoUnderground(DivingBell __instance)
    {
        ViralTremors.Mls.LogDebug($"GoUnderground got called");

        if (ViralTremors.DeviceManager.IsConnected() && Config.DivingBellEnabled.Value && Config.DivingBellTravelingEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBellTravelingStrength.Value, Config.DivingBellTravelingDuration.Value);
        }
    }
    
    [HarmonyPatch(typeof(DivingBell), "GoToSurface")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void GoToSurface(DivingBell __instance)
    {
        ViralTremors.Mls.LogDebug($"GoToSurface got called");

        if (ViralTremors.DeviceManager.IsConnected() && Config.DivingBellEnabled.Value && Config.DivingBellReturningEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBellTravelingStrength.Value, Config.DivingBellReturningDuration.Value);
        }
    }
}