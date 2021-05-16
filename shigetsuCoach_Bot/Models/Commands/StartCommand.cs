using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class StartCommand : Command
    {
        public override string Name => "start";

        public override bool isPublic => true;

        public override  async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            string messageToSent = "Привет \nЯ играю в доту 6 лет и имею более 9000 ммр - 130 ранг, у меня можно заказать разбор реплея и начать импруваться сейчас, а не тратить год жизни ради 1000 птс\n\n600 рублей - 1 реплей";

            await client.SendTextMessageAsync(chatId, messageToSent);
            MainMenuController mainMenuController = new MainMenuController(msg, client);
            mainMenuController.MainMenuButtons();

        }
    }
}
