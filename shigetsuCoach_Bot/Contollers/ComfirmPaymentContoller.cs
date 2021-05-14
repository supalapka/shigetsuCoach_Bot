using shigetsuCoach_Bot.Data;
using shigetsuCoach_Bot.Data.Files;
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

        public async void SendShigetsuScreen(Telegram.Bot.Types.File file, long chatId)
        {
            await client.SendPhotoAsync(ConfigSettings.shigetsuId, file.FileId, replyMarkup:ConfirmButtons(chatId),caption: chatId.ToString());
        }

        public async void SaveToParticipant(long chatId)
        {
            using (var context = new MyDbContext())
            {
                var participant = new Participant()
                {
                    userTelegramId = chatId
                };

                context.Participants.Add(participant);
               await context.SaveChangesAsync();
            }
        }


        private InlineKeyboardMarkup ConfirmButtons(long chatId)
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Да",("Confirm" + chatId)),
                        InlineKeyboardButton.WithCallbackData("Нет","Unconfirm"),
                    }
                });
            }

            return _inlineKeyboardMarkup;
        }

    }
}
