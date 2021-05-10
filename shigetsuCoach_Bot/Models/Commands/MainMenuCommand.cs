using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class MainMenuCommand : Command
    {
        public override string Name => "startMenu";

        public override  void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            MainMenuController mainMenuController = new MainMenuController(msg, client);
            mainMenuController.MainMenuButtons();
        }

    }
}
