using System.Runtime.CompilerServices;
using ViralTremors.Buttplug;
using ViralTremors.Comments.Events;
using ViralTremors.Comments.Providers;
using ViralTremors.Utils;

namespace ViralTremors.Comments;

public class CommentManager
{
    public static void Initialize()
    {
        ViralTremors.DeviceManager.OnVibrated += DeviceManagerOnOnVibrated;
        InitializeHooks();
    }

    private static void InitializeHooks()
    {
        On.ContentEventIDMapper.GetContentEvent += ContentEventIDMapperOnGetContentEvent;
    }

    private static ContentEvent ContentEventIDMapperOnGetContentEvent(On.ContentEventIDMapper.orig_GetContentEvent orig,
        ushort id)
    {
        return id switch
        {
            5601 => new VibeContentEvent(),
            _ => orig(id)
        };
    }

    private static void DeviceManagerOnOnVibrated(object sender, VibratedEventArgs e)
    {
        var player = PlayerUtils.GetPlayerWithCamera();

        if (player is null) return;
        if (!player.IsLocal) return;

        var componentInParent = new VibedContentProvider(e.Strength, e.Duration, player);
        ContentPolling.contentProviders.Add(componentInParent, 1);
    }
}