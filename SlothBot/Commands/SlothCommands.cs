using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace SlothBot.Commands {
  public class SlothCommands {

    [Command("ping")]
    [Description("PONG!")]
    public async Task Ping(CommandContext ctx) {
      await ctx.Channel.SendMessageAsync("Pong!").ConfigureAwait(false);
    }

    [Command("add")]
    [Description("Adds")]
    public async Task Add(CommandContext ctx,[Description("The numbers to add.")] params int[] numbers) {
      await ctx.Channel.SendMessageAsync(numbers.Sum().ToString()).ConfigureAwait(false);
    }
  }
}
