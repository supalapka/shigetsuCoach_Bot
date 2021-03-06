using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Commands
{
    class HelloCommand : Command
    {
        public override string Name => "hello";

        public override bool isPublic => true;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            //TODO
            await client.SendTextMessageAsync(chatId, "Привет");
        }
    }
}
