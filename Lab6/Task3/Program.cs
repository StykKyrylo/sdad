using System;
using System.Collections.Generic;
using System.IO;

namespace Blackjack
{
    // Подія для випадків перебору очків
    public delegate void BustEventHandler(object sender, EventArgs e);

    // Гравець у грі Blackjack
    public class Player
    {
        public event BustEventHandler Bust;

        private List<int> hand = new List<int>();

        public void AddCard(int cardValue)
        {
            hand.Add(cardValue);
            int totalPoints = CalculateTotalPoints();

            // Перевірка на перебір
            if (totalPoints > 21)
            {
                OnBust();
            }
        }

        public int CalculateTotalPoints()
        {
            int totalPoints = 0;
            foreach (int card in hand)
            {
                totalPoints += card;
            }
            return totalPoints;
        }

        protected virtual void OnBust()
        {
            Bust?.Invoke(this, EventArgs.Empty);
        }
    }

    // Сервіс для моніторингу випадків перебору
    public class BustMonitorService
    {
        public void Subscribe(Player player)
        {
            player.Bust += Player_Bust;
        }

        private void Player_Bust(object sender, EventArgs e)
        {
            Console.WriteLine("Гравець перебрав! Записую в файл.");
            // Логіка для запису в файл випадків перебору
        }
    }

    // Сервіс для збору аналітики про середню кількість очок
    public class AnalyticsService
    {
        private List<int> totalPointsHistory = new List<int>();

        public void Subscribe(Player player)
        {
            player.Bust += Player_Bust;
        }

        private void Player_Bust(object sender, EventArgs e)
        {
            // Додаємо кількість очок до історії для аналітики
            Player player = (Player)sender;
            int totalPoints = player.CalculateTotalPoints();
            totalPointsHistory.Add(totalPoints);
        }

        public void WriteAnalyticsToFile()
        {
            Console.WriteLine("Записую аналітику в файл.");
            // Логіка для запису в файл середньої кількості очок
        }
    }

    class Program
    {
        static void Main()
        {
            Player player = new Player();
            BustMonitorService bustMonitor = new BustMonitorService();
            AnalyticsService analyticsService = new AnalyticsService();

            // Підписка на події
            bustMonitor.Subscribe(player);
            analyticsService.Subscribe(player);

            // Сценарій гри
            player.AddCard(10);
            player.AddCard(8);
            player.AddCard(7); // Це призведе до перебору

            // Запис аналітики в файл
            analyticsService.WriteAnalyticsToFile();

            Console.ReadLine();
        }
    }
}
