using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
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
using MessageBox = Wpf.Ui.Controls.MessageBox;

namespace PR6_msg
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		List<string> messages = new List<string>();

		private Host _host;
		public Client _client;
		public static bool isAdmin;

		public static string IP_ADDRESS = "127.0.0.1";
		public static int PORT = 1234;
		public MainWindow()
		{
			InitializeComponent();
			_host = new Host();
			_client = new Client(IP_ADDRESS, PORT);
			if (isAdmin) LogsCol.Width = new GridLength(1, GridUnitType.Star);
		}

		private void HostStart_Click(object sender, RoutedEventArgs e)
		{
			_host.StartListening(PORT);
			_host.MessageReceived += OnMessageReceived;
			senddeb();

				
		}

		private void HostStop_Click(object sender, RoutedEventArgs e)
		{
			_host.StopListening();
			_host.MessageReceived -= OnMessageReceived;
			send($"{Client.Name}Server is stoppped");
			MessageList.Items.Add($"{Client.Name}Server is stopped \n{DateTime.Now.ToShortTimeString()}");
			messages.Add($"{Client.Name}Server is stopped");
		}

		private void ClientSend_Click(object sender, RoutedEventArgs e)
		{

			try
			{
				string message = $"{Client.Name}\n{ClientMessage.Text}\n{DateTime.Now.ToShortTimeString()}";
				_client.Send(message);
			}
			catch
			{
				System.Windows.MessageBox.Show("Сервер не подключен");
			}
			

		}

		public void senddeb()
		{
			Dispatcher.Invoke(() =>
			{
				send($"{Client.Name}Server is Connected");
				MessageList.Items.Add($"{Client.Name }Server is Connected \n{DateTime.Now.ToShortTimeString()}");
				messages.Add($"{Client.Name }Server is Connected");
			});
		}

		public void send(string msge)
		{
			LogsList.Items.Add($"{msge}\n{DateTime.Now.ToShortTimeString()}");
			messages.Add($"{msge}\n" + DateTime.Now.ToShortTimeString());
		}


		private void OnMessageReceived(string message)
		{
			Dispatcher.Invoke(() =>
			{
				MessageList.Items.Add($"{message}");
				messages.Add($"{message}");
			});
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			LoginWindow mainWindow = new LoginWindow();
			mainWindow.Show();
			Client.Name = null;
			MainWindow.isAdmin = false;
			this.Close();
		}

	}
}