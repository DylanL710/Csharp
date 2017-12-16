using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
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
        // Declare and Initialize variables
        double total = 0;
        double ans = 0;
        String key = "";
        bool dec = false;

        public MainPage()
        {
            this.InitializeComponent();
        }

        //Method for when user clicks on a number button.
        private void Number_click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            answer.Text += (String)b.Content;
        }

        //Method for when a user clicks on an operation button like the + - * or /
        private void operation_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            key = (String)b.Content;
            total = double.Parse(answer.Text);
            answer.Text = "";
            dec = false;
        }

        //Method to make sure that there is no more than one decimal placed.
        private void dec_Click(object sender, RoutedEventArgs e)
        {
            if (!dec)
            {
                answer.Text += ".";
                dec = true;
            }
        }

        //Method to clear all text from the text box.
        private void clear_Click(object sender, RoutedEventArgs e)
        {
            total = 0;
            ans = 0;
            key = "";
            dec = false;
            answer.Text = "";
        }

        //Method to take make sure there is text in the textbox, it also looks at which operation button was clicked and applies
        //that operation to the two numbers inputed.
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (answer.Text.Length > 0)
            {
                double num = double.Parse(answer.Text);
                if (key == "+")
                {
                    ans = total + num;
                }
                if (key == "-")
                {
                    ans = total - num;
                }
                if (key == "*")
                {
                    ans = total * num;
                }
                if (key == "/")
                {
                    ans = total / num;
                }

                answer.Text = ans.ToString();
                dec = false;
            }
        }

        //Method to save whatever number is in the textbox to local storage container.
        public void save(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("savedContent", Windows.Storage.ApplicationDataCreateDisposition.Always);

            localSettings.Containers["savedContent"].Values["exampleSetting"] = answer.Text;


        }

        //Method that takes whatever number was saved to the local storage container and place it into the textbox.
        public void load(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            Windows.Storage.ApplicationDataContainer container = localSettings.CreateContainer("savedContent", Windows.Storage.ApplicationDataCreateDisposition.Always);

            bool hasContainer = localSettings.Containers.ContainsKey("savedContent");
            bool hasSetting = false;

            if (hasContainer)
            {
                hasSetting = localSettings.Containers["savedContent"].Values.ContainsKey("exampleSetting");
                answer.Text += localSettings.Containers["savedContent"].Values["exampleSetting"];
            }
        }
    }
}
