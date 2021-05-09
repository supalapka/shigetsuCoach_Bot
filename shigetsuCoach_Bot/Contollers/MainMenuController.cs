using shigetsuCoach_Bot.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

public static class EnumExtensions
{
    public static int ToInt(this Enum @enum)
    {
        return (int)(object)@enum;
    }
}

namespace shigetsuCoach_Bot.Contollers
{
    class MainMenuController
    {
       static Message msg;
        static TelegramBotClient client = new TelegramBotClient(ConfigSettings.Token);

        private static InlineKeyboardMarkup _inlineKeyboardMarkup;
        public MainMenuController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public MainMenuController() {
        }

        public async void MainMenuButtons()
        {
            await client.SendTextMessageAsync(
                   chatId: msg.Chat.Id,
                   text: "Главное меню:",
                   replyMarkup: GenerateInlineKeyboardMarkup()
               );
        }


        private InlineKeyboardMarkup GenerateInlineKeyboardMarkup()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    // first row
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Про shigetsu","about"),
                        InlineKeyboardButton.WithCallbackData("Коучинг","coaching"),
                    },
                    // second row
                    new []
                    {
                         InlineKeyboardButton.WithCallbackData("test button 1","1"),
                        InlineKeyboardButton.WithCallbackData("test button 1","2"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
