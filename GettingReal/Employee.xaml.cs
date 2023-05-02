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
            controller.AddEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();

            if (controller.EmployeeIndex > 0)
            {
                Button_Prev.IsEnabled = true;
            }
            Button_Next.IsEnabled = false;
            Button_Edit.IsEnabled = false;
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
            controller.PrevEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();
            disabledTextboxes();
            updateTextbboxes();

            Button_Next.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.EmployeeIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();
            disabledTextboxes();
            updateTextbboxes();

            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.EmployeeIndex == controller.EmployeeCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();

            if (controller.EmployeeCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            else if (controller.EmployeeIndex >= 0)
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
            if (controller.EmployeeIndex >= 0)
            {
                controller.CurrentEmployee.FirstName = TextBox_FirstName.Text;
            }
        }

        private void TextBox_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                controller.CurrentEmployee.LastName = TextBox_LastName.Text;
            }
        }
        private void ComboBox_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                if (ComboBox_Role.SelectedItem != null)
                {
                    string selectedRole = ComboBox_Role.SelectedItem.ToString();
                    if (selectedRole == "System.Windows.Controls.ComboBoxItem: Svend") { selectedRole = "Svend"; }
                    else if (selectedRole == "System.Windows.Controls.ComboBoxItem: Mester") { selectedRole = "Mester"; }
                    controller.CurrentEmployee.Role = selectedRole;
                }
            }

        }
        private void TextBox_UNKNOWN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                int a = 0;
                bool b = int.TryParse(TextBox_UNKNOWN.Text, out a);
                if (b == true)
                {
                    controller.CurrentEmployee.Id = a;
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
            if (controller.EmployeeIndex >= 0)
            {
                controller.CurrentEmployee.Status = true;
            }
        }
        private void CheckBox_Status_Unchecked(object sender, RoutedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                controller.CurrentEmployee.Status = false;
            }
        }

        
        
        private void DataPicker_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0 && DatePicker_Date.SelectedDate != null)
            {
                controller.CurrentEmployee.Date = DatePicker_Date.SelectedDate.Value;
            }
        }

        private void enabledTextboxes()
        {
            TextBox_FirstName.IsEnabled = true;
            TextBox_LastName.IsEnabled = true;
            ComboBox_Role.IsEnabled = true;
            TextBox_UNKNOWN.IsEnabled = true;
            CheckBox_Status.IsEnabled = true;
            DatePicker_Date.IsEnabled = true;

        }

        private void disabledTextboxes()
        {
            TextBox_FirstName.IsEnabled = false;
            TextBox_LastName.IsEnabled = false;
            ComboBox_Role.IsEnabled = false;
            TextBox_UNKNOWN.IsEnabled = false;
            CheckBox_Status.IsEnabled = false;
            DatePicker_Date.IsEnabled= false;
        }

        private void updateTextbboxes()
        {
            TextBox_FirstName.Text = controller.CurrentEmployee.FirstName;
            TextBox_LastName.Text = controller.CurrentEmployee.LastName;
            ComboBox_Role.Text = controller.CurrentEmployee.Role;
            TextBox_UNKNOWN.Text = controller.CurrentEmployee.Id.ToString();
            if (controller.CurrentEmployee.Status == true) { CheckBox_Status.IsChecked = true; }
            else { CheckBox_Status.IsChecked = false; }
            DatePicker_Date.SelectedDate = controller.CurrentEmployee.Date;
        }

        private void clearTextboxes()
        {
            TextBox_FirstName.Text = string.Empty;
            TextBox_LastName.Text = string.Empty;
            ComboBox_Role.Text = string.Empty;
            TextBox_UNKNOWN.Text = string.Empty;
            CheckBox_Status.IsChecked = false;
            DatePicker_Date.SelectedDate = null;
        }

        private void isInvis()
        {
            Label_FirstName.Visibility = Visibility.Collapsed;
            Label_LastName.Visibility = Visibility.Collapsed;
            Label_Role.Visibility = Visibility.Collapsed;
            Label_UNKNOWN.Visibility = Visibility.Collapsed;
            Label_Checkbox.Visibility = Visibility.Collapsed;
            Label_DatePicker.Visibility = Visibility.Collapsed;
            TextBox_FirstName.Visibility = Visibility.Collapsed;
            TextBox_LastName.Visibility = Visibility.Collapsed;
            ComboBox_Role.Visibility = Visibility.Collapsed;
            TextBox_UNKNOWN.Visibility = Visibility.Collapsed;
            CheckBox_Status.Visibility = Visibility.Collapsed;
            DatePicker_Date.Visibility = Visibility.Collapsed;
        }
        private void isVis()
        {
            Label_FirstName.Visibility = Visibility.Visible;
            Label_LastName.Visibility = Visibility.Visible;
            Label_Role.Visibility = Visibility.Visible;
            Label_UNKNOWN.Visibility = Visibility.Visible;
            Label_Checkbox.Visibility = Visibility.Visible;
            Label_DatePicker.Visibility= Visibility.Visible;
            TextBox_FirstName.Visibility = Visibility.Visible;
            TextBox_LastName.Visibility = Visibility.Visible;
            ComboBox_Role.Visibility = Visibility.Visible;
            TextBox_UNKNOWN.Visibility = Visibility.Visible;
            CheckBox_Status.Visibility = Visibility.Visible;
            DatePicker_Date.Visibility= Visibility.Visible;
        }

        private void CheckBox_IsInvis_Checked(object sender, RoutedEventArgs e)
        {
            isInvis();
        }

        private void CheckBox_IsInvis_Unchecked(object sender, RoutedEventArgs e)
        {
            isVis();
        }


    }
}