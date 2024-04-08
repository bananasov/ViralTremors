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

    public static string[] VIBE_COMMENTS =
    {
        "Is <playername> using a vibrator!?",
        "Did <playername> just moan??",
        "Wow! Seems like <playername> is having a LOT of fun!",
        "Wish i was controlling their toy.",
        "Just banged <playername>.",
        "Wow, mine doesnt have that kind of power, where do I buy one?",
        "Has <playername> finished?",
        "I hope <playername> is enjoying themselves.",
        "I think <playername> is enjoying themselves a bit too much.",
        "I think <playername> might be leaking",
        "Did <playername> make a mess?",
        "Its so powerful, is this safe for <playername> to be using?",
        "What's that noise? is <playername> using my boyfriends toy?",
        "That's GOT TO feel good.",
        "Whoa, talk about a vibration, I thought a second diving bell was hitting the floor!",
        "Talk about a monster, <playername> can take some serious power.",
        "SpookTube?? More like moan tube! <playername> needs to calm down... this must be the new SpookTube meta.",
        "Monsters & Toys... name a better duo.",
        "This reminds me, I need to order one of these toys on ESpook, or maybe Spookazon.",
        "<playername> is probably hoping this factory has more toys.",
        "SpookTube meta just dropped! <playername> might get banned for this...",
        "Message blocked for review: \"Talk about a diving bell... that toy is deep inside <playername>\".",
    };
}