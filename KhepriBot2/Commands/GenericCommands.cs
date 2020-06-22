using System.Security.Cryptography;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace KhepriBot2.Commands {

    public class GenericCommands {

        [Command("hello")]
        [Description("A simple greeting from your favorite hug bug!")]
        public async Task Hello(CommandContext context) {
            await context.Channel.SendMessageAsync("Greetings Friend!").ConfigureAwait(false);
        }

        [Command("f")]
        [Description("F for maximum respect")]
        public async Task F(CommandContext context) {
            await context.Channel.SendMessageAsync("[F] for respect").ConfigureAwait(false);
        }

        [Command("goodbot")]
        [Description("A way to thank the best beetle")]
        public async Task GoodBot(CommandContext context) {
            await context.TriggerTypingAsync();
            var emoji = DiscordEmoji.FromGuildEmote(context.Client, 625863698287951873);
            await context.RespondAsync($"{emoji} Thank you, {context.Member.Mention}!");
        }


        private string[] jokes = {"What did the iceberg say to the sun? You crack me up. Ha! Hahahahaha!",
        "I lost the sun for a second, but then it dawned on me.",
        "The sun enjoys reading, you know. Just so that it may get brighter.",
        "Why don't lobsters share their food? Because they're shellfish!",
        "What happened when the crustacean was late to work? She lobster job! Hahahahahaha!",
        "I'm no feeder! Well okay, I'm a bottom-feeder, but I fight to win!"};

        [Command("joke")]
        [Description("VEL | SquareCircleSquare | XBX | YAY")]
        public async Task Joke(CommandContext context) {
            await context.TriggerTypingAsync();
            string joke = jokes[RandomNumberGenerator.GetInt32(0, jokes.Length)];
            await context.Channel.SendMessageAsync(joke).ConfigureAwait(false);
        }
    }
}