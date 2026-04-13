//2022/06/13
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
using System.Net.Security;

namespace TC_CoilOperation
{
   
    /// <summary>
    /// クレーン位置、コイル配置情報を表示するform
    /// </summary>
    public partial class OperationScreen : Form
    {
        
        public static string ShowMSG = "";
        public static string MSG1 = "クレーン座標より離れているタグを読み取りました。\nこのタグに対して操作を行いますか？";
        public static string MSG2 = "ロケーション情報のないタグを読み取りました。\nこのタグに対して作業を行いますか？";
        public static string Nodatacoil = "XX-XX-XX";

        public static int IOcount = 0;              //テストプログラム
        public static string テストIOタイマースタート確認="";                    //テスト

        static public bool multitagflag = false;    //複数読みフラグ
        static public int Xerrcount = 0;            //複数回エラー処理をしない為の変数
        static public int Yerrcount = 0;            //複数回エラー処理をしない為の変数
        static public int Zerrcount = 0;            //複数回エラー処理をしない為の変数
        static public bool Xerrvalue = false;         //Xreadtimeerr
        static public bool Yerrvalue = false;         //Yreadtimeerr
        static public bool Zerrvalue = false;         //Zreadtimeerr
        public static int Xvalue=-99999;                   //X距離計値
        public static int Yvalue=-99999;                   //Y距離計値
        public static int Zvalue=-99999;                   //Z距離計値
        public static string IOvalue;                    //IO値

        public static string testtest = "";
        public static bool lazerflag = false;       //距離計クローズフラグ
        public static bool lazerCloseflag = false;   //距離計シリアルオープンフラグ
        public static string caveat = "0";          //注意、警告エリア侵入フラグ
        public static string caveatflag = "0";        //注意、警告エリア侵入解除フラグ

        public static string xzicksta = "0";       //距離計ステータス
        public static string yzicksta = "0";       //距離計ステータス
        public static string zzicksta = "0";       //距離計ステータス

        public static string IOsta = "0";          //IOステータス
        public static string RFIDsta = "0";        //RFIDステータス
        public static bool RFIDContinuousflag = false;//連続確認フラグ
        

        public static bool bit1value = false;    //bit1
        public static bool bit2value = false;    //bit2
        public static int status = 0;           //アラームエリア判別用
        public static bool ALLstopflag = false;      // 機器チェック用フラグ 
        public static bool Threading_IO_OKflag = false;//IO処理中断フラグ
        public static bool Threading_lazer_OKflag = false;//距離計処理中断フラグ
        public static bool Theading_refresh_OKflag = false;//リフレッシュ処理中断フラグ
        public static int targetcntNo = -1;          // 目標コイル場所特定
        public static int targetcnt = 0;             // 目標コイル場所
        public static int testCrane_point_x = 1;     //クレーン位置保存用test用
        public static int testCrane_point_y = 1;     //クレーン位置保存用test用


        public static DateTime dateTime;            //比較用時刻
        public static DateTime datetime;            //比較用時刻移動距離保存用
        public static string time;
        //public static DateTime date_day;                 //比較用時刻
        //public static int Crane_point_x = -99999;     //クレーン位置保存用
        //public static int Crane_point_y = -99999;     //クレーン位置保存用
        //public static int Crane_point_z = -99999;     //クレーン位置保存用

        public static int Crane_point_x = 9999;     //クレーン位置保存用(test)
        public static int Crane_point_y = 9999;     //クレーン位置保存用(test)
        public static int Crane_point_z = 9999;     //クレーン位置保存用(test)

        public static string Crane_x = "1";     //現在のクレーン位置保存用
        public static string Crane_y = "1";     //現在のクレーン位置保存用
        public static string mozi = "-";    //クレーン文字と入れ替わった文字

        public static string Location_x = "-";       //ロケーション位置保存用
        public static string Location_y = "-";       //ロケーション位置保存用
        public static string Location_z = "-";       //ロケーション位置保存用

        public static string CLocation_x = "-";       //クレーンロケーション位置保存用
        public static string CLocation_y = "-";       //クレーンロケーション位置保存用


        //public static string Location_x = "10";       //ロケーション位置保存用(test)
        //public static string Location_y = "9";       //ロケーション位置保存用(test)
        //public static string Location_z = "8";       //ロケーション位置保存用(test)

        public static string Targetcoil = "";       //目標コイルのタグID
        public static bool IOflag = false;          //I/Oチェックフラグ

        public static int low_coil = 0;             //列コイル
        public static int col_coil = 0;             //連コイル

        public static int[] Com = new int[15];   //コイル配列
        public static string[] day = new string[15];          //日付
        //クレーン用
        static bool xOpenflag = true;
        static bool yOpenflag = true;
        static bool zOpenflag = true;
        //RFID用
        public static string Clocation = "XX-XX-XX";  //クレーンロケーション
        public static int coilpointX = 0;             //コイル座標X
        public static int coilpointY = 0;             //コイル座標Y
        public static int coilpointZ = 0;             //コイル座標Z
        public static string coillocX = "0";               //コイルロケX
        public static string coillocY = "0";               //コイルロケY
        public static string coillocZ = "0";               //コイルロケZ
        public static string coilloc = "0";               //コイルロケ
        public static int ClenpointX = Crane_point_x; //クレーン座標X
        public static int ClenpointY = Crane_point_y; //クレーン座標Y
        public static int ClenpointZ = Crane_point_z; //クレーン座標Z
        public static string 現品番号 = "現品情報無し";
        public static int CpointX = -99999;                         //DBから取得した掴んだコイルのX距離
        public static int CpointY = -99999;                         //DBから取得した掴んだコイルのY距離
        public static int CpointZ = -99999;                         //DBから取得した掴んだコイルのZ距離
        string g_read_cmd_header = "/reader/inventory/01";
        const int MBOX = 1;
        const int TBOX = 2;
        object g_api_lockObject = new object();
        public static string[] tagname = new string[5] { "", "", "", "", "" };
        public int tagcount = 0;
        public string f = "";
        public static bool RFIDflag = false;               　 //タグの読み取りが成功しているか？
        public static string tagId = "-";                    //コイルをつかんだ時のtagID
        public static string tagkbn;                   //区分格納用
        static public int RFIDcount = 0;                 //タグの読み取り回数
        public static bool 重複処理フラグ = false;              //読み取り処理重複実行防止　20240626 山﨑

        //DB移動履歴保存用
        public static string 対象現品No = "";
        public static string YARDID = Properties.Settings.Default.YardID;//ニッセイコムDB検索用ID
        public static string idYard = Properties.Settings.Default.IDYARD;//自社DB検索用ID

        public static string idCrane = "1";            //クレーンIDは固定
        public static string cdMove = "1";              //作業区分0入庫／1出庫／2配替／9その他
        public static string cdTongs = "1";             //0連動／1手動
        public static DateTime 移動開始時刻;            //タグをつかんだ瞬間の時間
        public static string PC名 = Environment.MachineName;
        public static string 移動前X = "-99";               //移動前ロケ
        public static string 移動前Y = "-99";
        public static string 移動前Z = "-99";

        //IO用
        public static StringBuilder szError = new StringBuilder("", 256);     // エラー文字列
        public static bool IOerrflag = true;
        public static int IOcountOPEN = 0;
        public static int IOcountCLOSE = 0;
        public static short Id = 0;
        public static int Ret;
        public static string szText = new string(' ', 100);
        public static short InpPortNo;
        public static byte InpPortData;
        public static bool IOCheckflag = false;          //IOチェックが通っているかのフラグ
        public static int IOmode = 0;
        public static int tagreadcnt = 0;                //タグの読み取り失敗回数
        public static string def_decibel = Properties.Settings.Default.antena_decibel;

        public static bool フリーエリア判定結果 = false;      //フリーエリアに置いたかどうかの判定フラグ

        //距離計用
        public static bool xrengeerr = true;            //X距離計値取得フラグ
        public static bool yrengeerr = true;            //Y距離計値取得フラグ
        public static bool zrengeerr = true;            //Z距離計値取得フラグ

        //フリーエリア用変数
        public static string Xロケ = Properties.Settings.Default.Free_X;               //Xロケーション
        public static string Yロケ = "1";              //Yロケーション

        public static readonly string[] arrayFreeArea = { "36-1", "36-2", "36-3", "36-4", "36-5", "36-6" };//2024.6.5 OGURI ADD フリーエリア名を配列で保持（ボタン名・コンボItem・DB問い合わせに使用）

        //20240621 morichika
        public static bool FreeAreaRefreshflg = false;


    int LabelNo = 0;
        // timer重入防止フラグ // 非同期化、重い処理をバックグラウンド実行に変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
        private volatile bool _ioProcessing = false;
        private volatile bool _rfidProcessing = false;
        private volatile bool _coordinateProcessing = false;
        public OperationScreen()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //出庫情報のダイアログを表示する
            Shipping_information f1 = new Shipping_information();
            f1.ShowDialog();
            //リフレッシュ処理
            disp();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Detail_View.SelectX = Convert.ToDecimal(coil_view.CurrentCellAddress.X) + 1;

            //選択された列の情報を元に表示
            //コイル詳細表示のダイアログを表示する
            if (Detail_View.SelectX != 0)
            {
                Detail_View f = new Detail_View();
                //f.view();
                f.timer1.Start();
                f.ShowDialog();
                //リフレッシュ処理
                disp();
            }

        }

        static public void フリーエリア判定()
        {
            if(OperationScreen.Location_x== Properties.Settings.Default.Free_X)
            {
                フリーエリア判定結果 = true;
                if (Properties.Settings.Default.Free_manual_mode == true)
                {
                    フリーエリア_確認画面 f = new フリーエリア_確認画面();
                    f.Location = new Point(440, 450);
                    f.StartPosition = FormStartPosition.Manual;
                    f.ShowDialog();
                }
            }
            else { フリーエリア判定結果= false; }

        }

        private void 開信号ボタン_Click(object sender, EventArgs e)
        {
            
            //テスト用20240613 山﨑
            //-------------------------------------
            //tagId = "000004";//テスト20240531
            //-------------------------------------
            
            
            //-----------------------------------------------------------------------
            //2024.06.17 morichika
            IO.Stop();

            try
            {
                IOCheckflag = true;
                IOmode = 2;
                io_process();
            }
            finally
            {
                IO.Start();

            }

            //if (Properties.Settings.Default.Lifter_Manualmode == true && tagId != "-")
            //{
            //    //OperationScreen.Location_x = "5";
            //    //OperationScreen.Location_y = "5";
            //    //OperationScreen.Location_z = "1";
            //    //OperationScreen.tagId = "000023";
            //    // ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(6);
            //    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
            //    //配替と出庫の判定は全てがブランクかどうか
            //    if (cdMove == "0" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//入庫
            //    {
            //        フリーエリア判定();
            //        cdMove = "0";
            //        tagkbn = "入庫";
                    
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(15);
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
            //    }
            //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//配替
            //    {
            //        フリーエリア判定();
            //        cdMove = "2";
            //        tagkbn = "配替";
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(16);
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
            //    }
            //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x == "-" && OperationScreen.Location_y == "-" && OperationScreen.Location_z == "-")//出庫
            //    {
            //        cdMove = "1";
            //        tagkbn = "出庫";
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(17);
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
            //    }
            //    else if (cdMove == "0" && OperationScreen.Location_x == "-" || OperationScreen.Location_y == "-" || OperationScreen.Location_z == "-")//その他
            //    {
            //        //その他の処理
            //        cdMove = "9";
            //        tagkbn = "入庫";
            //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
            //    }
            //    else if (cdMove == "9")
            //    {
            //        //その他の処理
            //    }
            //    else
            //    {
            //        MessageBox.Show("ロケーションの値が参照できない為処理が行えませんでした"); //エラー表示
            //    }
            //    //リセット処理
            //    tagdispreset();
            //    RFIDflag = false;

            //    //24/6/17 morichika
            //    //((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).disp();

            //    disp();
                //-----------------------------------------------------------------------

            //}


        }

