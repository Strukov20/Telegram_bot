using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot3.Models.Comands;

namespace TelegramBot3.Models
{
    public static class Bot
    {

        private static TelegramBotClient client;
        private static List<Command> commandsList;

        public static object Commands { get; internal set; }
        public static IReadOnlyList<Command> Comands { get => commandsList.AsReadOnly(); } 

        public static async Task<TelegramBotClient> Get()
        {
            if (client != null)
            {
                return client;
            }

            commandsList = new List<Command>();
            commandsList.Add(new HelloComand());

            client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await client.SetWebhookAsync(hook);

            return client;
        }
    }
}