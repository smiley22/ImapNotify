using System;
using System.Windows.Forms;

namespace ImapNotify {
	static class Program {
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Dialog Dlg = new Dialog();
			Application.Run();
		}
	}
}
