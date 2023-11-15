using System;

namespace Blackjack
{
    // Стратегія гри комп'ютерного персонажу
    public interface IComputerPlayerStrategy
    {
        bool ShouldTakeCard(int totalPoints);
    }

    // Обережна стратегія (зупинка після 13)
    public class CautiousStrategy : IComputerPlayerStrategy
    {
        public bool ShouldTakeCard(int totalPoints)
        {
            return totalPoints < 13;
        }
    }

    // Ризикова стратегія (зупинка після 19)
    public class RiskyStrategy : IComputerPlayerStrategy
    {
        public bool ShouldTakeCard(int totalPoints)
        {
            return totalPoints < 19;
        }
    }

    // Рандомна стратегія (зупинка за власним алгоритмом)
    public class RandomStrategy : IComputerPlayerStrategy
    {
        private readonly Random random = new Random();

        public bool ShouldTakeCard(int totalPoints)
        {
            // Зупинка з ймовірністю 50%
            return random.Next(2) == 0;
        }
    }

    // Клас гравця у грі Blackjack
    public class Player
    {
        public string Name { get; set; }
        public int TotalPoints { get; set; }

        public Player(string name)
        {
            Name = name;
        }

        public void AddCard(int cardValue)
        {
            TotalPoints += cardValue;
        }

        public void DisplayStatus()
        {
            Console.WriteLine($"{Name}: {TotalPoints} очок");
        }
    }

    // Клас гри Blackjack
    public class BlackjackGame
    {
        private IComputerPlayerStrategy computerPlayerStrategy;

        public BlackjackGame(IComputerPlayerStrategy strategy)
        {
            computerPlayerStrategy = strategy;
        }

        public void PlayGame()
        {
            Player player = new Player("Гравець");
            Player computerPlayer = new Player("Комп'ютер");

            // Логіка гри та взаємодія з стратегією комп'ютерного гравця
            while (true)
            {
                player.DisplayStatus();
                computerPlayer.DisplayStatus();

                // Логіка взяття карт
                int cardValue = GetRandomCard();
                player.AddCard(cardValue);

                // Логіка взяття карт комп'ютерним гравцем за стратегією
                if (computerPlayerStrategy.ShouldTakeCard(computerPlayer.TotalPoints))
                {
                    cardValue = GetRandomCard();
                    computerPlayer.AddCard(cardValue);
                }

                // Логіка завершення гри
                if (player.TotalPoints >= 21 || computerPlayer.TotalPoints >= 21)
                {
                    Console.WriteLine("Гра завершена.");
                    break;
                }
            }
        }

        private int GetRandomCard()
        {
            // Логіка отримання випадкової карти
            Random random = new Random();
            return random.Next(1, 11);
        }
    }

    class Program
    {
        static void Main()
        {
            // Використання стратегій для комп'ютерного гравця
            IComputerPlayerStrategy cautiousStrategy = new CautiousStrategy();
            IComputerPlayerStrategy riskyStrategy = new RiskyStrategy();
            IComputerPlayerStrategy randomStrategy = new RandomStrategy();

            // Вибір конкретної стратегії
            IComputerPlayerStrategy chosenStrategy = cautiousStrategy;

            BlackjackGame game = new BlackjackGame(chosenStrategy);
            game.PlayGame();

            Console.ReadLine();
        }
    }
}
