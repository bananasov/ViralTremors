using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public static class RoomStatsHolderPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching RoomStatsHolder functions.");
        
        On.RoomStatsHolder.AddMoney += RoomStatsHolderOnAddMoney;
    }

    private static void RoomStatsHolderOnAddMoney(On.RoomStatsHolder.orig_AddMoney orig, RoomStatsHolder self, int money)
    {
        orig(self, money);
        
        if (ViralTremors.DeviceManager.IsConnected() && Config.MoneyAdded.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.MoneyAdded.Strength!.Value,
                Config.MoneyAdded.Duration!.Value);
        }
    }
}