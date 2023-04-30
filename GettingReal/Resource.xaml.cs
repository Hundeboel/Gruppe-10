﻿using System;
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
        public Resource()
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

        private void Button_NewResource_Click(object sender, RoutedEventArgs e)
        {
            controller.AddInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Prev_Click(object sender, RoutedEventArgs e)
        {
            controller.PrevInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
        }

        private void Button_Next_Click(object sender, RoutedEventArgs e)
        {
            controller.NextInstance();
            Label_Count.Content = controller.InstanceCount.ToString();
            Label_Index.Content = controller.InstanceIndex.ToString();
        }

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
    }
}
