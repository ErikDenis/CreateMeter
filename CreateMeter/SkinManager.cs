using System;
using System.Drawing;
using System.Windows.Forms;

namespace CreateMeter {
	public partial class SkinManager : Form {
		public Form PpF;
		public SkinManager(Form pF)
		{
			InitializeComponent();
			
			if (pF != null) {
				PpF = pF;
			}
			
		}
		
		void SkinManagerClosed(object sender, EventArgs e)
		{
			PpF.Focus();
			PpF.Enabled = true;
		}
	}
}
