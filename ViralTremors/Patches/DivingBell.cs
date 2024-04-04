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
        ViralTremors.Mls?.LogDebug($"GoUnderground got called");

        if (ViralTremors.DeviceManager!.IsConnected() &&
            Config.DivingBell.Traveling.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBell.Traveling.Strength!.Value,
                Config.DivingBell.Traveling.Duration!.Value);
        }
    }

    [HarmonyPatch(typeof(DivingBell), "GoToSurface")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void GoToSurface(DivingBell __instance)
    {
        ViralTremors.Mls?.LogDebug($"GoToSurface got called");

        if (ViralTremors.DeviceManager!.IsConnected() &&
            Config.DivingBell.Returning.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBell.Traveling.Strength!.Value,
                Config.DivingBell.Returning.Duration!.Value);
        }
    }
}