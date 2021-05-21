using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands.PrivateCommands
{
    class ComfirmMyMmrCommand : Command
    {
        public override string Name => "confirmMyMmr";

        public override bool isPublic => false;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
          using(var context = new MyDbContext())
            {

            }
        }
    }
}
