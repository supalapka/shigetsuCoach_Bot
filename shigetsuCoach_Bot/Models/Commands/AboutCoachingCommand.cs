using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class AboutCoachingCommand : Command
    {
        public override string Name => "aboutCoaching";

        public override async void Execute(Message msg, TelegramBotClient client)
        {
            string messageToSent = "Как проходит коучинг:\nВ дискорде по демке я разбираю твой реплей, говорю твои ошибки, даю советы,  задаю вопросы, отвечаю на вопросы.\n";
             

            await client.SendTextMessageAsync(msg.Chat.Id, messageToSent);
        }
    }
}
