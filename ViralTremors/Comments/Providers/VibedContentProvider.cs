using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using ViralTremors.Comments.Events;

namespace ViralTremors.Comments.Providers;

public class VibedContentProvider : ContentProvider
{
    public VibedContentProvider(float strength, float duration, Player player)
    {
        _strength = strength;
        _duration = duration;
        this.player = player;
    }
    
    public override void GetContent(List<ContentEventFrame> contentEvents, float seenAmount, Camera camera, float time)
    {
        var nickName = player.refs.view.Owner.NickName;
        var actorNumber = player.refs.view.Owner.ActorNumber;
        
        contentEvents.Add(new ContentEventFrame(new VibeContentEvent(nickName, actorNumber, _strength, _duration), seenAmount, time));
    }

    private readonly float _strength;
    private readonly float _duration;
    public Player player;
}