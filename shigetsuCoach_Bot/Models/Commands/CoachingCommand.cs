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

        public override bool isPublic => true;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;


            string output = "Почему тебе стоит заказать разбор реплея?\n" +
                "\n" +
                "Гораздо профитнее узнать о своих ошибках, когда тебе их говорят, а не избавляться от них спустя 1000 матчей и терять много времени для достижения цели, которую можно получить повторяя решения построеные на опыте хай ранга.\n\n" +
                "В доте почти нет людей которые с рангом 130 будут разбирать твой реплей в дискорде.\n\n" +
                "Ты услышишь много мыслей по твоей игре со стороны 9к игрока, что может изменить твое понимание игры в целом и сам начнешь думать не так, как игроки с твоего рейтинга.\n\n" +
                "" +
                 "Аналоги разборов за такую цену можно найти от 7-8к игроков(1000 ранг), из них которые 8к попадаются с про игроками 1 раз в 5 игр.\n" +
                "Здесь же я каждый матч играю против про игроков.\n\n";


            //var imagePath1 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike1.png");
            //var imagePath2 = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Data\Files\winstrike2.png");

            //List<FileStream> streams = new List<FileStream>
            //{
            //    System.IO.File.OpenRead(imagePath1),
            //    System.IO.File.OpenRead(imagePath2),
            //};

            //List<InputMediaPhoto> m edia = new List<InputMediaPhoto>();


            //media.Add(new InputMediaPhoto(new InputMedia(streams[0], "sd")));
            //media.Add(new InputMediaPhoto(new InputMedia(streams[1], "fg")));

            await client.SendTextMessageAsync(chatId, output);

            //await client.SendMediaGroupAsync(chatId,media);

            //  await client.SendMediaGroupAsync(chatId, (inputMediaPhoto1, inputMediaPhoto2));

            CoachingController coachingContoller = new CoachingController(msg, client);
            coachingContoller.MainMenu();
        }
    }
}
