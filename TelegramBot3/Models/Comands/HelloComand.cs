
using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBot3.Models.Comands
{
    public class HelloComand : Command
    {
        public override string Name => "Hello";

        public override async void Execute(Message message, TelegramBotClient client)
        {
            var chatId = message.Chat.Id;
            var messageId = message.MessageId;



            await client.SendTextMessageAsync(chatId, "Hello", replyToMessageId: messageId);
        }
    }
}