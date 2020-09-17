using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace SPTNPP
{
	public class GameDirMessage
	{
		public string path { get; set; }
		public string type { get; set; }
	}

	public class SocketClient : IDisposable
	{
		Socket socket;
		const int MAX_BUFFER = 32767;
		byte[] recBuffer = new byte[MAX_BUFFER];
		static IPAddress localHost = new IPAddress(new byte[] { 127, 0, 0, 1 });

		public SocketClient(int port)
		{
			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(localHost, port);
		}

		public void SendCommand(string cmd)
		{
			string output = string.Format("{{\"type\": \"cmd\", \"cmd\": \"{0}\"}}\0", cmd);
			var bytes = Encoding.ASCII.GetBytes(output);

			if(bytes.Length > 32767)
			{
				MessageBox.Show(string.Format("Tried to send too long message! {0} bytes.", bytes.Length));
			}

			socket.Send(bytes, bytes.Length, SocketFlags.None);
			var msg = GetMessage();
			if(msg["type"] != "ack")
			{
				throw new Exception("Did not get ack from SPT!");
			}
		}

		unsafe public Dictionary<string, string> GetMessage()
		{
			var serializer = new JavaScriptSerializer();
			int bytes = socket.Receive(recBuffer);
			string json = "";

			fixed (byte* ptr = recBuffer)
			{
				json = Encoding.UTF8.GetString(ptr, bytes - 1);
			}
			

			return serializer.Deserialize<Dictionary<string, string>>(json);
		}

		public void Dispose()
		{
			if (socket.Connected)
			{
				socket.Close();
			}
		}
	}
}
