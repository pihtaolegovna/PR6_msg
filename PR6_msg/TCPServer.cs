using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace PR6_msg
{
	public class Host
	{
		private TcpListener _server = null;
		private Thread _listenerThread = null;
		private bool _listening = false;

		public delegate void MessageReceivedEventHandler(string message);
		public event MessageReceivedEventHandler MessageReceived;

		public void StartListening(int port)
		{
			_server = new TcpListener(IPAddress.Any, port);
			_listenerThread = new Thread(new ThreadStart(ListenForClients));
			_listenerThread.IsBackground = true;
			_listening = true;
			_listenerThread.Start();
		}

		public void StopListening()
		{
			_listening = false;
			if (_server != null)
			{
				_server.Stop();
				_server = null;
			}
			if (_listenerThread != null)
			{
				_listenerThread.Join();
				_listenerThread = null;
			}
		}

		private void ListenForClients()
		{
			_server.Start();

			while (_listening)
			{
				

				try
				{
					// Wait for client connection
					TcpClient client = _server.AcceptTcpClient();

					// Handle client request in separate thread
					Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientRequest));
					clientThread.IsBackground = true;
					clientThread.Start(client);
				}
				catch
				{

				}
			}
		}
		private void HandleClientRequest(object obj)
		{
			TcpClient client = (TcpClient)obj;

			// Get the stream object
			NetworkStream stream = client.GetStream();

			byte[] buffer = new byte[4096];
			StringBuilder sb = new StringBuilder();

			try
			{
				int bytesRead = 0;
				do
				{
					bytesRead = stream.Read(buffer, 0, 4096);
					sb.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
				} while (stream.DataAvailable);
			}
			catch (IOException ex)
			{
				MessageBox.Show($"IOException: {ex.Message}");
			}
			finally
			{
				client.Close();
			}

			string message = sb.ToString().Trim();
			if (!string.IsNullOrEmpty(message))
			{
				MessageReceived?.Invoke(message);
			}
		}
	}
}