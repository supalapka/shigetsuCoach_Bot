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

        public override async void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            string messageToSent = "Привет. \n Я играю в доту больше 6 лет и имею 9000 ммр - 160 ранг, могу научить тебя играть волрапвлорп лоарвплоаврплор валпровларп влаопрвлар. \n \n400 рублей 1 час либо 1 реплей. ";

            await client.SendTextMessageAsync(chatId, messageToSent, replyMarkup:MainMenuController.MainMenuButtons());

           

        }
    }
}
