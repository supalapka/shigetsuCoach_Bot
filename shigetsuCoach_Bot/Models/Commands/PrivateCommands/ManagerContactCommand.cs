using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class ManagerContactCommand : Command
    {
        public override string Name => "managerContact";

        public override bool isPublic => false;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            await client.SendContactAsync(msg.Chat.Id, ConfigSettings.supalapkaPhone,ConfigSettings.supalapkaName);
        }
    }
}
