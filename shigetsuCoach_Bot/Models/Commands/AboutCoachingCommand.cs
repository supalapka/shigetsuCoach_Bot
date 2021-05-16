using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands
{
    class AboutCoachingCommand : Command
    {
        public override string Name => "aboutCoaching";

        public override bool isPublic => true;

        private static InlineKeyboardMarkup _inlineKeyboardMarkup;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            string messageToSent = "Как проходит коучинг:\n\n" +
                "Ты кидаешь мне в дискорд код, который получил после оплаты, после чего я тебе пишу на счет реплея.\n" +
                "Далее по демке я разбираю твой реплей, говорю твои ошибки, даю советы, задаю вопросы, отвечаю на вопросы.\n";
            await client.SendTextMessageAsync(msg.Chat.Id, messageToSent,replyMarkup: CoachingButtons());
        }

        private InlineKeyboardMarkup CoachingButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Заказать разбор","makeOrder"),
                        InlineKeyboardButton.WithCallbackData("Главное меню","startMenu"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }

    }
}
