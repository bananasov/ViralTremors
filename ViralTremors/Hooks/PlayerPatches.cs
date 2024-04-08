using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public static class PlayerPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching Player functions.");

        On.Player.TakeDamage += PlayerOnTakeDamage;
        On.Player.Die += PlayerOnDie;
        On.Player.CallRevive += PlayerOnCallRevive;
        On.Player.Heal += PlayerOnHeal;
    }

    private static bool PlayerOnHeal(On.Player.orig_Heal orig, Player self, float healamount)
    {
        var balls = orig(self, healamount);

        if (!self.IsLocal) return balls;

        if (ViralTremors.DeviceManager!.IsConnected() && Config.Player.Heal.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Heal.Strength!.Value,
                Config.Player.Heal.Duration!.Value);
        }

        return balls;
    }

    private static void PlayerOnCallRevive(On.Player.orig_CallRevive orig, Player self)
    {
        orig(self);

        if (!self.IsLocal) return;

        if (ViralTremors.DeviceManager.IsConnected() && Config.Player.Revive.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Revive.Strength!.Value,
                Config.Player.Revive.Duration!.Value);
        }
    }

    private static void PlayerOnDie(On.Player.orig_Die orig, Player self)
    {
        orig(self);

        if (!self.IsLocal) return;

        if (ViralTremors.DeviceManager.IsConnected() && Config.Player.Death.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.Player.Death.Strength!.Value,
                Config.Player.Death.Duration!.Value);
        }
    }

    private static void PlayerOnTakeDamage(On.Player.orig_TakeDamage orig, Player self, float damage)
    {
        orig(self, damage);

        if (!self.IsLocal) return;

        if (ViralTremors.DeviceManager.IsConnected() && Config.Player.DamageTaken.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration((damage / 100f),
                Config.Player.DamageTaken.Duration!.Value);
        }
    }
}