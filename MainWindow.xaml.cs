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

namespace tk
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateScore_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(dbScore.Text, out int db) || db < 0 || db > 22 ||
                !int.TryParse(devScore.Text, out int dev) || dev < 0 || dev > 38 ||
                !int.TryParse(supportScore.Text, out int support) || support < 0 || support > 20)
            {
                MessageBox.Show("Введите корректные значения баллов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int total = db + dev + support;
            string grade;

            if (total >= 56)
                grade = "5 (отлично)";
            else if (total >= 32)
                grade = "4 (хорошо)";
            else if (total >= 16)
                grade = "3 (удовлетворительно)";
            else
                grade = "2 (неудовлетворительно)";

            resultText.Text = $"Сумма баллов: {total}\nОценка: {grade}";
        }
    }
}
