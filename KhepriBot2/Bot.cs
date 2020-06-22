using System.Text;
using System.IO;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus;
using System.Threading.Tasks;
using Newtonsoft.Json;
using KhepriBot2.Commands;
using KhepriBot2.JSONTemplates;

namespace KhepriBot2 {

    public class Bot {

        public DiscordClient client { get; private set; }
        public CommandsNextModule Commands { get; private set; }
        public async Task RunAsync() {

            var json = string.Empty;

            using (var fs = File.OpenRead("JSONFiles/config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = configJson.Prefix,
                EnableMentionPrefix = true,
                EnableDms = false
            };

            client = new DiscordClient(config);

            client.Ready += OnStartUpReady;

            Commands = client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<GenericCommands>();
            Commands.RegisterCommands<KhepriCommands>();

            await client.ConnectAsync();

            await Task.Delay(-1);
        }
        private Task OnStartUpReady(ReadyEventArgs e) {
            System.Console.WriteLine("KhepriBot is online!");
            return Task.CompletedTask;
        }
    }
}