using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace ClientView
{
    public partial class frmClientDetail : Form
    {
        public frmClientDetail( string CF, string CODE, string Quatity, string Folder)
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
            try
            {
                dxErr.Clear();
                if (string.IsNullOrWhiteSpace(txtUsername.Text))
                {
                    dxErr.SetError(txtUsername, "Not Empty");
                    return;
                }

                string filePath = Path.Combine(_Folder, "lý lịch.xlsx");
                workbook = File.Exists(filePath) ? new XLWorkbook(filePath) : new XLWorkbook();

                var ws = workbook.Worksheets.FirstOrDefault() ?? workbook.Worksheets.Add("Sheet1");
                EnsureHeaderIfNeeded(ws);

                int i = ws.LastRowUsed()?.RowNumber() + 1 ?? 2;

                ws.Cell(i, 1).Value = txtLine.Text;
                ws.Cell(i, 2).Value = txtCF.Text;
                ws.Cell(i, 3).Value = txtCODE.Text;
                ws.Cell(i, 4).Value = txtQuantity.Text;
                ws.Cell(i, 5).Value = txtContent.Text;
                ws.Cell(i, 6).Value = txtReason.Text;
                ws.Cell(i, 7).Value = txtFullname.Text;
                ws.Cell(i, 8).Value = txtUsername.Text;
                ws.Cell(i, 9).Value = DateTime.Now.ToString("dd/MM/yyyy");
                ws.Cell(i, 10).Value = DateTime.Now.ToString("hh:mm:ss tt");

                workbook.SaveAs(filePath);

                this.DialogResult = DialogResult.OK;

                var frmClient = new frmClient();
                this.Hide();
                frmClient.FormClosed += (s, args) => this.Close();
                frmClient.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EnsureHeaderIfNeeded(IXLWorksheet ws)
        {
            if (ws.LastRowUsed() == null || ws.FirstRowUsed().RowNumber() == 1 && string.IsNullOrEmpty(ws.Cell("A1").GetString()))
            {
                string[] headers = { "Line", "CF", "CODE", "Quantity", "Content", "Reason", "FullName", "UserName", "Date", "Time" };
                for (int c = 0; c < headers.Length; c++)
                    ws.Cell(1, c + 1).Value = headers[c];
            }
        }



        private void frmClientDetail_Load(object sender, EventArgs e)
        {            
            txtCF.Text = _CF;
            txtCODE.Text = _CODE;
            txtQuantity.Text = _Quatity;
        }

        private void frmClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            
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
