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

namespace GenerateTaxNumber
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void refresh()
        {
            TextBoxTN.Text = GenerateTaxNumber();
        }

        private string GenerateTaxNumber()
        {
            string str = "";

            if (DatePickerBD.SelectedDate != null)
            {
                TimeSpan ts = (TimeSpan)(DatePickerBD.SelectedDate - DateTime.Parse("31.12.1899"));
                str += ts.TotalDays.ToString() + "136";
                switch (ComboBoxSex.SelectedIndex)
                {
                    case 0:
                        str += "1";
                        break;
                    case 1:
                        str += "2";
                        break;
                    case -1:
                        str = "Не обрано стать.";
                        break;
                }
                if (ComboBoxSex.SelectedIndex != -1)
                {                                        
                    int x = -Cti(str[0]) + Cti(str[1]) * 5 + Cti(str[2]) * 7 + Cti(str[3]) * 9 + Cti(str[4]) * 4 + Cti(str[5]) * 6 + Cti(str[6]) * 10 + Cti(str[7]) * 5 + Cti(str[8]) * 7;
                    str += ((x%11)%10).ToString();
                }
            }
            //(DatePickerBD.SelectedDate - (DateTime.Parse("31.12.1899")))
            return str;
        }
        private static int Cti(char c)//Char-To-Int
        {
            if (Char.IsDigit(c)) return int.Parse(c.ToString());
            else return -1;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DatePickerBD_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            refresh();
        }
    }
    
}
