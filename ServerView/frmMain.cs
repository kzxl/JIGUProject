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
using System.Reflection;

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
        string CFPath, LogPath, APIUrl, tempPath;
        System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"notification.wav");
        private async void frmServer_Load(object sender, EventArgs e)
        {
            try
            {
                gv.DataSource = _bs;
                if (File.Exists("SSettings.xml"))
                {
                    string xmlFile = "SSettings.xml";
                    DataSet dsXML = new DataSet();
                    dsXML.ReadXml(xmlFile, XmlReadMode.InferSchema);

                    CFPath = dsXML.Tables["GeneralInfo"].Rows[0]["CFPath"].ToString();

                    APIUrl = dsXML.Tables["GeneralInfo"].Rows[0]["APIUrl"].ToString();
                    var exePath = Assembly.GetExecutingAssembly().Location;
                    var tempFolder = Path.Combine(Path.GetDirectoryName(exePath), "temp");
                    Directory.CreateDirectory(tempFolder);
                    tempPath = Path.Combine(tempFolder, Path.GetFileName(CFPath));
                    File.Copy(CFPath, tempPath, true);
                    LoadDataFromCF(tempPath);
                    LogPath = dsXML.Tables["GeneralInfo"].Rows[0]["LogPath"].ToString();
                }

                Clear();
                if (!File.Exists("SSettings.xml"))
                    lbLocation.Text = "Chưa chọn file chứa CF, vui lòng chọn ở Setting";
                else
                    lbLocation.Text = "";
                btConfirm.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        List<CF> lstCF = new List<CF>();
        private void LoadDataFromCF(string path)
        {
            using (var workbook = new XLWorkbook(tempPath))
            {
                var worksheet = workbook.Worksheet(1);

                int startRow = 9;
                int lastRow = worksheet.LastRowUsed().RowNumber();

                for (int rowNum = startRow; rowNum <= lastRow; rowNum++)
                {
                    var row = worksheet.Row(rowNum);

                    CF rowData = new CF
                    {
                        CFName = row.Cell(1).GetValue<string>(),
                        Code = row.Cell(2).GetValue<string>(),
                        CodeOther = row.Cell(3).GetValue<string>(),
                        Note = row.Cell(4).GetValue<string>(),
                        LocationOld = row.Cell(5).GetValue<string>(),
                        QuantityOld = row.Cell(6).GetValue<string>(),
                        LocationNew = row.Cell(7).GetValue<string>(),
                        QuantityNew = row.Cell(8).GetValue<string>()
                    };

                    lstCF.Add(rowData);
                }
            }
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
                // Reset UI
                ResetLocationUI();
                btConfirm.Enabled = true;
                Clear();

                // Lấy dữ liệu từ dòng được chọn
                var row = gv.Rows[e.RowIndex];
                lbLine.Text = row.Cells["LINE"].Value?.ToString() ?? "";
                lbCF.Text = row.Cells["CF"].Value?.ToString() ?? "";
                lbCode.Text = row.Cells["CODE"].Value?.ToString() ?? "";
                lbQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? "";

                string code = lbCode.Text.Trim();
                var result = GetValueFromList(code);

                if (result == null)
                {
                    MessageBox.Show($"⚠️ Code \"{code}\" không có trong file!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gán thông tin vị trí cũ
                UpdateLocationUI(
                    checkBox: ckLocation1,
                    quantityLabel: lbQuantity1,
                    location: result.LocationOld,
                    quantity: result.QuantityOld._IntOrZero(),
                    labelPrefix: "Vị trí cũ"
                );

                // Gán thông tin vị trí mới
                UpdateLocationUI(
                    checkBox: ckLocation2,
                    quantityLabel: lbQuantity2,
                    location: result.LocationNew,
                    quantity: result.QuantityNew._IntOrZero(),
                    labelPrefix: "Vị trí mới"
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xử lý dòng: " + ex.Message);
            }
        }
        private void ResetLocationUI()
        {
            ckLocation1.Text = "Không tìm thấy vị trí";
            ckLocation1.Enabled = false;
            ckLocation1.Checked = false;

            ckLocation2.Text = "Không tìm thấy vị trí";
            ckLocation2.Enabled = false;
            ckLocation2.Checked = false;

            lbQuantity1.Text = "";
            lbQuantity2.Text = "";
        }
        private void UpdateLocationUI(CheckBox checkBox, System.Windows.Forms.Label quantityLabel, string location, int quantity, string labelPrefix)
        {
            bool hasLocation = !string.IsNullOrEmpty(location);
            bool hasQuantity = quantity > 0;
            checkBox.Text = hasLocation && hasQuantity ? $"{labelPrefix}: {location}" : $"{labelPrefix}: (Không có)";
            checkBox.Enabled = hasLocation;
            checkBox.Checked = false;
            quantityLabel.Text = $"Hiện có {quantity}";
        }



        private CF GetValueFromList(string code)
        {
            try
            {
                if (lstCF == null) return null;
                var result = lstCF.Where(s => s.Code == code || s.CodeOther == code).ToList();

                if (result == null || result.Count == 0)
                    return null;

                if (result.Count == 1)
                {
                    return result.First();
                }
                else
                {
                    var totalQuantityOld = result.Sum(r => r.QuantityOld._IntOrZero());
                    var totalQuantityNew = result.Sum(r => r.QuantityNew._IntOrZero());
                    var locationOld = result.First().LocationOld;
                    var locationNew = result.First().LocationNew;

                    return new CF
                    {
                        Code = code,
                        QuantityOld = totalQuantityOld.ToString(),
                        QuantityNew = totalQuantityNew.ToString(),
                        LocationOld = locationOld,
                        LocationNew = locationNew
                    };
                }
            }
            catch
            {
                return null;
            }
        }

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
                var location1 = ckLocation1.Checked ? ckLocation1.Text : "";
                var location2 = ckLocation2.Checked ? ckLocation2.Text : "";
                SaveLogs(lbLine.Text, lbCF.Text, lbCode.Text, lbQuantity.Text, location1, location2, DateTime.Now);
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
                    ws.Cell("E" + newRow).Value = string.IsNullOrEmpty(Location1) ? "" : Location1.Split(':')[1].Trim();
                    ws.Cell("F" + newRow).Value = string.IsNullOrEmpty(Location2) ? "" : Location2.Split(':')[1].Trim();
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
