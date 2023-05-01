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
        string s = "";
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
            Button_Edit.IsEnabled = true;
            Button_Del.IsEnabled = true;

            enabledTextboxes();
            clearTextboxes();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            enabledTextboxes();
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

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();

            if (controller.InstanceCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            else if (controller.InstanceIndex >= 0)
            {
                updateTextbboxes();
            }
            else
            { 
                clearTextboxes(); 
                Button_Del.IsEnabled = false;
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
                Button_Edit.IsEnabled = false;
            }

            disabledTextboxes();

        }

        private void TextBox_FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(controller.InstanceIndex >= 0) 
            { 
                controller.CurrentInstance.FirstName = TextBox_FirstName.Text;  
            }
        }

        private void TextBox_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.InstanceIndex >= 0)
            {
                controller.CurrentInstance.LastName = TextBox_LastName.Text;
            }
        }
        private void ComboBox_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controller.InstanceIndex >= 0)
            {
                if (ComboBox_Role.SelectedItem != null)
                {
                    string selectedRole = ComboBox_Role.SelectedItem.ToString();
                    if (selectedRole == "System.Windows.Controls.ComboBoxItem: Svend") { selectedRole = "Svend"; }
                    else if (selectedRole == "System.Windows.Controls.ComboBoxItem: Mester") { selectedRole = "Mester"; }
                    controller.CurrentInstance.Role = selectedRole;
                }
            }
            
        }
        private void TextBox_UNKNOWN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.InstanceIndex >= 0)
            {
                int a = 0;
                bool b = int.TryParse(TextBox_UNKNOWN.Text, out a);
                if (b == true)
                {
                    controller.CurrentInstance.Id = a;
                }
                else if (TextBox_UNKNOWN.Text != "")
                {
                    MessageBox.Show("ERROR: Numbers only");
                    TextBox_UNKNOWN.Text = s;
                    TextBox_UNKNOWN.CaretIndex = TextBox_UNKNOWN.Text.Length;
                }
                s = TextBox_UNKNOWN.Text;
            }
        }

        private void CheckBox_Status_Checked(object sender, RoutedEventArgs e)
        {
            if (controller.InstanceIndex >= 0)
            {
                controller.CurrentInstance.Status = true;
            }
        }
        private void CheckBox_Status_Unchecked(object sender, RoutedEventArgs e)
        {
            if (controller.InstanceIndex >= 0)
            {
                controller.CurrentInstance.Status = false;
            }
        }

        private void enabledTextboxes() 
        {
            TextBox_FirstName.IsEnabled = true;
            TextBox_LastName.IsEnabled = true;
            ComboBox_Role.IsEnabled = true;
            TextBox_UNKNOWN.IsEnabled = true;
            CheckBox_Status.IsEnabled = true;
        }

        private void disabledTextboxes()
        {
            TextBox_FirstName.IsEnabled = false;
            TextBox_LastName.IsEnabled = false;
            ComboBox_Role.IsEnabled = false;
            TextBox_UNKNOWN.IsEnabled = false;
            CheckBox_Status.IsEnabled = false;
        }

        private void updateTextbboxes()
        {
            TextBox_FirstName.Text = controller.CurrentInstance.FirstName;
            TextBox_LastName.Text = controller.CurrentInstance.LastName;
            ComboBox_Role.Text = controller.CurrentInstance.Role;
            TextBox_UNKNOWN.Text = controller.CurrentInstance.Id.ToString();
            if(controller.CurrentInstance.Status == true) { CheckBox_Status.IsChecked = true; }
            else { CheckBox_Status.IsChecked = false;}
        }

        private void clearTextboxes()
        {
            TextBox_FirstName.Text = string.Empty;
            TextBox_LastName.Text = string.Empty;
            ComboBox_Role.Text = string.Empty;
            TextBox_UNKNOWN.Text = string.Empty;
            CheckBox_Status.IsChecked = false;
        }
    }
}
