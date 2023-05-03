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
    /// Interaction logic for Project.xaml
    /// </summary>
    public partial class Project : Window
    {
        private Controller controller;
        string s = "";
        public Project()
        {
            InitializeComponent();
            controller = new Controller();
        }

        #region Buttons

        private void Button_MainPage_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }

        private void Button_NewProject_Click(object sender, RoutedEventArgs e)
        {
            controller.AddProject();
            Label_Count.Content = controller.ProjectCount.ToString();
            Label_Index.Content = controller.ProjectIndex.ToString();

            if (controller.ProjectIndex > 0)
            {
                Button_Prev.IsEnabled = true;
            }
            Button_Next.IsEnabled = false;

            Button_Edit.IsEnabled = false;

            Button_Del.IsEnabled = true;

            enabledInputField();
            clearInputField();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {
            enabledInputField();
        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevProject();
            Label_Count.Content = controller.ProjectCount.ToString();
            Label_Index.Content = controller.ProjectIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Next.IsEnabled = true;

            Button_Edit.IsEnabled = true;

            if (controller.ProjectIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextProject();
            Label_Count.Content = controller.ProjectCount.ToString();
            Label_Index.Content = controller.ProjectIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.ProjectIndex == controller.ProjectCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveProject();
            Label_Count.Content = controller.ProjectCount.ToString();
            Label_Index.Content = controller.ProjectIndex.ToString();

            if (controller.ProjectCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            else if (controller.ProjectIndex >= 0)
            {
                updateInputField();
            }
            else
            {
                clearInputField();
                Button_Del.IsEnabled = false;
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
                Button_Edit.IsEnabled = false;
            }
            disabledInputField();
        }
        private void Button_Show_Projects(object sender, RoutedEventArgs e)
        {
            var newWindow = new ActiveProjects();
            newWindow.Show();
            this.Close();
        }

        #endregion

        #region Input Fields

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.ProjectIndex >= 0)
            {
                controller.CurrentProject.Name = TextBox_Name.Text;
            }
        }

        private void CheckBox_Finished_Checked(object sender, RoutedEventArgs e)
        {
            if (controller.ProjectIndex >= 0)
            {
                controller.CurrentProject.Finished = true;
            }
        }
        private void CheckBox_Finished_Unchecked(object sender, RoutedEventArgs e)
        {
            if (controller.ProjectIndex >= 0)
            {
                controller.CurrentProject.Finished = false;
            }
        }

        private void DatePicker_StartDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (controller.ProjectIndex >= 0 && DatePicker_StartDate.SelectedDate != null)
            {
               
                controller.CurrentProject.StartDate = DatePicker_StartDate.SelectedDate.Value;
            }
        }

        private void DatePicker_EndDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            if (controller.ProjectIndex >= 0 && DatePicker_EndDate.SelectedDate != null)
            {

                controller.CurrentProject.EndDate = DatePicker_EndDate.SelectedDate.Value;
            }
        }

        #endregion

        #region Methods
        private void enabledInputField()
        {
            TextBox_Name.IsEnabled = true;
            DatePicker_StartDate.IsEnabled = true;
            DatePicker_EndDate.IsEnabled = true;
            CheckBox_Finished.IsEnabled = true;
            
        }

        private void disabledInputField()
        {
            TextBox_Name.IsEnabled = false;
            DatePicker_StartDate.IsEnabled = false;
            DatePicker_EndDate.IsEnabled = false;
            CheckBox_Finished.IsEnabled = false;

        }

        private void updateInputField()
        {
            TextBox_Name.Text = controller.CurrentProject.Name;
            TextBox_Finished.Text = controller.CurrentProject.Finished.ToString();
            DatePicker_StartDate.SelectedDate = controller.CurrentProject.StartDate;
            DatePicker_EndDate.SelectedDate = controller.CurrentProject.EndDate;
            CheckBox_Finished.IsChecked = controller.CurrentProject.Finished;
        }

        private void clearInputField()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Finished.Text = string.Empty;
            DatePicker_StartDate.SelectedDate = null;
            DatePicker_EndDate.SelectedDate = null;
            CheckBox_Finished.IsChecked = false;

        }
        
        #endregion

    }
}

