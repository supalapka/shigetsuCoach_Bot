using shigetsuCoach_Bot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;


namespace shigetsuCoach_Bot.Contollers
{
    class MainMenuController
    {
        Message msg;
        TelegramBotClient client = new TelegramBotClient(ConfigSettings.Token);

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
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Про shigetsu","about"),
                        InlineKeyboardButton.WithCallbackData("Коучинг","coaching"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
