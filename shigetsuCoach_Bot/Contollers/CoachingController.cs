using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Contollers
{
    public class CoachingController
    {
        Message msg;
        TelegramBotClient client;
        public CoachingController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
            client.OnMessage += OnMessageHandler;
        }

        private async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            await client.SendTextMessageAsync(msg.Chat.Id, "Bot is developing..");
            switch (msg.Text)
            {
                case "Назад":
                    Program.isMainMenu = true;
                    await client.SendTextMessageAsync(msg.Chat.Id, "!!!!!!!!!!!!!!!!!!!!!");
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
