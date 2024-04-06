using System.Linq;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using ViralTremors.Buttplug;
using ViralTremors.Utils;

namespace ViralTremors.Hooks;

public class BombItemPatches
{
    [PatchInit]
    public static void Init()
    {
        ViralTremors.Logger.LogInfo("Patching BombItem functions.");

        IL.BombItem.Update += BombItemOnUpdate;
    }

    private static void BombItemOnUpdate(ILContext il)
    {
        var c = new ILCursor(il);
        c.GotoNext(MoveType.Before, instruction => instruction.MatchRet());
        c.Emit(OpCodes.Call, typeof(BombItemPatches).GetMethods().FirstOrDefault(x => x.Name == "Vibrate"));
    }

    // This function is for the IL thing above
    public static void Vibrate()
    {
        if (ViralTremors.DeviceManager.IsConnected() &&
            Config.BombExplosion.Enabled!.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.BombExplosion.Strength!.Value,
                Config.BombExplosion.Duration!.Value);
        }
    }
}