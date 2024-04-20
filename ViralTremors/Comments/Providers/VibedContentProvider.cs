using System.Collections.Generic;
using UnityEngine;
using ViralTremors.Comments.Events;

namespace ViralTremors.Comments.Providers;

public class VibedContentProvider : ContentProvider
{
    public VibedContentProvider(float strength, float duration, string? nickName = null, int? actorNumber = null)
    {
        _strength = strength;
        _duration = duration;
        
        if (nickName is null || actorNumber is null)
        {
            _nickName = Player.localPlayer.refs.view.Owner.NickName;
            _actorNumber = Player.localPlayer.refs.view.Owner.ActorNumber;
        }
        else
        {
            _nickName = nickName!;
            _actorNumber = (int)actorNumber!;
        }
    }

    public override void GetContent(List<ContentEventFrame> contentEvents, float seenAmount, Camera camera, float time)
    {
        contentEvents.Add(new ContentEventFrame(new VibeContentEvent(_nickName, _actorNumber, _strength, _duration),
            seenAmount, time));
    }

    private readonly float _strength;
    private readonly float _duration;
    private string _nickName;
    private int _actorNumber;
}