using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands
{
    class BootsMenuCommand : Command
    {
        private InlineKeyboardMarkup _inlineKeyboardMarkup;

        public override string Name => "boost";

        public override bool isPublic => true;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            string output = "Буст\n\n" +
                "4000-4500 ммр ->  500 рублей за 100 ммр\n" +
                "4500-5000 ммр ->  600 рублей за 100 ммр\n" +
                "5000-5500 ммр ->  700 рублей за 100 ммр\n" +
                "5500-6000 ммр ->  800 рублей за 100 ммр\n" +
                "6000-6500 ммр ->  900 рублей за 100 ммр\n" +
                "6500-7000 ммр ->  1100 рублей за 100 ммр\n" +
                "7000-7500 ммр ->  1300 рублей за 100 ммр\n" +
                "7500-8000 ммр ->  1500 рублей за 100 ммр\n" +
                "8000-8500 ммр ->  1700 рублей за 100 ммр\n" +
                "";

            await client.SendTextMessageAsync(msg.Chat.Id, output,replyMarkup: BoostgButtons());
        }

        private InlineKeyboardMarkup BoostgButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Заказать буст","orderBoost"),
                        InlineKeyboardButton.WithCallbackData("Отзывы","reviews"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
