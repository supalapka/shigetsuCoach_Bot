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
        private static InlineKeyboardMarkup _inlineKeyboardMarkup;
        public CoachingController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;

        }

        public CoachingController() { } 

        public async void MainMenu()
        {
            await client.SendTextMessageAsync(msg.Chat.Id, "Coaching", replyMarkup: CoachingButtons());
        }

        private InlineKeyboardMarkup CoachingButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Про коучинг","aboutCoaching"),
                        InlineKeyboardButton.WithCallbackData("empty button"," "),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
