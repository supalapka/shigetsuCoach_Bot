using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
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
        }

        public CoachingController()  { }

        public async void MainMenu()
        {
            await client.SendTextMessageAsync(msg.Chat.Id, "Coaching", replyMarkup: CoachingButtons());
        }

        private static IReplyMarkup CoachingButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Про тренировку" }, new KeyboardButton { Text = "Назад" }},
                }
            };
        }
    }
}
