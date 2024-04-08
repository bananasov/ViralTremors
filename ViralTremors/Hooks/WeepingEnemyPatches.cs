using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public static class WeepingEnemyPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching Bot_Weeping functions.");

        On.Bot_Weeping.TryCapturePlayer += TryCapturePlayerPatch;
    }

    private static void TryCapturePlayerPatch(On.Bot_Weeping.orig_TryCapturePlayer original, Bot_Weeping self)
    {
        original(self);

        if (ViralTremors.DeviceManager.IsConnected() && Config.Enemy.Weeping.Capture.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Enemy.Weeping.Capture.Strength!.Value,
                Config.Enemy.Weeping.Capture.Duration!.Value);
        }
    }
}