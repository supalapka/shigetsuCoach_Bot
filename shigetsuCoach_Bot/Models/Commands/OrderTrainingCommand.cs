using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class OrderTrainingCommand : Command
    {
        public override string Name => "makeOrder";

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var messageToSent = "";
            await client.SendTextMessageAsync(msg.Chat.Id, messageToSent);
        }
    }
}
