using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands.PrivateCommands
{
    class WriteReviewCommand : Command
    {
        public override string Name => "writeReview";
        public override bool isPublic => false;

        private static InlineKeyboardMarkup _inlineKeyboardMarkup;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            string output = "";
            await client.SendTextMessageAsync(msg.Chat.Id, output, replyMarkup: GenerateInlineKeyboardMarkup());
        }

        private InlineKeyboardMarkup GenerateInlineKeyboardMarkup()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Отказаться","cencel"),
                    },
                });
            }
            return _inlineKeyboardMarkup;
        }
    }
}
