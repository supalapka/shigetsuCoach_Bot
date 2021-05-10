using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Contollers
{
    class MakeOrderController
    {
        Message msg;
        TelegramBotClient client;
        private static ReplyKeyboardMarkup _inlineKeyboardMarkup;
        public MakeOrderController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public MakeOrderController() { }




        public async void GetContact()
        {
            var messageToSent = "Для дальнейшей связи после оплаты нам потребуются твои контактные данные (телеграм)";
            // await client.SendTextMessageAsync(747969117, "вот данные", replyMarkup: GetButtonShareConstacts());

            _inlineKeyboardMarkup = new ReplyKeyboardMarkup(new[]
              {
                    KeyboardButton.WithRequestContact("Поделиться"),
                });
            await client.SendTextMessageAsync(
                chatId: msg.Chat.Id,
                text: messageToSent + msg.Chat.Id,
                replyMarkup: _inlineKeyboardMarkup
            );
        }

        public async void SetPayment()
        {
            var messageToSent = "";

            await client.SendTextMessageAsync(
              chatId: msg.Chat.Id,
              text: messageToSent + msg.Chat.Id
             // replyMarkup: _inlineKeyboardMarkup
          );
        }
    }
}
