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

        #endregion

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Status_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_StartDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_EndDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void enabledInputField()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Status.IsEnabled = true;
            TextBox_StartDate.IsEnabled = true;
            TextBox_EndDate.IsEnabled = true;
        }

        private void disabledInputField()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Status.IsEnabled = false;
            TextBox_StartDate.IsEnabled = false;
            TextBox_EndDate.IsEnabled = false;
        }

        private void updateInputField()
        {
            TextBox_Name.Text = controller.CurrentInstance.FirstName;
            TextBox_Status.Text = controller.CurrentInstance.LastName;
            TextBox_StartDate.Text = controller.CurrentInstance.Role;
            TextBox_EndDate.Text = controller.CurrentInstance.Id.ToString();
        }

        private void clearInputField()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Status.Text = string.Empty;
            TextBox_StartDate.Text = string.Empty;
            TextBox_EndDate.Text = string.Empty;
        }

    }
}

