using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Net;
using System.Numerics;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using Shared.Services.ClientService;
using Shared.Services.Extension;
using Newtonsoft.Json;
using ModelDTO;
using Shared.Models;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;

namespace ServerView
{
    public partial class frmMain : Form
    {
        private readonly IClientService _service;
        private BindingSource _bs = new BindingSource();
        string[] allowedColumns = new[] { "Line", "Date" };
        public frmMain()
        {
            InitializeComponent();
            
            _service = new ClientService(new HttpClient());
        }

        public static XLWorkbook workbook, workbookLogs;
        string CFPath, LogPath, Location1, Location2, APIUrl;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"notification.wav");
        private async void frmServer_Load(object sender, EventArgs e)
        {            
            gv.DataSource = _bs;
            if (File.Exists("SSettings.xml"))
            {
                string xmlFile = "SSettings.xml";
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(xmlFile, XmlReadMode.InferSchema);

                CFPath = dsXML.Tables["GeneralInfo"].Rows[0]["CFPath"].ToString();

                APIUrl = dsXML.Tables["GeneralInfo"].Rows[0]["APIUrl"].ToString();

                workbook = new XLWorkbook(CFPath);

                LogPath = dsXML.Tables["GeneralInfo"].Rows[0]["LogPath"].ToString();
            }

            Clear();
            if (!File.Exists("SSettings.xml"))
                lbLocation.Text = "Chưa chọn file chứa CF, vui lòng chọn ở Setting";
            else
                lbLocation.Text = "";
            btConfirm.Enabled = false;
        }
        private List<int> _oldIds = new List<int>();
        private bool isLoading = false;
        async Task refreshData()
        {
            if (isLoading) return;
            if (string.IsNullOrWhiteSpace(APIUrl)) return;

            var _newData = await _service.GetLineInfo(APIUrl);

            var newIds = _newData.Select(x => x.Id).ToList();
            bool isDifferent = !_oldIds.SequenceEqual(newIds);
            bool isDifferentForPlayNotification = newIds.Except(_oldIds).Any();
            try
            {
                if (isDifferent)
                {
                    object selectedId = null;
                    if (gv.CurrentRow != null)
                    {
                        selectedId = gv.CurrentRow.Cells["Id"].Value;
                    }

                    gv.SuspendLayout();
                    isLoading = true;
                    _bs.DataSource = _newData;
                    gv.ResumeLayout();
                    
                    _oldIds = newIds; 

                    if (selectedId != null)
                    {
                        foreach (DataGridViewRow row in gv.Rows)
                        {
                            if (row.Cells["Id"].Value?.Equals(selectedId) == true)
                            {
                                row.Selected = true;
                                gv.CurrentCell = row.Cells[0];
                                break;
                            }
                        }
                    }
                    if (isDifferentForPlayNotification)
                    {
                        player.Play();
                    }
                }
            }
            finally
            {                
                isLoading = false;
            }
        }

        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }



        private void gv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ckLocation1.Text = "Không tìm thấy vị trí";
                ckLocation1.Enabled = false;
                ckLocation2.Text = "Không tìm thấy vị trí";
                ckLocation2.Enabled = false;
                btConfirm.Enabled = true;
                Clear();


                lbLine.Text = gv.Rows[e.RowIndex].Cells["LINE"].Value.ToString();
                lbCF.Text = gv.Rows[e.RowIndex].Cells["CF"].Value.ToString();
                lbCode.Text = gv.Rows[e.RowIndex].Cells["CODE"].Value.ToString();
                lbQuantity.Text = gv.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();

                string code = lbCode.Text.Trim();
                var locationParts = (CheckCFLocation(code) ?? "").Split('/');
                var quantityParts = (CheckCFQuantity(code) ?? "").Split('/');

                string loc1 = locationParts.Length > 0 ? locationParts[0] : "";
                string loc2 = locationParts.Length > 1 ? locationParts[1] : "";
                string qty1 = quantityParts.Length > 0 ? quantityParts[0] : "0";
                string qty2 = quantityParts.Length > 1 ? quantityParts[1] : "0";

                Location1 = qty1 == "0" ? "" : loc1;
                Location2 = qty2 == "0" ? "" : loc2;

                // UI - Vị trí 1
                ckLocation1.Text = string.IsNullOrEmpty(Location1) ? "Vị trí cũ: (Không có)" : $"Vị trí cũ: {Location1}";
                lbQuantity1.Text = $"Hiện có {qty1}";
                ckLocation1.Enabled = !string.IsNullOrEmpty(Location1);
                ckLocation1.Checked = !string.IsNullOrEmpty(Location1);

                // UI - Vị trí 2
                ckLocation2.Text = string.IsNullOrEmpty(Location2) ? "Vị trí mới: (Không có)" : $"Vị trí mới: {Location2}";
                lbQuantity2.Text = $"Hiện có {qty2}";
                ckLocation2.Enabled = !string.IsNullOrEmpty(Location2);
                ckLocation2.Checked = !string.IsNullOrEmpty(Location2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dòng: " + ex.Message);
            }
        }
        string ReadValueFromExcel(string code, string col1, string col2)
        {
            try
            {
                if (string.IsNullOrEmpty(CFPath)) return "";

                var ws = workbook.Worksheet(1);
                for (int row = 9; row <= ws.LastRowUsed().RowNumber(); row++)
                {
                    if (code == ws.Cell("B" + row).GetString().Trim())
                    {
                        return ws.Cell(col1 + row).GetString() + "/" + ws.Cell(col2 + row).GetString();
                    }
                }
            }
            catch { }

            return "";
        }

        string CheckCFLocation(string code) => ReadValueFromExcel(code, "E", "G");
        string CheckCFQuantity(string code) => ReadValueFromExcel(code, "F", "H");

        void Clear()
        {
            ckLocation1.Text = "Không tìm thấy vị trí";
            ckLocation1.Enabled = false;
            ckLocation2.Text = "Không tìm thấy vị trí";
            ckLocation2.Enabled = false;
            btConfirm.Enabled = true;

            lbLine.Text = "";
            lbCF.Text = "";
            lbCode.Text = "";
            lbQuantity.Text = "";
            lbLocation.Text = "";
        }
        private async void btConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                var idLine = gv.CurrentRow.Cells["id"].Value._IntOrNull();
                if (idLine == null)
                {
                    MessageBox.Show("Incorrect Id selected");
                    return;
                }
                if (ckLocation1.CheckState != CheckState.Checked && ckLocation2.CheckState != CheckState.Checked)
                {
                    MessageBox.Show("Cần chọn vị trí để lưu");
                    return;
                }
                if (ckLocation1.Checked == true && ckLocation2.Checked == false)
                    Location2 = "";
                else
                if (ckLocation2.Checked == true && ckLocation1.Checked == false)
                    Location1 = "";
                else
                { }
                SaveLogs(lbLine.Text, lbCF.Text, lbCode.Text, lbQuantity.Text, Location1, Location2, DateTime.Now);
                var response = await _service.DeleteCF(APIUrl, idLine.Value);
                if (response.IsSuccess == true)
                {
                    await refreshData();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Xảy ra lỗi");
                }
            }
            catch { }
        }
        void SaveLogs(string Line, string CF, string Code, string Quantity, string Location1, string Location2, DateTime Confirm)
        {
            try
            {
                string filePath = Path.Combine(LogPath, "phiếu xuất kho.xlsx");

                using (var workbookLogs = File.Exists(filePath) ? new XLWorkbook(filePath) : new XLWorkbook())
                {
                    var ws = workbookLogs.Worksheets.Any() ? workbookLogs.Worksheet(1) : workbookLogs.AddWorksheet("Logs");

                    // Nếu file mới, thêm tiêu đề
                    if (ws.Cell("A1").IsEmpty())
                    {
                        ws.Cell("A1").Value = "LINE";
                        ws.Cell("B1").Value = "CF";
                        ws.Cell("C1").Value = "CODE";
                        ws.Cell("D1").Value = "Quantity";
                        ws.Cell("E1").Value = "Location 1";
                        ws.Cell("F1").Value = "Location 2";
                        ws.Cell("G1").Value = "DATE";
                        ws.Cell("H1").Value = "TIME";
                    }

                    // Xác định hàng tiếp theo để ghi dữ liệu
                    int lastRow = ws.LastRowUsed()?.RowNumber() ?? 1;
                    int newRow = lastRow + 1;

                    // Ghi dữ liệu vào file Excel
                    ws.Cell("A" + newRow).Value = Line;
                    ws.Cell("B" + newRow).Value = CF;
                    ws.Cell("C" + newRow).Value = Code;
                    ws.Cell("D" + newRow).Value = Quantity;
                    ws.Cell("E" + newRow).Value = string.IsNullOrEmpty(Location1) ? "(Không có)" : Location1;
                    ws.Cell("F" + newRow).Value = string.IsNullOrEmpty(Location2) ? "(Không có)" : Location2;
                    ws.Cell("G" + newRow).Value = Confirm.ToString("dd/MM/yyyy");
                    ws.Cell("H" + newRow).Value = Confirm.ToString("HH:mm:ss");

                    // Lưu file
                    workbookLogs.SaveAs(filePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lưu log: " + ex.Message);
            }
        }

        private void btSetup_Click(object sender, EventArgs e)
        {
            frmSetting f = new frmSetting();
            if (f.ShowDialog() == DialogResult.OK)
                Clear();
        }
        private async void updateDateTimer_Tick(object sender, EventArgs e)
        {
            await refreshData();
        }
    }
}
