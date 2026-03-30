using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.NetworkInformation;

namespace TC_CoilOperation
{
    public partial class MachineCheck : Form
    {
        public static int IOcountOPEN = 0;
        public static int IOcountCLOSE = 0;
        public static short Id = 0;
        public static int Ret;
        public static string szText = new string(' ', 100);
        public static short InpPortNo;
        public static byte InpPortData;
        public static bool IOCheckflag = false;//IOチェックが通っているかのフラグ
        public static int IOmode = 0;
        // reader / antenna / common / 005getconfig
        string g_read_cmd_header = "/reader/module/003status";
        //string g_read_cmd_header = " /reader/antenna/1/007getconfig";
        const int MBOX = 1;
        const int TBOX = 2;
        object g_api_lockObject = new object();
        public string[] tagname = new string[5] { "", "", "", "", "" };
        public int tagcount = 0;
        public string f = "";
        public bool RFIDflag = false;               　 //タグの読み取りが成功しているか？
        public static string tagId = "-";                    //コイルをつかんだ時のtagID
        public static string tagkbn;                   //区分格納用
        static public int RFIDcount = 0;                 //タグの読み取り回数
        public MachineCheck()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((MainScreen)Application.OpenForms["MainScreen"]).formChange(1);
        }
        void 距離計チェック()
        {
            bool Xflag = true;
            bool Yflag = true;
            bool Zflag = true;

            SerialPort X_serialPort = new SerialPort();
            //SerialPort Y_serialPort = new SerialPort();
            //SerialPort Z_serialPort = new SerialPort();



            // Allow the user to set the appropriate properties.
            X_serialPort.PortName = Properties.Settings.Default.xport_name;
            X_serialPort.BaudRate = Properties.Settings.Default.xbaudrate;
            X_serialPort.DataBits = Properties.Settings.Default.xdatabit;

            //Y_serialPort.PortName = Properties.Settings.Default.yport_name;
            //Y_serialPort.BaudRate = Properties.Settings.Default.ybaudrate;
            //Y_serialPort.DataBits = Properties.Settings.Default.ydatabit;

            //Z_serialPort.PortName = Properties.Settings.Default.zport_name;
            //Z_serialPort.BaudRate = Properties.Settings.Default.zport_name;
            //Z_serialPort.DataBits = Properties.Settings.Default.zport_name;
            X_serialPort.ReadTimeout = 5000;
            //Y_serialPort.ReadTimeout = 5000;
            //Z_serialPort.ReadTimeout = 5000;
            try
            {
                X_serialPort.Open();
                XCheck1.Text = "OK";
            }
            catch (Exception ex)
            {
                XCheck1.Text = "NG";
                Xflag = false;
            }

            try
            {
                //Y_serialPort.Open();
                YCheck1.Text = "OK";
            }
            catch (Exception ex)
            {
                YCheck1.Text = "NG";
                Yflag = false;
            }

            try
            {
                //Z_serialPort.Open();
                ZCheck1.Text = "OK";
            }
            catch (Exception ex)
            {
                ZCheck1.Text = "NG";
                Zflag = false;
            }
            if (Xflag == true)
            {
                try
                {
                    int xcount = 0;
                    for (; ; )
                    {
                        //タイムアウトの時に返ってくる戻り値によって処理
                        string serial_x = Convert.ToString(X_serialPort.ReadLine());
                        if (serial_x.Length == 15 && serial_x.IndexOf("+") == 0)
                        {
                            double xrenge = Convert.ToDouble(serial_x.Substring(1, 6));//距離計座標生値
                            if (xrenge != 0)
                            {
                                XCheck2.Text = "OK";
                                XCheck3.Text = "OK";
                                Xvalue.Text = Convert.ToString(xrenge);
                            }
                            else if (xcount == 50)
                            {
                                XCheck2.Text = "NG";
                                XCheck3.Text = "NG";
                                Xvalue.Text = "---";
                                Xflag = false;
                            }
                            else { xcount++; }
                        }

                    }
                }
                catch (Exception ex)
                {

                    XCheck2.Text = "NG";
                    Xflag = false;

                }
            }
            else
            {

                XCheck2.Text = "NG";
                XCheck3.Text = "NG";
                Xvalue.Text = "---";
            }
            if (Yflag == true)
            {

                try
                {
                    //int ycount = 0;
                    //for (; ; )
                    //{
                    //    //タイムアウトの時に返ってくる戻り値によって処理
                    //    string serial_y = Convert.ToString(Y_serialPort.ReadLine());
                    //    if (serial_y.Length == 15 && serial_y.IndexOf("+") == 0)
                    //    {
                    //        double yrenge = Convert.ToDouble(serial_y.Substring(1, 6));//距離計座標生値
                    //        if (yrenge != 0)
                    //        {
                    //            YCheck2.Text = "OK";
                    //            YCheck3.Text = "OK";
                    //            Yvalue.Text = Convert.ToString(yrenge);
                    //        }
                    //        else if (ycount == 50)
                    //        {
                    //            YCheck2.Text = "NG";
                    //            YCheck3.Text = "NG";
                    //            Yvalue.Text = "---";
                    //            Yflag = false;
                    //        }
                    //        else { ycount++; }
                    //    }

                    //}
                }
                catch (Exception ex)
                {

                    YCheck2.Text = "NG";
                    Yflag = false;
                }

            }
            else
            {

                YCheck2.Text = "NG";
                YCheck3.Text = "NG";
                Yvalue.Text = "---";
            }

            if (Zflag == true)
            {
                try
                {
                    //int zcount = 0;
                    //for (; ; )
                    //{
                    //    //タイムアウトの時に返ってくる戻り値によって処理
                    //    string serial_z = Convert.ToString(Z_serialPort.ReadLine());
                    //    if (serial_z.Length == 15 && serial_z.IndexOf("+") == 0)
                    //    {
                    //        double zrenge = Convert.ToDouble(serial_z.Substring(1, 6));//距離計座標生値
                    //        if (zrenge != 0)
                    //        {
                    //            ZCheck2.Text = "OK";
                    //            ZCheck3.Text = "OK";
                    //            Zvalue.Text = Convert.ToString(zrenge);
                    //        }
                    //        else if (zcount == 50)
                    //        {
                    //            ZCheck2.Text = "NG";
                    //            ZCheck3.Text = "NG";
                    //            Zvalue.Text = "---";
                    //            Zflag = false;
                    //        }
                    //        else { zcount++; }
                    //    }

                    //}
                }
                catch (Exception ex)
                {

                    ZCheck2.Text = "NG";
                    Zflag = false;
                }
            }
            else
            {

                ZCheck2.Text = "NG";
                ZCheck3.Text = "NG";
                Zvalue.Text = "---";
            }


        }
        void IOチェック()
        {
            Ret = DIO.ccapdio.DioInit(Properties.Settings.Default.Lifter_DIOid, ref Id);
            szText = "0";
            try
            {
                InpPortNo = Convert.ToInt16(szText);
                IO1.Text = "OK";
            }
            catch (System.FormatException)
            {
                InpPortNo = 0;
                IO1.Text = "NG";

            }
            //-----------------------------
            // ポート入力
            //-----------------------------
            Ret = DIO.ccapdio.DioInpByte(Id, InpPortNo, ref InpPortData);
            //-----------------------------
            //// エラー処理
            ////-----------------------------
            //DIO.ccapdio.DioGetErrorString(Ret, szError);
            //szReturnCode = "DioInpByte : " + szError;
            //Returntxt.Text = szReturnCode;
            //if (Ret != DIO.ccapdio.DIO_ERR_SUCCESS)
            //{
            //	return;
            //}
            //-----------------------------
            // データ表示
            //-----------------------------
            try
            {
                szText = string.Format("{0:X2}", InpPortData);
                string IO = Convert.ToString(InpPortData);
                if (szText == "3")
                {
                    IO3.Text = "OK";
                    IO4.Text = "OK";
                    IO3value.Text = "1";
                    IO4value.Text = "1";
                }
                else if (szText == "2")
                {
                    IO3.Text = "OK";
                    IO4.Text = "OK";
                    IO3value.Text = "1";
                    IO4value.Text = "0";
                }
                else if (szText == "1")
                {
                    IO3.Text = "OK";
                    IO4.Text = "OK";
                    IO3value.Text = "0";
                    IO4value.Text = "1";
                }
                else if (szText == "0")
                {
                    IO3.Text = "OK";
                    IO4.Text = "OK";
                    IO3value.Text = "0";
                    IO4value.Text = "0";
                }
            }
            catch (Exception ex)
            {
                IO3.Text = "NG";
                IO4.Text = "MG";
                IO3value.Text = "-";
                IO4value.Text = "-";
            }
        }
        void RFID()
        {
            exec_set_commands("/reader/inventory/012setconfig?get_chanid_flg=1&get_phase_flg=1&get_seentime_flg=1&stop_timer=" + Properties.Settings.Default.antena_stoptime);
            exec_set_commands("/reader/antenna/1/008setconfig?antennastatus=1&powerlevel=" + Properties.Settings.Default.antena_decibel);
            button_start_Click_sub();

        }

