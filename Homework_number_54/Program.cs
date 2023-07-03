using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework_number_54
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandShowAllPlayers = "1";
            const string CommandShowTopPlayersByLevel = "2";
            const string CommandShowTopPlayersByForce = "3";
            const string CommandExit = "4";

            Database database = new Database();

            bool isExit = false;
            string userInput;

            while (isExit == false)
            {
                Console.WriteLine($"Для того что бы увидеть всех игроков нажмите: {CommandShowAllPlayers}\n" +
                                  $"Для того что бы увидеть список лучших игроков по уровню нажмите: {CommandShowTopPlayersByLevel}\n" +
                                  $"Для того что бы увидеть список лучших игроков по силе нажмите: {CommandShowTopPlayersByForce}\n" +
                                  $"Для того что бы закрыть приложение нажмите {CommandExit}\n");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandShowAllPlayers:
                        database.ShowAllPlayers();
                        break;

                    case CommandShowTopPlayersByLevel:
                        database.ShowTopPlayersByLevel();
                        break;

                    case CommandShowTopPlayersByForce:
                        database.ShowTopPlayersByForce();
                        break;

                    case CommandExit:
                        isExit = true;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет в наличии!");
                        break;
                }

                Console.WriteLine("\n\nДля продолжения ведите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    class Player
    {
        public Player(string name, int level, int force)
        {
            Name = name;
            Level = level;
            Force = force;
        }

        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Force { get; private set; }
    }

    class Database
    {
        private List<Player> _players = new List<Player>();

        public Database()
        {
            Fill();
        }

        public void ShowTopPlayersByLevel()
        {
            int quantityTopPlayer = 3;

            List<Player> sortedPlayers = GetTopPlayersByLevel(quantityTopPlayer);

            ShowPlayers(sortedPlayers);
        }

        public void ShowTopPlayersByForce()
        {
            int quantityTopPlayer = 3;

            List<Player> sortedPlayers = GetTopPlayersByForce(quantityTopPlayer);

            ShowPlayers(sortedPlayers);
        }

        public void ShowAllPlayers()
        {
            ShowPlayers(_players);
        }

        private List<Player> GetTopPlayersByLevel(int quantityPlayer)
        {
            return _players.OrderByDescending(player => player.Level).Take(quantityPlayer).ToList();
        }

        private List<Player> GetTopPlayersByForce(int quantityPlayer)
        {
            return _players.OrderByDescending(player => player.Force).Take(quantityPlayer).ToList();
        }

        private void ShowPlayers(List<Player> sortedPlayers)
        {
            foreach (Player player in sortedPlayers)
            {
                Console.WriteLine("Игрок:");
                Console.WriteLine($"Имя : {player.Name}");
                Console.WriteLine($"Уровень: {player.Level}");
                Console.WriteLine($"Сила: {player.Force}");
                Console.WriteLine();
            }
        }

        private void Fill()
        {
            Random random = new Random();

            List<string> names = new List<string>
           {
            "Иван",
            "Петр",
            "Алексей",
            "Ольга",
            "Андрей",
            "Максим",
            "Екатерина",
            "Игорь",
            "Анна",
            "Мария"
           };

            int quantityPlayer = 10;
            int maxLevel = 100;
            int maxForce = 100;

            for (int i = 0; i < quantityPlayer; i++)
            {
                _players.Add(new Player(names[random.Next(names.Count)],
                                        random.Next(maxLevel),
                                        random.Next(maxForce)));
            }
        }
    }
}
