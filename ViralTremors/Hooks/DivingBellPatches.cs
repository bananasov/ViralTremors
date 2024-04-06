using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public static class DivingBellPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching DiveBell functions.");
        
        On.DivingBell.GoToSurface += DivingBellOnGoToSurface;
        On.DivingBell.GoUnderground += DivingBellOnGoUnderground;
    }

    private static void DivingBellOnGoUnderground(On.DivingBell.orig_GoUnderground orig, DivingBell self)
    {
        orig(self);

        if (ViralTremors.DeviceManager.IsConnected() &&
            Config.DivingBell.Traveling.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBell.Traveling.Strength!.Value,
                Config.DivingBell.Traveling.Duration!.Value);
        }
    }

    private static void DivingBellOnGoToSurface(On.DivingBell.orig_GoToSurface orig, DivingBell self)
    {
        orig(self);

        if (ViralTremors.DeviceManager.IsConnected() &&
            Config.DivingBell.Returning.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.DivingBell.Traveling.Strength!.Value,
                Config.DivingBell.Returning.Duration!.Value);
        }
    }
}