using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CreateMeter {
    public partial class AddSectionForm : Form {
        public AddSectionForm() {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            XmlDocument SectionsXML = new XmlDocument();
            SectionsXML.Load("resources/Sections.xml");
            LoadSectionsList(SectionsXML);
        }

        private void LoadSectionsList(XmlDocument XML) {
            string SectionType = comboBox1.Text.Replace("s", "");
            listBox1.Items.Clear();
            XmlNodeList NList = XML.GetElementsByTagName(SectionType);
            Console.WriteLine(NList.Count);
            foreach (XmlElement section in NList) {
                listBox1.Items.Add(section.LocalName);
            }
        }
    }
}
