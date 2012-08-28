using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Reflection;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace ImapNotify {
	public partial class Dialog : Form {
		private bool reallyClose = false;
		private Icon IconOld;
		private string soundPath;

		public Dialog() {
			InitializeComponent();
			IconOld = notifyIcon.Icon;
			soundPath = Path.GetDirectoryName(
				Assembly.GetExecutingAssembly().Location) + @"\Notify.wav";
			if (!File.Exists(soundPath)) {
				soundPath = Environment.GetFolderPath(Environment.SpecialFolder.Windows) +
					@"\Media\Windows Notify.wav";
			}
			Location = new Point(
				Screen.PrimaryScreen.WorkingArea.Width - Width,
				Screen.PrimaryScreen.WorkingArea.Height - Height);
			NetworkChange.NetworkAvailabilityChanged += new NetworkAvailabilityChangedEventHandler(OnNetworkAvailabilityChanged);
			SystemEvents.PowerModeChanged += new PowerModeChangedEventHandler(OnPowerModeChanged);
			Imap.NewMessageEvent += new NewMessageEventHandler(OnNewMessage);
			try {
				if (Properties.Settings.Default.Username == "" ||
					Properties.Settings.Default.Password == "") {
					notifyIcon.ShowBalloonTip(300, "First Run?", "Right-cick to configure settings",
						ToolTipIcon.Info);
				} else {
					Imap.Start();
					CheckNewMail();
				}
			} catch (Exception ex) {
				notifyIcon.ShowBalloonTip(300, "Error connecting to host", ex.Message,
					ToolTipIcon.Error);
			}
		}

		private void Dialog_Resize(object sender, EventArgs e) {
			if (FormWindowState.Minimized == WindowState)
				Hide();
		}

		private void EnableFields(bool enable) {
			labelImapServer.Enabled = enable;
			labelServerPort.Enabled = enable;
			labelURL.Enabled = enable;
			textImapServer.Enabled = enable;
			textServerPort.Enabled = enable;
			textURL.Enabled = enable;
			useSSL.Enabled = enable;
		}

		private void useGmail_CheckedChanged(object sender, EventArgs e) {
			EnableFields(!useGmail.Checked);
			buttonApply.Enabled = true;
		}

		private void Dialog_FormClosing(object sender, FormClosingEventArgs e) {
			if (!reallyClose) {
				e.Cancel = true;
				WindowState = FormWindowState.Minimized;
			}

		}

		private void contextMenuQuit_Click(object sender, EventArgs e) {
			reallyClose = true;
			Close();
			Imap.Stop();
			Application.Exit();
		}

		private void contextMenuConfigure_Click(object sender, EventArgs e) {
			Show();
			WindowState = FormWindowState.Normal;
			Focus();
		}

		private void contextMenuReconnect_Click(object sender, EventArgs e) {
			Reconnect();
		}

		private void buttonApply_Click(object sender, EventArgs e) {
			Properties.Settings.Default.Password = Encryption.EncryptString(textPassword.Text);
			Properties.Settings.Default.Save();
			Util.RunOnStartup(Properties.Settings.Default.AutoRun);

			buttonApply.Enabled = false;
			Reconnect();
		}

		private void Dialog_Load(object sender, EventArgs e) {
			textPassword.Text = Encryption.DecryptString(Properties.Settings.Default.Password);
			EnableFields(!Properties.Settings.Default.UseGmail);
		}

		private void OnNewMessage(object sender, NewMessageEventArgs e) {
			notifyIcon.ShowBalloonTip(300, "You've got new e-mail",
				e.Message.Subject, ToolTipIcon.Info);
			if (Properties.Settings.Default.PlaySound) {
				try {
					(new SoundPlayer(soundPath)).Play();
				} catch (Exception) { }
			}
			UpdateTrayIcon(e.UnreadMails);
		}

		private void notifyIcon_BalloonTipClicked(object sender, EventArgs e) {
			string site = Properties.Settings.Default.UseGmail ?
				Properties.Settings.Default.GmailWebsite :
				Properties.Settings.Default.URL;
			if ((Control.MouseButtons & MouseButtons.Right) == MouseButtons.Right)
				return;
			if (site != "")
				Process.Start(site);
			notifyIcon.Icon = IconOld;
		}

		private void notifyIcon_MouseClick(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				string site = Properties.Settings.Default.UseGmail ?
					Properties.Settings.Default.GmailWebsite :
					Properties.Settings.Default.URL;
				if (site != "")
					Process.Start(site);
				notifyIcon.Icon = IconOld;
			}
		}

		private void text_TextChanged(object sender, EventArgs e) {
			if (((TextBox)sender).ContainsFocus)
				buttonApply.Enabled = true;
		}

		private void Dialog_FormClosed(object sender, FormClosedEventArgs e) {
			if (reallyClose)
				Application.Exit();
		}

		private void timer_Tick(object sender, EventArgs e) {
			if (Util.IsInternetConnected()) {
				if (Imap.Started())
					UpdateTrayIcon(Imap.GetUnreadCount());
				else {
					/* attempt to silently reconnect */
					Reconnect(false);
				}
			} else {
				/* Stop if not connected to the internet */
				Imap.Stop();
			}
		}

		private void UpdateTrayIcon(int Count) {
			if (Count > 0) {
				notifyIcon.Text = Count.ToString() + " unread message" + (Count > 1 ? "s" : "");
				notifyIcon.Icon = Properties.Resources.IconUnread;
			} else {
				notifyIcon.Text = "No new messages";
				notifyIcon.Icon = IconOld;
			}
		}

		private void CheckNewMail() {
			int Count = Imap.GetUnreadCount();
			if (Count > 0) {
				notifyIcon.ShowBalloonTip(300, "You've got new e-mail", Count.ToString() +
					" unread message" + (Count > 1 ? "s" : ""), ToolTipIcon.Info);
				if (Properties.Settings.Default.PlaySound) {
					try {
						(new SoundPlayer(soundPath)).Play();
					} catch (Exception) { }
				}
			}
			UpdateTrayIcon(Count);
		}

		private void checkBoxChanged(object sender, EventArgs e) {
			if (((CheckBox)sender).ContainsFocus)
				buttonApply.Enabled = true;
		}

		private void textURL_Enter(object sender, EventArgs e) {
			tipURL.Show("URL to go to when clicking on\ntrayicon or balloontip. If none,\njust leave empty.", textURL);
		}

		private void Reconnect(bool checkForNewMails = true) {
			try {
				Imap.Stop();
				Imap.Start();
				if (checkForNewMails)
					CheckNewMail();
			} catch (Exception ex) {
				notifyIcon.ShowBalloonTip(500, "Error connecting to host", ex.Message,
					ToolTipIcon.Error);
			}
		}

		private void OnNetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e) {
			/* Unfortunately this seems unreliable, so whenever network availability changes
			 * we disconnect and let the tick event take care of reconnecting */
			Imap.Stop();
		}

		private void OnPowerModeChanged(object sender, PowerModeChangedEventArgs e) {
			if (e.Mode == PowerModes.Suspend)
				Imap.Stop();
		}
	}
}
