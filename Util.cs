using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using System.Reflection;

namespace ImapNotify {
	class Util {
		/// <summary>
		/// Configures whether program is run on startup by modifying the
		/// Run settings in the registry under HKEY_CURRENT_USER.
		/// </summary>
		/// <param name="Run">Set to true to run program at startup</param>
		public static void RunOnStartup(bool Run) {
			string Path = @"Software\Microsoft\Windows\CurrentVersion\Run";
			AssemblyTitleAttribute Title = Assembly.GetExecutingAssembly().
				GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]
				as AssemblyTitleAttribute;
			RegistryKey Key = Registry.CurrentUser.OpenSubKey(Path, true);

			if (Run)
				Key.SetValue(Title.Title, Assembly.GetExecutingAssembly().Location);
			else
				Key.DeleteValue(Title.Title, false);
		}
	}
}
