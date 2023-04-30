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
    /// Interaction logic for Fastener.xaml
    /// </summary>
    public partial class Fastener : Window
    {
        private Controller controller;
        public Fastener()
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

        private void Button_NewFastener_Click(object sender, RoutedEventArgs e)
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

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Spes_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_Amount_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void enabledTextboxes()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Type.IsEnabled = true;
            TextBox_Spes.IsEnabled = true;
            TextBox_Amount.IsEnabled = true;
        }

        private void disabledTextboxes()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Type.IsEnabled = false;
            TextBox_Spes.IsEnabled = false;
            TextBox_Amount.IsEnabled = false;
        }

        private void updateTextbboxes()
        {
            TextBox_Name.Text = controller.CurrentInstance.FirstName;
            TextBox_Type.Text = controller.CurrentInstance.LastName;
            TextBox_Spes.Text = controller.CurrentInstance.Role;
            TextBox_Amount.Text = controller.CurrentInstance.Id.ToString();
        }

        private void clearTextboxes()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Type.Text = string.Empty;
            TextBox_Spes.Text = string.Empty;
            TextBox_Amount.Text = string.Empty;
        }


    }
}

