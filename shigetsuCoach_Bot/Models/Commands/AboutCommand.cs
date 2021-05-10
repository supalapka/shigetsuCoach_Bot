using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class AboutCommand: Command
    {
        public override string Name => "about";


        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            var imagePath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\Files\mmr.png");

            var outPutString = "Имя - Максим \nВозраст - 17 \nМмр - 9100\nRank - 150 \npos - 1 \nDOTABUFF - https://ru.dotabuff.com/players/194979527 \nDiscord - Shigetsu0#5979 \n";
            using (var stream = System.IO.File.OpenRead(imagePath))
            {
                await client.SendPhotoAsync(chatId, photo: stream,caption: outPutString);
            }
           // await client.SendTextMessageAsync(chatId, outPutString);
        }
    }
}
