using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using SlothBot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SlothBot {
  public class Bot {
    public DiscordClient Client { get; private set; }

    public CommandsNextModule Commands { get; private set; }

    public async Task RunAsync() {
      var config = new DiscordConfiguration() {
        Token = Constants.API_TOKEN,
        TokenType = TokenType.Bot,
        AutoReconnect = true,
        LogLevel = LogLevel.Debug,
        UseInternalLogHandler = true,
      };

      Client = new DiscordClient(config);

      Client.Ready += OnClientReady;

      var commandConfig = new CommandsNextConfiguration() {
        StringPrefix = Constants.PREFIX,
        EnableMentionPrefix = true,
        EnableDms = false,
        CaseSensitive = false,
      };

      Commands = Client.UseCommandsNext(commandConfig);

      Commands.RegisterCommands<SlothCommands>();

      await Client.ConnectAsync();

      await Task.Delay(-1);
    }

    private Task OnClientReady(ReadyEventArgs e) {
      return Task.CompletedTask;
    }
  }
}
