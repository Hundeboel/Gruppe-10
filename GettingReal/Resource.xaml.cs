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
    /// Interaction logic for Resource.xaml
    /// </summary>
    public partial class Resource : Window
    {
        private Controller controller;
        string s = "";
        public Resource()
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

        private void Button_NewResource_Click(object sender, RoutedEventArgs e)
        {
            controller.AddResource();

            Label_Count.Content = controller.ResourceCount.ToString();
            Label_Index.Content = controller.ResourceIndex.ToString();

            if (controller.ResourceIndex > 0)
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
            controller.PrevResource();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Next.IsEnabled = true;

            Button_Edit.IsEnabled = true;

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
            disabledInputField();
            updateTextbboxes();

            Button_Prev.IsEnabled = true;

            if (controller.InstanceIndex == controller.InstanceCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void Button_ShowResources_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AllResources();
            newWindow.Show();
            this.Close();
        }
        #endregion

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Status_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Amount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void enabledInputField()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Type.IsEnabled = true;
            TextBox_Status.IsEnabled = true;
            TextBox_Amount.IsEnabled = true;
        }

        private void disabledInputField()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Type.IsEnabled = false;
            TextBox_Status.IsEnabled = false;
            TextBox_Amount.IsEnabled = false;
        }

        private void clearInputField()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Type.Text = string.Empty;
            TextBox_Status.Text = string.Empty;
            TextBox_Amount.Text = string.Empty;
        }

        private void updateInputField()
        {
            TextBox_Name.Text = controller.CurrentResource.Name;
            TextBox_Type.Text = controller.CurrentResource.Type;
            TextBox_Status.Text = controller.CurrentResource.Status;
            TextBox_Amount.Text = controller.CurrentResource.Amount.ToString();
        }
    }
}

