using shigetsuCoach_Bot.Commands;
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
        private static InlineKeyboardMarkup _inlineKeyboardMarkup;
        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var messageToSent = "Для дальнейшей связи после оплаты нам потребуются твои контактные данные (телеграм)";
           // await client.SendTextMessageAsync(747969117, "вот данные", replyMarkup: GetButtonShareConstacts());

            var RequestReplyKeyboard = new ReplyKeyboardMarkup(new[]
               {
                    KeyboardButton.WithRequestContact("Поделиться"),
                });
            await client.SendTextMessageAsync(
                chatId: msg.Chat.Id,
                text: messageToSent + msg.Chat.Id,
                replyMarkup: RequestReplyKeyboard
            );
        }
    }
}
