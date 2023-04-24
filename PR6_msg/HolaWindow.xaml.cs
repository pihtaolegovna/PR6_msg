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
using Wpf.Ui.Appearance;

namespace PR6_msg
{
    /// <summary>
    /// Interaction logic for HolaWindow.xaml
    /// </summary>
    public partial class HolaWindow : Window
    {
        public HolaWindow()
        {
            InitializeComponent();
            Theme.Apply(
            ThemeType.Dark,         // Theme type
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }
        private void callmsgr()
        {
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            this.Close();
        }
    }
}
