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

namespace WPFapp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Controller controller;
        public MainWindow()
        {
            InitializeComponent();
            controller = new Controller();
        }

        private void Button_Project_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Project(); //create your new form.
            newWindow.Show(); //show the new form.
            this.Close(); //only if you want to close the current form.
        }

        private void Button_Employee_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Employee();
            controller.LoadEmployee();
            newWindow.Show();
            this.Close();
        }

        private void Button_Resource_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Resource();
            newWindow.Show();
            this.Close();
        }

        private void Button_Fastener_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Fastener();
            newWindow.Show();
            this.Close();
        }

        private void Button_Rental_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new Rental();
            newWindow.Show();
            this.Close();
        }
    }
}
