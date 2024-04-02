using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using ViralTremors.Buttplug;

namespace ViralTremors
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class ViralTremors : BaseUnityPlugin
    {
        internal static DeviceManager DeviceManager { get; private set; }
        internal static ManualLogSource Mls { get; private set; }
        
        private void Awake()
        {
            Mls = Logger;
            
            DeviceManager = new DeviceManager("ViralTremors");
            DeviceManager.ConnectDevices();

            var harmony = new Harmony(PluginInfo.PLUGIN_GUID);
            harmony.PatchAll(typeof(Patches.PlayerPatches));
            harmony.PatchAll(typeof(Patches.Bot_WeepingPatches));
            harmony.PatchAll(typeof(Patches.DivingBellPatches));

            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} has loaded!");
        }
    }
}