        public void test()
        {

            //2024.06.17 morichika
            IO.Stop();

            try
            {

                tagId = "000004";//テスト20240531
    
                //----------------------------------------------------------------------------
                //2024.06.17 morichika
                IOCheckflag = true;
                IOmode = 2;
                io_process();
                ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).disp();

                //if (Properties.Settings.Default.Lifter_Manualmode == true && tagId != "-")
                //{
                //    //OperationScreen.Location_x = "5";
                //    //OperationScreen.Location_y = "5";
                //    //OperationScreen.Location_z = "1";
                //    //OperationScreen.tagId = "000023";
                //    // ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(6);
                //    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                //    //配替と出庫の判定は全てがブランクかどうか
                //    if (cdMove == "0" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//入庫
                //    {
                //        フリーエリア判定();
                //        cdMove = "0";
                //        tagkbn = "入庫";

                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(15);
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                //    }
                //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//配替
                //    {
                //        フリーエリア判定();
                //        cdMove = "2";
                //        tagkbn = "配替";
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(16);
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
                //    }
                //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x == "-" && OperationScreen.Location_y == "-" && OperationScreen.Location_z == "-")//出庫
                //    {
                //        cdMove = "1";
                //        tagkbn = "出庫";
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(17);
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
                //    }
                //    else if (cdMove == "0" && OperationScreen.Location_x == "-" || OperationScreen.Location_y == "-" || OperationScreen.Location_z == "-")//その他
                //    {
                //        //その他の処理
                //        cdMove = "9";
                //        tagkbn = "入庫";
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                //    }
                //    else if (cdMove == "9")
                //    {
                //        //その他の処理
                //    }
                //    else
                //    {
                //        MessageBox.Show("ロケーションの値が参照できない為処理が行えませんでした"); //エラー表示
                //    }
                //    //リセット処理
                //     ((OperationScreen)Application.OpenForms["OperationScreen"]).tagdispreset();

                //    OperationScreen.RFIDflag = false;
                //    ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).disp();
                //    ((OperationScreen)Application.OpenForms["OperationScreen"]).disp();

                //}
            }
            finally
            {
                IO.Start();
            }
        }
        //
        public void tagdispreset()
        {
            対象現品No = "";
            Classification.Text = "--";
            tagID.Text = "--";
            APNo.Text = "--";
            weight.Text = "--";
            size.Text = "--";
            tagId = "-";
            ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(1, Convert.ToString(tagId));//テストプログラム
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //トングが閉じたとき
            if (Properties.Settings.Default.Lifter_Manualmode == true && tagId == "-")
            {
                for (int i = 0; i < tagname.Length; i++)
                {
                    tagname[i] = "";
                }
                tagcount = 0;
                exec_set_commands("/reader/inventory/012setconfig?get_chanid_flg=1&get_phase_flg=1&get_seentime_flg=1&stop_timer=" + Properties.Settings.Default.antena_stoptime);
                exec_set_commands("/reader/antenna/1/008setconfig?antennastatus=1&powerlevel=" + Properties.Settings.Default.antena_decibel);
                button_start_Click_sub();
                if (tagreadcnt == 0)
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(20);
                }
                else
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(21);
                }




                //タグを読む
                //DBにアクセスしデータを取得
                //表示
            }

        }
        private bool button_start_Click_sub()
        {
            g_read_cmd_header = "/reader/inventory/01";
            string result = send_http_message(g_read_cmd_header + "3start");
            if (json_get(result, "response") == "0")
            {

                show_status();
                RFIDtimer.Enabled = true;
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
                result = ProcessHttpApi(Properties.Settings.Default.RFIDcomIP, 8888, request, "User", "Pass");
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
            catch(Exception ex)
            {
                string a = Convert.ToString(ex);
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

        private void show_result_taglist_sub(ref string Epc, ref string Rssi, ref string Phase, ref string AntId, ref string ChanId, ref string SeenTime, ref string AccessData)//タグ読み取り挿入
        {
            if (Epc != string.Empty)
            { 
                string b = Convert.ToString(Epc).Substring(0, 14);
                if (b == Properties.Settings.Default.tagID)
                {
                    if (tagcount != 5)
                    {
                        string h = Convert.ToString(Epc).Substring(22, 7);
                        h = h.Replace("-", "");
                        for (int i = 0; i < tagname.Length; i++)
                        {
                            if (tagname[i] == string.Empty)
                            {
                                tagname[i] = h;
                                tagcount++;
                                //最終タグ読み取り数.Items.Add(h);//テストプログラム
                                break;
                            }
                            else if(tagname[i]==h)
                            {
                                break;
                            }
                        }
                    }
                }
            }
            //タグ読み取り数.Items.Add(Epc + "\r\n");//テストプログラム
            

            Log_WriteLine("       taglist: Epc=" + Epc + " AntId=" + AntId + " ChanId=" + ChanId + " Rssi=" + Rssi + " Phase=" + Phase + " SeenTime=" + SeenTime + " AccessData=" + AccessData, TBOX);
            Epc = "";
            Rssi = "";
            Phase = "";
            AntId = "";
            ChanId = "";
            SeenTime = "";
            AccessData = "";

        }
        /// <summary>
        /// 目標コイル座標値設定処理
        /// </summary>
        /// <param name="retu"></param>
        /// <param name="ren"></param>
        /// <param name="dan"></param>
        /// <param name="distx"></param>
        /// <param name="disty"></param>
        /// <param name="distz"></param>
        public void targetdisp(string retu, string ren, string dan, int distx, int disty, int distz)
        {
            //目標コイルまでのロケーションの表示
            //フォーマット変更（333,3）に変更する
            // distx=distx.Remove()
            if (distx == 0 && disty == 0 && distz == 0)
            {
                TRP.Text = "-";
                TRun.Text = "-";
                THgt.Text = "-";
            }
            else
            {
                distx = distx / 100;
                double distdx = distx;
                disty = disty / 100;
                double distdy = disty;
                distz = distz / 100;
                double distdz = distz;

                TRP.Text = Convert.ToString(distdx / 10);
                TRun.Text = Convert.ToString(distdy / 10);
                THgt.Text = Convert.ToString(distdz / 10);

            }
            TCol.Text = retu;
            TCom.Text = ren;
            TSt.Text = dan;
            //フリーエリア処理追加　20240610山﨑
            if (retu != "-" && ren != "-" && retu!= Properties.Settings.Default.Free_X)
            {
                coil_view[Convert.ToInt32(retu) - 1, Convert.ToInt32(ren) - 1].Style.BackColor = Color.Red;
                coil_view[Convert.ToInt32(retu) - 1, Convert.ToInt32(ren) - 1].Value = "";
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //案１更新タイミングを1時間とし、それとは別に更新ボタンを作成する使用　更新タイミングを自分で選べるが、操作が1手間必要になってしまう
            //案２更新タイミングを1分～5分とする仕様、更新周期が短くなるが、画面がちかちかしてしまう問題がある


        }

        private void OperationScreen_Load(object sender, EventArgs e)
        {
            
            // Crane_check.Checked = true;6
            //Crane_check.Checked = false;
            //disp();
            //Threading_Rangefinder();

            //Threading_X1();
            //Threading_Y1();
            //Threading_Z1();
            //Threading_Operation();
            //Threading_X();
            //Threading_Y();
            //Threading_Z();

            //Theading_refresh();

            //Threading_X1();
            //Threading_Y1();
            //Threading_Z1();
            //Threading_Operation();

            // ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(30);//テストプログラム
            //Threading_IO();


            disp();
            Task.Run(Threading_X1);//X軸値取得
            Task.Run(Threading_Y1);//Y軸値取得
            Task.Run(Threading_Z1);//Z軸値取得
            Task.Run(Threading_Operation);//値調整
            if (Properties.Settings.Default.DIOcomIP!= "localhost")
            {
                Task.Run(Threading_IO);//IO取得
            }

            Coordinate_timer.Start();//周期タイマー   

            //テストプログラム
            //for(int i = 0; i < 5; i++)
            //{
            //    listBox1.Items.Add(Properties.Settings.Default.tagID);
            //    listBox2.Items.Add(Properties.Settings.Default.tagID);

            //}


        }
       
            /// <summary>
            /// X軸距離計取得タスク
            /// </summary>
            static async void Threading_X1()
        {
            lazercls Xcls = new lazercls();
            Xcls.portname = Properties.Settings.Default.xport_name;
            Xcls.baudrate = Properties.Settings.Default.xbaudrate;
            Xcls.address = Properties.Settings.Default.XcomIP;
            Xcls.ReadTimeout = Properties.Settings.Default.XTimeout;
            //初期起動確認
            for (; ; )
            {
                if (Xcls.init() == false)
                {
                    Xvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if (Xcls.Ping() == false)
                {
                    Xvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if (Xcls.PortOpen() == false)
                {
                    Xvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }
            //値取得処理
            for (; ; )
            {
                Xvalue = Xcls.lazer();
                //----------------------------
                //2026/3/13 morichika
                //if (Xvalue == -99999|| Zvalue == -99998)
                if (Xvalue == -99999 || Xvalue == -99998)
                //----------------------------
                    {
                        for (; ; )
                    {
                        if (Xcls.PortOpenCheck() == false)
                        {
                            if (Xcls.PortOpen() == false)
                            {
                                //Xvalue = -99999;
                                await Task.Delay(100);
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else if (Xvalue == -99998)
                {
                    Xerrvalue = true;
                }
                else
                {
                    Xerrvalue = false;
                }
                await Task.Delay(100);
            }
        }
        /// <summary>
        /// Y軸距離計取得タスク
        /// </summary>
        static async void Threading_Y1()
        {
           
            Ylazercls Ycls = new Ylazercls();
            Ycls.portname = Properties.Settings.Default.yport_name;
            Ycls.baudrate = Properties.Settings.Default.ybaudrate;
            Ycls.address = Properties.Settings.Default.YcomIP;
            Ycls.ReadTimeout = Properties.Settings.Default.YTimeout;
            //初期起動確認

            for (; ; )
            {
                if (Ycls.init() == false)
                {
                    Yvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if (Ycls.Ping() == false)
                {
                    Yvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if (Ycls.PortOpen() == false)
                {
                    Yvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }
            //値取得処理
            for (; ; )
            {
                Yvalue = Ycls.lazer();
                //----------------------------
                //2026/3/13 morichika
                //if (Yvalue == -99999 || Zvalue == -99998)
                if (Yvalue == -99999 || Yvalue == -99998)
                //----------------------------
                {
                    for (; ; )
                    {
                        if (Ycls.PortOpenCheck() == false)
                        {
                            if (Ycls.PortOpen() == false)
                            {
                                //Yvalue = -99999;
                                await Task.Delay(100);
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                   
                }
                else if (Yvalue == -99998)
                {
                    Yerrvalue = true;
                }
                else
                {
                    Yerrvalue = false;
                }
                await Task.Delay(100);
            }
        }
        /// <summary>
        /// Z軸距離計取得タスク
        /// </summary>
        static async void Threading_Z1()
        {
            Zlazercls Zcls = new Zlazercls();
            Zcls.portname = Properties.Settings.Default.zport_name;
            Zcls.baudrate= Properties.Settings.Default.zbaudrate;
            Zcls.address = Properties.Settings.Default.ZcomIP;
            Zcls.ReadTimeout = Properties.Settings.Default.ZTimeout;
            //初期起動確認
            for (; ; )
            {
                if (Zcls.init() == false)
                {
                    Zvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if (Zcls.Ping() == false)
                {
                    Zvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else if ( Zcls.PortOpen() == false)
                {
                    Zvalue = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }
            //値取得処理
            for(; ; )
            {
                Zvalue = Zcls.lazer();
                if (Zvalue == -99999||Zvalue==-99998)
                {
                    for (; ; )
                    {
                        if (Zcls.PortOpenCheck() == false)
                        {
                            if (Zcls.PortOpen() == false)
                            {
                                //Zvalue = -99999;
                                await Task.Delay(100);
                                continue;
                            }
                        }
                        else
                        {
                            break;
                        }
                        
                    }
                   
                }
                else if (Zvalue == -99998)
                {
                    Zerrvalue = true;
                }
                else
                {
                    Zerrvalue = false;
                }
                await Task.Delay(100);
            }
        }
        /// <summary>
        /// 距離計値処理用タスク
        /// </summary>
        static async void Threading_Operation()
        {
            await Task.Delay(3000);
            for (; ; )
            {
                //Yvalue -= 1;
                //Zvalue -= 1;
                //Xvalue = 10000;//test
                //Yvalue = 10000;
                //Zvalue = 4000;
                //----------------------------
                //2026/3/13 morichika
                //if (Xvalue == -99999)
                if (Xvalue == -99999|| Xvalue == -99998)
                //----------------------------
                {
                    Crane_point_x = -99999;
                }
                //----------------------------
                //2026/3/13 morichika
                //if (Yvalue == -99999)
                if (Yvalue == -99999|| Yvalue == -99998)
                //----------------------------
                {
                    Crane_point_y = -99999;
                }
                //----------------------------
                //2026/3/13 morichika
                //if (Zvalue == -99999)
                if (Zvalue == -99999|| Zvalue == -99998)
                //----------------------------
                {
                    Crane_point_z = -99999;
                }

                //----------------------------
                //2026/3/13 morichika
                //if (Xvalue != -99999)
                if (Xvalue != -99999 && Xvalue != -99998)
                //----------------------------
                {
                    if (Properties.Settings.Default.Inverted_Value_X == 0)
                    {
                        Crane_point_x = Convert.ToInt32(Xvalue - Properties.Settings.Default.Offset_Value_X);
                    }
                    else
                    {
                        Crane_point_x = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_X - Xvalue);
                    }
                }

                //----------------------------
                //2026/3/13 morichika
                //if (Yvalue != -99999)
                if (Yvalue != -99999 && Yvalue != -99998)
                //----------------------------
                {
                    if (Properties.Settings.Default.Inverted_Value_Y == 0)
                    {
                        Crane_point_y = Convert.ToInt32(Yvalue - Properties.Settings.Default.Offset_Value_Y);
                    }
                    else
                    {
                        Crane_point_y = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_Y - Yvalue);
                    }
                }

                //----------------------------
                //2026/3/13 morichika
                //if (Zvalue != -99999)
                if (Zvalue != -99999 && Zvalue != -99998)
                //----------------------------
                {
                    if (Properties.Settings.Default.Inverted_Value_Z == 0)
                    {
                        Crane_point_z = Convert.ToInt32(Zvalue - Properties.Settings.Default.Offset_Value_Z);
                    }
                    else
                    {
                        Crane_point_z = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_Z - Zvalue);
                    }
                }
                
                await Task.Delay(10);

            }

            //await Task.Delay(1);
        }
        static async void Threading_X()
        {
            //シリアルポートプロパティ設定
            X_serialPort.PortName = Properties.Settings.Default.xport_name;//ポート番号
            X_serialPort.BaudRate = Properties.Settings.Default.xbaudrate;//ボーレート
            X_serialPort.ReadTimeout = 5000;//リードラインタイムアウト時間
            //PING応答処理
            string Xaddress = Properties.Settings.Default.XcomIP;//IPアドレス
            for (; ; )
            {
                Ping Xsender = new Ping();

                PingReply Xreply = Xsender.Send(Xaddress);//送信モジュール
                if (Xreply.Status != IPStatus.Success)
                {
                    Crane_point_x = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }
            //シリアルポートオープン処理
            for (; ; )
            {
                if (X_serialPort.IsOpen != true)
                {
                    try
                    {
                        X_serialPort.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Crane_point_x = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            //距離計値取得処理
            string serial_x = "";//電文
            double xrenge = 0;//距離計値
            X_serialPort.DiscardInBuffer();//シリアルバッファ初期化
            int xcount = 0;//エラーカウント
            for (; ; )
            {
                //シリアルポートオープン処理
                for (; ; )
                {

                    if (X_serialPort.IsOpen != true)
                    {
                        try
                        {
                            X_serialPort.Open();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Crane_point_x = -99999;
                            await Task.Delay(100);
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                //電文取得処理
                try
                {
                    serial_x = Convert.ToString(X_serialPort.ReadLine());
                }
                catch (Exception ex)
                {
                    Crane_point_x = -99999;
                    X_serialPort.Close();
                    await Task.Delay(100);
                    continue;
                }
                //電文解析
                if (serial_x.Length == 15 && serial_x.IndexOf("+") == 0)
                {
                    xrenge = Convert.ToDouble(serial_x.Substring(1, 6));//距離計座標生値
                    if (xrenge != 0)
                    {
                        Crane_point_x = Convert.ToInt32(xrenge);
                        break;
                    }
                    else if (xcount == 50)
                    {

                        Crane_point_x = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                    else { xcount++; }
                }

            }
            await Task.Delay(1);
        }
        static async void Threading_Y()
        {
            Y_serialPort.PortName = Properties.Settings.Default.yport_name;
            Y_serialPort.BaudRate = Properties.Settings.Default.ybaudrate;
            Y_serialPort.ReadTimeout = 5000;

            string Yaddress = Properties.Settings.Default.YcomIP;
            for (; ; )
            {
                Ping Ysender = new Ping();

                PingReply Yreply = Ysender.Send(Yaddress);//送信モジュール
                if (Yreply.Status != IPStatus.Success)
                {
                    Crane_point_y = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }

            for (; ; )
            {
                if (Y_serialPort.IsOpen != true)
                {
                    try
                    {
                        Y_serialPort.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Crane_point_y = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            string serial_y = "";
            double yrenge = 0;
            Y_serialPort.DiscardInBuffer();
            int ycount = 0;
            for (; ; )
            {
                for (; ; )
                {
                    if (Y_serialPort.IsOpen != true)
                    {
                        try
                        {
                            Y_serialPort.Open();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Crane_point_y = -99999;
                            await Task.Delay(100);
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                try
                {
                    serial_y = Convert.ToString(Y_serialPort.ReadLine());
                }
                catch (Exception ex)
                {
                    Crane_point_y = -99999;
                    Y_serialPort.Close();
                    await Task.Delay(100);
                    continue;
                }

                if (serial_y.Length == 15 && serial_y.IndexOf("+") == 0)
                {
                    yrenge = Convert.ToDouble(serial_y.Substring(1, 6));//距離計座標生値
                    if (yrenge != 0)
                    {
                        Crane_point_y = Convert.ToInt32(yrenge);
                        break;
                    }
                    else if (ycount == 50)
                    {

                        Crane_point_y = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                    else { ycount++; }
                }

            }
            await Task.Delay(1);
        }
        static async void Threading_Z()
        {
            Z_serialPort.PortName = Properties.Settings.Default.zport_name;
            Z_serialPort.BaudRate = Properties.Settings.Default.zbaudrate;
            Z_serialPort.ReadTimeout = 5000;

            string Zaddress = Properties.Settings.Default.ZcomIP;
            for (; ; )
            {
                Ping Zsender = new Ping();

                PingReply Zreply = Zsender.Send(Zaddress);//送信モジュール
                if (Zreply.Status != IPStatus.Success)
                {
                    Crane_point_z = -99999;
                    await Task.Delay(100);
                    continue;
                }
                else
                {
                    break;
                }
            }

            for (; ; )
            {
                if (Z_serialPort.IsOpen != true)
                {
                    try
                    {
                        Z_serialPort.Open();
                        break;
                    }
                    catch (Exception ex)
                    {
                        Crane_point_z = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                }
                else
                {
                    break;
                }
            }
            string serial_z = "";
            double zrenge = 0;
            Z_serialPort.DiscardInBuffer();
            int zcount = 0;
            for (; ; )
            {
                for (; ; )
                {
                    if (Z_serialPort.IsOpen != true)
                    {
                        try
                        {
                            Z_serialPort.Open();
                            break;
                        }
                        catch (Exception ex)
                        {
                            Crane_point_z = -99999;
                            await Task.Delay(100);
                            continue;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                try
                {
                    serial_z = Convert.ToString(Z_serialPort.ReadLine());
                }
                catch (Exception ex)
                {
                    Crane_point_z = -99999;
                    Z_serialPort.Close();
                    await Task.Delay(100);
                    continue;
                }

                if (serial_z.Length == 15 && serial_z.IndexOf("+") == 0)
                {
                    zrenge = Convert.ToDouble(serial_z.Substring(1, 6));//距離計座標生値
                    if (zrenge != 0)
                    {
                        Crane_point_z = Convert.ToInt32(zrenge);
                        break;
                    }
                    else if (zcount == 50)
                    {

                        Crane_point_z = -99999;
                        await Task.Delay(100);
                        continue;
                    }
                    else { zcount++; }
                }

            }
            await Task.Delay(1);
        }
        bool IOcheck()
        {
            bool IO = false;
            //IOチェック関数
            return IO;
        }
        void read_tag()
        {
            //タグの読み取り関数
            //読み取れなかった場合は読み取れるまで繰り返す（表示もだすかも）
        }
        void coil_move()
        {

            //コイル移動履歴更新
            //コイル位置情報更新
        }

        public void test_text(int no, string text)
        {
            //if (no == 1)
            //{
            //    test1.Text = text;
            //}
            //else if (no == 2)
            //{
            //    test2.Text = text;
            //}
            //else if (no == 3)
            //{
            //    test3.Text = text;
            //}
            //else if (no == 4)
            //{
            //    test4.Text = text;
            //}
        }
        static async void Threading_IO()
        {
            for (; ; )
            {
                if (Properties.Settings.Default.Lifter_Manualmode == false)
                {


                    InpPortData = 0;
                    //-----------------------------
                    // 画面からポート番号を取得する
                    //-----------------------------

                    Ret = DIO.ccapdio.DioInit(Properties.Settings.Default.Lifter_DIOid, ref Id);
                    if (Ret != DIO.ccapdio.DIO_ERR_SUCCESS)
                    {
                        IOvalue = "-";
                        await Task.Delay(Properties.Settings.Default.Lifter_Signal_Interval);
                        continue;
                    }
                   // else
                   //{
                   //    IOvalue = Convert.ToString(InpPortData);
                   //}
                    szText = "0";
                    try
                    {
                        InpPortNo = Convert.ToInt16(szText);
                    }
                    catch (System.FormatException)
                    {
                        InpPortNo = 0;
                        continue;
                    }
                    //-----------------------------
                    // ポート入力
                    //-----------------------------
                    Ret = DIO.ccapdio.DioInpByte(Id, InpPortNo, ref InpPortData);
                    //-----------------------------
                    //// エラー処理
                    ////-----------------------------
                    DIO.ccapdio.DioGetErrorString(Ret, szError);


                    if (Ret != DIO.ccapdio.DIO_ERR_SUCCESS)
                    {
                        IOvalue = "-";
                        await Task.Delay(Properties.Settings.Default.Lifter_Signal_Interval);
                        continue;
                    }
                    else
                    {
                        IOvalue = Convert.ToString(InpPortData);
                        await Task.Delay(Properties.Settings.Default.Lifter_Signal_Interval);
                    }
                }
                
            }
        }
        void read_IO()
        {
            if (IOvalue == "-" && IOerrflag == true)
            {
                IOerrflag = false;
                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(18);
                ((MainScreen)Application.OpenForms["MainScreen"]).System_log("接続エラー", "2", "IO/ユニット接続", "IO");
                bit1value = false;
                bit2value = false;
                return;
            }
            else if(IOvalue == "-")
            {
                return;
            }
            if (IOvalue == "0")
            {
                bit1value = false;
                bit2value = false;
            }
            else if (IOvalue == "1")
            {
                bit1value = true;
                bit2value = false;

            }
            else if (IOvalue == "2")
            {
                bit1value = false;
                bit2value = true;
            }
            else if (IOvalue == "3")
            {
                bit1value = true;
                bit2value = true;
            }
            if (IOvalue == "3")//閉じたとき
            {
                IOcountOPEN = 0;
                if (IOerrflag == false)
                {
                    IOerrflag = true;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("再接続", "1", "IO/ユニット接続", "IO");
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);

                }
                IOcountCLOSE++;
                if (IOcountCLOSE == Properties.Settings.Default.Lifter_Signal_ON_Judgment && IOflag == false)
                {
                    IOmode = 1;
                    IOcountCLOSE = 0;
                    IOCheckflag = true;
                    IOflag = true;
                   

                }
                else if (IOcountCLOSE == Properties.Settings.Default.Lifter_Signal_ON_Judgment)
                {
                    IOcountCLOSE = 0;
                   
                }
            }
            //2024.6.20 morichika
            //else if (IOvalue == "0")//開いた時
            else if (IOvalue == "1")//開いた時
                    {
                        IOcountCLOSE = 0;
                if (RFIDContinuousflag == true)
                {
                    RFIDContinuousflag = false;
                    tagreadcnt = 0;
                    Properties.Settings.Default.antena_decibel = def_decibel;
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                }
                if (IOerrflag == false)
                {
                    IOerrflag = true;
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(19);//エラー復帰
                }
                IOcountOPEN++;
                if (IOcountOPEN == Properties.Settings.Default.Lifter_Signal_OFF_Judgment && tagId != "-" )
                {
                    IOmode = 2;
                   // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                    IOcountOPEN = 0;
                   
                    IOCheckflag = true;
                    //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム
                                                                                                                            //あとで設定変数にするかも？
                                                                                                                            //  await Task.Delay(1000);

                }
                else if (IOcountOPEN == Properties.Settings.Default.Lifter_Signal_OFF_Judgment)
                {
                    IOcountOPEN = 0;
                    // await Task.Delay(1000);

                }
            }
            else
            { //エラー処理必要なのか？}
              //IOerrflag = false;
              //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(18);
            }
            

            //if(I/Oフラグ==false&&I/Oチェック==ture){I/OフラグON; タグの読み取り関数実行}
            //if(I/Oフラグ==true&&I/Oチェック==false){I/OフラグOFF; 位置情報決定関数;移動履歴関数;}
            //await Task.Delay(1000);
        }
                
    

        
            //IOチェック(スレッド処理)
            //一定周期でIOのチェックを行い、閉じている場合、開いている場合の確認が規定の数確認が行えた場合にメインに処理を投げる
            //また、本案件は常にOPEN(開状態)されていることがよそうされるため、規定以上の数のOPENが確認された場合は（処理効率を上げるため数秒ディレイ処理を入れる仕様とした
            /// <summary>
            /// IO取得処理
            /// </summary>
            static async void read_IO2()
        {

            for (; ; )
            {
                if (Properties.Settings.Default.Lifter_Manualmode == false)
                {

                    for (; ; )
                    {
                        if (ALLstopflag == true)
                        {
                            Threading_IO_OKflag = true;
                            await Task.Delay(1000);
                        }
                        else
                        {
                            Threading_IO_OKflag = false;
                            break;
                        }
                    }
                    InpPortData = 0;
                    //-----------------------------
                    // 画面からポート番号を取得する
                    //-----------------------------

                    Ret = DIO.ccapdio.DioInit(Properties.Settings.Default.Lifter_DIOid, ref Id);
                    szText = "0";
                    try
                    {
                        InpPortNo = Convert.ToInt16(szText);
                    }
                    catch (System.FormatException)
                    {
                        InpPortNo = 0;
                    }
                    //-----------------------------
                    // ポート入力
                    //-----------------------------
                    Ret = DIO.ccapdio.DioInpByte(Id, InpPortNo, ref InpPortData);
                    //-----------------------------
                    //// エラー処理
                    ////-----------------------------
                    DIO.ccapdio.DioGetErrorString(Ret, szError);


                    if (Ret != DIO.ccapdio.DIO_ERR_SUCCESS)
                    {
                        IOerrflag = false;
                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(18);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("接続エラー", "2", "IO/ユニット接続", "IO");
                        bit1value = false;
                        bit2value = false;
                        await Task.Delay(1000);
                        continue;
                    }
                    else
                    {
                        if (IOerrflag == false)
                        {
                            IOerrflag = true;
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(19);
                            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("再接続", "1", "IO/ユニット接続", "IO");
                        }
                    }
                    //-----------------------------
                    // データ表示
                    //-----------------------------
                    szText = string.Format("{0:X2}", InpPortData);
                    string IO = Convert.ToString(InpPortData);
                    //int b = Properties.Settings.Default.Lifter_Signal_ON_Judgment;
                    //int a = Properties.Settings.Default.Lifter_Signal_OFF_Judgment;
                    if (IO == "0")
                    {
                        bit1value = false;
                        bit2value = false;
                    }
                    else if (IO == "1")
                    {
                        bit1value = true;
                        bit2value = false;

                    }
                    else if (IO == "2")
                    {
                        bit1value = false;
                        bit2value = true;
                    }
                    else if (IO == "3")
                    {
                        bit1value = true;
                        bit2value = true;
                    }
                    if (IO == "3")//閉じたとき
                    {
                        if (IOerrflag == false)
                        {
                            IOerrflag = true;
                            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("再接続", "1", "IO/ユニット接続", "IO");
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(19);

                        }
                        IOcountCLOSE++;
                        if (IOcountCLOSE == Properties.Settings.Default.Lifter_Signal_ON_Judgment && IOflag == false)
                        {
                            IOmode = 1;
                            //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                            IOcountCLOSE = 0;
                            IOcountOPEN = 0;
                            IOCheckflag = true;
                          //  ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2,Convert.ToString(IOCheckflag));//テストプログラム
                           
                            IOflag = true;
                            //あとで設定変数にするかも？
                            //await Task.Delay(1000);

                        }
                        else if (IOcountCLOSE == Properties.Settings.Default.Lifter_Signal_ON_Judgment)
                        {
                            IOcountCLOSE = 0;
                            //あとで設定変数にするかも？
                            //await Task.Delay(1000);
                        }
                    }
                    else if (IO == "0")//開いた時
                    {
                        if (RFIDContinuousflag == true)
                        {
                            RFIDContinuousflag = false;
                            tagreadcnt = 0;
                            Properties.Settings.Default.antena_decibel = def_decibel;
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                        }
                        if (IOerrflag == false)
                        {
                            IOerrflag = true;
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(19);//エラー復帰
                        }
                        IOcountOPEN++;
                        if (IOcountOPEN == Properties.Settings.Default.Lifter_Signal_OFF_Judgment && tagId != "-")
                        {
                            IOmode = 2;
                           // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                            IOcountOPEN = 0;
                            IOcountCLOSE = 0;
                            IOCheckflag = true;
                           // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム
                            //あとで設定変数にするかも？
                            //  await Task.Delay(1000);

                        }
                        else if (IOcountOPEN == Properties.Settings.Default.Lifter_Signal_OFF_Judgment)
                        {
                            IOcountOPEN = 0;
                            // await Task.Delay(1000);

                        }
                    }
                    else
                    { //エラー処理必要なのか？}
                        //IOerrflag = false;
                        //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(18);
                    }
                    await Task.Delay(Properties.Settings.Default.Lifter_Signal_Interval);

                    //if(I/Oフラグ==false&&I/Oチェック==ture){I/OフラグON; タグの読み取り関数実行}
                    //if(I/Oフラグ==true&&I/Oチェック==false){I/OフラグOFF; 位置情報決定関数;移動履歴関数;}
                    //await Task.Delay(1000);
                }
                else { await Task.Delay(100); }
            }
        }
        static async void Theading_refresh()
        {
            for (; ; )
            {
                if (ALLstopflag == true)
                {
                    Theading_refresh_OKflag = true;
                    await Task.Delay(1000);
                }
                else
                {
                    Theading_refresh_OKflag = false;
                    break;
                }
            }
            await Task.Delay(1000000);
            ((OperationScreen)Application.OpenForms["OperationScreen"]).disp();
        }

        static public SerialPort X_serialPort = new SerialPort();
        static public SerialPort Y_serialPort = new SerialPort();
        static public SerialPort Z_serialPort = new SerialPort();

        static async void Threading_Rangefinder()
        {

            // Create a new SerialPort object with default settings.
            //SerialPort X_serialPort = new SerialPort();
            //SerialPort Y_serialPort = new SerialPort();
            //SerialPort Z_serialPort = new SerialPort();

            // Allow the user to set the appropriate properties.
            X_serialPort.PortName = Properties.Settings.Default.xport_name;
            X_serialPort.BaudRate = Properties.Settings.Default.xbaudrate;
            //X_serialPort.DataBits = Properties.Settings.Default.xdatabit;
            X_serialPort.ReadTimeout = 5000;


            Y_serialPort.PortName = Properties.Settings.Default.yport_name;
            Y_serialPort.BaudRate = Properties.Settings.Default.ybaudrate;
            //Y_serialPort.DataBits = Properties.Settings.Default.ydatabit;
            Y_serialPort.ReadTimeout = 5000;


            Z_serialPort.PortName = Properties.Settings.Default.zport_name;
            Z_serialPort.BaudRate = Properties.Settings.Default.zbaudrate;
            //Z_serialPort.DataBits = Properties.Settings.Default.zdatabit;
            Z_serialPort.ReadTimeout = 5000;




            //X_serialPort.Close();
            //Y_serialPort.Close();
            //Z_serialPort.Close();
            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(28);
            //await Task.Delay(5000);


            for (; ; )
            {


                xOpenflag = true;
                yOpenflag = true;
                zOpenflag = true;

                string Xaddress = Properties.Settings.Default.XcomIP;
                string Yaddress = Properties.Settings.Default.YcomIP;
                string Zaddress = Properties.Settings.Default.ZcomIP;



                Ping Xsender = new Ping();

                PingReply Xreply = Xsender.Send(Xaddress);//送信モジュール
                if (Xreply.Status != IPStatus.Success)
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(22);
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X距離計ping処理失敗", "2", "距離計接続処理", "xlazer");
                    xOpenflag = false;

                    Crane_point_x = -99998;
                }
                else
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X距離計ping処理成功", "1", "距離計接続処理", "lazer");
                }

                Ping Ysender = new Ping();

                PingReply Yreply = Ysender.Send(Yaddress);//送信モジュール
                if (Yreply.Status != IPStatus.Success)
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(23);
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X距離計ping処理失敗", "2", "距離計接続処理", "ylazer");
                    yOpenflag = false;

                    Crane_point_y = -99998;
                }
                //else
                //{
                //    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y距離計ping処理成功", "1", "距離計接続処理", "lazer");
                //}
                Ping Zsender = new Ping();
                PingReply Zreply = Zsender.Send(Zaddress);//送信モジュール
                if (Zreply.Status != IPStatus.Success)
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(24);
                    //((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z距離計ping処理失敗", "2", "距離計接続処理", "zlazer");
                    zOpenflag = false;

                    Crane_point_z = -99998;
                }
                else
                {
                    //((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z距離計ping処理成功", "1", "距離計接続処理", "lazer");
                }

                if (xOpenflag == true && X_serialPort.IsOpen != true)
                {
                    try
                    {
                        //string[] allPortNames = System.IO.Ports.SerialPort.GetPortNames();
                        X_serialPort.Open();

                        await Task.Delay(100);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸シリアルポートOPEN", "1", "距離計接続処理", "xlazer");
                    }
                    catch (Exception ex)
                    {
                        //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(6);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸シリアルポートOPENエラー", "2", "距離計接続処理", "xlazer");
                        xOpenflag = false;

                        Crane_point_x = -99997;

                    }
                }
                if (yOpenflag == true && Y_serialPort.IsOpen != true)
                {
                    try
                    {

                        Y_serialPort.Open();

                        await Task.Delay(100);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸シリアルポートOPEN", "1", "距離計接続処理", "ylazer");
                    }
                    catch (Exception ex)
                    {
                        // ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(7);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸シリアルポートOPENエラー", "2", "距離計接続処理", "ylazer");
                        yOpenflag = false;

                        Crane_point_y = -99997;

                    }
                }

                if (zOpenflag == true && Z_serialPort.IsOpen != true)
                {
                    try
                    {

                        Z_serialPort.Open();

                        await Task.Delay(100);
                        //  ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸シリアルポートOPEN", "1", "距離計接続処理", "zlazer");
                    }
                    catch (Exception ex)
                    {
                        //  ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(8);
                        //((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸シリアルポートOPENエラー", "2", "距離計接続処理", "zlazer");
                        zOpenflag = false;

                        Crane_point_z = -99997;

                    }
                }
                if (xOpenflag == false || yOpenflag == false || zOpenflag == false)
                {
                    await Task.Delay(20000);
                }
                else { ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0); break; }
                //break;//test
            }
            for (; ; )
            {
                if (lazerflag == true)
                {

                    //X_serialPort.DiscardInBuffer();
                    //X_serialPort.DiscardOutBuffer();
                    //Y_serialPort.DiscardInBuffer();
                    //Y_serialPort.DiscardOutBuffer();
                    //Z_serialPort.DiscardInBuffer();
                    //Z_serialPort.DiscardOutBuffer();
                    for (; ; )
                    {
                        //if (X_serialPort.IsOpen == true)
                        //{

                        //    X_serialPort.Close();
                        //    X_serialPort.Dispose();
                        //}
                        //if (Y_serialPort.IsOpen == true)
                        //{
                        //    Y_serialPort.Close();
                        //    Y_serialPort.Dispose();
                        //}
                        //if (Z_serialPort.IsOpen == true)
                        //{
                        //    Z_serialPort.Close();
                        //    Z_serialPort.Dispose();
                        //}
                        //if (X_serialPort.IsOpen != true && Y_serialPort.IsOpen != true && Z_serialPort.IsOpen != true)
                        //{
                        lazerCloseflag = true;
                        return;
                        //}
                    }
                }
                bool Xping = true;
                bool Yping = true;
                bool Zping = true;
                //各シリアルの状態を確認し、不備があればクローズしてオープンする
                for (; ; )
                {
                    string Xaddress = Properties.Settings.Default.XcomIP;
                    string Yaddress = Properties.Settings.Default.YcomIP;
                    string Zaddress = Properties.Settings.Default.ZcomIP;


                    for (; ; )
                    {
                        if (ALLstopflag == true)
                        {
                            Threading_lazer_OKflag = true;
                            await Task.Delay(1000);
                        }
                        else
                        {
                            Threading_lazer_OKflag = false;
                            break;
                        }
                    }

                    //Ping Xsender = new Ping();

                    //PingReply Xreply = Xsender.Send(Xaddress);//送信モジュール
                    //if (Xreply.Status != IPStatus.Success)
                    //{
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(22);
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X距離計ping処理失敗", "2", "距離計接続処理", "xlazer");
                    //    Xping = false;
                    //    xrengeerr = false;
                    //    Crane_point_x=-99998;

                    //}
                    //else
                    //{
                    //    if (Xping == false)
                    //    {
                    //        Xping = true;
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(25);
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X距離計ping処理成功", "2", "距離計接続処理", "xlazer");
                    //    }
                    //}
                    //Ping Ysender = new Ping();

                    //PingReply Yreply = Ysender.Send(Yaddress);//送信モジュール
                    //if (Yreply.Status != IPStatus.Success)
                    //{
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(23);
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y距離計ping処理失敗", "2", "距離計接続処理", "ylazer");
                    //    Yping = false;
                    //    yrengeerr = false;
                    //    Crane_point_y = -99998;
                    //}
                    //else
                    //{
                    //    if (Yping == false)
                    //    {
                    //        Yping = true;
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(26);
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y距離計ping処理成功", "2", "距離計接続処理", "ylazer");
                    //    }
                    //}

                    //Ping Zsender = new Ping();
                    //PingReply Zreply = Zsender.Send(Zaddress);//送信モジュール
                    //if (Zreply.Status != IPStatus.Success)
                    //{
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(24);
                    //    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z距離計ping処理失敗", "2", "距離計接続処理", "zlazer");
                    //    Zping = false;
                    //    zrengeerr = false;

                    //    Crane_point_z = -99998;

                    //}
                    //else
                    //{
                    //    if (Zping == false)
                    //    {
                    //        Zping = true;
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(27);
                    //        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z距離計ping処理成功", "2", "距離計接続処理", "zlazer");
                    //    }
                    //}

                    //if (X_serialPort.IsOpen != true)
                    //{
                    //    int count = 0;

                    //        if (count == 1)
                    //        {
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(6);
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Xシリアルポートオープンエラー","2", "距離計接続処理", "xlazer");
                    //        count = 0;
                    //            xrengeerr = false;
                    //            Crane_point_x = -99997;
                    //        }
                    //        try
                    //        {
                    //            X_serialPort.Open();
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸シリアルポート再OPEN", "1", "距離計接続処理", "xlazer");


                    //    }
                    //        catch (Exception ex)
                    //        {
                    //            xrengeerr = false;
                    //            Crane_point_x = -99997;
                    //        }
                    //    }


                    //if (Y_serialPort.IsOpen != true)
                    //{
                    //    int count = 0;

                    //        if (count == 1)
                    //        {
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(7);
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Yシリアルポートオープンエラー","2", "距離計接続処理", "ylazer");
                    //        count = 0;
                    //            yrengeerr = false;
                    //            Crane_point_y = -99997;
                    //        }
                    //        try
                    //        {
                    //            Y_serialPort.Open();
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸シリアルポート再OPEN", "1", "距離計接続処理", "ylazer");


                    //    }
                    //        catch (Exception ex)
                    //        {
                    //            yrengeerr = false;
                    //            Crane_point_y = -99997;
                    //        }
                    //    }


                    //if (Z_serialPort.IsOpen != true)
                    //{
                    //    int count = 0;

                    //        if (count == 1)
                    //        {
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(8);
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Zシリアルポートオープンエラー","2", "距離計接続処理", "zlazer");
                    //        count = 0;
                    //            zrengeerr = false;
                    //            Crane_point_z = -99997;
                    //        }
                    //        try
                    //        {
                    //            Z_serialPort.Open();
                    //            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸シリアルポート再OPEN", "1", "距離計接続処理", "zlazer");


                    //    }
                    //        catch (Exception ex)
                    //        {
                    //            zrengeerr = false;
                    //            Crane_point_z = -99997;
                    //        }

                    //}
                    if (xrengeerr == false || yrengeerr == false || zrengeerr == false)
                    {
                        xrengeerr = true;
                        yrengeerr = true;
                        zrengeerr = true;
                        //await Task.Delay(20000);
                        continue;
                    }
                    if (ALLstopflag == true)
                    {
                        Threading_lazer_OKflag = true;
                        await Task.Delay(1000);
                    }
                    else
                    {
                        Threading_lazer_OKflag = false;
                        break;
                    }
                }

                //for (int i = 0; i < 10; i++)
                //{
                string serial_x = "";
                string serial_y = "";
                string serial_z = "";
                double xrenge = 0;
                double yrenge = 0;
                double zrenge = 0;
                X_serialPort.DiscardInBuffer();
                Y_serialPort.DiscardInBuffer();
                Z_serialPort.DiscardInBuffer();
                int xcount = 0;
                int ycount = 0;
                int zcount = 0;

                //シリアルの状態チェック
                //状態が悪かった場合
                for (; ; )
                {

                    try
                    {
                        //タイムアウトの時に返ってくる戻り値によって処理
                        serial_x = Convert.ToString(X_serialPort.ReadLine());
                        if (xrengeerr == false)
                        {
                            xrengeerr = true;
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(15);
                            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値再取得確認", "1", "距離計値取得処理", "xlazer");
                        }
                    }
                    catch (Exception ex)
                    {

                        Crane_point_x = -99999;




                        xrengeerr = false;
                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(9);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値取得エラー", "2", "距離計値取得処理", "xlazer");
                        break;
                    }



                    if (serial_x.Length == 15 && serial_x.IndexOf("+") == 0)
                    {
                        // string a = serial_x;
                        xrenge = Convert.ToDouble(serial_x.Substring(1, 6));//距離計座標生値
                        if (xrenge != 0)
                        {
                            break;
                        }
                        else if (xcount == 50)
                        {

                            Crane_point_x = -99999;




                            xrengeerr = false;
                            //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(9);
                        }
                        else { xcount++; }
                    }

                }


                for (; ; )
                {
                    try
                    {
                        //タイムアウトの時に返ってくる戻り値によって処理
                        serial_y = Convert.ToString(Y_serialPort.ReadLine());
                        if (yrengeerr == false)
                        {
                            yrengeerr = true;
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(16);
                            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値再取得確認", "1", "距離計値取得処理", "ylazer");
                        }
                    }
                    catch (Exception ex)
                    {





                        Crane_point_y = -99999;


                        yrengeerr = false;
                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(10);
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値取得エラー", "2", "距離計値取得処理", "ylazer");
                        break;
                    }



                    if (serial_y.Length == 15 && serial_y.IndexOf("+") == 0)
                    {
                        yrenge = Convert.ToDouble(serial_y.Substring(1, 6));//距離計座標生値
                        if (yrenge != 0)
                        {
                            break;
                        }
                        else if (ycount == 50)
                        {





                            Crane_point_y = -99999;


                            yrengeerr = false;
                            //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(9);
                        }
                        else { ycount++; }
                    }
                }

                for (; ; )
                {
                    try
                    {
                        //タイムアウトの時に返ってくる戻り値によって処理
                        serial_z = Convert.ToString(Z_serialPort.ReadLine());
                        if (zrengeerr == false)
                        {
                            zrengeerr = true;
                            //  ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(17);
                            //    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値再取得確認", "1", "距離計値取得処理", "zlazer");
                        }
                    }
                    catch (Exception ex)
                    {



                        Crane_point_z = -99999;
                        zrengeerr = false;
                        //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(11);
                        // ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値取得エラー", "2", "距離計値取得処理", "zlazer");
                        break;
                    }



                    if (serial_z.Length == 15 && serial_z.IndexOf("+") == 0)
                    {
                        zrenge = Convert.ToDouble(serial_z.Substring(1, 6));//距離計座標生値
                        if (zrenge != 0)
                        {
                            break;
                        }
                        else if (zcount == 100)
                        {
                            Crane_point_z = -99999;
                            zrengeerr = false;
                            //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(9);
                        }
                        else { zcount++; }
                    }
                }







                if (xrengeerr == true)
                {
                    if (Properties.Settings.Default.Inverted_Value_X == 0)
                    {

                        Crane_point_x = Convert.ToInt32(xrenge - Properties.Settings.Default.Offset_Value_X);
                    }
                    else
                    {
                        Crane_point_x = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_X - xrenge);
                    }
                }

                if (yrengeerr == true)
                {
                    if (Properties.Settings.Default.Inverted_Value_Y == 0)
                    {
                        Crane_point_y = Convert.ToInt32(yrenge - Properties.Settings.Default.Offset_Value_Y);
                    }
                    else { Crane_point_y = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_Y - yrenge); }
                }

                if (zrengeerr == true)
                {
                    if (Properties.Settings.Default.Inverted_Value_Z == 0)
                    {
                        Crane_point_z = Convert.ToInt32(zrenge - Properties.Settings.Default.Offset_Value_Z);
                    }
                    else { Crane_point_z = Convert.ToInt32(Properties.Settings.Default.Inverted_Value_Z - zrenge); }
                }
                //Crane_point_y = 5000;//test
                //Crane_point_z = 4000;//test
                if (xrengeerr == true && yrengeerr == true && zrengeerr == true)
                {
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(2);
                }
                else
                {
                    xrengeerr = true;
                    yrengeerr = true;
                    zrengeerr = true;

                    // await Task.Delay(20000);
                    continue;

                }


                //Crane_point_x =i;テスト
                //Crane_point_y =i;
                //Crane_point_z =i;

                //CoilLocation(Crane_point_x, Crane_point_y, Crane_point_z);
                await Task.Delay(100);
                //}


            }

        }

        static void CoilLocation(double X, double Y, double Z)
        {
            string xloc = "";//ロケーション座標
            string yloc = "";//ロケーション座標
            string zloc = "";//ロケーション座標

            //DBの検索結果を各変数に入れる

            //Location_x = xloc;
            //Location_y = yloc;
            //Location_z = zloc;

        }




        static void label_check(int labelNo)
        {







        }
        /// <summary>
        /// 作業区分表示項目決定処理
        /// </summary>
        /// <param name="区分"></param>
        /// <param name="タグID"></param>
        /// <param name="現品NO"></param>
        /// <param name="重量"></param>
        /// <param name="寸法"></param>
        public void tag_show(string 区分, string タグID, string 現品NO, string 重量, string 寸法)
        {

            if (区分 == "入庫")
            {
                cdMove = "0";
            }
            else if (区分 == "出庫")
            {
                cdMove = "1";
            }
            else if (区分 == "配替")
            {
                cdMove = "2";
            }
            else { cdMove = "9"; }
            対象現品No = 現品NO;
            移動開始時刻 = datetime;
            tagkbn = 区分;
            Classification.Text = 区分;
            tagID.Text = tagId;
            APNo.Text = 現品NO;
            weight.Text = 重量;
            size.Text = 寸法;
        }
        /// <summary>
        /// 表示コイルの色、文字決定
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="出庫日"></param>
        /// <param name="積込日"></param>
        /// <param name="目標"></param>
        /// <param name="モード"></param>
        public void Operation_disp(int x, int y, string 出庫日, string 積込日, int 目標, int モード)
        {
            if (出庫日 == string.Empty || 積込日 == string.Empty)
            {
                if (目標 == 1)
                {
                    coil_view[x, y].Style.BackColor = Color.Red;
                    return;
                }

                if (モード == 1)
                {


                    coil_view[x, y].Style.BackColor = Color.SkyBlue;

                }
                else coil_view[x, y].Style.BackColor = Color.Purple;
                return;
            }

            string day = 積込日;
            day = day.Remove(0, 8);
            day = day.TrimStart(new Char[] { '0' });
            //積込日 = "2021/05/26";
            //出庫日 = "2021/05/27";
            if (モード == 1)
            {
                if (目標 == 1) { coil_view[x, y].Style.BackColor = Color.Red; }
                else if (Convert.ToDateTime(積込日) <= dateTime)
                {
                    if (積込日 == 出庫日) { coil_view[x, y].Style.BackColor = Color.Yellow; }
                    else { coil_view[x, y].Style.BackColor = Color.Yellow; coil_view[x, y].Value = "ヨ"; }
                }
                else if (Convert.ToDateTime(積込日) == dateTime.AddDays(1))
                {
                    if (積込日 == 出庫日) { coil_view[x, y].Style.BackColor = Color.LightGreen; }
                    else { coil_view[x, y].Style.BackColor = Color.LightGreen; coil_view[x, y].Value = "ヨ"; }
                }
                else
                {
                    if (Convert.ToDateTime(積込日) <= dateTime.AddDays(Properties.Settings.Default.Add_day))
                    {
                        coil_view[x, y].Style.BackColor = Color.SkyBlue; coil_view[x, y].Value = Convert.ToString(day);
                    }
                    else { coil_view[x, y].Style.BackColor = Color.SkyBlue; }
                }
            }
            else if (モード == 2)
            {
                if (目標 == 1) { coil_view[x, y].Style.BackColor = Color.Red; }
                else if (Convert.ToDateTime(積込日) <= dateTime)
                {
                    if (積込日 == 出庫日) { coil_view[x, y].Style.BackColor = Color.Yellow; }
                    else { coil_view[x, y].Style.BackColor = Color.Yellow; coil_view[x, y].Value = "ヨ"; }
                }
                else if (Convert.ToDateTime(積込日) == dateTime.AddDays(1))
                {
                    if (積込日 == 出庫日) { coil_view[x, y].Style.BackColor = Color.LightGreen; }
                    else { coil_view[x, y].Style.BackColor = Color.LightGreen; coil_view[x, y].Value = "ヨ"; }
                }
                else
                {
                    if (Convert.ToDateTime(積込日) <= dateTime.AddDays(Properties.Settings.Default.Add_day))
                    {
                        coil_view[x, y].Style.BackColor = Color.Purple; coil_view[x, y].Value = Convert.ToString(day);
                        coil_view[x, y].Style.ForeColor = Color.White;
                        //coil_view[x, y].Style = new DataGridViewCellStyle { ForeColor = Color.White };
                    }
                    else { coil_view[x, y].Style.BackColor = Color.Purple; }
                }
            }
        }
        /// <summary>
        /// 未設定エリア表示
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Location_Not_set_disp(int X, int Y)
        {
            coil_view[X - 1, Y - 1].Style.BackColor = Color.Gray;
            coil_view[X - 1, Y - 1].Value = "";

        }
        /// <summary>
        /// 禁止エリア表示
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public void Location_ban_disp(int X, int Y)
        {
            coil_view[X - 1, Y - 1].Style.BackColor = Color.White;
            coil_view[X - 1, Y - 1].Value = "×";
        }
        /// <summary>
        /// ロケーション画面表示
        /// </summary>
        public void disp()
        {
            //フリーエリアボタン名設定 2024.6.5 OGURI ADD STRAT↓
            int f = 0;
            foreach (Button btnFree in gro_FreeArea.Controls.OfType<Button>())
            {
                //フリーエリア名セット
                btnFree.Text = arrayFreeArea[f] + "\nコイル数:";//フリーエリアボタン名=フリーエリア名+改行+"コイル数:"+コイル数（コイル数はDBから取得）
                btnFree.Tag = arrayFreeArea[f];                 //Tagにフリーエリア名を保持
                btnFree.BackColor = SystemColors.Control;       //ボタン背景色リセット
                f += 1;
            }
            //フリーエリアボタン名にセットするコイル数をDBから取得しセットする
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(23);
            //選択されているコイルが存在するフリーエリアの場合ボタン色を赤に設定する
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(24);
            //2024.6.5 OGURI ADD END↑

            //コイル灰色未設定黒
            mozi = "-";
            // DataGridView初期化（データクリア）
            coil_view.Columns.Clear();
            coil_view.Rows.Clear();

            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            coil_view.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            coil_view.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


            coil_view.ColumnHeadersVisible = false;
            coil_view.RowHeadersVisible = false;





            //dataGridView1.Columns[0].HeaderText = "1";
            //dataGridView1.Columns[1].HeaderText = "2";
            coil_view.ColumnHeadersHeight = 55;
            coil_view.RowHeadersWidth = 55;



            //coil_view.ColumnCount = 46;//A1
            //coil_view.RowCount = 15;//A1
            coil_view.ColumnCount = 35;//B2
            coil_view.RowCount = 17;//B2


            for (int i = 0; i < coil_view.ColumnCount; i++)
            {
                coil_view.Columns[i].HeaderText = (i + 1).ToString();
                coil_view.Columns[i].Width = 23;
                coil_view.Columns[i].DefaultCellStyle.Alignment =
            DataGridViewContentAlignment.MiddleCenter;
            }
            int count = coil_view.RowCount;
            for (int j = 0; j < coil_view.RowCount; j++)
            {
                coil_view.Rows[j].Height = 21;
                coil_view.Rows[j].HeaderCell.Value = (count).ToString();
                count--;
            }
             //コイル取得

             ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(3);
            //未設定禁止エリア取得
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(20);
            //目標コイル取得
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);


            if (Crane_check.Checked == true)
            {
                //関数を使用し、クレーン座標の取得、座標値を元にロケ割り出し、割り出し先のロケに●を付与
            }
            this.coil_view.DefaultCellStyle.Font = new Font("メイリオ", 7);
        }

        void Coil_Setting()
        {
            //未設定エリアの設定

            //11(有効マスの数)
            coil_view[0, 11].Style.BackColor = Color.Gray;
            coil_view[0, 12].Style.BackColor = Color.Gray;
            coil_view[0, 13].Style.BackColor = Color.Gray;
            coil_view[0, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[1, 11].Style.BackColor = Color.Gray;
            coil_view[1, 12].Style.BackColor = Color.Gray;
            coil_view[1, 13].Style.BackColor = Color.Gray;
            coil_view[1, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[2, 10].Style.BackColor = Color.Gray;
            coil_view[2, 11].Style.BackColor = Color.Gray;
            coil_view[2, 12].Style.BackColor = Color.Gray;
            coil_view[2, 13].Style.BackColor = Color.Gray;
            coil_view[2, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[3, 10].Style.BackColor = Color.Gray;
            coil_view[3, 11].Style.BackColor = Color.Gray;
            coil_view[3, 12].Style.BackColor = Color.Gray;
            coil_view[3, 13].Style.BackColor = Color.Gray;
            coil_view[3, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[4, 11].Style.BackColor = Color.Gray;
            coil_view[4, 12].Style.BackColor = Color.Gray;
            coil_view[4, 13].Style.BackColor = Color.Gray;
            coil_view[4, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[5, 11].Style.BackColor = Color.Gray;
            coil_view[5, 12].Style.BackColor = Color.Gray;
            coil_view[5, 13].Style.BackColor = Color.Gray;
            coil_view[5, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[6, 11].Style.BackColor = Color.Gray;
            coil_view[6, 12].Style.BackColor = Color.Gray;
            coil_view[6, 13].Style.BackColor = Color.Gray;
            coil_view[6, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[7, 10].Style.BackColor = Color.Gray;
            coil_view[7, 11].Style.BackColor = Color.Gray;
            coil_view[7, 12].Style.BackColor = Color.Gray;
            coil_view[7, 13].Style.BackColor = Color.Gray;
            coil_view[7, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[8, 9].Style.BackColor = Color.Gray;
            coil_view[8, 10].Style.BackColor = Color.Gray;
            coil_view[8, 11].Style.BackColor = Color.Gray;
            coil_view[8, 12].Style.BackColor = Color.Gray;
            coil_view[8, 13].Style.BackColor = Color.Gray;
            coil_view[8, 14].Style.BackColor = Color.Gray;
            //13
            coil_view[10, 13].Style.BackColor = Color.Gray;
            coil_view[10, 14].Style.BackColor = Color.Gray;
            //12
            coil_view[11, 12].Style.BackColor = Color.Gray;
            coil_view[11, 13].Style.BackColor = Color.Gray;
            coil_view[11, 14].Style.BackColor = Color.Gray;
            //12
            coil_view[12, 12].Style.BackColor = Color.Gray;
            coil_view[12, 13].Style.BackColor = Color.Gray;
            coil_view[12, 14].Style.BackColor = Color.Gray;

            //10
            coil_view[13, 10].Style.BackColor = Color.Gray;
            coil_view[13, 11].Style.BackColor = Color.Gray;
            coil_view[13, 12].Style.BackColor = Color.Gray;
            coil_view[13, 13].Style.BackColor = Color.Gray;
            coil_view[13, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[14, 10].Style.BackColor = Color.Gray;
            coil_view[14, 11].Style.BackColor = Color.Gray;
            coil_view[14, 12].Style.BackColor = Color.Gray;
            coil_view[14, 13].Style.BackColor = Color.Gray;
            coil_view[14, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[15, 9].Style.BackColor = Color.Gray;
            coil_view[15, 10].Style.BackColor = Color.Gray;
            coil_view[15, 11].Style.BackColor = Color.Gray;
            coil_view[15, 12].Style.BackColor = Color.Gray;
            coil_view[15, 13].Style.BackColor = Color.Gray;
            coil_view[15, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[16, 9].Style.BackColor = Color.Gray;
            coil_view[16, 10].Style.BackColor = Color.Gray;
            coil_view[16, 11].Style.BackColor = Color.Gray;
            coil_view[16, 12].Style.BackColor = Color.Gray;
            coil_view[16, 13].Style.BackColor = Color.Gray;
            coil_view[16, 14].Style.BackColor = Color.Gray;
            //13
            coil_view[18, 13].Style.BackColor = Color.Gray;
            coil_view[18, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[19, 11].Style.BackColor = Color.Gray;
            coil_view[19, 12].Style.BackColor = Color.Gray;
            coil_view[19, 13].Style.BackColor = Color.Gray;
            coil_view[19, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[20, 11].Style.BackColor = Color.Gray;
            coil_view[20, 12].Style.BackColor = Color.Gray;
            coil_view[20, 13].Style.BackColor = Color.Gray;
            coil_view[20, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[21, 11].Style.BackColor = Color.Gray;
            coil_view[21, 12].Style.BackColor = Color.Gray;
            coil_view[21, 13].Style.BackColor = Color.Gray;
            coil_view[21, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[22, 11].Style.BackColor = Color.Gray;
            coil_view[22, 12].Style.BackColor = Color.Gray;
            coil_view[22, 13].Style.BackColor = Color.Gray;
            coil_view[22, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[23, 11].Style.BackColor = Color.Gray;
            coil_view[23, 12].Style.BackColor = Color.Gray;
            coil_view[23, 13].Style.BackColor = Color.Gray;
            coil_view[23, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[24, 11].Style.BackColor = Color.Gray;
            coil_view[24, 12].Style.BackColor = Color.Gray;
            coil_view[24, 13].Style.BackColor = Color.Gray;
            coil_view[24, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[25, 11].Style.BackColor = Color.Gray;
            coil_view[25, 12].Style.BackColor = Color.Gray;
            coil_view[25, 13].Style.BackColor = Color.Gray;
            coil_view[25, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[26, 10].Style.BackColor = Color.Gray;
            coil_view[26, 11].Style.BackColor = Color.Gray;
            coil_view[26, 12].Style.BackColor = Color.Gray;
            coil_view[26, 13].Style.BackColor = Color.Gray;
            coil_view[26, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[27, 10].Style.BackColor = Color.Gray;
            coil_view[27, 11].Style.BackColor = Color.Gray;
            coil_view[27, 12].Style.BackColor = Color.Gray;
            coil_view[27, 13].Style.BackColor = Color.Gray;
            coil_view[27, 14].Style.BackColor = Color.Gray;


            //9
            coil_view[28, 9].Style.BackColor = Color.Gray;
            coil_view[28, 10].Style.BackColor = Color.Gray;
            coil_view[28, 11].Style.BackColor = Color.Gray;
            coil_view[28, 12].Style.BackColor = Color.Gray;
            coil_view[28, 13].Style.BackColor = Color.Gray;
            coil_view[28, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[29, 9].Style.BackColor = Color.Gray;
            coil_view[29, 10].Style.BackColor = Color.Gray;
            coil_view[29, 11].Style.BackColor = Color.Gray;
            coil_view[29, 12].Style.BackColor = Color.Gray;
            coil_view[29, 13].Style.BackColor = Color.Gray;
            coil_view[29, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[30, 9].Style.BackColor = Color.Gray;
            coil_view[30, 10].Style.BackColor = Color.Gray;
            coil_view[30, 11].Style.BackColor = Color.Gray;
            coil_view[30, 12].Style.BackColor = Color.Gray;
            coil_view[30, 13].Style.BackColor = Color.Gray;
            coil_view[30, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[31, 10].Style.BackColor = Color.Gray;
            coil_view[31, 11].Style.BackColor = Color.Gray;
            coil_view[31, 12].Style.BackColor = Color.Gray;
            coil_view[31, 13].Style.BackColor = Color.Gray;
            coil_view[31, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[32, 10].Style.BackColor = Color.Gray;
            coil_view[32, 11].Style.BackColor = Color.Gray;
            coil_view[32, 12].Style.BackColor = Color.Gray;
            coil_view[32, 13].Style.BackColor = Color.Gray;
            coil_view[32, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[33, 10].Style.BackColor = Color.Gray;
            coil_view[33, 11].Style.BackColor = Color.Gray;
            coil_view[33, 12].Style.BackColor = Color.Gray;
            coil_view[33, 13].Style.BackColor = Color.Gray;
            coil_view[33, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[34, 11].Style.BackColor = Color.Gray;
            coil_view[34, 12].Style.BackColor = Color.Gray;
            coil_view[34, 13].Style.BackColor = Color.Gray;
            coil_view[34, 14].Style.BackColor = Color.Gray;
            //11
            coil_view[35, 11].Style.BackColor = Color.Gray;
            coil_view[35, 12].Style.BackColor = Color.Gray;
            coil_view[35, 13].Style.BackColor = Color.Gray;
            coil_view[35, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[36, 10].Style.BackColor = Color.Gray;
            coil_view[36, 11].Style.BackColor = Color.Gray;
            coil_view[36, 12].Style.BackColor = Color.Gray;
            coil_view[36, 13].Style.BackColor = Color.Gray;
            coil_view[36, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[37, 10].Style.BackColor = Color.Gray;
            coil_view[37, 11].Style.BackColor = Color.Gray;
            coil_view[37, 12].Style.BackColor = Color.Gray;
            coil_view[37, 13].Style.BackColor = Color.Gray;
            coil_view[37, 14].Style.BackColor = Color.Gray;
            //10
            coil_view[38, 10].Style.BackColor = Color.Gray;
            coil_view[38, 11].Style.BackColor = Color.Gray;
            coil_view[38, 12].Style.BackColor = Color.Gray;
            coil_view[38, 13].Style.BackColor = Color.Gray;
            coil_view[38, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[39, 9].Style.BackColor = Color.Gray;
            coil_view[39, 10].Style.BackColor = Color.Gray;
            coil_view[39, 11].Style.BackColor = Color.Gray;
            coil_view[39, 12].Style.BackColor = Color.Gray;
            coil_view[39, 13].Style.BackColor = Color.Gray;
            coil_view[39, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[40, 9].Style.BackColor = Color.Gray;
            coil_view[40, 10].Style.BackColor = Color.Gray;
            coil_view[40, 11].Style.BackColor = Color.Gray;
            coil_view[40, 12].Style.BackColor = Color.Gray;
            coil_view[40, 13].Style.BackColor = Color.Gray;
            coil_view[40, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[41, 9].Style.BackColor = Color.Gray;
            coil_view[41, 10].Style.BackColor = Color.Gray;
            coil_view[41, 11].Style.BackColor = Color.Gray;
            coil_view[41, 12].Style.BackColor = Color.Gray;
            coil_view[41, 13].Style.BackColor = Color.Gray;
            coil_view[41, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[42, 9].Style.BackColor = Color.Gray;
            coil_view[42, 10].Style.BackColor = Color.Gray;
            coil_view[42, 11].Style.BackColor = Color.Gray;
            coil_view[42, 12].Style.BackColor = Color.Gray;
            coil_view[42, 13].Style.BackColor = Color.Gray;
            coil_view[42, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[43, 9].Style.BackColor = Color.Gray;
            coil_view[43, 10].Style.BackColor = Color.Gray;
            coil_view[43, 11].Style.BackColor = Color.Gray;
            coil_view[43, 12].Style.BackColor = Color.Gray;
            coil_view[43, 13].Style.BackColor = Color.Gray;
            coil_view[43, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[44, 9].Style.BackColor = Color.Gray;
            coil_view[44, 10].Style.BackColor = Color.Gray;
            coil_view[44, 11].Style.BackColor = Color.Gray;
            coil_view[44, 12].Style.BackColor = Color.Gray;
            coil_view[44, 13].Style.BackColor = Color.Gray;
            coil_view[44, 14].Style.BackColor = Color.Gray;
            //9
            coil_view[45, 9].Style.BackColor = Color.Gray;
            coil_view[45, 10].Style.BackColor = Color.Gray;
            coil_view[45, 11].Style.BackColor = Color.Gray;
            coil_view[45, 12].Style.BackColor = Color.Gray;
            coil_view[45, 13].Style.BackColor = Color.Gray;
            coil_view[45, 14].Style.BackColor = Color.Gray;

            //クレーン位置test用
            //coil_view[5, 0].Value = "99";
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ポインタの表示
            if (Crane_check.Checked == false)
            {
                coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
            }
            else
            {
                //コイル表示画面のクレーン表示の削除処理
                //リロール

            }
        }

        private void OperationScreen_Shown(object sender, EventArgs e)
        {
            coil_view.CurrentCell = null;
        }

        private void red_coil1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //グリッドビューを選択できないようにする
            coil_view.ClearSelection();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label47_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label81_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Col_No1_Load(object sender, EventArgs e)
        {

        }

        private void lbl_Col_No1_Load_1(object sender, EventArgs e)
        {

        }


        public  void testref()
        {

            
            if (Crane_point_x != -99999 && Crane_point_x != -99998 && Crane_point_y != -99999 && Crane_point_y != -99998 && Crane_point_z != -99999 && Crane_point_z != -99998)
            {
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(2);
            }

            //警告音
            //if (caveat == "2")
            //{
            //    //警告音を鳴らす
            //    ((MainScreen)Application.OpenForms["MainScreen"]).MP3("2");
            //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(12);
            //    caveatflag = "1";
            //}
            //else if (caveat == "1")
            //{
            //    //注意音を鳴らす
            //    ((MainScreen)Application.OpenForms["MainScreen"]).MP3("1");
            //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(13);
            //    caveatflag = "1";
            //}
            //else if (caveat == "0" && caveatflag == "1")
            //{
            //    caveatflag = "0";
            //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
            //}

            //button2.Text = OperationScreen.testtest;//削除
            if (Properties.Settings.Default.Lifter_Manualmode == true) { bit1.Visible = false; bit2.Visible = false; }
            else { bit1.Visible = true; bit2.Visible = true; }
            if (bit1value == true)
            {
                bit1.Checked = true;
            }
            else { bit1.Checked = false; }

            if (bit2value == true)
            {
                bit2.Checked = true;
            }
            else { bit2.Checked = false; }
            //もしかしたらフラグチェックでストップ
            /*クレーン位置test用
            //testCrane_point_x++;
            //testCrane_point_y++;
            //if (testCrane_point_x == 15)
            //{
            //    testCrane_point_x = 1;
            //}
            //if (testCrane_point_y == 15)
            //{
            //    testCrane_point_y = 1;
            //}
            //Location_x=Convert.ToString(Convert.ToInt32(Location_x) + testCrane_point_x);
            //Location_y = Convert.ToString(1);
            */


            //クレーン距離表示
            if (Crane_point_x == -99999 || Crane_point_x == -99998)
            {
                if (Xerrvalue == true && Xerrcount == 0)
                {
                    Xerrcount = 1;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値取得エラー", "2", "距離計値取得処理", "xlazer");
                }
                CRP.Text = "-";
            }
            else
            {
                if (Xerrcount == 1)
                {
                    Xerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値再取得確認", "1", "距離計値取得処理", "xlazer");
                }
                //double pointx = Crane_point_x;
                //pointx = pointx * 0.001;
                //string Xpoint = Convert.ToString(pointx).ToString("0.0");

                Crane_point_x = Crane_point_x / 100;
                double Crane_point_dx = Crane_point_x;
                //フォーマット変更
                CRP.Text = Convert.ToString(Crane_point_dx / 10);


            }
            if (Crane_point_y == -99999 || Crane_point_y == -99998)
            {
                if (Yerrvalue == true && Yerrcount == 0)
                {
                    Yerrcount = 1;

                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値取得エラー", "2", "距離計値取得処理", "ylazer");
                }
                CRun.Text = "-";
            }
            else
            {
                if (Yerrcount == 1)
                {
                    Yerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値再取得確認", "1", "距離計値取得処理", "ylazer");
                }
                Crane_point_y = Crane_point_y / 100;
                double Crane_point_dy = Crane_point_y;
                CRun.Text = Convert.ToString(Crane_point_dy / 10);
            }
            if (Crane_point_z == -99999 || Crane_point_z == -99998)
            {
                if (Zerrvalue == true && Zerrcount == 0)
                {
                    Zerrcount = 1;

                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値取得エラー", "2", "距離計値取得処理", "zlazer");
                }
                CHgt.Text = "-";
            }
            else
            {


                if (Zerrcount == 1)
                {
                    Zerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値再取得確認", "1", "距離計値取得処理", "zlazer");
                }
                Crane_point_z = Crane_point_z / 100;
                double Crane_point_dz = Crane_point_z;
                CHgt.Text = Convert.ToString(Crane_point_dz / 10);
            }

            //クレーンロケーション表示
            if (CRP.Text == "-" || CRun.Text == "-" || CHgt.Text == "-")
            {

                CCol.Text = "-";
                CCom.Text = "-";
                CSt.Text = "-";
            }
            else
            {
                CCol.Text = Convert.ToString(Location_x);
                CCom.Text = Convert.ToString(Location_y);
                CSt.Text = Convert.ToString(Location_z);
            }
            //  Location_x = "-";//test
            //Location_y = "1";//test
            //Location_z = "1";//test




            // CRun.Text = "1";//test
            //CCom.Text = "1";//test
            //CHgt.Text = "1";//test
            //Location_x = "1";//test
            //Location_y = "1";//test
            //Crane_y = "1";//test
            //Location_z = "1";//test

            //coil_view[Crane_x, Crane_y].Value ==
            //ここのロジック修正
            if (Crane_check.Checked == true)
            {
                //フリーエリアの場合の処理追加//20240610 山﨑
                if (CLocation_x == Properties.Settings.Default.Free_X)
                {
                    if (mozi != string.Empty && mozi != "-")
                    {
                        coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                    }
                    else if (Convert.ToString(coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value) == "●")
                    {
                        coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = "";
                    }
                }
                else
                {

                    if (CLocation_x != "-" && CLocation_y != "-" && CLocation_x != "99" && CLocation_x != "98")
                    {

                        if (Convert.ToString(coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value) != "●")
                        {
                            if (mozi != "-")
                            {
                                coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                            }
                            mozi = Convert.ToString(coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value);


                            coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value = "●";
                            Crane_x = CLocation_x;
                            Crane_y = CLocation_y;
                        }
                    }
                    else
                    {
                        if (mozi != string.Empty && mozi != "-")
                        {
                            coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                        }
                        else if (Convert.ToString(coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value) == "●")
                        {
                            coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = "";
                        }

                    }
                }



            }

            if (Properties.Settings.Default.Lifter_Manualmode == false)
            {
                if (manualOpen.Visible == true || manuaClose.Visible == true)
                {
                    manualOpen.Visible = false;
                    manuaClose.Visible = false;
                }

            }
            else
            {
                if (manualOpen.Visible == false || manuaClose.Visible == false)
                {
                    manualOpen.Visible = true;
                    manuaClose.Visible = true;
                }
            }           
        }

        /// <summary>
        /// 画面更新処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timer1_Tick(object sender, EventArgs e)  // 非同期化、重い処理をバックグラウンド実行に変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
        //private void timer1_Tick(object sender, EventArgs e)      // 2026/03/27 OGURI DEL（ver1.1.0.0対応）
        {
            if (_coordinateProcessing) return; // 重入防止フラグを追加して二重実行を防止 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            _coordinateProcessing = true;
            Coordinate_timer.Stop();
            try // try-finallyブロックを追加してフラグのリセットとタイマーの再開を確実に行うように変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            {
                if (Crane_point_x != -99999 && Crane_point_x != -99998 && Crane_point_y != -99999 && Crane_point_y != -99998 && Crane_point_z != -99999 && Crane_point_z != -99998)
                    {
                    try
                    {
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(2);
                    }
                    catch (Exception ex)
                    {
                        ((MainScreen)Application.OpenForms["MainScreen"]).System_log("OracleDBsql(2) failed: " + ex.Message, "2", "DB", "Oracle"); // 異常発生時ログ出力 2026/03/27 OGURI ADD（ver1.1.0.0対応）
                    }
                }

                //警告音
                //if (caveat == "2")
                //{
                //    //警告音を鳴らす
                //    ((MainScreen)Application.OpenForms["MainScreen"]).MP3("2");
                //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(12);
                //    caveatflag = "1";
                //}
                //else if (caveat == "1")
                //{
                //    //注意音を鳴らす
                //    ((MainScreen)Application.OpenForms["MainScreen"]).MP3("1");
                //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(13);
                //    caveatflag = "1";
                //}
                //else if (caveat == "0" && caveatflag == "1")
                //{
                //    caveatflag = "0";
                //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                //}

                //button2.Text = OperationScreen.testtest;//削除
                if (Properties.Settings.Default.Lifter_Manualmode == true) { bit1.Visible = false; bit2.Visible = false; }
            else { bit1.Visible = true; bit2.Visible = true; }
            if (bit1value == true)
            {
                bit1.Checked = true;
            }
            else { bit1.Checked = false; }

            if (bit2value == true)
            {
                bit2.Checked = true;
            }
            else { bit2.Checked = false; }

            //クレーン距離表示
            if (Crane_point_x == -99999 || Crane_point_x == -99998)
            {
                if (Xerrvalue == true && Xerrcount == 0)
                {
                    Xerrcount = 1;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値取得エラー", "2", "距離計値取得処理", "xlazer");
                }
                CRP.Text = "-";
            }
            else 
            {
                if (Xerrcount == 1)
                {
                    Xerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸値再取得確認", "1", "距離計値取得処理", "xlazer");
                }

                Crane_point_x = Crane_point_x / 100;
                double Crane_point_dx = Crane_point_x;
                //フォーマット変更
                CRP.Text = Convert.ToString(Crane_point_dx / 10);
            }
            if (Crane_point_y == -99999|| Crane_point_y == -99998)
            {
                if (Yerrvalue == true && Yerrcount == 0)
                {
                    Yerrcount = 1;
                   
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値取得エラー", "2", "距離計値取得処理", "ylazer");
                }
                CRun.Text = "-";
            }
            else 
            {
                if (Yerrcount == 1)
                {
                    Yerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸値再取得確認", "1", "距離計値取得処理", "ylazer");
                }
                Crane_point_y = Crane_point_y / 100;
                double Crane_point_dy = Crane_point_y;
                CRun.Text = Convert.ToString(Crane_point_dy / 10);
            }
            if (Crane_point_z == -99999||Crane_point_z == -99998 )
            {
                if (Zerrvalue == true && Zerrcount == 0)
                {
                    Zerrcount = 1;
                   
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値取得エラー", "2", "距離計値取得処理", "zlazer");
                }
                CHgt.Text = "-";
            }
            else {
                if (Zerrcount == 1)
                {
                    Zerrcount = 0;
                    ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸値再取得確認", "1", "距離計値取得処理", "zlazer");
                }
                Crane_point_z = Crane_point_z / 100;
                double Crane_point_dz = Crane_point_z;
                CHgt.Text = Convert.ToString(Crane_point_dz / 10);
            }

            //クレーンロケーション表示
            if (CRP.Text == "-" || CRun.Text == "-" || CHgt.Text == "-")
            {
                CCol.Text = "-";
                CCom.Text = "-";
                CSt.Text = "-";
            }
            else
            {
                CCol.Text = Convert.ToString(Location_x);
                CCom.Text = Convert.ToString(Location_y);
                CSt.Text = Convert.ToString(Location_z);
            }
            if (Crane_check.Checked == true)
            {
                //フリーエリアの場合の処理追加//20240610 山﨑
                if (CLocation_x == Properties.Settings.Default.Free_X)
                {
                    if (mozi != string.Empty && mozi != "-")
                    {
                        coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                    }
                    else if (Convert.ToString(coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value) == "●")
                    {
                        coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = "";
                    }
                }
                else { 
                    if (CLocation_x != "-" && CLocation_y != "-" && CLocation_x != "99" && CLocation_x != "98")
                    {
                        if (Convert.ToString(coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value) != "●")
                        {
                            if (mozi != "-")
                            {
                                coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                            }
                            mozi = Convert.ToString(coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value);

                            coil_view[Convert.ToInt32(CLocation_x) - 1, Convert.ToInt32(CLocation_y) - 1].Value = "●";
                            Crane_x = CLocation_x;
                            Crane_y = CLocation_y;
                        }
                    }
                    else
                    {
                        if (mozi != string.Empty && mozi != "-")
                        {
                            coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = mozi;
                        }
                        else if (Convert.ToString(coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value) == "●")
                        {
                            coil_view[Convert.ToInt32(Crane_x) - 1, Convert.ToInt32(Crane_y) - 1].Value = "";
                        }
                    }
                }
            }
           
            if (Properties.Settings.Default.Lifter_Manualmode == false)
            {
                if (manualOpen.Visible == true || manuaClose.Visible == true)
                {
                    manualOpen.Visible = false;
                    manuaClose.Visible = false;
                }
            }
            else
            {
                if (manualOpen.Visible == false || manuaClose.Visible == false)
                {
                    manualOpen.Visible = true;
                    manuaClose.Visible = true;
                }
            }
                Coordinate_timer.Interval = 300;
                //Coordinate_timer.Start(); // finallyに移動 2026/03/27 OGURI DEL（ver1.1.0.0対応）
            }
            finally
            {
                Coordinate_timer.Start();
                _coordinateProcessing = false;
            }
        }

        private void refresh_timer_Tick(object sender, EventArgs e)
        {
            //もしかしたらフラグチェックでストップ
            //refresh_timer.Stop();
            //disp();
            //refresh_timer.Start();
        }

        /// <summary>
        /// タグ読み取り処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void RFIDtimer_Tick(object sender, EventArgs e)   // 非同期化、重い処理をバックグラウンド実行に変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
        //private void RFIDtimer_Tick(object sender, EventArgs e)       //  2026/03/27 OGURI DEL（ver1.1.0.0対応）
        {
            if (_rfidProcessing) return; // 重入防止フラグを追加して二重実行を防止 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            _rfidProcessing = true;
            RFIDtimer.Stop();

            //もしかしたらフラグチェックでストップ
            try // try-finallyブロックを追加してフラグのリセットとタイマーの再開を確実に行うように変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            {
                var result = await Task.Run(() => send_http_message(g_read_cmd_header + "4getlist"));// 非同期でHTTPリクエストを送信して結果を取得 2026/03/27 OGURI ADD（ver1.1.0.0対応）
                // string result = send_http_message(g_read_cmd_header + "4getlist");
                //テストプログラム
                //for(int i = 0; i < tagname.Length; i++)
                //{
                //    最終タグ読み取り数.Items.Add(tagname[i]);
                //}
                //ここまで

                //if (json_get(result, "status").StartsWith("stopped") && RFIDflag == false)
                if (true)
                {
                    coilpointX = -99999;        //コイル座標X
                    coilpointY = -99999;        //コイル座標Y
                    coilpointZ = -99999;        //コイル座標Z
                    coillocX = "0";             //コイルロケX
                    coillocY = "0";             //コイルロケY
                    coillocZ = "0";             //コイルロケZ
                    coilloc = "0-0-0";          //コイルロケ
                    ClenpointX = Crane_point_x; //クレーン座標X
                    ClenpointY = Crane_point_y; //クレーン座標Y
                    ClenpointZ = Crane_point_z; //クレーン座標Z

                    現品番号 = "現品情報無し";
                    //string f = tagname[0];
                    //string b = tagname[1];
                    //string c = tagname[2];
                    //string d = tagname[3];
                    if (tagname[0] != string.Empty)
                    {
                        RFIDContinuousflag = false;
                        Properties.Settings.Default.antena_decibel = def_decibel;
                        if (tagname[1] == string.Empty)//単体読み
                        {
                            tagId = tagname[0];
                            //ここからDB等の処理に移行
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(22);
                            if (coilpointX != -99999 && coilpointY != -99999 && coilpointZ != -99999)//ロケデータが存在するか？
                            {
                                if (coilpointX >= Crane_point_x - Properties.Settings.Default.X_sikiti && coilpointX <= Crane_point_x + Properties.Settings.Default.X_sikiti && coilpointY >= Crane_point_y - Properties.Settings.Default.Y_sikiti && coilpointY <= Crane_point_y + Properties.Settings.Default.Y_sikiti && coilpointZ >= Crane_point_z - Properties.Settings.Default.Z_sikiti && coilpointZ <= Crane_point_z + Properties.Settings.Default.Z_sikiti)
                                {

                                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                                    RFIDflag = true;
                                    RFIDcount = 0;
                                    RFIDtimer.Enabled = false;
                                    //RFIDContinuousflag = false;
                                    tagreadcnt = 0;
                                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                }
                                else//MSG１
                                {
                                    if (coilloc == "0-0-0")
                                    {
                                        coilloc = "ロケ情報なし";
                                    }
                                    //メッセージボックスを表示する
                                    Clocation = Location_x + "-" + Location_y + "-" + Location_z;
                                    ShowMSG = MSG1;
                                    //重複起動処理フラグ追加　20240626 山﨑
                                    重複処理フラグ = true;
                                    //ここまで
                                    CoilShowDialog coilShow = new CoilShowDialog();
                                    coilShow.ShowDialog();
                                    if (tagId != "-")
                                    {
                                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                                        // RFIDflag = true;
                                        RFIDcount = 0;
                                        // RFIDtimer.Enabled = false;
                                        //RFIDContinuousflag = false;
                                        tagreadcnt = 0;
                                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                    }
                                    else
                                    {
                                        RFIDContinuousflag = true;
                                        RFIDcount = 2;


                                        tagreadcnt = 0;
                                        RFIDcount = 0;
                                        RFIDtimer.Enabled = false;
                                        IOflag = false;
                                        if (Properties.Settings.Default.Lifter_Manualmode == true && tagreadcnt != 0)
                                        {
                                            //  manuaClose.PerformClick();
                                        }
                                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                        return;
                                        //}


                                    }

                                }
                            }
                            else//MSG2
                            {
                                if (Location_x == "-" || Location_y == "-" || Location_z == "-")//ロケーション外
                                {

                                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                                    RFIDflag = true;
                                    RFIDcount = 0;
                                    RFIDtimer.Enabled = false;
                                    //RFIDContinuousflag = false;
                                    tagreadcnt = 0;
                                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                }
                                else
                                {
                                    Clocation = Location_x + "-" + Location_y + "-" + Location_z;
                                    ShowMSG = MSG2;

                                    //重複起動処理フラグ追加　20240626 山﨑
                                    重複処理フラグ = true;
                                    //ここまで

                                    CoilShowDialog coilShow = new CoilShowDialog();
                                    coilShow.ShowDialog();
                                    if (tagId != "-")
                                    {

                                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                                        // RFIDflag = true;
                                        RFIDcount = 0;
                                        // RFIDtimer.Enabled = false;
                                        //RFIDContinuousflag = false;
                                        tagreadcnt = 0;
                                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                    }
                                    else
                                    {
                                        RFIDContinuousflag = true;
                                        RFIDcount = 2;


                                        tagreadcnt = 0;
                                        RFIDcount = 0;
                                        RFIDtimer.Enabled = false;
                                        IOflag = false;
                                        if (Properties.Settings.Default.Lifter_Manualmode == true && tagreadcnt != 0)
                                        {
                                            //  manuaClose.PerformClick();
                                        }
                                        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                        return;
                                        //}


                                    }
                                }
                            }

                        }
                        else //複数読み
                        {
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                            Clocation = Location_x + "-" + Location_y + "-" + Location_z;

                            //重複起動処理フラグ追加　20240626 山﨑
                            重複処理フラグ = true;
                            //ここまで

                            multicoil coil = new multicoil();
                            coil.ShowDialog();
                            if (tagId != "-")
                            {
                                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                                // RFIDflag = true;
                                RFIDcount = 0;
                                // RFIDtimer.Enabled = false;
                                //RFIDContinuousflag = false;
                                tagreadcnt = 0;
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                            }
                            else
                            {
                                RFIDContinuousflag = true;
                                RFIDcount = 2;


                                tagreadcnt = 0;
                                RFIDcount = 0;
                                RFIDtimer.Enabled = false;
                                IOflag = false;
                                if (Properties.Settings.Default.Lifter_Manualmode == true && tagreadcnt != 0)
                                {
                                    //  manuaClose.PerformClick();
                                }
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                return;
                                //}


                            }
                        }
                        //以下複数読みテストプログラム
                        //string c;//タグIDチェック用変数
                        //for (int i = 1; i < tagname.Length; i++) {

                        //    if (tagname[i] == string.Empty)
                        //    {
                        //        break;
                        //    }
                        //    c = Convert.ToString(tagname[i]).Substring(0, 14);
                        //    if (c != Properties.Settings.Default.tagID)
                        //    { continue; }

                        //    else if (tagname[0] != tagname[i])
                        //    {
                        //        RFIDflag = true;
                        //        RFIDcount = 0;
                        //        RFIDtimer.Enabled = false;
                        //        //RFIDContinuousflag = false;
                        //        tagreadcnt = 0;
                        //        multitagflag = true;
                        //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(30);

                        //    }

                    }
                    else if (tagname[0] == string.Empty)
                    {
                        RFIDContinuousflag = true;
                        RFIDcount = 2;

                        if (RFIDcount == 2)
                        {

                            //ここに出力上げる処理
                            tagreadcnt++;
                            if (tagreadcnt == 1)
                            {
                                Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_A;
                            }
                            else if (tagreadcnt == 2)
                            {
                                Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_B;
                            }
                            else if (tagreadcnt == 3)
                            {
                                Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_C;
                            }
                            else if (tagreadcnt == 4)
                            {
                                Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_D;
                            }
                            else if (tagreadcnt == 5)
                            {
                                Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_E;
                            }
                            else
                            {
                                Properties.Settings.Default.antena_decibel = def_decibel;
                                tagreadcnt = 0;
                                // MessageBox.Show("TEST RFIDタグを読み取れませんでした");
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                            }
                            RFIDcount = 0;
                            RFIDtimer.Enabled = false;
                            IOflag = false;
                            if (Properties.Settings.Default.Lifter_Manualmode == true && tagreadcnt != 0)
                            {
                                manuaClose.PerformClick();
                            }
                            return;
                        }
                    }
                    //ここまで

                    //string b = Convert.ToString(tagname[0]).Substring(0, 14);
                    //if (b == Properties.Settings.Default.tagID)
                    //{
                    //string h = Convert.ToString(tagname[0]).Substring(22, 7);
                    //tagID.Text = h.Replace("-", "");
                    //tagId = h.Replace("-", "");


                    ////ここからDB等の処理に移行
                    //((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                    //RFIDflag = true;
                    //RFIDcount = 0;
                    //RFIDtimer.Enabled = false;
                    ////RFIDContinuousflag = false;
                    //tagreadcnt = 0;
                    //((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);

                    // }

                }
                else
                {
                    RFIDContinuousflag = true;
                    RFIDcount = 2;

                    if (RFIDcount == 2)
                    {

                        //ここに出力上げる処理
                        tagreadcnt++;
                        if (tagreadcnt == 1)
                        {
                            Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_A;
                        }
                        else if (tagreadcnt == 2)
                        {
                            Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_B;
                        }
                        else if (tagreadcnt == 3)
                        {
                            Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_C;
                        }
                        else if (tagreadcnt == 4)
                        {
                            Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_D;
                        }
                        else if (tagreadcnt == 5)
                        {
                            Properties.Settings.Default.antena_decibel = Properties.Settings.Default.antena_decibel_E;
                        }
                        else
                        {
                            Properties.Settings.Default.antena_decibel = def_decibel;
                            tagreadcnt = 0;
                            // MessageBox.Show("TEST RFIDタグを読み取れませんでした");
                            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                        }
                        RFIDcount = 0;
                        RFIDtimer.Enabled = false;
                        IOflag = false;
                        if (Properties.Settings.Default.Lifter_Manualmode == true && tagreadcnt != 0)
                        {
                            manuaClose.PerformClick();
                        }
                        return;
                    }
                }
                //show_status();

                if (Properties.Settings.Default.Lifter_Manualmode == false)
                {
                    if (IOmode != 2)
                    {
                        IOCheckflag = false;
                        //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム

                        IOmode = 0;
                        //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                    }
                    IO.Start();
                }
            }
            finally
            {
                RFIDtimer.Start();
                _rfidProcessing = false;
            }
        }

        /// <summary>
        /// IO処理　閉じたときはタグの読み取りを行い、開いた時はコイルの位置を確定させる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void IO_Tick(object sender, EventArgs e)  // 非同期化、重い処理をバックグラウンド実行に変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
        //private void IO_Tick(object sender, EventArgs e)      // 2026/03/27 OGURI DEL（ver1.1.0.0対応）
        {
            if (_ioProcessing) return; // 重入防止フラグを追加して二重実行を防止 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            _ioProcessing = true;
            //bool 設定1;//テストプログラム
            //bool 設定2;//テストプログラム
            //もしかしたらフラグチェックでストップ
            IO.Enabled=false;
            try // try-finallyブロックを追加してフラグのリセットとタイマーの再開を確実に行うように変更 2026/03/27 OGURI ADD（ver1.1.0.0対応）
            {
                read_IO();
            //----------------------------------------------------------------------------------
            //2024.06.17 morichika
            io_process();

                //bool IOpingflag = true;
                //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(4, "タイマーストップ");//テストプログラム
                //test5.Text = "flag="+Convert.ToString(IOCheckflag) + ":mode="+Convert.ToString(IOmode) + ":ID="+tagId;
                //IOCheckflag = true;//テストプログラム
                ////IOmode = 1;//テストプログラム

                //コメントアウト
                //if (IOCheckflag == true && IOmode == 1 && tagId == "-")//閉じたとき
                //{
                //    //テストプログラム
                //    //タグ読み取り数.Items.Clear();
                //    //最終タグ読み取り数.Items.Clear();
                //    //ここまで
                //   // IOcount++;
                //    //test1.Text = "RFID処理開始　"+IOcount;
                //    for (int i = 0; i < tagname.Length; i++)
                //    {
                //        tagname[i] = "";
                //    }
                //    tagcount = 0;
                //    if(exec_set_commands("/reader/inventory/012setconfig?get_chanid_flg=1&get_phase_flg=1&get_seentime_flg=1&stop_timer=" + Properties.Settings.Default.antena_stoptime) == false)
                //    {
                //        IOpingflag = false;
                //        //test3.Text = Convert.ToString(false);
                //    }
                //    else
                //    {
                //        //test3.Text = Convert.ToString(true);
                //    }
                //    if(exec_set_commands("/reader/antenna/1/008setconfig?antennastatus=1&powerlevel=" + Properties.Settings.Default.antena_decibel) == false)
                //    {
                //        IOpingflag = false;
                //        //test3.Text = Convert.ToString(false);
                //    }
                //    else
                //    {
                //        //test3.Text = Convert.ToString(true);
                //    }
                //    if (IOpingflag == true)
                //    {
                //        if (button_start_Click_sub() == false)//読み取り開始
                //        {
                //            //test3.Text = "処理失敗";
                //            IOpingflag = false;
                //            //test3.Text = Convert.ToString(false);
                //        }
                //        else
                //        {
                //            //test3.Text = "処理成功";
                //            //test3.Text = Convert.ToString(true);
                //        }
                //    }
                //    //test2.Text = "RFID処理終了" + IOcount;
                //    if (IOpingflag == false)
                //    {
                //        IOflag = false;
                //        IOCheckflag = false;
                //        IOmode = 0;
                //    }
                //    else
                //    {
                //        IOCheckflag = false;
                //        IOmode = 0;
                //    }
                //    //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム
                //    //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                //    if (tagreadcnt == 0)
                //    {
                //        //test4.Text = "読み取り開始150" + IOcount;
                //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(20);
                //    }
                //    else
                //    {
                //        //test4.Text = "読み取り開始200" + IOcount;
                //        ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(21);
                //    }
                //}
                //else if (IOCheckflag == true && IOmode == 2 && tagId != "-" && tagId != string.Empty)//開いた時
                //{
                //    ////複数よんでいた場合の処理
                //    //if (multitagflag == true)
                //    //{
                //    //    multitagflag = false;
                //    //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                //    //    //リセット処理
                //    //    RFIDflag = false;
                //    //    IOCheckflag = false;
                //    //    IOmode = 0;
                //    //    IOflag = false;
                //    //    IO.Enabled = true;
                //    //    return;
                //    //}
                //    //OperationScreen.Location_x = "5";
                //    //OperationScreen.Location_y = "5";
                //    //OperationScreen.Location_z = "1";
                //    //OperationScreen.tagId = "000023";
                //    // ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(6);
                //    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                //    //配替と出庫の判定は全てがブランクかどうか
                //    if (cdMove == "0" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//入庫
                //    {
                //        cdMove = "0";
                //        tagkbn = "入庫";
                //        フリーエリア判定();
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(15);//入庫
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                //    }
                //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//配替
                //    {
                //        cdMove = "2";
                //        tagkbn = "配替";
                //        フリーエリア判定();
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(16);//配替
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル取得
                //    }
                //    else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x == "-" && OperationScreen.Location_y == "-" && OperationScreen.Location_z == "-")//出庫
                //    {
                //        cdMove = "1";
                //        tagkbn = "出庫";
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(17);//出庫
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル取得
                //    }
                //    else if (cdMove == "0" && OperationScreen.Location_x == "-" || OperationScreen.Location_y == "-" || OperationScreen.Location_z == "-")//その他
                //    {
                //        //その他の処理
                //        cdMove = "9";
                //        tagkbn = "入庫";
                //        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                //    }
                //    else if (cdMove == "9")
                //    {
                //        //その他の処理
                //    }
                //    else
                //    {
                //        MessageBox.Show("ロケーションの値が参照できない為処理が行えませんでした"); //エラー表示
                //    }
                //    //リセット処理
                //    tagdispreset();
                //    RFIDflag = false;
                //    disp();
                //    IOCheckflag = false;
                //   // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム
                //    IOmode = 0;
                //   // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                //    IOflag = false;
                //    // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(4, "タイマー起動");//テストプログラム
                //    IO.Enabled = true;
                //}
                // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(4, "タイマー起動");//テストプログラム
                //----------------------------------------------------------------------------------

                //IO.Enabled = true; //finallyブロックに移動 2026/03/27 OGURI DEL（ver1.1.0.0対応）
            }
            finally
            {
                IO.Enabled = true;
                _ioProcessing = false;
            }
        }

        //2024.06.17 morichika
        public void io_process()
        {
            bool IOpingflag = true;

            if (IOCheckflag == true && IOmode == 1 && tagId == "-")//閉じたとき
            {
                //重複起動処理追加　20240626 山﨑
                if (重複処理フラグ == true)
                {
                    return;
                }
                // ここまで

                //テストプログラム
                //タグ読み取り数.Items.Clear();
                //最終タグ読み取り数.Items.Clear();
                //ここまで
                // IOcount++;

                //test1.Text = "RFID処理開始　"+IOcount;
                for (int i = 0; i < tagname.Length; i++)
                {
                    tagname[i] = "";
                }
                tagcount = 0;

                if (exec_set_commands("/reader/inventory/012setconfig?get_chanid_flg=1&get_phase_flg=1&get_seentime_flg=1&stop_timer=" + Properties.Settings.Default.antena_stoptime) == false)
                {
                    IOpingflag = false;

                    //test3.Text = Convert.ToString(false);
                }
                else
                {
                    //test3.Text = Convert.ToString(true);
                }

                if (exec_set_commands("/reader/antenna/1/008setconfig?antennastatus=1&powerlevel=" + Properties.Settings.Default.antena_decibel) == false)
                {
                    IOpingflag = false;

                    //test3.Text = Convert.ToString(false);
                }
                else
                {
                    //test3.Text = Convert.ToString(true);
                }
                if (IOpingflag == true)
                {
                    if (button_start_Click_sub() == false)//読み取り開始
                    {
                        //test3.Text = "処理失敗";
                        IOpingflag = false;

                        //test3.Text = Convert.ToString(false);
                    }
                    else
                    {
                        //test3.Text = "処理成功";
                        //test3.Text = Convert.ToString(true);
                    }
                }
                //test2.Text = "RFID処理終了" + IOcount;
                if (IOpingflag == false)
                {
                    IOflag = false;
                    IOCheckflag = false;
                    IOmode = 0;
                }
                else
                {
                    IOCheckflag = false;
                    IOmode = 0;
                }



                //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム

                //((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                if (tagreadcnt == 0)
                {
                    //test4.Text = "読み取り開始150" + IOcount;
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(20);
                }
                else
                {
                    //test4.Text = "読み取り開始200" + IOcount;
                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(21);
                }


            }
            else if (IOCheckflag == true && IOmode == 2 && tagId != "-" && tagId != string.Empty)//開いた時
            {
                ////複数よんでいた場合の処理
                //if (multitagflag == true)
                //{
                //    multitagflag = false;
                //    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                //    //リセット処理
                //    RFIDflag = false;
                //    IOCheckflag = false;
                //    IOmode = 0;
                //    IOflag = false;
                //    IO.Enabled = true;
                //    return;
                //}

                //OperationScreen.Location_x = "5";
                //OperationScreen.Location_y = "5";
                //OperationScreen.Location_z = "1";
                //OperationScreen.tagId = "000023";
                // ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(6);

                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(14);
                //配替と出庫の判定は全てがブランクかどうか
                if (cdMove == "0" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//入庫
                {
                    cdMove = "0";
                    tagkbn = "入庫";
                    フリーエリア判定();
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(15);//入庫
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                }
                else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x != "-" && OperationScreen.Location_y != "-" && OperationScreen.Location_z != "-")//配替
                {                    
                    cdMove = "2";
                    tagkbn = "配替";
                    フリーエリア判定();
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(16);//配替
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル取得
                }
                else if (cdMove != "0" && cdMove != "9" && OperationScreen.Location_x == "-" && OperationScreen.Location_y == "-" && OperationScreen.Location_z == "-")//出庫
                {
                    cdMove = "1";
                    tagkbn = "出庫";
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(17);//出庫
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);//移動履歴
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル取得
                }
                else if (cdMove == "0" && OperationScreen.Location_x == "-" || OperationScreen.Location_y == "-" || OperationScreen.Location_z == "-")//その他
                {
                    //その他の処理
                    cdMove = "9";
                    tagkbn = "入庫";
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(5);
                }
                else if (cdMove == "9")
                {
                    //その他の処理
                }
                else
                {
                    MessageBox.Show("ロケーションの値が参照できない為処理が行えませんでした"); //エラー表示
                }

                //リセット処理
                tagdispreset();
                RFIDflag = false;
                disp();
                IOCheckflag = false;
                // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(2, Convert.ToString(IOCheckflag));//テストプログラム

                IOmode = 0;
                // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(3, Convert.ToString(IOmode));//テストプログラム
                IOflag = false;

                // ((OperationScreen)Application.OpenForms["OperationScreen"]).test_text(4, "タイマー起動");//テストプログラム
                IO.Enabled = true;

                //20240621 morichika
                FreeAreaRefreshflg = true;
            }

        }
        private void bit2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bit1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TCol_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 選択行を赤で表示する
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void coil_view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Detail_View.SelectX = Convert.ToDecimal(coil_view.CurrentCellAddress.X) + 1;
            string text = "";

            for (int i = 0; i < 47; i++)
            {
                string label = "lbl_Col_";
                label += i;
                //子コントロールも検索する。
                Control[] cs = this.Controls.Find(label, true);
                //全て黒にする
                if (cs.Length > 0)
                {
                    ((Label)cs[0]).ForeColor = Color.Black;
                    ((Label)cs[0]).BackColor = SystemColors.Control;
                }
            }
            //TextBox1をさがす。子コントロールも検索する。
            string chengelabel = "lbl_Col_";
            chengelabel += Convert.ToDecimal(coil_view.CurrentCellAddress.X) + 1;
            Control[] ccs = this.Controls.Find(chengelabel, true);
            //TextBox1が見つかれば、Textを変更する
            if (ccs.Length > 0)
                ((Label)ccs[0]).ForeColor = Color.White;

            ((Label)ccs[0]).BackColor = Color.Red;


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //testref();
            disp();
                
            }
        


        private void tagID_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CSt_Click(object sender, EventArgs e)
        {

        }

        private void Btn_FreeArea1_Click(object sender, EventArgs e)
        {
            
            フリーエリア画面.Yロケ = (string)Btn_FreeArea1.Tag;
            フリーエリア画面.Yロケーション = 1;
            フリーエリアOpen();


        }
        public static void フリーエリアOpen()
        {
            フリーエリア画面 f4 = new フリーエリア画面();
            //f4.Location = new Point(440, 450);
            f4.Location = new Point(0, 210);
            f4.StartPosition = FormStartPosition.Manual;
            //this.AddOwnedForm(f4);
            f4.ShowDialog();
        }

        private void Btn_FreeArea2_Click(object sender, EventArgs e)
        {
            フリーエリア画面.Yロケ = (string)Btn_FreeArea2.Tag;
            フリーエリア画面.Yロケーション = 2;
            フリーエリアOpen();
        }

        private void Btn_FreeArea3_Click(object sender, EventArgs e)
        {
            フリーエリア画面.Yロケ = (string)Btn_FreeArea3.Tag;
            フリーエリア画面.Yロケーション = 3;
            フリーエリアOpen();
        }

        private void Btn_FreeArea4_Click(object sender, EventArgs e)
        {
            フリーエリア画面.Yロケ = (string)Btn_FreeArea4.Tag;
            フリーエリア画面.Yロケーション = 4;
            フリーエリアOpen();
        }

        private void Btn_FreeArea5_Click(object sender, EventArgs e)
        {
            フリーエリア画面.Yロケ = (string)Btn_FreeArea5.Tag;
            フリーエリア画面.Yロケーション = 5;
            フリーエリアOpen();
        }

        private void Btn_FreeArea6_Click(object sender, EventArgs e)
        {
            フリーエリア画面.Yロケ = (string)Btn_FreeArea6.Tag;
            フリーエリア画面.Yロケーション = 6;
            フリーエリアOpen();
        }

        /// <summary>
        /// コイル数セット
        /// </summary>
        /// <param name="area">フリーエリア名</param>
        /// <param name="cnt">コイル数</param>
        /// <remarks>フリーエリアボタン名にコイル数をセットします。2024.6.5 OGURI ADD</remarks>
        public void SetCoilCnt(string area, int cnt)
        {
            foreach (Button btnFree in gro_FreeArea.Controls.OfType<Button>())
            {
                if (btnFree.Tag.ToString() == area)
                {
                    btnFree.Text += cnt.ToString();
                }
            }
        }

        /// <summary>
        /// ボタン色設定
        /// </summary>
        /// <param name="area">フリーエリア名</param>
        /// <remarks>フリーエリアボタンの背景色を赤に設定します。2024.6.5 OGURI ADD</remarks>
        public void SetBtnColor(string area)
        {
            foreach (Button btnFree in gro_FreeArea.Controls.OfType<Button>())
            {
                if (btnFree.Tag.ToString() == area)
                {
                    btnFree.BackColor = Color.Red;
                }
            }
        }
    }
}
