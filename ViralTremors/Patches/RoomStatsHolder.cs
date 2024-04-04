using HarmonyLib;

namespace ViralTremors.Patches;

public class RoomStatsHolderPatches
{
    [HarmonyPatch(typeof(RoomStatsHolder), "AddMoney")]
    [HarmonyPostfix]
    // ReSharper disable once InconsistentNaming
    private static void AddMoney(RoomStatsHolder __instance, int money)
    {
        
    }
}