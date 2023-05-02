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
        public Project()
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

        private void Button_NewProject_Click(object sender, RoutedEventArgs e)
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

        private void enabledTextboxes()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Status.IsEnabled = true;
            TextBox_StartDate.IsEnabled = true;
            TextBox_EndDate.IsEnabled = true;
        }

        private void disabledTextboxes()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Status.IsEnabled = false;
            TextBox_StartDate.IsEnabled = false;
            TextBox_EndDate.IsEnabled = false;
        }

        private void updateTextbboxes()
        {
            TextBox_Name.Text = controller.CurrentInstance.FirstName;
            TextBox_Status.Text = controller.CurrentInstance.LastName;
            TextBox_StartDate.Text = controller.CurrentInstance.Role;
            TextBox_EndDate.Text = controller.CurrentInstance.Id.ToString();
        }

        private void clearTextboxes()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Status.Text = string.Empty;
            TextBox_StartDate.Text = string.Empty;
            TextBox_EndDate.Text = string.Empty;
        }

        private void Button_DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            controller.DeleteProject();
            
            Label_Count.Content = "Count Project " + controller.ProjectCount.ToString();
            Label_Index.Content = "Index " + controller.ProjectIndex.ToString;

            if (controller.ProjectIndex < 0) 
            { 
                Button_DeleteProject.IsEnabled = false;
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;

                TextBox_Name.IsEnabled = false;
                TextBox_Status.IsEnabled = false;
                TextBox_StartDate.IsEnabled = false;
                TextBox_EndDate.IsEnabled = false;

                TextBox_Name.Text = string.Empty;
                TextBox_Status.Text = string.Empty;
                TextBox_StartDate.Text = string.Empty;
                TextBox_EndDate.Text = string.Empty;
            }
            else
            {
                TextBox_Name.Text = controller.CurrentProject.Name;
                TextBox_Status.Text = controller.CurrentProject.Status;
                TextBox_StartDate.Text = controller.CurrentProject.StartDate;
                TextBox_EndDate.Text = controller.CurrentProject.EndDate;
            }
        }
    }
}

