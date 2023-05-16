using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PR6_msg
{
	/// <summary>
	/// Interaction logic for LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public static bool isServer;
		public static string myname;
		public LoginWindow()
		{
			InitializeComponent();
		}

		private void Server_Click(object sender, RoutedEventArgs e)
		{
			if (Client.Name != null)
			{
				ClientName.Text = Client.Name;
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				MainWindow.IP_ADDRESS = IPbox.Text.ToString();
				try
				{
					MainWindow.PORT = Convert.ToInt32(Portbox.Text);
				}
				catch { }
				if (MainWindow.isAdmin) mainWindow.LogsCol.Width = new GridLength(1, GridUnitType.Star);
				this.Close();
			}
			else System.Windows.MessageBox.Show("Почему имя пусто");
			
		}

		private void Client_Click(object sender, RoutedEventArgs e)
		{
			if (Client.Name != null)
			{
				ClientName.Text = Client.Name;
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				if (MainWindow.isAdmin)
				{
					mainWindow.LogsCol.Width = new GridLength(1, GridUnitType.Star);
					this.Close();
				}
				else
					mainWindow.ServBtn.Visibility = Visibility.Hidden;
			}
			else System.Windows.MessageBox.Show("Почему имя пусто");
			
		}

		private void Admin_Click(object sender, RoutedEventArgs e)
		{
			if (Client.Name != null)
			{
				MainWindow mainWindow = new MainWindow();
				mainWindow.Show();
				ClientName.Text = Client.Name;
				MainWindow.isAdmin = true;
				this.Close();
				if (MainWindow.isAdmin) mainWindow.LogsCol.Width = new GridLength(1, GridUnitType.Star); mainWindow.Width = 600; mainWindow.MinWidth = 500; ;
			}
			else System.Windows.MessageBox.Show("Почему имя пусто");
		}
	}
}
