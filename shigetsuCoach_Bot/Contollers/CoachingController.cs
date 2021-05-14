using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Contollers
{
    public class CoachingController
    {
        Message msg;
        TelegramBotClient client;
        private static InlineKeyboardMarkup _inlineKeyboardMarkup;
        public CoachingController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public CoachingController() { } 

        public async void MainMenu()
        {
            await client.SendTextMessageAsync(msg.Chat.Id, "Коучинг меню", replyMarkup: CoachingButtons());
        }

        private InlineKeyboardMarkup CoachingButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Про разбор","aboutCoaching"),
                        InlineKeyboardButton.WithCallbackData("Отзывы","reviews"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
