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
            Label_Count.Content = controller.ResourceCount.ToString();
            Label_Index.Content = controller.ResourceIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Next.IsEnabled = true;

            Button_Edit.IsEnabled = true;

            if (controller.ResourceIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextResource();
            Label_Count.Content = controller.ResourceCount.ToString();
            Label_Index.Content = controller.ResourceIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.ResourceIndex == controller.ResourceCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveResource();
            Label_Count.Content = controller.ResourceCount.ToString();
            Label_Index.Content = controller.ResourceIndex.ToString();

            if (controller.ResourceCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            else if (controller.ResourceIndex >= 0)
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

        private void Button_ShowResources_Click(object sender, RoutedEventArgs e)
        {
            var newWindow = new AllResources();
            newWindow.Show();
            this.Close();
        }
        #endregion

        #region Input fields

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.ResourceIndex >= 0)
            {
                controller.CurrentResource.Name = TextBox_Name.Text;
            }
        }

        private void TextBox_Type_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.ResourceIndex >= 0)
            {
                controller.CurrentResource.Type = TextBox_Type.Text;
            }
        }

        private void TextBox_Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.ResourceIndex >= 0)
            {
                int a = 0;
                bool b = int.TryParse(TextBox_Amount.Text, out a);
                if (b == true)
                {
                    controller.CurrentResource.Amount = a;
                }
                else if (TextBox_Amount.Text != "")
                {
                    MessageBox.Show("ERROR: Numbers only");
                    TextBox_Amount.Text = s;
                    TextBox_Amount.CaretIndex = TextBox_Amount.Text.Length;
                }
                s = TextBox_Amount.Text;
            }
        }

        private void CheckBox_Rented_Checked(object sender, RoutedEventArgs e)
        {
            if (controller.ResourceIndex >= 0)
            {
                controller.CurrentResource.Rented = true;
            }
        }
        private void CheckBox_Rented_Unchecked(object sender, RoutedEventArgs e)
        {
            if (controller.ResourceIndex >= 0)
            {
                controller.CurrentResource.Rented = false;
            }
        }
        #endregion

        #region Methods

        private void enabledInputField()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Type.IsEnabled = true;
            TextBox_Rented.IsEnabled = true;
            TextBox_Amount.IsEnabled = true;
            CheckBox_Rented.IsEnabled = true;
        }

        private void disabledInputField()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Type.IsEnabled = false;
            TextBox_Rented.IsEnabled = false;
            TextBox_Amount.IsEnabled = false;
            CheckBox_Rented.IsEnabled = false;
        }

        private void updateInputField()
        {
            TextBox_Name.Text = controller.CurrentResource.Name;
            TextBox_Type.Text = controller.CurrentResource.Type;
            TextBox_Rented.Text = controller.CurrentResource.Rented.ToString();
            TextBox_Amount.Text = controller.CurrentResource.Amount.ToString();
            CheckBox_Rented.IsChecked = controller.CurrentResource.Rented;
            //if (controller.CurrentResource.Rented == true) { CheckBox_Rented.IsChecked = true; }
            //else { CheckBox_Rented.IsChecked = false; }
        }

        private void clearInputField()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Type.Text = string.Empty;
            TextBox_Rented.Text = string.Empty;
            TextBox_Amount.Text = string.Empty;
            CheckBox_Rented.IsChecked = false;
        }
        #endregion

        #region Visibility

        private void isInvis()
        {
            Label_Name.Visibility = Visibility.Collapsed;
            Label_Type.Visibility = Visibility.Collapsed;
            Label_Rented.Visibility = Visibility.Collapsed;
            Label_Amount.Visibility = Visibility.Collapsed;
            TextBox_Name.Visibility = Visibility.Collapsed;
            TextBox_Type.Visibility = Visibility.Collapsed;
            TextBox_Rented.Visibility = Visibility.Collapsed;
            TextBox_Amount.Visibility = Visibility.Collapsed;
            CheckBox_Rented.Visibility = Visibility.Collapsed;
        }

        private void isVis()
        {
            Label_Name.Visibility = Visibility.Visible;
            Label_Type.Visibility = Visibility.Visible;
            Label_Rented.Visibility = Visibility.Visible;
            Label_Amount.Visibility = Visibility.Visible;
            TextBox_Name.Visibility = Visibility.Visible;
            TextBox_Type.Visibility = Visibility.Visible;
            TextBox_Rented.Visibility = Visibility.Visible;
            TextBox_Amount.Visibility = Visibility.Visible;
            CheckBox_Rented.Visibility = Visibility.Visible;
        }

        private void CheckBox_IsInvis_Checked(object sender, RoutedEventArgs e)
        {
            isInvis();
        }

        private void CheckBox_IsInvis_Unchecked(object sender, RoutedEventArgs e)
        {
            isVis();
        }
        #endregion
    }
}

