using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using ViralTremors.Buttplug;
using ViralTremors.Utils;
using Zorro.Core;

namespace ViralTremors;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class ViralTremors : BaseUnityPlugin
{
    public static ViralTremors Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static DeviceManager DeviceManager { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;
        Instance = this;

        DeviceManager = new DeviceManager("ViralTremors");
        DeviceManager.ConnectDevices();

        Hook();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    private static void Hook()
    {
        ValueTuple<MethodInfo, Attribute>[] methodsWithAttribute = ReflectionUtility.GetMethodsWithAttribute<PatchInitAttribute>();
        foreach (var valueTuple in methodsWithAttribute)
        {
            var method = valueTuple.Item1;
            method.Invoke(null, Array.Empty<object>()); 
        }
        
        Logger.LogInfo("Hooking finished");
    }
}