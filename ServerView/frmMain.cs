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

namespace ServerView
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmServer_Load(object sender, EventArgs e)
        {
            if (File.Exists("SSettings.xml"))
            {

                string xmlFile = "SSettings.xml";
                DataSet dsXML = new DataSet();
                dsXML.ReadXml(xmlFile, XmlReadMode.InferSchema);
                CFPath = dsXML.Tables["GeneralInfo"].Rows[0]["CFPath"].ToString();

                workbook = new XLWorkbook(CFPath);

                LogPath = dsXML.Tables["GeneralInfo"].Rows[0]["LogPath"].ToString();
            }
            if (File.Exists("mydb.db"))
                sqlite_conn = clsFunctions.CreateConnection();
            else
            {
                sqlite_conn = clsFunctions.CreateConnection();
                clsFunctions.CreateTable(sqlite_conn);
            }

            refreshData();
            Clear();
            if (!File.Exists("SSettings.xml"))
                lbLocation.Text = "Chưa chọn file chứa CF, vui lòng chọn ở Setting";
            else
                lbLocation.Text = "";
            btChecked.Enabled = false;

            if (clsFunctions.GetIPv4() != null)
            {
                foreach (string temp in clsFunctions.GetIPv4())
                {
                    lbIP.Text += " " + temp + " ";
                }
            }
            else { lbIP.Text += ""; }

            lbComputerName.Text += " " + clsFunctions.GetComputerName();


            th_StartListen = new Thread(new ThreadStart(StartListen));
            th_StartListen.Start();


        }
        private void StartListen()
        {
            //Creating a TCP Connection and listening to the port
            tcpListener = new TcpListener(System.Net.IPAddress.Any, 6666);
            tcpListener.Start();
            lbStatus.Text = "Listening on port 6666 ...";
            int counter = 0;
            appStatus = 0;

            while (appStatus != 2)
            {
                try
                {
                    client = tcpListener.AcceptTcpClient();
                    counter++;
                    clientList.Add(client);
                    IPEndPoint ipend = (IPEndPoint)client.Client.RemoteEndPoint;
                    //Updating status of connection
                    lbStatus.Text = "Connected from " + IPAddress.Parse(ipend.Address.ToString());

                    //lstUser.Items.Add(ipend.Address.ToString() + " " + counter);

                    appStatus = 1;
                    th_handleClient = new Thread(delegate () { handleClient(client, counter); });
                    th_handleClient.Start();

                }
                catch (Exception err)
                {

                }
            }
        }

        private void handleClient(object client, int i)
        {
            try
            {
                TcpClient streamData = (TcpClient)client;
                byte[] data = new byte[4096];
                byte[] sendData = new byte[4096];
                int byteRead;
                string strdata;
                ASCIIEncoding encode = new ASCIIEncoding();
                Thread.Sleep(1000);
                NetworkStream networkstream = streamData.GetStream();

                StreamWriter writer = new StreamWriter(networkstream);
                StreamReader reader = new StreamReader(networkstream);
                //Send Command 1
                sendData = encode.GetBytes("1");
                //networkstream.Write(sendData, 0, sendData.Length);
                writer.WriteLine(sendData);
                //networkstream.Flush();
                //Listen...
                while (true)
                {

                    //byteRead = 8;
                    //byteRead = networkstream.Read(data, 0, 4096);

                    if (networkstream.DataAvailable == true)
                    {


                        //MessageBox.Show(byteRead.ToString());
                        //strdata = Encoding.ASCII.GetString(data, 0, byteRead);
                        strdata = reader.ReadLine();
                        //Get user info
                        if (strdata.StartsWith("MESS"))
                        {

                            lbLine.Text = strdata.Split('/')[1];
                            lbCF.Text = strdata.Split('/')[2];
                            lbCode.Text = strdata.Split('/')[3];
                            lbQuantity.Text = strdata.Split('/')[4];
                            clsFunctions.InsertData(sqlite_conn, strdata.Split('/')[1], strdata.Split('/')[2], strdata.Split('/')[3], strdata.Split('/')[4]);
                            player.Play();
                            //refreshData();
                            // break;
                            timer1.Enabled = true;
                            Thread.Sleep(2000);
                            timer1.Enabled = false;
                        }
                        if (strdata.StartsWith("END"))
                        {

                        }
                    }
                }

            }
            catch (Exception)
            {

            }

        }
        void refreshData()
        {
            dt = clsFunctions.ExecuteReadQuery("Select * from LineInfo order by DATE DESC", sqlite_conn);
            dgv.AutoGenerateColumns = false;
            dgv.DataSource = dt;
        }
        void getDataByID(int id)
        {
            try
            {

            }
            catch { }
        }
        private void frmServer_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(Environment.ExitCode);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refreshData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                ckLocation1.Text = "Không tìm thấy vị trí";
                ckLocation1.Enabled = false;
                ckLocation2.Text = "Không tìm thấy vị trí";
                ckLocation2.Enabled = false;
                btChecked.Enabled = true;
                Clear();

                idLine = dgv.Rows[e.RowIndex].Cells["Id"].Value._Int();
                lbLine.Text = dgv.Rows[e.RowIndex].Cells["LINE"].Value.ToString();
                lbCF.Text = dgv.Rows[e.RowIndex].Cells["CF"].Value.ToString();
                lbCode.Text = dgv.Rows[e.RowIndex].Cells["CODE"].Value.ToString();
                lbQuantity.Text = dgv.Rows[e.RowIndex].Cells["Quantity"].Value.ToString();

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
                lblQuantity1.Text = $"Hiện có {qty1}";
                ckLocation1.Enabled = !string.IsNullOrEmpty(Location1);
                ckLocation1.Checked = !string.IsNullOrEmpty(Location1);

                // UI - Vị trí 2
                ckLocation2.Text = string.IsNullOrEmpty(Location2) ? "Vị trí mới: (Không có)" : $"Vị trí mới: {Location2}";
                lblQuantity2.Text = $"Hiện có {qty2}";
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
            btChecked.Enabled = true;

            lbLine.Text = "";
            lbCF.Text = "";
            lbCode.Text = "";
            lbQuantity.Text = "";
            lbLocation.Text = "";
        }
        private void btChecked_Click(object sender, EventArgs e)
        {
            try
            {
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
                clsFunctions.DeleteData(sqlite_conn, idLine);
                refreshData();
                Clear();
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
            frmServer_Setting f = new frmServer_Setting();
            if (f.ShowDialog() == DialogResult.OK)
                Clear();
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ckLocation2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lbLocation_Click(object sender, EventArgs e)
        {

        }
    }
    public class LineInfo
    {
        public string Line { get; set; }
        public string CF { get; set; }
        public string Code { get; set; }
        public string Quantity { get; set; }

    }
}
