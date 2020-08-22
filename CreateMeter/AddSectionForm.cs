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
            XmlTextReader SectionsXML = new XmlTextReader("resources/Sections.xml");
            LoadSectionsList(SectionsXML);
        }

        private void LoadSectionsList(XmlTextReader XML) {
            while (XML.Read()) {
                if (XML.NodeType == XmlNodeType.Element) {
                    Console.WriteLine(XML.LocalName);
                }
            }
        }
    }
}
