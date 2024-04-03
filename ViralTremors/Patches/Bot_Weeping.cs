using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

public class Bot_WeepingPatches
{
    [HarmonyPatch(typeof(Bot_Weeping), "TryCapturePlayer")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void TryCapturePlayer(Bot_Weeping __instance)
    {
        ViralTremors.Mls.LogDebug($"GoUnderground got called");

        if (ViralTremors.DeviceManager.IsConnected() && Config.Enemy.Weeping.Capture.Enabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Enemy.Weeping.Capture.Strength.Value,
                Config.Enemy.Weeping.Capture.Duration.Value);
        }
    }
}