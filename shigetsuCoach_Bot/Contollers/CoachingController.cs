using shigetsuCoach_Bot.Contollers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Contollers
{
    public class CoachingController
    {
        public static bool coachControllerWork = true;
        Message msg;
        TelegramBotClient client;
        public CoachingController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;

            client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            client.StopReceiving();

        }

        private async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            msg = e.Message;
            System.Console.WriteLine($"message recieved: {msg.Text}");
            switch (msg.Text)
            {
                case "Назад":
                    Program.isMainMenu = true;
                    //await client.SendTextMessageAsync(msg.Chat.Id, "Main menu:",replyMarkup:MainMenuController.MainMenuButtons());
                    MainMenuController.MainMenuButtons();
                    coachControllerWork = false;
                    client.StopReceiving();
                    break;
                default:
                    await client.SendTextMessageAsync(msg.Chat.Id, "CoachController: developing..");
                    client.StopReceiving();
                    break;
            }
        }

        public CoachingController() { } 

        public async void MainMenu()
        {
            Program.isMainMenu = false;
            await client.SendTextMessageAsync(msg.Chat.Id, "Coaching", replyMarkup: CoachingButtons());
        }

        public static IReplyMarkup CoachingButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Про тренировку" }, new KeyboardButton { Text = "Назад" }},
                }
            };
        }
        ~CoachingController()
        {
            Program.isMainMenu = true;
        }
    }
}
