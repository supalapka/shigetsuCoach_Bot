using shigetsuCoach_Bot.Models;
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
       static Message msg;
        static TelegramBotClient client = new TelegramBotClient(ConfigSettings.Token);
        public MainMenuController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
            // client.OnMessage += OnMessageHandler;
        }

        public MainMenuController() {
        client = new TelegramBotClient(ConfigSettings.Token);
        }

        public static async void MainMenuButtons()
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
               {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("1.1", "11"),
                        InlineKeyboardButton.WithCallbackData("1.2", "12"),
                    },
                    // second row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("2.1", "21"),
                        InlineKeyboardButton.WithCallbackData("2.2", "22"),
                    }

                });
            await client.SendTextMessageAsync(
                   chatId: msg.Chat.Id,
                   text: "Main menu:",
                   replyMarkup: inlineKeyboard
               );
        }
    }
}
