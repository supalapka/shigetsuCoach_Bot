using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Models;
using shigetsuCoach_Bot.Models.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot
{
    class Program
    {
        public static bool isMainMenu = true;
        public static  bool botWorks = true;


        private static List<Command> commandsList;
        public static IReadOnlyList<Command> commands { get => commandsList.AsReadOnly(); }

        private static TelegramBotClient client;

            public static async Task Main()
        {
            client = new TelegramBotClient(ConfigSettings.Token);

            commandsList = new List<Command>();
            // adding new commands
            commandsList.Add(new HelloCommand());
            commandsList.Add(new HelpCommand());
            commandsList.Add(new StartCommand());
            commandsList.Add(new AboutCommand());


            client.StartReceiving();
            client.OnMessage += BotOnMessageReceived;
            client.OnCallbackQuery += BotOnCallBackQueryAsync;

            //  Console.ReadLine();
            while (botWorks)  { }
            client.StopReceiving();
        }

        private static async void BotOnCallBackQueryAsync(object sender, CallbackQueryEventArgs e)
        {
            var callback = e.CallbackQuery.Data;
            var msg = e.CallbackQuery.Message;

            foreach (var command in commands)
            {
                if (command.Contains(callback))
                {
                    command.Execute(msg, client);
                    //isCommand = true;
                    break;
                }
            }
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            bool isCommand = false;
            if (msg.Text != null)
            {
                Console.WriteLine($"message recieved: {msg.Text}");

                foreach (var command in commands)
                {
                    if (command.Contains(msg.Text))
                    {
                        command.Execute(msg, client);
                        isCommand = true;
                        break;
                    }
                }


                if (!isCommand && isMainMenu)
                    switch (msg.Text)
                    {
                        case "Про shigetsu":
                            msg.Text = "about";
                            foreach (var command in commands)
                            {
                                if (command.Contains(msg.Text))
                                {
                                    command.Execute(msg, client);
                                    isCommand = true;
                                    break;
                                }
                            }
                            break;

                        //case "Коучинг":
                        //    msg.Text = "coaching";
                        //    foreach (var command in commands)
                        //    {
                        //        if (command.Contains(msg.Text))
                        //        {
                        //            command.Execute(msg, client);
                        //            isCommand = true;
                        //            break;
                        //        }
                        //    }
                        //    break;

                        //case "a":
                        //    msg.Text = "a";
                        //    foreach (var command in commands)
                        //    {
                        //        if (command.Contains(msg.Text))
                        //        {
                        //            command.Execute(msg, client);
                        //            isCommand = true;
                        //            break;
                        //        }
                        //    }
                        //    break;

                        //case "b":
                        //    msg.Text = "b";
                        //    foreach (var command in commands)
                        //    {
                        //        if (command.Contains(msg.Text))
                        //        {
                        //            command.Execute(msg, client);
                        //            isCommand = true;
                        //            break;
                        //        }
                        //    }
                        //    break;

                        default:
                            await client.SendTextMessageAsync(msg.Chat.Id, "Bot is developing..");
                            break;
                    }
            }
        }

    }
}
