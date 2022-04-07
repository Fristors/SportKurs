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
using System.Windows.Shapes;

namespace SportDemin
{
    /// <summary>
    /// Логика взаимодействия для RecordWindow.xaml
    /// </summary>
    public partial class RecordWindow : Window
    {
        SportBDEntities db;
        public RecordWindow(Users userObj)
        {
            InitializeComponent();
            db = new SportBDEntities();
            db.Record.Load();
            SportGrid.ItemsSource = db.Record.Local.ToBindingList();
            if (userObj.idTypeUsers == 2)
            {
                SportGrid.IsReadOnly = true;
                deleteButton.IsEnabled = false;
            }
            this.Closing += MainWindow_Closing;
        }
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Неверный ввод данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (SportGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < SportGrid.SelectedItems.Count; i++)
                {
                    Record record = SportGrid.SelectedItems[i] as Record;
                    if (record != null)
                    {
                        db.Record.Remove(record);
                    }
                }
            }
            db.SaveChanges();
            MessageBox.Show("Удаление прошло успешно", "Результат работы", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}
