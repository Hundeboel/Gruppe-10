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
        string s = "";
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
            controller.AddFastener();
            Label_Count.Content = controller.FastenerCount.ToString();
            Label_Index.Content = controller.FastenerIndex.ToString();

            if (controller.FastenerIndex > 0)
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
            controller.PrevFastener();
            Label_Count.Content = controller.FastenerCount.ToString();
            Label_Index.Content = controller.FastenerIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Next.IsEnabled = true;

            Button_Edit.IsEnabled = true;

            if (controller.FastenerIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            
            controller.NextFastener();
            Label_Count.Content = controller.FastenerCount.ToString();
            Label_Index.Content = controller.FastenerIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.FastenerIndex == controller.FastenerCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }
        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            //Call method Remove____ from controller
            controller.RemoveFastener();
            Label_Count.Content = controller.FastenerCount.ToString();
            Label_Index.Content = controller.FastenerIndex.ToString();

            //If; only 1 instance exist - disable prev and next buttons
            if (controller.FastenerCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            //If; 1 or more instance exist update the input fields to reflect current instance
            else if (controller.FastenerIndex >= 0)
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

        private void TextBox_Name_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.FastenerIndex >= 0)
            {
                controller.CurrentFastener.Name = TextBox_Name.Text;
            }
        }

        private void TextBox_Type_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.FastenerIndex >= 0)
            {
                controller.CurrentFastener.Type = TextBox_Type.Text;
            }
        }

        private void TextBox_Specs_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.FastenerIndex >= 0)
            {
                controller.CurrentFastener.Description = TextBox_Specs.Text;
            }
        }

        private void TextBox_Amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.FastenerIndex >= 0)
            {
                //Copypaste it and change TextBox_UNKNOWN to name of current TextBox + Current____.---- to current class and variable name
                //Id = int
                //For futher explaination ask Laura
                int a = 0;
                bool b = int.TryParse(TextBox_Amount.Text, out a);
                if (b == true)
                {
                    controller.CurrentFastener.Amount = a;
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
        private void enabledInputField()
        {
            TextBox_Name.IsEnabled = true;
            TextBox_Type.IsEnabled = true;
            TextBox_Specs.IsEnabled = true;
            TextBox_Amount.IsEnabled = true;
            Button_Del.IsEnabled= true;
            Button_Edit.IsEnabled = true;
        }

        private void disabledInputField()
        {
            TextBox_Name.IsEnabled = false;
            TextBox_Type.IsEnabled = false;
            TextBox_Specs.IsEnabled = false;
            TextBox_Amount.IsEnabled = false;
        }

        private void updateInputField()
        {
            TextBox_Name.Text = controller.CurrentFastener.Name;
            TextBox_Type.Text = controller.CurrentFastener.Type;
            TextBox_Specs.Text = controller.CurrentFastener.Description;
            TextBox_Amount.Text = controller.CurrentFastener.Amount.ToString();
        }

        private void clearInputField()
        {
            TextBox_Name.Text = string.Empty;
            TextBox_Type.Text = string.Empty;
            TextBox_Specs.Text = string.Empty;
            TextBox_Amount.Text = string.Empty;
        }


    }
}

