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
    /// Логика взаимодействия для AdminMainWindow.xaml
    /// </summary>
    public partial class AdminMainWindow : Window
    {
        Users userobj;
        public AdminMainWindow(Users userObj)
        {
            InitializeComponent();
            userobj = userObj;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RecordWindow rw = new RecordWindow(userobj);
            rw.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NameSportWindow nsw = new NameSportWindow(userobj);
            nsw.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            UnitSportWindow usw = new UnitSportWindow(userobj);
            usw.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            UsersWindow uw = new UsersWindow();
            uw.Show();
        }
    }
}
