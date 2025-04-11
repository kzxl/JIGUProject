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

namespace ServerView
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }
        private void txtLogs_Click(object sender, EventArgs e)
        {
            if (fbdPath.ShowDialog() == DialogResult.OK)
            {
                txtLogs.Text = fbdPath.SelectedPath;
            }
        }

        private void txtCF_Click(object sender, EventArgs e)
        {
            if (ofdPath.ShowDialog() == DialogResult.OK)
            {
                txtCF.Text = ofdPath.FileName;
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            bool b = true;
            if (string.IsNullOrEmpty(txtCF.Text))
            {
                b = false;
            }
            if (string.IsNullOrEmpty(txtLogs.Text))
            {
                b |= false;
            }
            if (string.IsNullOrEmpty(txtAPI.Text))
            {
                b = false;
            }
            if (b)
            {
                createXMLSettings(txtCF.Text,txtAPI.Text, txtLogs.Text);
            }
        }

        void createXMLSettings(string CFPath, string API, string LogPath)
        {
            try
            {
                if (!File.Exists("SSettings.xml"))
                {
                    XmlWriterSettings settings = new XmlWriterSettings();
                    settings.Indent = true;
                    XmlWriter writer = XmlWriter.Create("SSettings.xml", settings);
                    writer.WriteStartDocument();
                    writer.WriteStartElement("GeneralInfo");
                    writer.WriteElementString("CFPath", CFPath);
                    writer.WriteElementString("APIUrl", API);
                    writer.WriteElementString("LogPath", LogPath);
                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                    writer.Flush();
                    writer.Close();
                }
                else
                {
                    string xmlFile = Application.StartupPath + @"\SSettings.xml";
                    XmlDocument xml = new XmlDocument();
                    xml.Load(xmlFile);
                    XmlNodeList nodes = xml.SelectNodes(@"/GeneralInfo");
                    foreach (XmlElement element in nodes)
                    {
                        element.SelectSingleNode("CFPath").InnerText = CFPath;
                        element.SelectSingleNode("APIUrl").InnerText = API;
                        element.SelectSingleNode("LogPath").InnerText = LogPath;
                        xml.Save(xmlFile);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void frmServer_Setting_Load(object sender, EventArgs e)
        {
            if (File.Exists("SSettings.xml"))
            {
                string xmlFile = "SSettings.xml";
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(xmlFile, XmlReadMode.InferSchema);
                txtCF.Text = dsXML.Tables["GeneralInfo"].Rows[0]["CFPath"].ToString();
                txtAPI.Text = dsXML.Tables["GeneralInfo"].Rows[0]["APIUrl"].ToString();
                txtLogs.Text = dsXML.Tables["GeneralInfo"].Rows[0]["LogPath"].ToString();
            }

        }

        private void frmServer_Setting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

    }
}
