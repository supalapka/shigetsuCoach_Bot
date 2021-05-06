using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class AboutCommand: Command
    {
        public override string Name => "about";


        public override async void Execute(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            //TODO
            var outPutString = "Имя - Максим \nВозраст - 17 \nМмр - 9000\nRank - 170 \npos - 1 \nDOTABUFF - https://ru.dotabuff.com/players/194979527 \nDiscord - Shigetsu0#5979 \n";
            await client.SendPhotoAsync(chatId, photo: "https://sun9-49.userapi.com/impg/1mOZfhk4OU3T3oO1hDIQrQVzX5cUE1k_JhYaOw/3mvWKMjv0IU.jpg?size=929x602&quality=96&sign=30ac3cf854b40bd7dcdce1232a44de38&type=album");
            await client.SendTextMessageAsync(chatId, outPutString);

        }
    }
}
