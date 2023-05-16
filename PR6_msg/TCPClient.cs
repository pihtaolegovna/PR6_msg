using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace PR6_msg
{
	public class Client
	{
		private TcpClient _client = null;
		private int _port;
		private IPAddress _ipAddress;
		public static string Name;

		public Client(string ipAddressStr, int port)
		{
			_port = 1234;
			if (!IPAddress.TryParse(ipAddressStr, out _ipAddress))
			{
				throw new ArgumentException("IP Address is invalid.");
			}
		}

		public void Send(string message)
		{
			if (_client == null)
			{
				Connect();
			}

			NetworkStream stream = _client.GetStream();

			byte[] buffer = Encoding.UTF8.GetBytes(message);
			stream.Write(buffer, 0, buffer.Length);

			stream.Close();
			_client.Close();
			_client = null;
		}

		private void Connect()
		{
			_client = new TcpClient();
			_client.Connect(_ipAddress, _port);
		}
	}
}