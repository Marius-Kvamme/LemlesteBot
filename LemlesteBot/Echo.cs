using System;
using Discord;
using System.Threading.Tasks;
using Discord.WebSocket;

namespace LemlesteBot
{
    class Echo
    {
        const string BOT_NAME = "echo bot";

        static async Task EchoBot()
        {
            string token = "NTE5NzkzMDA5Nzk4MTUyMjAz.DukfKA.tRPI52C1dtkgeapWfYQoT9HCFjA";
            var client = Program.client;
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
