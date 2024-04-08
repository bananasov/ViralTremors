using System.Text;
using Zorro.Core;
using Zorro.Core.Serizalization;

namespace ViralTremors.Comments.Events;

public class VibeContentEvent : ContentEvent
{
    // I am well aware i have basically reimplemented PlayerBaseEvent.
    public VibeContentEvent()
    {
    }

    public VibeContentEvent(string playerName, int actorNumber, float strength, float duration)
    {
        Strength = strength;
        Duration = duration;
        PlayerName = playerName;
        ActorNumber = actorNumber;
    }

    public override float GetContentValue() => 1000f; // Pretty fucking big.

    public override Comment GenerateComment() => new(FixPlayerName(VIBE_COMMENTS.GetRandom()));

    public override int GetUniqueID() => ActorNumber;

    public override ushort GetID() => 5601;

    public override string GetName() => "PlayerVibed";

    public override void Serialize(BinarySerializer serializer)
    {
        serializer.WriteInt(ActorNumber);
        serializer.WriteString(PlayerName, Encoding.UTF8);
        serializer.WriteFloat(Strength);
        serializer.WriteFloat(Duration);
    }

    public override void Deserialize(BinaryDeserializer deserializer)
    {
        ActorNumber = deserializer.ReadInt();
        PlayerName = deserializer.ReadString(Encoding.UTF8);
        Strength = deserializer.ReadFloat();
        Duration = deserializer.ReadFloat();
    }

    public string FixPlayerName(string comment) => comment.Replace("<playername>", PlayerName);

    public string PlayerName;
    public int ActorNumber;
    public float Strength;
    public float Duration;

    public string[] VIBE_COMMENTS =
    {
        "Is <playername> using a vibrator!?",
        "Did <playername> just moan??",
        "Wow! Seems like <playername> is having a LOT of fun!",
        "Wish i was controlling their toy.",
        "Just banged <playername>.",
    };
}