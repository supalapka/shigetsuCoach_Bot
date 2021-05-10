using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Contollers
{
    class ReviewsController
    {
        Message msg;
        TelegramBotClient client;
        public ReviewsController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public ReviewsController() { }


    }
}
