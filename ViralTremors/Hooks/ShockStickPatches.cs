using ViralTremors.Buttplug;

namespace ViralTremors.Hooks;

public static class ShockStickPatches
{
    public static void Init()
    {
        On.ShockStick.OnShock += ShockStickOnOnShock;
    }

    private static void ShockStickOnOnShock(On.ShockStick.orig_OnShock orig, ShockStick self, Player playertoshock)
    {
        orig(self, playertoshock);
        
        if (ViralTremors.DeviceManager.IsConnected() && Config.Item.ShockStick.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Item.ShockStick.Strength!.Value,
                Config.Item.ShockStick.Duration!.Value);
        }
    }
}