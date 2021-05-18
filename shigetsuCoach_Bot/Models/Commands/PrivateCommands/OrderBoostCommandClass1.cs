using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands.PrivateCommands
{
    class OrderBoostCommandClass1 : Command
    {
        public override string Name => "orderBoost";

        public override bool isPublic => false;

        public override void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            
        }
    }
}
