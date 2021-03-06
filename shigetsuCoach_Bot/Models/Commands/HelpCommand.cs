using shigetsuCoach_Bot.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands
{
    class HelpCommand : Command
    {
        public override string Name => "help";

        public override bool isPublic => true;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
            var chatId = msg.Chat.Id;
            var messageId = msg.MessageId;

            var commands = Program.commands;

            string outputString = "Список команд: \n";
            foreach (var command in commands)
            {
                if (command.Name != "help" && command.isPublic)
                    outputString += $"/{command.Name} \n";

            }
                await client.SendTextMessageAsync(chatId, outputString);

        }
    }
}