        private bool button_start_Click_sub()
        {
            g_read_cmd_header = "/reader/inventory/01";
            string result = send_http_message(g_read_cmd_header + "3start");
            if (json_get(result, "response") == "0")
            {

                show_status();
                timer1.Enabled = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        private void show_status()
        {
            send_http_message(g_read_cmd_header + "5status");
        }
        private bool exec_set_commands(string request)
        {
            if (!request.StartsWith("#"))
            {
                string[] request_split = request.Split(';');
                for (int j = 0; j < request_split.Length; j++)
                {
                    string request2 = request_split[j];
                    if (request2.StartsWith("/reader/") && (request2.IndexOf("getconfig") >= 0 || request2.IndexOf("status") >= 0 || request2.IndexOf("reset") >= 0 || request2.IndexOf("setconfig") >= 0))
                    {
                        string result = send_http_message(request2);
                        if (json_get(result, "response") != "0")
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private string json_get(string json, string search)
        {
            json = json.Replace("\r", "");
            string[] json_split = json.Split('\n');
            for (int i = 0; i < json_split.Count(); i++)
            {
                string tmp = json_get_single_line(json_split[i], search);
                if (tmp != null) return tmp;
            }
            return "";
        }

        private string json_get_single_line(string json, string search)
        {
            if (json.StartsWith("\"" + search + "\":"))
            {
                return json.Substring(search.Length + 3).Replace("\"", "").Replace(",", "");
            }
            return null;
        }

        private string send_http_message(string request)
        {
            lock (g_api_lockObject)
            {

                string result = "";
                Log_WriteLine("ProcessHttpApi() request=" + request, TBOX);
                result = ProcessHttpApi("192.168.4.156", 8888, request, "User", "Pass");
                show_result(result);
                return result;
            }
        }

        private string ProcessHttpApi(string ip, int port, string url, string user, string pass)
        {
            string response = "";
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.Proxy = null;
                if (user != "") wc.Credentials = new System.Net.NetworkCredential(user, pass);
                System.IO.Stream st = wc.OpenRead("http://" + ip + ":" + port + url);
                System.IO.StreamReader sr = new System.IO.StreamReader(st, System.Text.Encoding.GetEncoding("us-ascii"));
                response = sr.ReadToEnd().ToString();
                sr.Close();
                st.Close();
                wc.Dispose();
            }
            catch
            {
                response = "{\r\n\"response\":\"9999\"\r\n\"message\":\"exception_occured\"\r\n}";
            }
            return response;
        }

        private void Log_WriteLine(String msg, int type)
        {
            Log_WriteLine(msg);
            if (type >= TBOX)
            {
                //string[] each_line = textBox_display.Text.Split('\n');
                //if (each_line.Length >= 1000) textBox_display.Text = "";
                //textBox_display.AppendText(msg + "\r\n");
                string a = msg;
                type -= TBOX;
            }
            if (type >= MBOX)
            {
                MessageBox.Show(msg);
            }
        }

        private void Log_WriteLine(String msg)
        {
            string format = DateTime.Now.ToString("yy/MM/dd HH:mm:ss.fff ") + msg;
            //if (g_stream_log != null) g_stream_log.WriteLine(format);
        }

        private bool show_result(string result)
        {
            if (json_get(result, "response") == "0")
            {
                if (result.IndexOf("x001Epc") >= 0)
                {
                    show_result_taglist(result);
                    return true;
                }
                else
                {
                    Log_WriteLine("○成功 result=" + result.Replace("\r\n", " "), TBOX);
                    Log_WriteLine("", TBOX);
                    return true;
                }
            }
            else
            {
                Log_WriteLine("★★★ ERROR: result=" + result.Replace("\r\n", " "), TBOX);
                Log_WriteLine("", TBOX);
                return false;
            }
        }

        private bool show_result_taglist(string result)
        {
            int num = 0;
            string result_without_taglist = "";
            string tmp = "";
            string Epc = "";
            string Rssi = "";
            string Phase = "";
            string AntId = "";
            string ChanId = "";
            string SeenTime = "";
            string AccessData = "";
            result = result.Replace("\r", "");
            string[] result_split = result.Split('\n');
            for (int i = 0; i < result_split.Count(); i++)
            {
                tmp = json_get_single_line(result_split[i], "x" + (num + 1).ToString("D3") + "Epc");
                if (tmp != null)
                {
                    if (num > 0) show_result_taglist_sub(ref Epc, ref Rssi, ref Phase, ref AntId, ref ChanId, ref SeenTime, ref AccessData);
                    Epc = tmp;
                    num++;
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "Rssi");
                if (tmp != null)
                {
                    if (tmp.Length > 1)
                    {
                        Rssi = tmp.Substring(0, tmp.Length - 1) + "." + tmp.Substring(tmp.Length - 1) + "dBm";
                    }
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "Phase");
                if (tmp != null)
                {
                    Phase = tmp;
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "AntId");
                if (tmp != null)
                {
                    AntId = tmp;
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "ChanId");
                if (tmp != null)
                {
                    ChanId = tmp;
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "SeenTime");
                if (tmp != null)
                {
                    if (tmp.Length > 6)
                    {
                        SeenTime = tmp.Substring(0, tmp.Length - 3);
                        DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(Double.Parse(SeenTime)).ToLocalTime();
                        SeenTime = dt.ToString("yyyy/MM/dd HH:mm:ss.fff");
                    }
                    continue;
                }
                tmp = json_get_single_line(result_split[i], "x" + (num).ToString("D3") + "AccessData");
                if (tmp != null)
                {
                    AccessData = tmp;
                    continue;
                }
                result_without_taglist += result_split[i] + " ";
            }
            if (num > 0) show_result_taglist_sub(ref Epc, ref Rssi, ref Phase, ref AntId, ref ChanId, ref SeenTime, ref AccessData);
            Log_WriteLine("○成功 result=" + result_without_taglist, TBOX);
            Log_WriteLine("", TBOX);
            return true;
        }

        private void show_result_taglist_sub(ref string Epc, ref string Rssi, ref string Phase, ref string AntId, ref string ChanId, ref string SeenTime, ref string AccessData)
        {
            if (Epc != string.Empty)
            {

                if (tagcount != 3)
                {
                    tagname[tagcount] = Epc + "\r\n";
                    tagcount++;
                }

            }
            Log_WriteLine("       taglist: Epc=" + Epc + " AntId=" + AntId + " ChanId=" + ChanId + " Rssi=" + Rssi + " Phase=" + Phase + " SeenTime=" + SeenTime + " AccessData=" + AccessData, TBOX);
            Epc = "";
            Rssi = "";
            Phase = "";
            AntId = "";
            ChanId = "";
            SeenTime = "";
            AccessData = "";

        }
        void allclear()
        {
            XCheck1.Text = "";
            XCheck2.Text = "";
            XCheck3.Text = "";
            Xvalue.Text = "";

            YCheck1.Text = "";
            YCheck2.Text = "";
            YCheck3.Text = "";
            Yvalue.Text = "";

            ZCheck1.Text = "";
            ZCheck2.Text = "";
            ZCheck3.Text = "";
            Zvalue.Text = "";

            RFID1.Text = "";
            RFID2.Text = "";

            IO1.Text = "";
            IO2.Text = "";
            IO3.Text = "";
            IO3value.Text = "";
            IO4.Text = "";
            IO4value.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MachineCheckList.Items.Clear();
            allclear();
            
           
            string Xaddress = Properties.Settings.Default.XcomIP;
            string Yaddress = Properties.Settings.Default.YcomIP;
            string Zaddress = Properties.Settings.Default.ZcomIP;
            string RFID = Properties.Settings.Default.RFIDcomIP;
            string DIO = Properties.Settings.Default.DIOcomIP;
            if (OperationScreen.Xvalue != -99999&& OperationScreen.Xvalue != -99998&& OperationScreen.Xvalue != -99997)
            {
                XCheck1.Text = "OK";
                XCheck2.Text = "OK";
                XCheck3.Text = "OK";
                Xvalue.Text = Convert.ToString(OperationScreen.Xvalue);
                MachineCheckList.Items.Add("X軸距離計異常なし");
            }
            else
            {
                if(OperationScreen.Xvalue != -99999)
                {
                    XCheck1.Text = "OK";
                    XCheck2.Text = "OK";
                    XCheck3.Text = "NG";
                    Xvalue.Text = "NG";
                    MachineCheckList.Items.Add("X軸距離計値取得エラー");
                }
                else if(OperationScreen.Xvalue != -99998)
                {
                    XCheck1.Text = "NG";
                    XCheck2.Text = "NG";
                    XCheck3.Text = "NG";
                    Xvalue.Text = "NG";
                    MachineCheckList.Items.Add("X軸距離計ping応答なし");
                }
                else
                {
                    XCheck1.Text = "NG";
                    XCheck2.Text = "NG";
                    XCheck3.Text = "NG";
                    Xvalue.Text = "NG";
                    MachineCheckList.Items.Add("X軸距離計openエラー");
                }

            }

            if (OperationScreen.Yvalue != -99999 && OperationScreen.Yvalue != -99998 && OperationScreen.Yvalue != -99997)
            {
                YCheck1.Text = "OK";
                YCheck2.Text = "OK";
                YCheck3.Text = "OK";
                Yvalue.Text = Convert.ToString(OperationScreen.Yvalue);
                MachineCheckList.Items.Add("Y軸距離計異常なし");
            }

            else
            {


                if (OperationScreen.Yvalue != -99999)
                {
                    YCheck1.Text = "OK";
                    YCheck2.Text = "OK";
                    YCheck3.Text = "NG";
                    Yvalue.Text = "NG";
                    MachineCheckList.Items.Add("Y軸距離計値取得エラー");
                }
                else if (OperationScreen.Yvalue != -99998)
                {
                    YCheck1.Text = "NG";
                    YCheck2.Text = "NG";
                    YCheck3.Text = "NG";
                    Yvalue.Text = "NG";
                    MachineCheckList.Items.Add("Y軸距離計ping応答なし");
                }
                else
                {
                    YCheck1.Text = "NG";
                    YCheck2.Text = "NG";
                    YCheck3.Text = "NG";
                    Yvalue.Text = "NG";
                    MachineCheckList.Items.Add("Y軸距離計openエラー");
                }

            }

            if (OperationScreen.Zvalue != -99999 && OperationScreen.Zvalue != -99998 && OperationScreen.Zvalue != -99997)
            {
                ZCheck1.Text = "OK";
                ZCheck2.Text = "OK";
                ZCheck3.Text = "OK";
                MachineCheckList.Items.Add("Z軸距離計異常なし");
                Zvalue.Text = Convert.ToString(OperationScreen.Zvalue);
            }
            else
            {
                if (OperationScreen.Zvalue != -99999)
                {
                    ZCheck1.Text = "OK";
                    ZCheck2.Text = "OK";
                    ZCheck3.Text = "NG";
                    Zvalue.Text = "NG";
                    MachineCheckList.Items.Add("Z軸距離計値取得エラー");
                }
                else if (OperationScreen.Zvalue != -99998)
                {
                    ZCheck1.Text = "NG";
                    ZCheck2.Text = "NG";
                    ZCheck3.Text = "NG";
                    Zvalue.Text = "NG";
                    MachineCheckList.Items.Add("Z軸距離計ping応答なし");
                }
                else
                {
                    ZCheck1.Text = "NG";
                    ZCheck2.Text = "NG";
                    ZCheck3.Text = "NG";
                    Zvalue.Text = "NG";
                    MachineCheckList.Items.Add("Z軸距離計openエラー");
                }

            }
            //RFIDチェック
            Ping RFIDsender = new Ping();

            PingReply RFIDreply = RFIDsender.Send(RFID);//送信モジュール
            if (RFIDreply.Status != IPStatus.Success)
            {
                RFID1.Text = "NG";
                RFID2.Text = "NG";
                MachineCheckList.Items.Add("RFIDping応答なし");

            }
            else
            {
                RFID1.Text = "OK";


                string result = send_http_message(g_read_cmd_header);
                string[] RFIDresult = new string[10];
                RFIDresult = result.Replace("\r\n", "\n").Split(new[] { '\n', '\r' });
                if (RFIDresult.Length >= 5)
                {
                   
                    RFID2.Text = "OK";

                    MachineCheckList.Items.Add("RFID異常なし");
                }
                else
                {
                   
                    RFID2.Text = "NG";

                    MachineCheckList.Items.Add("RFIDステータス異常");
                }
            }
            //IOチェック
                if (OperationScreen.IOerrflag == true)
                {
                    IO1.Text = "OK";
                    IO2.Text = "OK";
                    if (OperationScreen.bit1value == true)
                    {
                        IO3.Text = "OK";
                        IO3value.Text = "1";

                    }
                    else
                    {
                        IO3.Text = "OK";
                        IO3value.Text = "0";
                    }
                    if (OperationScreen.bit2value == true)
                    {
                        IO4.Text = "OK";
                        IO4value.Text = "1";
                    }
                    else
                    {
                        IO4.Text = "OK";
                        IO4value.Text = "0";
                    }
                    MachineCheckList.Items.Add("DIO異常なし");
                }
                else
                {
                    string DIOaddress = Properties.Settings.Default.DIOcomIP;
                    IO3.Text = "NG";
                    IO4.Text = "NG";
                    IO3value.Text = "NG";
                    IO4value.Text = "NG";

                    Ping DIOsender = new Ping();

                    PingReply DIOreply = DIOsender.Send(DIOaddress);//送信モジュール
                    if (DIOreply.Status != IPStatus.Success)
                    {

                        IO1.Text = "NG";
                        IO2.Text = "NG";
                        MachineCheckList.Items.Add("DIO未接続");
                    }
                    else
                    {
                        IO1.Text = "OK";
                        IO2.Text = "NG";
                        MachineCheckList.Items.Add("DIO本体異常");
                    }
                }
            
            
            //Crane_point_x
            //各距離計の値を取得できているかの確認
            //できていなければできていない距離計のpingチェック
            //IOが取れなくなった場合
            //pingチェック
            //RFIDステータス確認のコマンドを投げる
            //できるだけエラーチェックできるようにする
            //OperationScreen.ALLstopflag = true;
            //for (; ; )
            //{
            //    if (OperationScreen.Theading_refresh_OKflag == true && OperationScreen.Threading_IO_OKflag == true && OperationScreen.Threading_lazer_OKflag == true)
            //    {
            //        break;
            //    }
            //}
            //距離計チェック();
            //IOチェック();
            //RFID();
            //OperationScreen.ALLstopflag = false;
            //各機種の通信チェックを行いそれぞれが正常かそうでないかをリストボックスに記入する処理を追加
            //X軸距離計チェック
            //if(serialportx.Open==true){MachineCheckList.add(0,232接続チェック正常)
            //if(X軸レーザの通信関数が正常の場合){
            //label15.Text = "OK";
            //listBox1.Items.Insert(0, "RS422メディアコンバータ（X軸）チェック正常");
            //  if(X軸距離取得成功){
            //      label38.Text=距離計の値;
            //      label32.Text = "OK";
            //      label27.Text = "OK";
            //      listBox1.Items.Insert(0, "距離計取得（X軸）チェック正常");
            //  }
            //  else{label32.Text = "NG";label27.Text = "NG";listBox1.Items.Insert(0, "距離計取得（X軸）チェック異常");}
            //}
            //else{label15.Text = "NG";　listBox1.Items.Insert(0, "RS422メディアコンバータ（X軸）異常");}


            //Y軸距離計チェック
            //if(serialportx.Open==true){MachineCheckList.add(0,232接続チェック正常)
            //if(Y軸レーザの通信関数が正常の場合){
            //label17.Text = "OK";
            //listBox1.Items.Insert(0, "RS422メディアコンバータ（Y軸）チェック正常");
            //  if(X軸距離取得成功){
            //      label42.Text=距離計の値;
            //      label33.Text = "OK";
            //      label28.Text = "OK";
            //      listBox1.Items.Insert(0, "距離計取得（Y軸）チェック正常");
            //  }
            //  else{label33.Text = "NG";label28.Text = "NG";listBox1.Items.Insert(0, "距離計取得（Y軸）チェック異常");}
            //}
            //else{label17.Text = "NG";　listBox1.Items.Insert(0, "RS422メディアコンバータ（Y軸）異常");}

            //Z軸距離計チェック
            //if(serialportx.Open==true){MachineCheckList.add(0,232接続チェック正常)
            //if(Z軸レーザの通信関数が正常の場合){
            //label24.Text = "OK";
            //listBox1.Items.Insert(0, "RS422メディアコンバータ（Z軸）チェック正常");
            //  if(X軸距離取得成功){
            //      label39.Text=距離計の値;
            //      label34.Text = "OK";
            //      label29.Text = "OK";
            //      listBox1.Items.Insert(0, "距離計取得（Z軸）チェック正常");
            //  }
            //  else{label34.Text = "NG";label29.Text = "NG";listBox1.Items.Insert(0, "距離計取得（Z軸）チェック異常");}
            //}
            //else{label24.Text = "NG";　listBox1.Items.Insert(0, "RS422メディアコンバータ（Z軸）異常");}

            //RFIDチェック
            //if(RFID通信関数が正常の場合){
            //label25.Text = "OK";
            //listBox1.Items.Insert(0, "RFIDチェック正常");
            //  if(RFID値取得成功){
            //      label40.Text=RFIDの値;
            //      label35.Text = "OK";
            //      label30.Text = "OK";
            //      listBox1.Items.Insert(0, "RFIDチェック正常");
            //  }
            //  else{label35.Text = "NG";label30.Text = "NG";listBox1.Items.Insert(0, RFIDチェック異常");}
            //}
            //else{label25.Text = "NG";　listBox1.Items.Insert(0, "RFIDチェック異常");}

            //DIモジュール用CPUチェック
            //if(DIモジュール通信関数が正常の場合){
            //label26.Text = "OK";
            //listBox1.Items.Insert(0, "DIモジュール用CPUチェック正常");
            //  if(DIモジュールIO取得成功){
            //      label41.Text=DIモジュールIOの値;
            //      label36.Text = "OK";
            //      label31.Text = "OK";
            //      listBox1.Items.Insert(0, "DIモジュール用CPUチェック正常");
            //  }
            //  else{label36.Text = "NG";label31.Text = "NG";listBox1.Items.Insert(0, DIモジュール用CPUチェック異常");}
            //}
            //else{label26.Text = "NG";　listBox1.Items.Insert(0, "DIモジュール用CPUチェック異常");}
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //もしかしたらフラグチェックでストップ
            string result = send_http_message(g_read_cmd_header + "4getlist");
            if (json_get(result, "status").StartsWith("stopped") && RFIDflag == false)
            {

                //string f = tagname[0];
                //string b = tagname[1];
                //string c = tagname[2];
                //string d = tagname[3];
                if (tagname[0] != string.Empty)
                {
                    //複数読み取った場合の処理
                    string h = Convert.ToString(tagname[0]).Substring(22, 7);
                    h = h.Replace("-", "");
                    RFID1.Text = "OK";
                    RFID2.Text = "OK";
                    
                    //ここからDB等の処理に移行
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                    RFIDflag = true;
                    RFIDcount = 0;
                    timer1.Enabled = false;

                }
                else
                {
                    RFIDcount++;
                    if (RFIDcount == 3)
                    {
                        RFID1.Text = "NG";
                        RFID2.Text = "NG";
                       
                        RFIDcount = 0;
                        timer1.Enabled = false;
                        return;
                    }
                    timer1.Start();
                }
                //show_status();
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }

        private void MachineCheck_Load(object sender, EventArgs e)
        {

        }
    }
}
