using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class CoachingCommand : Command
    {
        public override string Name => "coaching";

        public override void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;


            CoachingController coachingContoller = new CoachingController(msg, client);

            coachingContoller.MainMenu();
        }
    }
}
