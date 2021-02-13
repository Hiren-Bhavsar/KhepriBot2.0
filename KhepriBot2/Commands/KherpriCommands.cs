using System.Security.Cryptography;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using KhepriBot2.JSONTemplates;

namespace KhepriBot2.Commands {
    public class KhepriCommands {

        private KhepriFileStorageManager kfsm;
        public KhepriCommands() {
            kfsm = new KhepriFileStorageManager();
        }

        [Command("listall")]
        [Description("Lists all users and their amount of khepris")]
        public async Task ListAll(CommandContext context) {
            string toDisplay = "```";
            await context.TriggerTypingAsync();
            foreach (User u in kfsm.UserList) {
                toDisplay += u.nickname + " has " + u.khepris + " khepris! \n";
            }
            await context.Channel.SendMessageAsync(toDisplay + "```").ConfigureAwait(false);
        }

        [Command("give")]
        [Description("Give a user a number of khepris, within range 1 - 5")]
        public async Task give(CommandContext context, DiscordUser user, int khepris) {
            await context.TriggerTypingAsync();
            if (khepris > 0 && khepris < 6) {
                int tempkhep = kfsm.AdjustKhepris(user.Username, khepris);
                await context.Channel.SendMessageAsync(user.Username + " has " + tempkhep + " khepris!").ConfigureAwait(false);
            } else {
                await context.Channel.SendMessageAsync("You have not used this command correctly").ConfigureAwait(false);
            }
        }

        [Command("take")]
        [Description("Take from a user a number of khepris, within range 1 - 5")]
        public async Task take(CommandContext context, DiscordUser user, int khepris) {
            await context.TriggerTypingAsync();
            if (khepris > 0 && khepris < 6) {
                int tempkhep = kfsm.AdjustKhepris(user.Username, -khepris);
                await context.Channel.SendMessageAsync(user.Username + " has " + tempkhep + " khepris!").ConfigureAwait(false);
            } else {
                await context.Channel.SendMessageAsync("You have not used this command correctly").ConfigureAwait(false);
            }
        }

        [Command("forcesave")]
        [Description("Forces all data to be backed up")]
        public async Task ForceSave(CommandContext context) {
            await context.TriggerTypingAsync();
            kfsm.SaveAll();
            await context.Channel.SendMessageAsync("Force save has been completed!").ConfigureAwait(false);
        }

        
        [Command("test")]
        [Description("It may or may not do someting")]
        public async Task Test(CommandContext context) {
            
        }
    }
}