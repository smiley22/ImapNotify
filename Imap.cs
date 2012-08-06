using System;
using AE.Net.Mail;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ImapNotify {
	public delegate void NewMessageEventHandler(object sender, NewMessageEventArgs e);

	class Imap {
		private static ImapClient IC;
		public static event NewMessageEventHandler NewMessageEvent;

		public static void Start() {
			bool Gmail	= Properties.Settings.Default.UseGmail;
			string Host = Gmail ? Properties.Settings.Default.GmailImapServer :
				Properties.Settings.Default.ImapServer;
			int Port = Gmail ? Int32.Parse(Properties.Settings.Default.GmailServerPort) :
				Int32.Parse(Properties.Settings.Default.ServerPort);
			string Username = Properties.Settings.Default.Username;
			string Password = Encryption.DecryptString(Properties.Settings.Default.Password);
			bool SSL = Gmail ? true : Properties.Settings.Default.UseSSL;

			IC = new ImapClient(Host, Username, Password, ImapClient.AuthMethods.Login,
				Port, SSL);

			IC.NewMessage += (sender, e) => {
				MailMessage m = IC.GetMessage(e.MessageCount - 1);
				NewMessageEventArgs args = new NewMessageEventArgs(
					IC.GetMessage(e.MessageCount - 1), e.MessageCount);
				NewMessageEvent(sender, args);
			};
        }

		public static void Stop() {
			IC.Dispose();
		}

		public static int GetUnreadCount() {
			return IC.GetUnreadCount();
		}
	}

	public class NewMessageEventArgs : EventArgs {
		public NewMessageEventArgs(MailMessage m, int u) {
			this.Message = m;
			this.UnreadMails = u;
		}

		public MailMessage Message;
		public int UnreadMails;
	}
}
