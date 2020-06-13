using System.Text;
using System.IO;
using DSharpPlus.EventArgs;
using DSharpPlus.CommandsNext;
using DSharpPlus;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KhepriBot2 {

    public class Bot {

        public DiscordClient _client { get; private set; }
        public CommandsNextModule Commands { get; private set; }
        public async Task RunAsync() {

            var json = string.Empty;

            using(var fs = File.OpenRead("config.json"))
            using(var sr = new StreamReader(fs, new UTF8Encoding(false)))
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

            _client = new DiscordClient(config);

            _client.Ready += OnStartUpReady;

            Commands = _client.UseCommandsNext(commandsConfig);

            await _client.ConnectAsync();

            await Task.Delay(-1);
        }
        private Task OnStartUpReady(ReadyEventArgs e) {
            //TODO
            return Task.CompletedTask;
        }
    }
}