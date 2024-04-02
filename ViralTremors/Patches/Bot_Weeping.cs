﻿using BepInEx;
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

        if (ViralTremors.DeviceManager.IsConnected() && Config.WeepingEnemyCaptureEnabled.Value)
        {
            ViralTremors.DeviceManager.VibrateConnectedDevicesWithDuration(Config.WeepingEnemyCaptureStrength.Value, Config.WeepingEnemyCaptureDuration.Value);
        }
    }
}