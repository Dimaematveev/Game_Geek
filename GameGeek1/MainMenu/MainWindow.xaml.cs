using GameGeek.BL;
using System;
using System.Windows.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Data;

namespace MainMenu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime NowDateTime = DateTime.Now.Date;
        private User Player;
        public MainWindow(User player)
        {
            if (player == null) 
            {
                throw new ArgumentNullException(nameof(player), $"Пользователь не должен быть null!!!");
            }
            InitializeComponent();
            Player = player;
            Player.NotifyAmountOfMoneyChanged += Player_NotifyAmountOfMoneyChanged;
            var timer = new DispatcherTimer();
            timer.Tick += new EventHandler(OnTimedEvent);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.Start();
            Loaded += MainWindow_Loaded;

        }


        private void OnTimedEvent(object obj, EventArgs e)
        {
            
            if (NowDateTime.AddHours(1).Date > NowDateTime.Date)
            {
                Player.EditMoney(100);
            }
            NowDateTime = NowDateTime.AddHours(1);
            DateTimeText.BeginInit();
            
            DateTimeText.Text = $"Date: {NowDateTime.ToShortDateString()} Time: {NowDateTime.ToShortTimeString()}";
            DateTimeText.EndInit();
        }

        private void Player_NotifyAmountOfMoneyChanged(string message)
        {
            MoneyPlayers.BeginInit();
            MoneyPlayers.Text = Player.Money.ToString();
            MoneyPlayers.EndInit();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DateTimeText.Text = $"Date: {NowDateTime.ToShortDateString()} Time: {NowDateTime.ToShortTimeString()}";
            NamePlayers.Text = Player.Name;
            MoneyPlayers.Text = Player.Money.ToString();
        }
    }
}
