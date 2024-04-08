﻿using System.Runtime.CompilerServices;

namespace ViralTremors.Integrations;

public class MyceliumIntegration
{
    private static bool? _enabled;

    public static bool enabled
    {
        get
        {
            _enabled ??= BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("RugbugRedfern.MyceliumNetworking");

            return (bool)_enabled;
        }
    }

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void InitializeIntegration()
    {
        ViralTremors.Logger.LogInfo("Initializing MyceliumNetworking integration");
    }
}