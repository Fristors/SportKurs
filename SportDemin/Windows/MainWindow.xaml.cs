using System;
using System.Data.Entity;
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

namespace SportDemin
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            OdbConnectHelper.entobj = new SportBDEntities();

        }

        private void Autoriz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = OdbConnectHelper.entobj.Users.FirstOrDefault(
                    x => x.Login == Login.Text && x.Password == Password.Password);
                if (userObj == null)
                    MessageBox.Show("Неверный логин или пароль",
                                    "Уведомление",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning);
                else
                {
                    if (userObj.idTypeUsers == 1)
                    {
                        AdminMainWindow amw = new AdminMainWindow(userObj);
                        amw.Show();
                        this.Close();
                    }
                    else if (userObj.idTypeUsers == 2)
                    {
                        UserMainWindow umw = new UserMainWindow(userObj);
                        umw.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Критический сбор в работе приложения:" + ex.Message.ToString(),
                                "Уведомление",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
            }
            

        }

        private void Regist_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RegistrWindow rw = new RegistrWindow();
            rw.Show();
            this.Close();
        }
    }
}
