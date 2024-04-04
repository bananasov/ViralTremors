using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

public class ShockStickPatches
{
    [HarmonyPatch(typeof(ShockStick), "OnShock")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void OnShock(ShockStick __instance, Player playerToShock)
    {
        if (!__instance.isHeldByMe) return;

        ViralTremors.Mls?.LogDebug($"OnShock got called");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Item.ShockStick.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Item.ShockStick.Strength!.Value,
                Config.Item.ShockStick.Duration!.Value);
        }
    }
}