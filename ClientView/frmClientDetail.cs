using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ClientView
{
    public partial class frmClientDetail : Form
    {
        public frmClientDetail(string CF, string CODE, string Quatity, string Folder)
        {
            InitializeComponent();
            _CF = CF;
            _CODE = CODE;
            _Quatity = Quatity;
            _Folder = Folder;
        }
        string _CF, _CODE, _Quatity, _Folder;
        public static XLWorkbook workbook;
        private void btConfirm_Click(object sender, EventArgs e)
        {
            bool bSave = true;

            if (txtUsername.Text == "")
            {
                dxErr.SetError(txtUsername, "Not Empty");
                bSave = false;
            }

            if (bSave)
            {
                //Save Data to excel file

                if (File.Exists(_Folder + @"\lý lịch.xlsx"))
                {
                    workbook = new XLWorkbook(_Folder + @"\lý lịch.xlsx");
                    var ws = workbook.Worksheet("Sheet1");

                    int i = ws.LastRowUsed().RowNumber() + 1;
                    ws.Cell("A" + i).Value = txtCF.Text;
                    //CODE
                    ws.Cell("B" + i).Value = txtCODE.Text;
                    //Quatity
                    ws.Cell("C" + i).Value = txtQuantity.Text;
                    //Content
                    ws.Cell("D" + i).Value = txtContent.Text;
                    //Reason
                    ws.Cell("E" + i).Value = txtReason.Text;
                    //FullName
                    ws.Cell("F" + i).Value = txtFullname.Text;
                    //UserName
                    ws.Cell("G" + i).Value = txtUsername.Text;
                    //Time
                    ws.Cell("H" + i).Value = DateTime.Now.ToString("dd/MM/yyyy");

                    ws.Cell("I" + i).Value = DateTime.Now.ToString("hh:mm:ss tt"); // Giờ


                    workbook.Save();

                }
                else
                {
                    workbook = new XLWorkbook();
                    AddtoExcel();
                }
                //
                this.DialogResult = DialogResult.OK;
                frmClient frmClient = new frmClient();
                this.Hide();
                frmClient.Closed += (s, args) => this.Close();
                //frmClientDetail.Show();
                frmClient.ShowDialog();

            }
        }
        private void AddtoExcel()
        {
            var ws = workbook.AddWorksheet();
            ws.Cell("A1").Value = "CF";
            ws.Cell("B1").Value = "CODE";
            ws.Cell("C1").Value = "Quatity";
            ws.Cell("D1").Value = "Content";
            ws.Cell("E1").Value = "Reason";
            ws.Cell("F1").Value = "FullName";
            ws.Cell("G1").Value = "UserName";
            ws.Cell("H1").Value = "date";
            ws.Cell("I1").Value = "Time"; // Tiêu đề cho cột Giờ

            //var dateformat = "dd/MM";
            try
            {
                for (int i = 2; i < 3; i++)
                {
                    //CF
                    ws.Cell("A" + i).Value = txtCF.Text;
                    //CODE
                    ws.Cell("B" + i).Value = txtCODE.Text;
                    //Quatity
                    ws.Cell("C" + i).Value = txtQuantity.Text;
                    //Content
                    ws.Cell("D" + i).Value = txtContent.Text;
                    //Reason
                    ws.Cell("E" + i).Value = txtReason.Text;
                    //FullName
                    ws.Cell("F" + i).Value = txtFullname.Text;
                    //UserName
                    ws.Cell("G" + i).Value = txtUsername.Text;
                    //Time
                    ws.Cell("H" + i).Value = DateTime.Now.ToString("dd/MM/yyyy");
                    ws.Cell("I" + i).Value = DateTime.Now.ToString("hh:mm:ss tt"); // Giờ



                }
                workbook.SaveAs(_Folder + @"\lý lịch.xlsx");

            }
            catch { throw new Exception(); }


        }

        private void frmClientDetail_Load(object sender, EventArgs e)
        {
            txtCF.Text = _CF;
            txtCODE.Text = _CODE;
            txtQuantity.Text = _Quatity;
        }

        private void frmClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmClient frmClient = new frmClient();
            //this.Hide();
            //frmClient.Closed += (s, args) => this.Close();
            ////frmClientDetail.Show();
            //frmClient.ShowDialog();
        }

        private void frmClientDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (txtUsername.Text == "")
            {
                dxErr.SetError(txtUsername, "Not empty");
                e.Cancel = true;
            }
        }
    }
}
