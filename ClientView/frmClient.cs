using Shared.Services.Extension;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ClientView
{
    public partial class frmClient : Form
    {
        public frmClient()
        {
            InitializeComponent();
        }
        string Line,APIUrl, Folder;
        SerialPort serPort;

        private void btSend_Click(object sender, EventArgs e)
        {
            try
            {
                bool bSend = true;
                if (txtCF.Text == "")
                {
                    bSend = false;
                    dxErr.SetError(txtCF, "Not Empty");
                }
                if (txtCODE.Text == "")
                {
                    bSend = false;
                    dxErr.SetError(txtCODE, "Not Empty");
                }
                if (txtQuantity.Text == "")
                {
                    bSend = false;
                    dxErr.SetError(txtQuantity, "Not Empty");
                }
                if (bSend)
                {
                    //Send to Server
                    clsFunctions.SentMess("MESS/" + lbLINE.Text + "/" + txtCF.Text + "/" + txtCODE.Text + "/" + txtQuantity.Text, IPServer, 6666);
                    //Open frmDetail

                    frmClientDetail frmClientDetail = new frmClientDetail(txtCF.Text, txtCODE.Text, txtQuantity.Text, Folder);
                    this.Hide();
                    frmClientDetail.Closed += (s, args) => this.Close();
                    if ("COM7".checkCOMExits())
                    {
                        serPort.Close();
                    }
                    //frmClientDetail.Show();
                    frmClientDetail.ShowDialog();

                    if (frmClientDetail.DialogResult == DialogResult.OK)
                    {
                        txtCF.Text = "";
                        txtCODE.Text = "";
                        txtQuantity.Text = "";
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            LoadInfo();
            //Check COM exist
            if ("COM7".checkCOMExits())
            {
                serPort = new SerialPort("COM7"); // thats the USB port on which the scanner is connected
                serPort.DataReceived += new SerialDataReceivedEventHandler(serial_DataReceived);
                serPort.Open();
            }

        }
        void LoadInfo()
        {
            if (File.Exists("Settings.xml"))
            {
                string xmlFile = "Settings.xml";
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(xmlFile, XmlReadMode.InferSchema);
                Line = dsXML.Tables["GeneralInfo"].Rows[0]["LINE"].ToString();
                APIUrl = dsXML.Tables["GeneralInfo"].Rows[0]["APIUrl"].ToString();
                Folder = dsXML.Tables["GeneralInfo"].Rows[0]["Folder"].ToString();

                lbLine.Text = Line;

            }
        }
        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string response = serPort.ReadExisting();

            //do work
            if (response != null)
            {
                txtCF.Text = response.Split(new char[] { '\r', '\n', })[0];
                txtCODE.Text = response.Split(new char[] { '\r', '\n' })[1];

            }
        }
    }
}
