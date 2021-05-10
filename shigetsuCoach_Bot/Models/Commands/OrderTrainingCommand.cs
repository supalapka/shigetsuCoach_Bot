using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands
{
    class OrderTrainingCommand : Command
    {
        public override string Name => "makeOrder";
        public static ReplyKeyboardMarkup _inlineKeyboardMarkup;
        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            MakeOrderController makeOrderController = new MakeOrderController(msg, client);
            makeOrderController.GetContact();
        }

       
    }
}
