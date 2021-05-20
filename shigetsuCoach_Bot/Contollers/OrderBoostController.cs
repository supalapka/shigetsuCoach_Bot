using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Contollers
{
    class OrderBoostController
    {
        Message msg;
        TelegramBotClient client;
        public OrderBoostController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public OrderBoostController() { }

        public  async void GetUserMmr()
        {
            string output = "Введите ваш  текущий рейтинг и желаемый через команду /mmr число1-число2.\n" +
                "Пример /mmr4700-5300\n\n" +
                "Диапазон от 4000 до 8500.";
            await client.SendTextMessageAsync(msg.Chat.Id, output);
        }

    }
}
