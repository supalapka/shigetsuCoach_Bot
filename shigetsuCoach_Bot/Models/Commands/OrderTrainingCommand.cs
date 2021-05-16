using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using shigetsuCoach_Bot.Data;
using System.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class OrderTrainingCommand : Command
    {
        public override string Name => "makeOrder";

        public override bool isPublic => true;

        bool isAdded = false;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            using (var context = new MyDbContext())
            {
                var query = context.Users.Where(u => u.userTelegramId == msg.Chat.Id);
                System.Console.WriteLine(query.ToString());

                foreach (Data.User id in query)  //this foreach equels if condition. trash code //fix
                {
                    isAdded = true;
                    MakeOrderController makeOrderController = new MakeOrderController(msg, client);
                        makeOrderController.SetPayment();
                        break;
                }

                if (!isAdded)
                {
                    MakeOrderController makeOrderController = new MakeOrderController(msg, client);
                    makeOrderController.GetContact();
                }
            }
        }
    }
}
