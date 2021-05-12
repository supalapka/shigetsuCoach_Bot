using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using System;
using System.Collections.Generic;
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
                "Имея 140 ранг я уже играл в стаках с чего имею опыт профессиональной доты и уже обыграл винстрайк на квалах (ноябрь 2020 год, 700 ранг)\n" +
                "to be edited..";


            var imagePath1 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike1.png");
            var imagePath2 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike2.png");

            List<FileStream> streams = new List<FileStream>
            {
                System.IO.File.OpenRead(imagePath1),
                System.IO.File.OpenRead(imagePath2),
            };

            List<InputMediaPhoto> media = new List<InputMediaPhoto>();


            media.Add(new InputMediaPhoto(new InputMedia(streams[0], "sd")));
            media.Add(new InputMediaPhoto(new InputMedia(streams[1], "fg")));

            await client.SendTextMessageAsync(chatId, output);

            await client.SendMediaGroupAsync(chatId,media);

            //  await client.SendMediaGroupAsync(chatId, (inputMediaPhoto1, inputMediaPhoto2));

            CoachingController coachingContoller = new CoachingController(msg, client);
            coachingContoller.MainMenu();
        }
    }
}
