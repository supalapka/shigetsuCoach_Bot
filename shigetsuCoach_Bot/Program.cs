﻿using shigetsuCoach_Bot.Commands;
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
        public static bool isMainMenu = true;

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
                        case "Коучинг":
                            CoachingController coachController = new CoachingController(msg, client);
                            coachController.MainMenu();
                            break;
                        default:
                            await client.SendTextMessageAsync(msg.Chat.Id, "Bot is developing..");
                            break;
                    }
            }
        }

    }
}
