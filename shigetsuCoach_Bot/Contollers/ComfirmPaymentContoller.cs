using shigetsuCoach_Bot.Models;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Contollers
{
    public class ConfirmPaymentContoller
    {
        Message msg;
        TelegramBotClient client;
        private static InlineKeyboardMarkup _inlineKeyboardMarkup;

        public ConfirmPaymentContoller(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;

        }

        public ConfirmPaymentContoller() { }

        public async void SendShigetsuScreen(Telegram.Bot.Types.File file)
        {
            await client.SendPhotoAsync(ConfigSettings.shigetsuId, file.FileId,replyMarkup:ConfirmButtons());
        }


        private InlineKeyboardMarkup ConfirmButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да","Confirm"),
                        InlineKeyboardButton.WithCallbackData("Нет","Unconfirm"),
                    }
                });
            }

            return _inlineKeyboardMarkup;
        }

    }
}
