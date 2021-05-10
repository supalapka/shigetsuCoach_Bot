using shigetsuCoach_Bot.Data;
using shigetsuCoach_Bot.Data.Files;
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

           // SaveReviews("first text review");
        }

        public ReviewsController() { }



        public void SaveReviews(string _review)
        {
            using (var context = new MyDbContext())
            {
                var review = new Review()
                {
                    ReviewString = _review,
                };
                context.Reviews.Add(review);
                context.SaveChanges();
            }
        }
    }
}
