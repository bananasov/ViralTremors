using ContentLibrary;
using MyceliumNetworking;
using Steamworks;
using System.Runtime.CompilerServices;
using UnityEngine;
using ViralTremors.Buttplug;
using ViralTremors.Comments.Events;
using ViralTremors.Comments.Providers;
using ViralTremors.Utils;

namespace ViralTremors.Comments;

public class CommentManager
{
    public void Initialize()
    {
        ViralTremors.DeviceManager.OnVibrated += DeviceManagerOnOnVibrated;
        MyceliumNetwork.RegisterNetworkObject(this, ViralTremors.modID);
    }

    private static void DeviceManagerOnOnVibrated(object sender, VibratedEventArgs e)
    {
        var player = ContentHandler.GetPlayerWithCamera();
        if (player is null) return;

        VibedContentProvider componentInParent = new VibedContentProvider(e.Strength, e.Duration);
        ContentHandler.ManualPoll(componentInParent, 1, 100);

        if (player.IsLocal) return;

        CSteamID steamID;
        bool idSuccess = SteamAvatarHandler.TryGetSteamIDForPlayer(player, out steamID);
        if (idSuccess == false) return;

        MyceliumNetwork.RPCTarget(ViralTremors.modID, nameof(RPCOnVibrated), steamID, ReliableType.Reliable, e.Strength, e.Duration, player.NickName, player.ActorNumber);

        // if (!player.IsMasterClient) return;
        // ^ I do not know if this line is needed or not

        /* 
         * var componentInParent = new VibedContentProvider(e.Strength, e.Duration, player);
         * For context Sov, this is wrong because every time a device vibrates it will poll a provider with the ID of whoever is holding the camera
         * So if you vibrate but your saint friend who doesn't dwell in these thoughts is holding the camera, they are going to get labelled as-
         * -the person who felt the rumbling
         */
    }

    [CustomRPC]
    private static void RPCOnVibrated(float strength, float duration, string nickName, int actorNumber)
    {
        VibedContentProvider componentInParent = new VibedContentProvider(strength, duration, nickName, actorNumber);
        ContentHandler.ManualPoll(componentInParent, 1, 100);
    }
}