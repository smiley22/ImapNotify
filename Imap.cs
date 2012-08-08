using System;
using AE.Net.Mail;
using System.Windows.Forms;
using Microsoft.Win32;

namespace ImapNotify {
	public delegate void NewMessageEventHandler(object sender, NewMessageEventArgs e);

	class Imap {
		private static ImapClient IC;
		private static bool IsRunning = false;
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
			IsRunning = true;

      /* Does NOT run in the context of the "UI thread" but in its _own_ thread */
			IC.NewMessage += (sender, e) => {
        MailMessage m = null;
        lock (IC) {
          m = IC.GetMessage(e.MessageCount - 1, false, false);
        };
        NewMessageEventArgs args = new NewMessageEventArgs(
          m, e.MessageCount);
				NewMessageEvent(sender, args);
			};
    }

		public static void Stop() {
			if(IsRunning)
				IC.Dispose();
			IsRunning = false;
		}

    public static bool Started() {
      return IsRunning;
    }

		public static int GetUnreadCount() {
			if (!IsRunning)
				return 0;
      int Count = 0;
      lock (IC) {
        Count = IC.GetUnreadCount();
      }
			return Count;
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
