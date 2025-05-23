﻿using ModelDTO;
using Shared.Services.ClientService;
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
        private readonly IClientService _service;
        public frmClient()
        {
            InitializeComponent();
            _service = new ClientService(new HttpClient());
        }
        string Line, APIUrl, Folder, COMPort = "COM7";
        SerialPort serPort;

        private async void btSend_Click(object sender, EventArgs e)
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
                if (txtQuantity.Text == "" || !txtQuantity.Text.IsNumber())
                {
                    bSend = false;
                    dxErr.SetError(txtQuantity, "Incorrect format");
                }
                if (bSend)
                {
                    var response = await _service.SendCF(APIUrl, new RequestDTO
                    {
                        Line = lbLine.Text,
                        CF = txtCF.Text,
                        CODE = txtCODE.Text,
                        Quantity = txtQuantity.Text._Int()
                    });
                    if (response.IsSuccess)
                    {
                        frmClientDetail frmClientDetail = new frmClientDetail( txtCF.Text, txtCODE.Text, txtQuantity.Text, Folder);
                        this.Hide();
                        frmClientDetail.Closed += (s, args) => this.Close();
                        if (COMPort.checkCOMExits())
                        {
                            serPort.Close();
                        }
                        frmClientDetail.ShowDialog();

                        if (frmClientDetail.DialogResult == DialogResult.OK)
                        {
                            txtCF.Text = "";
                            txtCODE.Text = "";
                            txtQuantity.Text = "";
                        }
                    }
                    else
                        MessageBox.Show(response.Message);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

        }
        private void frmClient_Load(object sender, EventArgs e)
        {
            LoadInfo();
            if (COMPort.checkCOMExits())
            {
                serPort = new SerialPort(COMPort);
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
