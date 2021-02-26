using Discord;
namespace DiscordRPG
{
    public class Emote
    {
        public static IEmote Shield = new Emoji("🛡️");
        public static IEmote Sword = new Emoji("⚔️");
        public static IEmote Bag = new Emoji("💼");
        public static IEmote Wand = new Emoji("🪄");
        public static IEmote QuestionMark = new Emoji("❓");
        public static IEmote TurnBack = new Emoji("↩️");
        public static IEmote CheckMark = new Emoji("✅");
        public static IEmote CrossMark = new Emoji("❎");
        public static IEmote BackButton = new Emoji("◀️");
        public static IEmote NextButton = new Emoji("▶️");
        public static IEmote Flag = new Emoji("🏁");
        public static IEmote[] Numbers = { //Access using index
            new Emoji("0️⃣"),
            new Emoji("1️⃣"),
            new Emoji("2️⃣"),
            new Emoji("3️⃣"),
            new Emoji("4️⃣"),
            new Emoji("5️⃣"),
            new Emoji("6️⃣"),
            new Emoji("7️⃣"),
            new Emoji("8️⃣"),
            new Emoji("9️⃣"),
            new Emoji("🔟")
        };
    }
}
