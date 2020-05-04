using GameGeek.BL;
using MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WelcomeWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Welcome : Window
    { 
        public Welcome()
        {
            InitializeComponent();
            Enter.Click += Enter_Click;
            UserName.MaxLength = User.MaxNameLength;
            UserName.TextChanged += UserName_TextChanged;

            //Todo:Потом удалить как и авто имя
            UserName.Text = "Dima";
            Enter_Click(Enter, new RoutedEventArgs());
        }

        /// <summary>
        /// Изменение имени пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            foreach (var changeItem in e.Changes)
            {
                if (changeItem.AddedLength>0)
                {
                    //Изменения
                    string addString = textBox.Text.Substring(changeItem.Offset, changeItem.AddedLength);
                    foreach (var ch in addString)
                    {
                        if (!User.IsSymbolAllowed(ch)) 
                        {
                            textBox.Text = textBox.Text.Replace(ch.ToString(), "");
                        }
                    }
                }
                
            }
            
            
        }

        /// <summary>
        /// Нажатие кнопки войти. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User(UserName.Text);
                MessageBox.Show($"Здравствуй {user.Name}!");
                MainWindow mainWindow = new MainWindow(user);
                mainWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
