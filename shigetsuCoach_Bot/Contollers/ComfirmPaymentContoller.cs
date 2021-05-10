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
            await client.SendPhotoAsync(443521128, file.FileId,replyMarkup:ConfirmButtons());
            //await client.SendPhotoAsync(msg.Chat.Id, file.FileId,replyMarkup:ConfirmButtons());
            // await client.SendPhotoAsync(msg.Chat.Id, msg.Photo);
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
