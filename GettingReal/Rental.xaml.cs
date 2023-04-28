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

namespace WPFapp
{
    /// <summary>
    /// Interaction logic for Rental.xaml
    /// </summary>
    public partial class Rental : Window
    {
        private Controller controller;
        public Rental()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void Button_MainPage_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void Button_NewRental_Click(object sender, RoutedEventArgs e)
        {
            controller.AddInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_Resource_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Project_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Periode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Renter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
