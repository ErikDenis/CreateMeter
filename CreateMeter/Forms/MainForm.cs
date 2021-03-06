﻿using System;
using System.IO;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading;

namespace CreateMeter {
	public partial class MainForm : Form {
		public MainForm() {
            InitializeComponent();
			LoadFolderTreeView();
            SwitchLang(false);
        }

        private void SwitchLang(bool ShowMssg) {
            switch (Properties.Settings.Default.Language) {
                case 0:
                    englishToolStripMenuItem.CheckState = CheckState.Checked;
                    russianToolStripMenuItem.CheckState = CheckState.Unchecked;
                    break;
                case 1:
                    englishToolStripMenuItem.CheckState = CheckState.Unchecked;
                    russianToolStripMenuItem.CheckState = CheckState.Checked;
                    break;
            }
            if (ShowMssg) {
                MessageBox.Show(
                    resources.MyStrings.LangSwitchMssg,
                    resources.MyStrings.LangSwitchTitle,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                    );
            }
        }

		private void LoadFolderTreeView() {
			var root = new TreeNode() {Text = "Rainmeter Skins Folder", Tag = "C:\\Users\\" + Environment.UserName +"\\Documents\\Rainmeter\\Skins\\"};
            treeView.Nodes.Add(root);
            BuildFolderTreeView(root);
            root.Expand();
		}
		
		private void BuildFolderTreeView(TreeNode parent) {
            var path = parent.Tag as string;
            parent.Nodes.Clear();
 
            try {
                foreach (var dir in Directory.GetDirectories(path))
                    parent.Nodes.Add(new TreeNode(Path.GetFileName(dir), new[] { new TreeNode("...") }) { Tag = dir });
 
                foreach (var file in Directory.GetFiles(path))
                    parent.Nodes.Add(new TreeNode(Path.GetFileName(file), 1, 1) { Tag = file });
            } catch {
            	treeView.EndUpdate();
            }
        }
		
		void TreeViewAfterExpand(object sender, TreeViewEventArgs e) {
            BuildFolderTreeView(e.Node);
		}
		
		void SkinsManageToolStripMenuItemClick(object sender, EventArgs e) {
			new SkinManager().Show();
		}

        private void englishToolStripMenuItem_Clicked(object sender, EventArgs e) {
            Program.LanguageChange(0);
            SwitchLang(true);
        }

        private void russianToolStripMenuItem_Clicked(object sender, EventArgs e) {
            Program.LanguageChange(1);
            SwitchLang(true);
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e) {
            System.Diagnostics.Process.Start("https://github.com/ErikDenis/CreateMeter");
        }

        private void globalVariablesToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void AddSection_Click(object sender, EventArgs e) {
            new AddSectionForm().Show();
        }
    }
}