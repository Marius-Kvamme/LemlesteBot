using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord;

namespace LemlesteBot
{
    class Program
    {
        public static DiscordSocketClient client;
        public static CommandService commands;
        public static IServiceProvider services;

        static void Main(string[] args) => new Program().MainAsync().GetAwaiter().GetResult();


        public async Task MainAsync()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();
            services = new ServiceCollection().BuildServiceProvider();
            client.MessageReceived += CommandRecieved;

            client.Log += Log;
            string token = "NTE5NzkzMDA5Nzk4MTUyMjAz.DukfKA.tRPI52C1dtkgeapWfYQoT9HCFjA";
            await commands.AddModulesAsync(Assembly.GetEntryAssembly());
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            await Task.Delay(-1);
        }


        private async Task CommandRecieved(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            Console.WriteLine("{0} {1}:{2}", message.Channel.Name, message.Author.Username, message);

            if (message == null) { return; }

            if (message.Author.IsBot) { return; }

            int argPos = 0;


            if (!(message.HasCharPrefix('.', ref argPos) || message.HasMentionPrefix(client.CurrentUser, ref argPos))) { return; }

            var context = new CommandContext(client, message);

            var result = await commands.ExecuteAsync(context, argPos, services);

            if (!result.IsSuccess) { await context.Channel.SendMessageAsync(result.ErrorReason); }

        }


        private Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}