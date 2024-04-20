using System;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using ContentLibrary;
using MyceliumNetworking;
using UnityEngine;
using ViralTremors.Buttplug;
using ViralTremors.Comments;
using ViralTremors.Comments.Events;
using ViralTremors.Utils;
using Zorro.Core;

namespace ViralTremors;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
[BepInDependency(ContentLibrary.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)] // I don't know how to handle soft dependency cases yet
[BepInDependency(MyceliumNetworking.MyPluginInfo.PLUGIN_GUID, BepInDependency.DependencyFlags.HardDependency)]
public class ViralTremors : BaseUnityPlugin
{
    public static ViralTremors Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;
    internal static DeviceManager DeviceManager { get; private set; } = null!;
    internal static ushort modID = (ushort)Hash128.Compute(MyPluginInfo.PLUGIN_GUID).GetHashCode();

    private void Awake()
    {
        Logger = base.Logger;
        Instance = this;

        DeviceManager = new DeviceManager("ViralTremors");
        DeviceManager.ConnectDevices();
        ContentHandler.AssignEvent(new VibeContentEvent());
        
        Hook();

        if (Buttplug.Config.Comments.Enabled!.Value) new CommentManager().Initialize();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    private static void Hook()
    {
        ValueTuple<MethodInfo, Attribute>[] methodsWithAttribute =
            ReflectionUtility.GetMethodsWithAttribute<PatchInitAttribute>();
        foreach (var valueTuple in methodsWithAttribute)
        {
            var method = valueTuple.Item1;
            method.Invoke(null, Array.Empty<object>());
        }

        Logger.LogInfo("Hooking finished");
    }
}