using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Contollers;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot.Models.Commands
{
    class BootsMenuCommand : Command
    {
        private InlineKeyboardMarkup _inlineKeyboardMarkup;

        public override string Name => "boost";

        public override bool isPublic => true;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            string output = "Буст\n\n" +
                //$"4000-4500 ммр -> {(int)MmrBoostPrice.from4000to4500} рублей за 100 ммр\n" +
                //$"4500-5000 ммр -> {(int)MmrBoostPrice.from4500to5000} рублей за 100 ммр\n" +
                //$"5000-5500 ммр -> {(int)MmrBoostPrice.from5000to5500} рублей за 100 ммр\n" +
                //$"5500-6000 ммр -> {(int)MmrBoostPrice.from5500to6000} рублей за 100 ммр\n" +
                $"6000-6500 ммр -> {(int)MmrBoostPrice.from6000to6500} рублей за 100 ммр\n" +
                $"6500-7000 ммр -> {(int)MmrBoostPrice.from6500to7000} рублей за 100 ммр\n" +
                $"7000-7500 ммр -> {(int)MmrBoostPrice.from7000to7500} рублей за 100 ммр\n" +
                $"7500-8000 ммр -> {(int)MmrBoostPrice.from7500to8000} рублей за 100 ммр\n" +
                $"8000-8500 ммр -> {(int)MmrBoostPrice.from8000to8500} рублей за 100 ммр\n" +
                "";

            await client.SendTextMessageAsync(msg.Chat.Id, output, replyMarkup: BoostgButtons());
        }

        private InlineKeyboardMarkup BoostgButtons()
        {
            if (_inlineKeyboardMarkup == null)
            {
                _inlineKeyboardMarkup = new InlineKeyboardMarkup(new[]
                {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Заказать буст","orderBoost"),
                        InlineKeyboardButton.WithCallbackData("Отзывы","reviews"),
                    },
                });
            }

            return _inlineKeyboardMarkup;
        }
    }
}
