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
    /// Interaction logic for Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        private Controller controller;
        public Employee()
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

        private void Button_NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            controller.AddInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();

            if(controller.InstanceIndex > 0) 
            { 
                Button_Prev.IsEnabled = true;
            }
            Button_Next.IsEnabled = false;

            enabledTextboxes();
            clearTextboxes();
        }

        private void Button_EditEmployee_Click(object sender, RoutedEventArgs e)
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

            if(controller.InstanceIndex == 0 )
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

            if(controller.InstanceIndex == controller.InstanceCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void TextBox_FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentInstance.FirstName = TextBox_FirstName.Text;
        }

        private void TextBox_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentInstance.LastName = TextBox_LastName.Text;
        }

        private void TextBox_Role_TextChanged(object sender, TextChangedEventArgs e)
        {
            controller.CurrentInstance.Role = TextBox_Role.Text;
        }

        private void TextBox_UNKNOWN_TextChanged(object sender, TextChangedEventArgs e)
        {
            int a = 0;
            bool b = int.TryParse(TextBox_UNKNOWN.Text, out a);
            if(b == true)
            {
                controller.CurrentInstance.Id = a;
            }
        }

        private void enabledTextboxes() 
        {
            TextBox_FirstName.IsEnabled = true;
            TextBox_LastName.IsEnabled = true;
            TextBox_Role.IsEnabled = true;
            TextBox_UNKNOWN.IsEnabled = true;
        }

        private void disabledTextboxes()
        {
            TextBox_FirstName.IsEnabled = false;
            TextBox_LastName.IsEnabled = false;
            TextBox_Role.IsEnabled = false;
            TextBox_UNKNOWN.IsEnabled = false;
        }

        private void updateTextbboxes()
        {
            TextBox_FirstName.Text = controller.CurrentInstance.FirstName;
            TextBox_LastName.Text = controller.CurrentInstance.LastName;
            TextBox_Role.Text = controller.CurrentInstance.Role;
            TextBox_UNKNOWN.Text = controller.CurrentInstance.Id.ToString();
        }

        private void clearTextboxes()
        {
            TextBox_FirstName.Text = string.Empty;
            TextBox_LastName.Text = string.Empty;
            TextBox_Role.Text = string.Empty;
            TextBox_UNKNOWN.Text = string.Empty;
        }
    }
}
