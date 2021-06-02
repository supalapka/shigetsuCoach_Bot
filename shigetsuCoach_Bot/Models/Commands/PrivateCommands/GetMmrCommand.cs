using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using shigetsuCoach_Bot.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            string exampleCommand = "/mmr6000-7000";
            if (msg.Text.Length == exampleCommand.Length)
            {
                string mmr = msg.Text.Remove(0, 4); //mmr skip
                string finalmmr = msg.Text.Remove(0, 9); //mmrxxxx- skip
                string currentmmr = mmr.Remove(4);  //delete -xxxx (final mmr)
                mmr = currentmmr;

                int intmmr = Convert.ToInt16(mmr);
                int intfinalmmr = Convert.ToInt16(finalmmr);
                int price = 0;

                if (intmmr < 6000 || intfinalmmr > 8500 || intmmr >= intfinalmmr)
                    RequestMmr(msg, client);
                else
                {
                    while(intmmr < intfinalmmr)
                    {
                         if (intmmr >= 6000 && intmmr < 6500)
                            price += (int)MmrBoostPrice.from6000to6500;
                        else if (intmmr >= 6500 && intmmr < 7000)
                            price += (int)MmrBoostPrice.from6500to7000;
                        else if (intmmr >= 7000 && intmmr < 7500)
                            price += (int)MmrBoostPrice.from7000to7500;
                        else if (intmmr >= 7500 && intmmr < 8000)
                            price += (int)MmrBoostPrice.from7500to8000;
                        else if (intmmr >= 8000 && intmmr < 8500)
                            price += (int)MmrBoostPrice.from8000to8500;

                        intmmr += 100;

                    }

                    await client.SendTextMessageAsync(msg.Chat.Id, ($"Текущий рейтинг - {mmr}\n" + $"цель - {finalmmr}\n" +
                        $"Цена - {price} рублей/{(int)(price/2.7)} гривен"), replyMarkup: BoostButtons());


                }
            } 
            else
            {
                RequestMmr(msg,client);
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
                        InlineKeyboardButton.WithCallbackData("Подтвердить","confirmMyMmr"),
                        InlineKeyboardButton.WithCallbackData("Редактировать","orderBoost"),
                        InlineKeyboardButton.WithCallbackData("Главное меню","startMenu"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }

        private async void RequestMmr(Message msg, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(msg.Chat.Id, "Некорректно введены данные\n" +
                 "Диапазон от 6000 до 8500\n" +
                 "Пример /mmr6000-7000");
        }
    }
}
