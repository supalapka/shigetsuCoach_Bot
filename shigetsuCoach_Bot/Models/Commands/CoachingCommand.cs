using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using System;
using System.IO;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class CoachingCommand : Command
    {
        public override string Name => "coaching";

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;


            string output = "Почему тебе стоит заказать разбор реплея?\n" +
                "\n" +
                "В интернете почти нет людей которые с рангом 140 будут разбирать твой реплей в дискорде.\n" +
                "Аналоги разборов за такую цену можно найти от 6-7к игроков(1500 ранг) которым явно далеко до игры с про игроками.\n" +
                "\n" +
                "Имея 140 ранг я уже играл в стаках с чего имею опыт профессиональной доты и даже обыгрывал винстрайк на квалах (2020 год, 600 ранг)";


            var imagePath1 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike1.png");
            var imagePath2 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike2.png");
            await client.SendTextMessageAsync(chatId, output);

            InputMediaPhoto inputMediaPhoto1 = new InputMediaPhoto(imagePath1);
            InputMediaPhoto inputMediaPhoto2 = new InputMediaPhoto(imagePath2);

            InputMediaBase media = new InputMediaBase(imagePath1);


            await client.SendMediaGroupAsync(chatId, (inputMediaPhoto1, inputMediaPhoto2));

            CoachingController coachingContoller = new CoachingController(msg, client);
            coachingContoller.MainMenu();
        }
    }
}
