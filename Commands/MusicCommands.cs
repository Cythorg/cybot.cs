using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.VoiceNext;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace Cybot.Commands
{
    class MusicCommands : BaseCommandModule
    {
        [Command("play")]
        public async Task Play(CommandContext ctx)
        {
            var voiceNext = ctx.Client.GetVoiceNext();

            var channel = ctx.Member?.VoiceState?.Channel;

            if (voiceNext.GetConnection(ctx.Guild) != null)
            {
                Logger.Log(this, $"Bot is already connected to a channel in this server", LogType.Error);
                throw new InvalidOperationException("Already connected to a voice channel in this Guild");
            }

            if (channel == null)
            {
                Logger.Log(this, $"Member ({ctx.Member.DisplayName}) is not in a voice channel", LogType.Error);
                throw new InvalidOperationException("Member is not in a voice channel");
            }

            await voiceNext.ConnectAsync(channel).ConfigureAwait(false);

            Logger.Log(this, $"Successfully connected to channel: {channel.Name}", LogType.Debug);

            
        }

        [Command("stop")]
        public async Task Stop(CommandContext ctx)
        {
            var voiceNext = ctx.Client.GetVoiceNext();

            var channel = voiceNext.GetConnection(ctx.Guild)?.Channel?.Name;

            if (voiceNext.GetConnection(ctx.Guild) == null)
            {
                Logger.Log(this, $"Bot is not connected to a channel in this server", LogType.Error);
                throw new InvalidOperationException("Not connected to a voice channel in this Guild");
            }

            voiceNext.GetConnection(ctx.Guild).Disconnect();
            Logger.Log(this, $"Successfully disconnected from channel: {channel}", LogType.Debug);
        }
    }
}
