using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class CencelCommand : Command
    {
        public override string Name => "cencel";

        public override void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            MainMenuController m = new MainMenuController(msg, client);
            m.MainMenuButtons();
        }
    }
}
