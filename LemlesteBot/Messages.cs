using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using System.Collections.Generic;
using Discord.WebSocket;
using Discord;

namespace LemlesteBot
{
    public class Messages : ModuleBase
    {
        Dictionary<int, string> rule = new Dictionary<int, string>()
        {
            {0, "Alex"},
            {1, "Marius"},
            {2, "Thea"},
            {3, "Lemleste"},
            {4, "Norman"},
        };

        Dictionary<int, string> stage = new Dictionary<int, string>()
        {
            {0,   "Niceguy" },
            {1 ,  "Badboy"},
            {2 ,  "Goodboy"},
            {3 ,  "Goodguy"},
            {4 ,  "Lateboy"},
            {5 ,  "Earlyboy"},
            {6 ,  "マンタマリア号"},
            {7 ,  "ホッケふ頭"},
            {8 ,  "タチウオパーキング"},
            {9 , "エンガワ河川敷"},
            {10, "モズク農園"},
            {11,  "Ｂバスパーク"},
            {12,  "デボン海洋博物館"},
            {13,  "ザトウマーケット"},
            {14,  "ハコフグ倉庫"},
            {15,  "アロワナモール"}
        };


        [Command("rl")]
        public async Task rl()
        {
            Random random = new System.Random();
            int randomRule = random.Next(5);
            int randomStage = random.Next(16);

            string Messages = rule[randomRule].ToString() + "**\n\n";
            Messages += "er en、\n ・**" + stage[randomStage].ToString() + "**\n";

            await ReplyAsync(Messages);
        }

        [Command("Alex")]
        public async Task Alex()
        {
            
        }

    }
}