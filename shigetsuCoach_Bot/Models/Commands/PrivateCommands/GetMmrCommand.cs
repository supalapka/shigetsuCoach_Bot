using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands.PrivateCommands
{
    class GetMmrCommand : Command
    {
        private InlineKeyboardMarkup _inlineKeyboardMarkup;

        public override string Name => "mmr";

        public override bool isPublic => false; 

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            string exampleCommand = "/mmr4700-5300";
            if (msg.Text.Length == exampleCommand.Length)
            {
                string mmr = msg.Text.Remove(0, 4); //mmr skip
                string finalmmr = msg.Text.Remove(0, 9); //mmrxxxx- skip
                mmr = mmr.Remove(4);  //delete -xxxx (final mmr)
                await client.SendTextMessageAsync(msg.Chat.Id, ($"Текущий рейтинг - {mmr}\n" + $"цель - {finalmmr}"), replyMarkup: BoostButtons());
            }
            else
            {
                await client.SendTextMessageAsync(msg.Chat.Id, "Некорректно введены данные\n" +
                    "Диапазон от 4000 до 8500");
                
            }
        }

        public InlineKeyboardMarkup BoostButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Подтвердить"," "),
                        InlineKeyboardButton.WithCallbackData("Редактировать","orderBoost"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
