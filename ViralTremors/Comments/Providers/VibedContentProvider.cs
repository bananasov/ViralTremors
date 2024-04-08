using System.Collections.Generic;
using UnityEngine;
using ViralTremors.Comments.Events;

namespace ViralTremors.Comments.Providers;

public class VibedContentProvider : ContentProvider
{
    public VibedContentProvider(float strength, float duration, Photon.Realtime.Player player)
    {
        _strength = strength;
        _duration = duration;
        _player = player;
    }

    public override void GetContent(List<ContentEventFrame> contentEvents, float seenAmount, Camera camera, float time)
    {
        var nickName = _player.NickName;
        var actorNumber = _player.ActorNumber;

        contentEvents.Add(new ContentEventFrame(new VibeContentEvent(nickName, actorNumber, _strength, _duration),
            seenAmount, time));
    }

    private readonly float _strength;
    private readonly float _duration;
    private Photon.Realtime.Player _player;
}