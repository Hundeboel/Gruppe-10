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
    /// Interaction logic for Rental.xaml
    /// </summary>
    public partial class Rental : Window
    {
        private Controller controller;

        string s = "";
        public Rental()
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

        private void Button_NewRental_Click(object sender, RoutedEventArgs e)
        {
            controller.AddRental();
            Label_Count.Content = controller.RentalCount.ToString();
            Label_Index.Content = controller.RentalIndex.ToString();

            if (controller.RentalIndex > 0)
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
            controller.PrevRental();
            Label_Count.Content = controller.RentalCount.ToString();
            Label_Index.Content = controller.RentalIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Next.IsEnabled = true;

            Button_Edit.IsEnabled = true;

            if (controller.RentalIndex == 0)
            {
                Button_Prev.IsEnabled = false;
            }
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextRental();
            Label_Count.Content = controller.RentalCount.ToString();
            Label_Index.Content = controller.RentalIndex.ToString();
            disabledInputField();
            updateInputField();

            Button_Prev.IsEnabled = true;
            Button_Edit.IsEnabled = true;

            if (controller.RentalIndex == controller.RentalCount - 1)
            {
                Button_Next.IsEnabled = false;
            }
        }

        private void Button_Del_Click(object sender, RoutedEventArgs e)
        {
            controller.RemoveRental();
            Label_Count.Content = controller.RentalCount.ToString();
            Label_Index.Content = controller.RentalIndex.ToString();

            if (controller.RentalCount == 1)
            {
                Button_Prev.IsEnabled = false;
                Button_Next.IsEnabled = false;
            }
            else if (controller.RentalIndex >= 0)
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

        #region Input fields

        //tekstboksene er indtastningsstrings lige nu

        private void TextBox_Resource_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.RentalIndex >= 0)
            {
                controller.CurrentRental.Resource = TextBox_Resource.Text;
            }
        }

        private void TextBox_Project_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.RentalIndex >= 0)
            {
                controller.CurrentRental.Project = TextBox_Project.Text;
            }
        }

        private void TextBox_Periode_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_Rentee_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (controller.RentalIndex >= 0)
            {
                controller.CurrentRental.Rentee = TextBox_Rentee.Text;
            }
        }

        #endregion

        #region Methods
        private void enabledInputField()
        {
            TextBox_Resource.IsEnabled = true;
            TextBox_Project.IsEnabled = true;
            TextBox_Periode.IsEnabled = true;
            TextBox_Rentee.IsEnabled = true;
        }

        private void disabledInputField()
        {
            TextBox_Resource.IsEnabled = false;
            TextBox_Project.IsEnabled = false;
            TextBox_Periode.IsEnabled = false;
            TextBox_Rentee.IsEnabled = false;
        }

        private void updateInputField()
        {
            TextBox_Resource.Text = controller.CurrentRental.Resource;
            TextBox_Project.Text = controller.CurrentRental.Project;
            TextBox_Periode.Text = controller.CurrentRental.Timeframe.ToString();
            TextBox_Rentee.Text = controller.CurrentRental.Rentee;
        }

        private void clearInputField()
        {
            TextBox_Resource.Text = string.Empty;
            TextBox_Project.Text = string.Empty;
            TextBox_Periode.Text = string.Empty;
            TextBox_Rentee.Text = string.Empty;
        }
        #endregion
    }
}

