using shigetsuCoach_Bot.Commands;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Models.Commands.PrivateCommands
{
    class ConfirmCommand : Command
    {
        public override string Name => "Confirm";

        public override bool isPublic => false;

        public override async void ExecuteAsync(Message msg, TelegramBotClient client)
        {
                string chatId = msg.Text.Remove(0,7); //confirm word skip
                Console.WriteLine(chatId);

            await client.SendTextMessageAsync(ConfigSettings.supalapkaId, ("Оплата реплея успешна! \n\n" +  //fix
                "Скиньте данный код " + chatId + " в дискорд Shigetsu0#5979 и далее он уже с вами довогорится о всем."));

            await client.SendTextMessageAsync(msg.Chat.Id, chatId + " успешно прошел оплату");
        }
    }
}
