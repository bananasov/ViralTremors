using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors.Patches;

public class RoomStatsHolderPatches
{
    [HarmonyPatch(typeof(RoomStatsHolder), "AddMoney")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void AddMoney(RoomStatsHolder __instance, int money)
    {
        ViralTremors.Mls?.LogDebug($"AddMoney got called");

        if (ViralTremors.DeviceManager!.IsConnected() && Config.MoneyAdded.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.MoneyAdded.Strength!.Value,
                Config.MoneyAdded.Duration!.Value);
        }
    }
}