using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public static class JumpScareSoundPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching JumpScareSound functions.");
        
        On.JumpScareSound.Scare += JumpScareSoundOnScare;
    }

    private static void JumpScareSoundOnScare(On.JumpScareSound.orig_Scare orig, JumpScareSound self)
    {
        orig(self);
        
        if (ViralTremors.DeviceManager.IsConnected() &&
            Config.Jumpscare.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Jumpscare.Strength!.Value,
                Config.Jumpscare.Duration!.Value);
        }
    }
}