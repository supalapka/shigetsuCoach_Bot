using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Contollers
{
    class MakeOrderController
    {
        Message msg;
        TelegramBotClient client;
        private static ReplyKeyboardMarkup shareButton;
        public static InlineKeyboardMarkup _inlineKeyboardMarkup;
        public MakeOrderController(Message _msg, TelegramBotClient _client)
        {
            msg = _msg;
            client = _client;
        }

        public MakeOrderController() { }


        public async void GetContact()
        {
            var messageToSent = "Для дальнейшей связи после оплаты нам потребуются твои контактные данные (телеграм)";

            shareButton = new ReplyKeyboardMarkup(new[]
              {
                    KeyboardButton.WithRequestContact("Поделиться"),
                });
            await client.SendTextMessageAsync(
                chatId: msg.Chat.Id,
                text: messageToSent + msg.Chat.Id,
                replyMarkup: shareButton
            );
        }

        public  async void SetPayment()
        {
            var messageToSent = "На даную карту 5166 7422 2993 6467 скинуть 600 рублей/200 гривен. После оплаты нажать \"я оплатил\" и отправить скриншот платежа сюда.\n" +
                "После проверки скриншота и баланса на карте с вами свяжется человек для уточнения времени проведения разбора реплея. (тест текст)";
            await client.SendTextMessageAsync(
              chatId: msg.Chat.Id,
              text: messageToSent,
             replyMarkup: PaymentMenu()
          );
        }

        private InlineKeyboardMarkup PaymentMenu()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Я оплатил","paymentDone"),
                        InlineKeyboardButton.WithCallbackData("Отмена","cencel"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
