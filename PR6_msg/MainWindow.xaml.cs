using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

namespace PR6_msg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> messages = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            HolaWindow newWindow = new HolaWindow();
            newWindow.Show();
            Theme.Apply(
            ThemeType.Light,         // Theme type
            BackgroundType.Mica, // Background type
            true                                      // Whether to change accents automatically
            );

            Theme.Apply(
            ThemeType.Dark,         // Theme type
            BackgroundType.Mica, // Background type
            true                                      // Whether to change accents automatically
            );


            Loaded += (sender, args) =>
            {
                Wpf.Ui.Appearance.Watcher.Watch(
                    this,                                  // Window class
                    Wpf.Ui.Appearance.BackgroundType.Mica, // Background type
                    true,                                   // Whether to change accents automatically
                    true
                );
            };
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            sendmessage();
        }

        public void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                sendmessage();
            }
        }
        private void sendmessage()
        {
            if (!string.IsNullOrEmpty(MessageInput.Text))
            {
                messages.Add(MessageInput.Text);
                MessageInput.Text = string.Empty;
            }
            MessageList.ItemsSource = messages;
        }

    }
}
