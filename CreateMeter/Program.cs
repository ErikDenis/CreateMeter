﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace CreateMeter {
	internal sealed class Program {
		public static string[] lags = {
			"en",
			"ru"
		};
		[STAThread]
		private static void Main(string[] args) {
			Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lags[Properties.Settings.Default.Language]);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}

		public static void LanguageChange(int LangID) {
			Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lags[LangID]);
			Properties.Settings.Default.Language = LangID;
			Properties.Settings.Default.Save();
		}

	}
}