using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    // Functionality for the calculator goes here
    public sealed partial class MainPage : Page
    {

        double total = 0;
        double ans = 0;
        String key = "";
        bool dec = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Number_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            answer.Text += (String)b.Content;
        }

        private void operation_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            key = (String)b.Content;
            total = double.Parse(answer.Text);
            answer.Text = "";
            dec = false;
        }

        private void dec_Click(object sender, RoutedEventArgs e)
        {
            if (!dec)
            {
                answer.Text += ".";
                dec = true;
            }
        }
    }
}
