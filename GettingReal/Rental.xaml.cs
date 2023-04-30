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

            if (controller.InstanceIndex > 0)
            {
                Button_Prev.IsEnabled = true;
            }
            Button_Next.IsEnabled = false;

            enabledTextboxes();
            clearTextboxes();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
            disabledTextboxes();
            updateTextbboxes();

            Button_Next.IsEnabled = true;

            if (controller.InstanceIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
            disabledTextboxes();
            updateTextbboxes();

            Button_Prev.IsEnabled = true;

            if (controller.InstanceIndex == controller.InstanceCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
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
        private void enabledTextboxes()
        {
            TextBox_Resource.IsEnabled = true;
            TextBox_Project.IsEnabled = true;
            TextBox_Periode.IsEnabled = true;
            TextBox_Renter.IsEnabled = true;
        }

        private void disabledTextboxes()
        {
            TextBox_Resource.IsEnabled = false;
            TextBox_Project.IsEnabled = false;
            TextBox_Periode.IsEnabled = false;
            TextBox_Renter.IsEnabled = false;
        }

        private void updateTextbboxes()
        {
            TextBox_Resource.Text = controller.CurrentInstance.FirstName;
            TextBox_Project.Text = controller.CurrentInstance.LastName;
            TextBox_Periode.Text = controller.CurrentInstance.Role;
            TextBox_Renter.Text = controller.CurrentInstance.Id.ToString();
        }

        private void clearTextboxes()
        {
            TextBox_Resource.Text = string.Empty;
            TextBox_Project.Text = string.Empty;
            TextBox_Periode.Text = string.Empty;
            TextBox_Renter.Text = string.Empty;
        }


    }
}

