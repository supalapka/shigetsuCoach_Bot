using shigetsuCoach_Bot.Data;
using shigetsuCoach_Bot.Data.Files;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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



        public void SaveRivew(string _review)
        {
            //using (var context = new MyDbContext())
            //{
            //    var review = new Review()
            //    {
            //        ReviewString = _review,
            //    };

            //    context.Reviews.Add(review);
            //    context.SaveChanges();
            //}
        }

        //public void SaveUser()
        //{
        //    using (var context = new MyDbContext())
        //    {
        //        var user = new Data.User()
        //        {
        //            userTelegramId = msg.Chat.Id,
        //            firstName = msg.Contact.FirstName,
        //            phoneNumber = msg.Contact.PhoneNumber

        //        };
        //        context.Users.Add(user);
        //        context.SaveChangesAsync();
        //    }
        //}

        //get reviews TODO


        public async void ShowReviews()
        {
            List<string> reviews;
            StringBuilder outputString = new StringBuilder("");
            using (var context = new MyDbContext())
            {
                reviews = await GetReviewsString(context);
            }

            foreach(var review in reviews)
            {
                outputString.Append(review + "\n\n");
            }

            await client.SendTextMessageAsync(msg.Chat.Id, "Отзывы");
            await client.SendTextMessageAsync(msg.Chat.Id, outputString.ToString());

        }

        private async Task<List<string>> GetReviewsString(MyDbContext _context)
        {

            var reviewsFromDb = await _context.Reviews.ToListAsync();
            var reviews = new List<string>();
            if (reviewsFromDb?.Any() == true)
            {
                foreach (var review in reviewsFromDb)
                {
                    reviews.Add(review.ReviewString);
                }
            }
            return reviews;
        }
    }
}
