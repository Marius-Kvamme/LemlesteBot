using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace LemlesteBot
{
    class Echo
    {
        const string BOT_NAME = "echo bot";

        static async Task EchoBot(string token, DiscordSocketClient client)
        {

            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();

            client.MessageReceived += Client_MessageReceived;

            Console.ReadLine();
        }
        static async Task Client_MessageReceived(SocketMessage arg)
        {
            if (!arg.Author.Username.Equals("Marius"))
            {
                await arg.Channel.SendMessageAsync(arg.Content);
            }
        }
    }
}
