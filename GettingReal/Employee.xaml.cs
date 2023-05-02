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
        //Used for textboxes which only accepts numbers
        string s = "";
        public Employee()
        {
            InitializeComponent();

            //create a controller to call on
            controller = new Controller();
        }

        //The buttons
        #region Buttons

        //Button to the main page
        //Copy paste it 
        private void Button_MainPage_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow -> NameOfNewWindowXamlClass
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        //Button to add a new instance of current class
        private void Button_NewEmployee_Click(object sender, RoutedEventArgs e)
        {
            //Create new instance by calling the Add_____ method from controller
            //____ changes based on class - if added to controller, else use placeholder 'Instance' (Placeholder has been added to controller)
            controller.AddEmployee();

            //Update the labels at the top which displays current instance 
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();

            //If; to only enable Button_Prev if more than 1 instance current exists
            if (controller.EmployeeIndex > 0)
            {
                Button_Prev.IsEnabled = true;
            }
            //Disable next button (There will never be a next instance - making a new instance will always be the newest)
            Button_Next.IsEnabled = false;
            //Disable the edit button (Making a new instance will enabled the input fields - edit button is redundant here)
            Button_Edit.IsEnabled = false;
            //Enable delete button (If you make a new instance, there will be something you can delete)
            Button_Del.IsEnabled = true;


            //Calls the methods enabledTextboxes() and clearTextboxes()
            enabledInputField();
            clearInputField();
        }

        //Enable 'edit mode' (Saving the information is handled by the input fields when they detect change - NOT here)
        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            //Calls enabledTextboxes() method;
            enabledInputField();
        }

        //Button to view the previous instance (Previous = older)
        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            //Calls Prev____ method from controller (____ <- see comment on line 43)
            controller.PrevEmployee();

            //Update the labels at the top which displays current instance 
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();

            //Calls methods disabledTextboxes() and updateTextboxes()
            disabledInputField();
            updateInputField();

            //Enables next button (If you press prev, then there is a next)
            Button_Next.IsEnabled = true;
            //Enables edit button (Prev and Next auto disables editing the input fields) 
            Button_Edit.IsEnabled = true;

            //If; to disable prev button if on oldest instance
            if (controller.EmployeeIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        //Button to view the next instance (Next = newer)
        //Near identical to Prev version (Only commented on diffences)
        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            //Next____ instead of Prev____
            controller.NextEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();
            disabledInputField();
            updateInputField();

            //Enabled prev instead of next (See line 89)
            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            //If; checks if on the newest instance
            if (controller.EmployeeIndex == controller.EmployeeCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        //Delete the current instance (Button may not exist - added later)
        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            //Call method Remove____ from controller
            controller.RemoveEmployee();
            Label_Count.Content = controller.EmployeeCount.ToString();
            Label_Index.Content = controller.EmployeeIndex.ToString();

            //If; only 1 instance exist - disable prev and next buttons
            if (controller.EmployeeCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            //If; 1 or more instance exist update the input fields to reflect current instance
            else if (controller.EmployeeIndex >= 0)
            {
                updateInputField();
            }
            //If; no instances exist - disable all but new instance button and clear input fields 
            else
            {
                clearInputField();
                Button_Del.IsEnabled = false;
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
                Button_Edit.IsEnabled = false;
            }

            //Disable editing
            disabledInputField();

        }
        #endregion

        //The input fields
        #region Input fields

        //Standard TextBox changed event
        private void TextBox_FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            //If; Checks at least 1 instance exist (All input changed event needs one or delete can break program)
            if (controller.EmployeeIndex >= 0)
            {
                //Call where to store variable and set it = to the input from input field
                //Firstname = string
                controller.CurrentEmployee.FirstName = TextBox_FirstName.Text;

                //controller.Current____.#### = InputField_NAME.----
                //____ referes to class
                //#### referes to the name of the current variable (found in class - Add in class if needed)
                //InputField_NAME referes to name of the inputfield giving in xaml file (in most cases: InputField_NAME (InputField_ <- type of input (TextBox_) and NAME <- name of variable)
                //---- referes to the content of the input field (Different based on type of input field)

                //InputField content overview:
                //TextBox = Text
                //Combobox = SelectedItem
                //CheckBox does not have one
                //DatePicker = SelectedDate.Value
            }
        }

        //See the one above
        private void TextBox_LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                controller.CurrentEmployee.LastName = TextBox_LastName.Text;
            }
        }

        //ComboBox changed event
        private void ComboBox_Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                //If; user selected an item (not null)
                if (ComboBox_Role.SelectedItem != null)
                {
                    //Save selected item to string (Remember .ToString() at the end)
                    //Role = string

                    //Change string name to reflext current event
                    string selectedRole = ComboBox_Role.SelectedItem.ToString();
                    //Copypaste if and else if and change 'Svend'/'Mester' and change to content of the ComboBox
                    //For futher explaination ask Laura
                    if (selectedRole == "System.Windows.Controls.ComboBoxItem: Svend") { selectedRole = "Svend"; }
                    else if (selectedRole == "System.Windows.Controls.ComboBoxItem: Mester") { selectedRole = "Mester"; }

                    //set instance to value of the string
                    controller.CurrentEmployee.Role = selectedRole;
                }
            }

        }

        //TextBox which input is only numbers
        private void TextBox_UNKNOWN_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                //Copypaste it and change TextBox_UNKNOWN to name of current TextBox + Current____.---- to current class and variable name
                //Id = int
                //For futher explaination ask Laura
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

        //CheckBox Checked event 
        private void CheckBox_Status_Checked(object sender, RoutedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                //Set bool from class to true
                //Status = bool
                controller.CurrentEmployee.Status = true;
            }
        }
        //CheckBox Unchecked event (Not automaticly added by double clicking in XAML - Unchecked="TAB (new event handler based on name)")
        private void CheckBox_Status_Unchecked(object sender, RoutedEventArgs e)
        {
            if (controller.EmployeeIndex >= 0)
            {
                //Same as above just flipped 
                //Set to false
                controller.CurrentEmployee.Status = false;
            }
        }
        
        //DatePicker changed event
        private void DatePicker_Date_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //Added to standard if sentence; && DATEPICKERNAME.SelectedDate != null 
            //Without an error will appear when making a new instance
            if (controller.EmployeeIndex >= 0 && DatePicker_Date.SelectedDate != null)
            {
                //Set variable to InputField_NAME.SelectedDate.Value;
                //Date = DateTime
                controller.CurrentEmployee.Date = DatePicker_Date.SelectedDate.Value;
            }
        }
        #endregion

        //Private methods (To avoid having to write everything multiple times)
        #region Methods

        //Enables input fields when called (Changed name from enabledTextBoxes)
        //Remember to add new input fields if added to XAML 
        private void enabledInputField()
        {
            //InputField_NAME.IsEnabled = true;
            TextBox_FirstName.IsEnabled = true;
            TextBox_LastName.IsEnabled = true;
            ComboBox_Role.IsEnabled = true;
            TextBox_UNKNOWN.IsEnabled = true;
            CheckBox_Status.IsEnabled = true;
            DatePicker_Date.IsEnabled = true;

        }

        //Disables input fields when called (Changed name from disabledTextBoxes)
        //Remember to add new input fields if added to XAML 
        private void disabledInputField()
        {
            //InputField_NAME.IsEnabled = false;
            TextBox_FirstName.IsEnabled = false;
            TextBox_LastName.IsEnabled = false;
            ComboBox_Role.IsEnabled = false;
            TextBox_UNKNOWN.IsEnabled = false;
            CheckBox_Status.IsEnabled = false;
            DatePicker_Date.IsEnabled= false;
        }

        //Updates input fields to reflect current instance when called (Changed name from updateTextBoxes)
        //Remember to add new input fields if added to XAML 
        private void updateInputField()
        {
            //If string; set input field = variable from class
            //InputField_NAME.Text = controller.Current____.----;
            TextBox_FirstName.Text = controller.CurrentEmployee.FirstName;
            TextBox_LastName.Text = controller.CurrentEmployee.LastName;
            ComboBox_Role.Text = controller.CurrentEmployee.Role;
            //If string which draws from int; remember to add .ToString() at the end
            TextBox_UNKNOWN.Text = controller.CurrentEmployee.Id.ToString();

            //If CheckBox; if controller.Current____.---- (bool) = true -> InputField_NAME.IsChecked = true;
            if (controller.CurrentEmployee.Status == true) { CheckBox_Status.IsChecked = true; }
            //Else; InputField_NAME.IsChecked = false;
            else { CheckBox_Status.IsChecked = false; }

            //If DatePicker; InputField_NAME.SelectedDate = controller.Current____.----; (---- is a DateTime)
            DatePicker_Date.SelectedDate = controller.CurrentEmployee.Date;
        }

        //Clears input fields when called (Changed name from clearTextBoxes)
        //Remember to add new input fields if added to XAML 
        private void clearInputField()
        {
            //If string input; InputField_NAME.Text = string.Empty;
            TextBox_FirstName.Text = string.Empty;
            TextBox_LastName.Text = string.Empty;
            ComboBox_Role.Text = string.Empty;
            TextBox_UNKNOWN.Text = string.Empty;

            //If CheckBox; InputField_NAME.IsChecked = false; 
            CheckBox_Status.IsChecked = false;
            
            //If DatePicker; InputField_NAME.SelectedDate = null;
            DatePicker_Date.SelectedDate = null;
        }
        #endregion

        //Visibility toogle (FX only logged in on 'mester' role may see something)
        #region Visibility
        
        //Method to set all input fields and their labels to invisible
        //Can use Hidden instead of Collapsed
        private void isInvis()
        {
            //Label|InputField_NAME.Visibility = Visibility.Collapsed;
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

        //Method to set all input fields and their labels to visible
        private void isVis()
        {
            //Label|InputField_NAME.Visibility = Visibility.Visible;
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

        //CheckBox event handlers to toogle visibility
        private void CheckBox_IsInvis_Checked(object sender, RoutedEventArgs e)
        {
            isInvis();
        }
        //CheckBox event handlers to toogle visibility
        private void CheckBox_IsInvis_Unchecked(object sender, RoutedEventArgs e)
        {
            isVis();
        }
        #endregion

    }
}