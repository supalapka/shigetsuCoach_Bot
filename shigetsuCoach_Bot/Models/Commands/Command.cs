using Telegram.Bot;
using Telegram.Bot.Types;

namespace shigetsuCoach_Bot.Commands
{
   public abstract class Command
    {
        public abstract string Name { get; }
        public abstract void ExecuteAsync(Message msg, TelegramBotClient client);
        public bool Contains(string command)
        {

            return command.Contains(this.Name);
        }
    }
}
