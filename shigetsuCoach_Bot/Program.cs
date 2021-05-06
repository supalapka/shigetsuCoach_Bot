using shigetsuCoach_Bot.Commands;
using shigetsuCoach_Bot.Models;
using shigetsuCoach_Bot.Models.Commands;
using shigetsuCoach_Bot.Models.Contollers;
using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace shigetsuCoach_Bot
{
    class Program
    {

        private static List<Command> commandsList;
        public static IReadOnlyList<Command> commands { get => commandsList.AsReadOnly(); }

        private static TelegramBotClient client;
        static void Main(string[] args)
        {
            client = new TelegramBotClient(ConfigSettings.Token);

            commandsList = new List<Command>();
            // adding new commands
            commandsList.Add(new HelloCommand());
            commandsList.Add(new HelpCommand());
            commandsList.Add(new StartCommand());
            commandsList.Add(new AboutCommand());


            client.StartReceiving();

            client.OnMessage += OnMessageHandler;

            Console.ReadLine();
            client.StopReceiving();

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
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


                if (!isCommand)
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
                        case "Коучинг":
                            CoachingController coachController = new CoachingController(msg, client);
                            coachController.MainMenu();
                            break;
                        default:
                            await client.SendTextMessageAsync(msg.Chat.Id, "Bot is developing..", replyMarkup: MainMenuButtons());
                            break;
                    }
            }
        }


        private static IReplyMarkup MainMenuButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Про shigetsu" }, new KeyboardButton { Text = "Коучинг" }},
                  //  new List<KeyboardButton> { new KeyboardButton { Text = "Beta" },  new KeyboardButton { Text = "Пока" }}
                }
            };
        }

        //private static IReplyMarkup CoachingButtons()
        //{
        //    return new ReplyKeyboardMarkup
        //    {
        //        Keyboard = new List<List<KeyboardButton>>
        //        {
        //            new List<KeyboardButton> { new KeyboardButton { Text = "Про тренировку" }, new KeyboardButton { Text = "Назад" }},
        //          //  new List<KeyboardButton> { new KeyboardButton { Text = "Beta" },  new KeyboardButton { Text = "Пока" }}
        //        }
        //    };
        //}
    }
}
