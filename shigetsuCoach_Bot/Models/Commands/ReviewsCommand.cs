using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class ReviewsCommand : Command
    {
        public override string Name => "reviews";

        public override bool isPublic => true;

        public override void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            ReviewsController reviewsController = new ReviewsController(msg, client);
            reviewsController.ShowReviews();
        }
    }
}
