using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CreateMeter {
	public partial class SkinManager : Form {
		public SkinManager()
		{
			InitializeComponent();
			LoadSkinsListBox();
		}
		private void LoadSkinsListBox() {
			DirectoryInfo dir = new DirectoryInfo("C:\\Users\\" + Environment.UserName + "\\Documents\\Rainmeter\\Skins\\");
			foreach (var item in dir.GetDirectories()) {
				if (!item.Name.StartsWith("@")) {
					SkinPacksListBox.Items.Add(item.Name);
                }
            }
		}
	}
}
