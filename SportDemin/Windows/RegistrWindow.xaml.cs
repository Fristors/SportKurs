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
using System.Windows.Shapes;

namespace SportDemin
{
    /// <summary>
    /// Логика взаимодействия для RegistrWindow.xaml
    /// </summary>
    public partial class RegistrWindow : Window
    {
        public RegistrWindow()
        {
            InitializeComponent();
        }

        private void Regist_Click(object sender, RoutedEventArgs e)
        {
            if(Login.Text.Length == 0 || Password.Password.Length == 0)
            {
                MessageBox.Show("Нельзя оставлять поля пустыми",
                                "Предупреждение",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }
            if (OdbConnectHelper.entobj.Users.Count(x => x.Login == Login.Text) > 0)
            {
                MessageBox.Show("Такой пользователь уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else
            {
                try
                {
                    Users userObj = new Users()
                    {
                        id = OdbConnectHelper.entobj.Users.Count()+1,
                        Login = Login.Text,
                        Password = Password.Password,
                        idTypeUsers = 2
                    };

                    OdbConnectHelper.entobj.Users.Add(userObj);
                    OdbConnectHelper.entobj.SaveChanges();
                    MessageBox.Show("Пользователь создан!", 
                                    "Уведомление", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Information);
                    MainWindow mw = new MainWindow();
                    mw.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), 
                                    "Критический сбор работы", 
                                    MessageBoxButton.OK, 
                                    MessageBoxImage.Warning);
                }

            }
        }
    }
}
