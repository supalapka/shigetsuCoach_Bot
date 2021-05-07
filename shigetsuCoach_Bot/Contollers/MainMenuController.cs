using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Contollers
{
    class MainMenuController
    {
        Message msg;
        TelegramBotClient client;
        public MainMenuController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
            // client.OnMessage += OnMessageHandler;
        }

        public MainMenuController() { }

        public static IReplyMarkup MainMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Про shigetsu" }, new KeyboardButton { Text = "Коучинг" }},
                }
            };
        }
    }
}
