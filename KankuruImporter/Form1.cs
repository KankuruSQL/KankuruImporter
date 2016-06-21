using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KankuruImporter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buImport_Click(object sender, EventArgs e)
        {
            openFileDialogBox.Filter = "Regsrvr from SSMS|*.regsrvr";
            openFileDialogBox.CheckFileExists = true;
            openFileDialogBox.CheckPathExists = true;

            DialogResult result = openFileDialogBox.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var file = openFileDialogBox.FileName;
            TxtFile.Text = file;

        }

        private void TxtFile_TextChanged(object sender, EventArgs e)
        {
            ParseFile();
        }


        private void ParseFile()
        {
            var reader = new System.Xml.XmlTextReader(TxtFile.Text);
            var contents = new StringBuilder();
            try
            {
                while (reader.Read())
                {
                    reader.MoveToContent();
                    if (reader.NodeType == System.Xml.XmlNodeType.Element &&
                        (
                        reader.Name.StartsWith("RegisteredServers:ConnectionStringWithEncryptedPassword"))
                        && reader.HasAttributes
                        )
                    {
                        string line = reader.ReadString();
                        CnxString c = new CnxString(line);
                        contents.AppendLine(c.GenerateScript());
                        contents.AppendLine("");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
            TxtScript.Text = contents.ToString();
        }


        private void TxtScript_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                TxtScript.SelectAll();
            }
        }




    }
}
