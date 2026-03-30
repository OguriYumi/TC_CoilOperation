using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Net.NetworkInformation;
using WMPLib;
using System.Data.SqlTypes;

namespace TC_CoilOperation
{
    public partial class MainScreen : Form
    {
        
        string 区分 = "";
        string 項目 = "";
        string 明細情報 = "";
        string 対象スレ = "";
        string sqlNo = "";
        static public string 段数 = "1";
        bool DBflag = false;
        Ping sender = new Ping();
        OperationScreen f = new OperationScreen();
        Menu f1 = new Menu();
        MachineCheck f2 = new MachineCheck();
        setting_Device f3 = new setting_Device();
        //フリーエリア画面 f4 = new フリーエリア画面();
        OracleConnection conn = new OracleConnection();
        WindowsMediaPlayer _mediaPlayer = new WindowsMediaPlayer();
        //コイルをつかんだ時離したときの処理は、それぞれタグ情報が読み取れたかとれていないかで処理を変える

        public MainScreen()
        {

            InitializeComponent();




        }
        public void MP3(string モード)
        {
            if (モード == "1")//注意
            {
                _mediaPlayer.URL = Properties.Settings.Default.MP3_1;// mp3も使用可能
                _mediaPlayer.controls.play();
            }
            else//警告
            {
                _mediaPlayer.URL = Properties.Settings.Default.MP3_2;// mp3も使用可能
                _mediaPlayer.controls.play();
            }
        }
        
        public void oracleDBopen()
        {
            try
            {
                conn.ConnectionString = "User Id=" + Properties.Settings.Default.Oracle_UserID + ";Password=" + Properties.Settings.Default.Oracle_UserPass + ";Data Source=" + Properties.Settings.Default.Oracle_ServiceName + ";";
                conn.Open();
                System_log("DB接続成功", "1", "DB接続処理", "main");
            }
            catch (Exception ex)
            {
                //MessageBox.Show("DB接続エラー");
                Show_Message(3);
                System_log("接続エラー","2", "DB接続", "main");
            }
        }

        public void OracleDBclose()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {
                Show_Message(4);
                System_log(Convert.ToString(ex),"2", "DB例外処理", "main");
            }
        }
        
       

        public void OracleDBsql(int sqlnum)
        {
           
            string sql = "";
            string sql3 = "";
            string sql4 = "";
            string 二段 = "2";
            string 三段 = "3";

            bool 重複 = false;

            string IDYARD = "2";
            string testsql2 = "(select sysdate from dual@ncom_LINK)";
            string testsql = "SELECT SYSDATE FROM DUAL";
            int testcount = 0;
            for (; ; )
            {
                if (testcount == 3)
                {
                    Show_Message(3);
                  //  System_log(Convert.ToString("接続エラー"),"2", "DB接続", "main");
                    return;
                }
                if (conn == null)//存在するか
                {
                    try
                    {
                        OracleConnection conn = new OracleConnection();
                        System_log(Convert.ToString("コネクション再作成"), "1", "DB再接続処理", "main");
                    }
                    catch(Exception ex)
                    {
                        
                     //   System_log("接続エラー","2", "DB接続", "main");
                        testcount++;
                        continue;
                    }
                }
                if (conn.State == ConnectionState.Closed)//open確認
                {
                    try
                    {
                        conn.ConnectionString = "User Id=" + Properties.Settings.Default.Oracle_UserID + ";Password=" + Properties.Settings.Default.Oracle_UserPass + ";Data Source=" + Properties.Settings.Default.Oracle_ServiceName + ";";
                        conn.Open();
                        Show_Message(29);
                        System_log(Convert.ToString("oracleDB再接続"), "1", "DB接続処理", "main");
                    }
                    catch(Exception ex)
                    {
                       // System_log("接続エラー","2", "DB接続", "main");

                        testcount++;
                        continue;
                    }
                }
                try//クエリ処理確認
                {
                    OracleCommand test = new OracleCommand(testsql);
                    test.Connection = conn;
                    test.CommandType = CommandType.Text;
                    OracleDataReader testreader = test.ExecuteReader();
                    while (testreader.Read())
                    {
                        

                    }
                    test.Parameters.Clear();
                    test.Dispose();
                    testreader.Dispose();
                    
                }
                catch (Exception ex)
                {
                  //  System_log("接続エラー","2", "DB接続", "main");
                    testcount++;
                    continue;
                }

                try//クエリ処理確認
                {
                    OracleCommand test2 = new OracleCommand(testsql2);
                    test2.Connection = conn;
                    test2.CommandType = CommandType.Text;
                    OracleDataReader test2reader = test2.ExecuteReader();
                    while (test2reader.Read())
                    {


                    }
                    test2.Parameters.Clear();
                    test2.Dispose();
                    test2reader.Dispose();
                    break;
                }
                catch (Exception ex)
                {
                //    System_log("接続エラー（上位システム）", "2", "DB接続", "main");
                    testcount++;
                    continue;
                }

            }
            switch (sqlnum)
            {
                case 1://システム時刻の取得
                    sqlNo = "1";
                    sql = "SELECT TO_CHAR((select sysdate from dual@ncom_LINK),'YYYY/MM/DD HH24:MI:SS') FROM DUAL";//時刻表示
                    string sql1 = "SELECT TO_CHAR((select sysdate from dual@ncom_LINK),'YYYYMMDD') FROM DUAL";//時刻表示

                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string times= Convert.ToString(reader[0]);
                            times = times.Remove(16, 3);
                            SystemTime.Text = times;
                            OperationScreen.time=Convert.ToString(reader[0]);
                            OperationScreen.datetime = Convert.ToDateTime(reader[0]);

                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("システム時刻取得"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql1);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            string time = Convert.ToString(reader[0]);
                            time = time.Insert(4, "/");
                            time = time.Insert(7, "/");
                            OperationScreen.dateTime = Convert.ToDateTime(time);
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("システム時刻取得"),"2", "SQL処理", "main");
                    }
                    break;
                case 2://クレーン位置ロケーションの取得
                    sqlNo = "2";
                    //追加案　ロケーションが取得できた場合はクレーン位置をロケと合わせるが取れなかった場合はX.Y座標のみを対象とし、クレーン位置を表示する
                    //ロケ情報が取得できるかの判定（CDstatusの値が0かどうか）
                    //０なら取得それ以外なら"-"
                    //その後配列の中の一番下のCDステータスを取得（status）

                    string csql2 = "Select A.pointX,A.pointY, A.pointZ,A.cdLocation from TM_location A where idYard = " + OperationScreen.idYard + " and distXFrom <= " + OperationScreen.Crane_point_x + " and distXTo     > " + OperationScreen.Crane_point_x + " and distYFrom <=  " + OperationScreen.Crane_point_y + " and distYTo     > " + OperationScreen.Crane_point_y + " and pointZ=1  order By A.pointX,A.pointY, A.pointZ";
                    sql = "Select A.pointX,A.pointY, A.pointZ,A.cdLocation from TM_location A where idYard = " + OperationScreen.idYard + " and distXFrom <= " + OperationScreen.Crane_point_x + " and distXTo     > " + OperationScreen.Crane_point_x + " and distYFrom <= " + OperationScreen.Crane_point_y + " and distYTo     > " + OperationScreen.Crane_point_y + " and distZFrom <= " + OperationScreen.Crane_point_z + " and distZTo     > " + OperationScreen.Crane_point_z + " order By A.pointX,A.pointY, A.pointZ";
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        int cnt = 0;
                        int set = 0;
                        while (reader.Read())
                        {
                            if (Convert.ToString(reader[3]) == "3" || Convert.ToString(reader[3]) == "4")
                            {
                                set = Convert.ToInt32(reader[3]);
                            }
                            else if (cnt != 1)
                            {
                                if (reader[0] != DBNull.Value)
                                {
                                    if (Convert.ToString(reader[0]) == string.Empty)
                                    {
                                        OperationScreen.Location_x = "-";
                                    }
                                    else OperationScreen.Location_x = Convert.ToString(reader[0]);

                                }
                                else
                                {
                                    OperationScreen.Location_x = "-";
                                }
                                if (reader[1] != DBNull.Value)
                                {
                                    if (Convert.ToString(reader[1]) == string.Empty)
                                    {
                                        OperationScreen.Location_y = "-";
                                    }
                                    else OperationScreen.Location_y = Convert.ToString(reader[1]);
                                }

                                if (reader[2] != DBNull.Value)
                                {
                                    if (Convert.ToString(reader[2]) == string.Empty)
                                    {
                                        OperationScreen.Location_z = "-";
                                    }
                                    else OperationScreen.Location_z = Convert.ToString(reader[2]);
                                }
                                

                                //Convert.ToString(reader[3]);CDlocation
                                cnt++;
                            }
                            if (set == 3)
                            {
                                ((MainScreen)Application.OpenForms["MainScreen"]).MP3("1");
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(13);
                                // System_log("侵入エリア:注意", "1", "注意", "lazer");
                                OperationScreen.caveat = "3";
                            }
                            else if (set == 4)
                            {
                                ((MainScreen)Application.OpenForms["MainScreen"]).MP3("2");
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(12);
                                //System_log("侵入エリア:警告", "1", "警告", "lazer");
                                OperationScreen.caveat = "4";

                            }
                            else
                            {
                                if(OperationScreen.caveat == "3"&& OperationScreen.caveat == "4")
                                {
                                    ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                                }
                                OperationScreen.caveat = "0";
                            }
                        }
                        if (cnt == 0)
                        {
                            OperationScreen.Location_x = "-";
                            OperationScreen.Location_y = "-";
                            OperationScreen.Location_z = "-";
                            if (set != 3 && set != 4)
                            {
                                OperationScreen.caveat = "0";
                                ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(0);
                            }
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log("ロケーション取得処理", "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    try
                    {
                        int cnt = 0;
                        OracleCommand cmd2 = new OracleCommand(csql2);
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        OracleDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            if (cnt == 0) 
                            { 
                               if (reader2[0] != DBNull.Value || reader2[1] != DBNull.Value)
                                {
                                    OperationScreen.CLocation_x = Convert.ToString(reader2[0]);
                                    OperationScreen.CLocation_y = Convert.ToString(reader2[1]);
                                    cnt++;
                                }
                                else
                                {
                                    OperationScreen.CLocation_x = "-";
                                    OperationScreen.CLocation_y = "-";
                                }
                            }
                          

                           
                        }
                        if (cnt == 0)
                        {
                            OperationScreen.CLocation_x = "-";
                            OperationScreen.CLocation_y = "-";
                        }
                        cmd2.Parameters.Clear();
                        cmd2.Dispose();
                        reader2.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log("クレーン位置取得", "2", "SQL処理", "main");
                    }
                    break;
                case 3://現在コイルの配置状況の取得
                    sqlNo = "3";
                    for (int x = 1; x < 47; x++)
                    {
                        //sql = "Select pointY,COUNT(*), MAX(D.SHUKOYMD) as 出庫日, MAX(D.TSUMIYMD) as 積込日,MAX(A.cdTarget) as 目標設定 from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C, TSHUKO@NCOM_LINK D where A.pointX = " + x + " and A.tag = B.RFIDtag and B.ZAIKONO = C.ZAIKONO and B.ZAIKONOEDANO = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and latest=1 Group By A.pointY";
                        sql = "Select	pointY,COUNT(*), MAX(D.SHUKOYMD) as 出庫日, MAX(D.TSUMIYMD) as 積込日,MAX(A.cdTarget) as 目標設定 from	TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C, TSHUKO@NCOM_LINK D where A.pointX =" + x + "  and";
                        sql+= " A.tag = B.RFIDtag (+) and 	B.ZAIKONO = C.ZAIKONO (+) and 	B.ZAIKONOEDANO = C.ZAIKONOEDANO (+) and 	C.SHUKONO = D.SHUKONO (+) and 	latest=1 and IDYARD=" + OperationScreen.idYard + " Group By 	A.pointY order by A.pointY ";
                        try
                        {
                            OracleCommand cmd = new OracleCommand(sql);
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            OracleDataReader reader = cmd.ExecuteReader();
                            int cnt_y = 1;

                            while (reader.Read())
                            {
                                string syukodate = Convert.ToString(reader[2]);
                                string tumikomidate = Convert.ToString(reader[3]);
                                if (syukodate != string.Empty||tumikomidate!=string.Empty)
                                {
                                    syukodate = syukodate.Insert(4, "/");
                                    syukodate = syukodate.Insert(7, "/");
                                    tumikomidate = tumikomidate.Insert(4, "/");
                                    tumikomidate = tumikomidate.Insert(7, "/");
                                }
                                if (Convert.ToInt32(reader[1]) == 1)
                                {
                                    ((OperationScreen)Application.OpenForms["OperationScreen"]).Operation_disp(x - 1, Convert.ToInt32(reader[0]) - 1, syukodate, tumikomidate, Convert.ToInt32(reader[4]), 1);


                                }
                                else if (Convert.ToInt32(reader[1]) >= 2)
                                {
                                    string syuko = "";
                                    string tumikomi = "";
                                    int target = 0;
                                    syukodate = "";
                                    tumikomidate = "";
                                    int priority = 99;//優先度
                                    //string mode2sql = "Select A.pointZ,A.cdTarget as 目標設定,D.SHUKOYMD,D.TSUMIYMD from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D where A.pointX = " + x + " and A.pointY = " + cnt_y + " and A.tag = B.RFIDtag and B.ZAIKONO = C.ZAIKONO and B.ZAIKONOEDANO = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and Latest=1 Order by A.cdTarget desc, D.TSUMIYMD,D.SHUKOYMD,A.pointZ";
                                    string mode2sql = "Select 	A.pointZ,A.cdTarget as 目標設定,D.SHUKOYMD,D.TSUMIYMD from 	TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D where A.pointX = " + x + " and A.pointY = ";
                                    mode2sql += Convert.ToString(reader[0]) + "and A.tag = B.RFIDtag (+)and B.ZAIKONO = C.ZAIKONO (+) and B.ZAIKONOEDANO = C.ZAIKONOEDANO (+) and C.SHUKONO = D.SHUKONO (+) and Latest=1 and IDYARD=";
                                    mode2sql+= OperationScreen.idYard + "Order by A.cdTarget desc, D.TSUMIYMD,D.SHUKOYMD,A.pointZ";
                                    OracleCommand cmd2 = new OracleCommand(mode2sql);
                                    cmd2.Connection = conn;
                                    cmd2.CommandType = CommandType.Text;
                                    OracleDataReader reader2 = cmd2.ExecuteReader();
                                    while (reader2.Read())
                                    {
                                       
                                        int setprioryty = 99;

                                        
                                        if (Convert.ToString(reader2[2]) == string.Empty || Convert.ToString(reader2[3]) == string.Empty)
                                        {
                                            setprioryty = 5;
                                        }
                                        else
                                        {
                                            syukodate = Convert.ToString(reader2[2]);
                                            tumikomidate = Convert.ToString(reader2[3]);
                                            syukodate = syukodate.Insert(4, "/");
                                            syukodate = syukodate.Insert(7, "/");
                                            tumikomidate = tumikomidate.Insert(4, "/");
                                            tumikomidate = tumikomidate.Insert(7, "/");

                                            if (Convert.ToInt32(reader2[1]) == 1) { setprioryty = 0; }
                                            else if (Convert.ToDateTime(syukodate) <= OperationScreen.dateTime)
                                            {
                                                if (tumikomidate == syukodate) { setprioryty = 1; }
                                                else { setprioryty = 2; }
                                            }
                                            else if (Convert.ToDateTime(syukodate) == OperationScreen.dateTime.AddDays(1))
                                            {
                                                if (tumikomidate == syukodate) { setprioryty = 3; }
                                                else { setprioryty = 4; }
                                            }
                                            else
                                            {
                                                setprioryty = 5;
                                            }
                                            
                                        }
                                        if (priority > setprioryty)
                                        {
                                            priority = setprioryty;
                                            syuko = syukodate;
                                            tumikomi = tumikomidate;
                                            target = Convert.ToInt32(reader2[1]);
                                        }
                                    }
                                    //if (Convert.ToString(reader[0]) != string.Empty)
                                    //{
                                        ((OperationScreen)Application.OpenForms["OperationScreen"]).Operation_disp(x - 1, Convert.ToInt32(reader[0]) - 1, syuko, tumikomi, target, 2);
                                    //}
                                    
                                    cmd2.Parameters.Clear();
                                    cmd2.Dispose();
                                    reader2.Dispose();
                                }
                                cnt_y++;

                            }
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                            reader.Dispose();



                        }
                        catch (Exception ex)
                        {
                            Show_Message(5);
                            System_log(Convert.ToString("コイル配置状況の取得"), "2", "SQL処理(" + sqlNo + ")", "main");
                        }
                        
                        
                           
                        
                    }
                    

                    //for (int i = 0; i < 15; i++)
                    //{
                    //    OperationScreen.day[i] = "";
                    //}
                    //sql = "";
                    //int count = 0;
                    //try
                    //{
                    //    OracleCommand cmd = new OracleCommand(sql);
                    //    cmd.Connection = conn;
                    //    cmd.CommandType = CommandType.Text;
                    //    OracleDataReader reader = cmd.ExecuteReader();
                    //    while (reader.Read())
                    //    {

                    //        if (Convert.ToInt32(reader[0]) != 1)
                    //        {
                    //            //積み込み日の取得日数が設定日時以下かの判定[1]
                    //            //カウント値が2以上だった場合の判定
                    //            string sql2 = "";
                    //            OracleCommand cmd2 = new OracleCommand(sql2);
                    //            cmd.Connection = conn;
                    //            cmd.CommandType = CommandType.Text;
                    //            OracleDataReader reader2 = cmd.ExecuteReader();
                    //            int priority = 10;//優先度
                    //            //優先度（目標 0,本日1,本日ヨ,）
                    //            while (reader.Read())
                    //            {

                    //                //一番優先度の高いものを取得
                    //                OperationScreen.Com[count] = 1;
                    //                OperationScreen.day[count] = "";
                    //            }
                    //        }
                    //        else
                    //        {
                    //            //if (Convert.ToString(reader[1]) == "NULL") //未設定
                    //            //{
                    //            //    OperationScreen.Com[count] = 1;
                    //            //}

                    //            if (Convert.ToDateTime(reader[1]) == Convert.ToDateTime(SystemTime.Text))//本日
                    //            {
                    //                if(Convert.ToDateTime(reader[1])== Convert.ToDateTime(reader[2]))
                    //                {
                    //                    OperationScreen.Com[count] = 4;
                    //                }
                    //                else { OperationScreen.Com[count] = 8; }

                    //            }
                    //            if (Convert.ToDateTime(reader[1]) == Convert.ToDateTime(SystemTime.Text).AddDays(1))//翌日（＋１日）
                    //            {
                    //                if (Convert.ToDateTime(reader[1]) == Convert.ToDateTime(reader[2]))
                    //                {
                    //                    OperationScreen.Com[count] = 3;
                    //                }
                    //                else { OperationScreen.Com[count] = 9; }

                    //            }
                    //            if(Convert.ToDateTime(reader[1]) != Convert.ToDateTime(SystemTime.Text)&& Convert.ToDateTime(reader[1]) != Convert.ToDateTime(SystemTime.Text).AddDays(1))
                    //            {
                    //                string readerday="";
                    //                //if積み込み日とシステム時間の差分の日付をとり結果と設定変数の日付を比較し、以内なら
                    //                OperationScreen.Com[count] = 2;
                    //                OperationScreen.day[count] = readerday;

                    //            }
                    //        }
                    //        count++;
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    Show_Message(5);
                    //    System_log(Convert.ToString(ex));
                    //}
                    break;
                case 4://アラーム位置の判定
                    sqlNo = "4";
                    sql = "";
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                        }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("アラームエリア"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 5://コイル移動距離履歴更新
                    sqlNo = "5";
                    string x1, y1, z1 = ""; 
                    if (Properties.Settings.Default.Lifter_Manualmode == false)
                    {
                        OperationScreen.cdTongs = "0";
                    }
                    else { OperationScreen.cdTongs = "1"; }
                    //OperationScreen.Location_x = "1";
                    //OperationScreen.Location_y = "1";
                    //OperationScreen.Location_z = "1";
                    //OperationScreen.tagId = "999999";
                    if (OperationScreen.Location_x == "-")
                    {
                        x1= "-99";
                    }
                    else
                    {
                        x1 = OperationScreen.Location_x;
                    }
                    if (OperationScreen.Location_y == "-")
                    {
                        y1 = "-99";
                    }
                    else
                    {
                        y1 = OperationScreen.Location_y;
                    }
                    if (OperationScreen.Location_z == "-")
                    {
                        z1 = "-99";
                    }
                    else
                    {
                        z1 = OperationScreen.Location_z;
                    }
                    
                    sql = "Insert into TH_move (Tag,Coil,idYard,idCrane,cdMove,CDTongs,pointX,pointY,pointZ,distX,distY,distZ,pointPreX,pointPreY,pointPreZ,dtMovestart,termInsert,dtInsert,PROCESSINSERT)VALUES('";
                    sql += OperationScreen.tagId + "'," + "\'"+OperationScreen.対象現品No+"\'" + "," + OperationScreen.idYard + "," + OperationScreen.idCrane + "," + OperationScreen.cdMove + "," + OperationScreen.cdTongs + "," + x1 + "," + y1+ "," + z1+ ",";
                    sql += OperationScreen.Crane_point_x +","+ OperationScreen.Crane_point_y + ","+ OperationScreen.Crane_point_z + ","+ OperationScreen.移動前X + ","+ OperationScreen.移動前Y + ","+ OperationScreen.移動前Z + ",TO_DATE('"+OperationScreen.移動開始時刻+"', 'YYYY-MM-DD HH24:MI:SS')" + ","+ "\'"+OperationScreen.PC名+"\'" + ",(select sysdate from dual@ncom_LINK),'I/Oタスク')";
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        OperationScreen.移動前X="-99";
                        OperationScreen.移動前Y="-99";
                        OperationScreen.移動前Z="-99";
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル移動距離履歴"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 6://コイル移動更新
                    sqlNo = "6";
                    sql = "Insert into TS_tag (Tag,idYard,pointX,pointY,pointZ,distX,distY,distZ,termInsert, dtInsert,PROCESSINSERT) VALUES('"+OperationScreen.tagId+ "',1,2,2,1,20,20,20,'sousa',(select sysdate from dual@ncom_LINK),'" + OperationScreen.tagkbn+"')  ";
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                        }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("移動更新"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 7://出庫情報表示（積込）
                   
                    
                    

                    sqlNo = "7";
                    sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C, TSHUKO@NCOM_LINK D ,WKOKBSYSREN@NCOM_LINK E where ";
                    sql += "A.tag(+) = B.RFIDtag and B.ZAIKONO = C.ZAIKONO and B.ZAIKONOEDANO = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and D.SOKOCD='" + OperationScreen.YARDID + "' and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is not null Order by ";
                    sql+="D.TSUMINO, B.GENPINNO";
                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                            string 積込NO = "";
                            string 現品NO = "";
                            string RFID = "";
                            string PX = "";
                            string PY = "";
                            string PZ = "";
                            string GPMETU = "";
                            string GPSUN = "";
                            string 出庫 = "";
                            string 積込 = "";
                            string 目標 = "";

                            if (reader[0] != DBNull.Value)
                            {
                                積込NO = Convert.ToString(reader[0]);
                            }
                            if (reader[1] != DBNull.Value)
                            {
                                現品NO = Convert.ToString(reader[1]);
                            }
                            if (reader[2] != DBNull.Value)
                            {
                                RFID = Convert.ToString(reader[2]);
                            }
                            if (reader[3] != DBNull.Value)
                            {
                                PX = Convert.ToString(reader[3]);
                            }
                            if (reader[4] != DBNull.Value)
                            {
                                PY = Convert.ToString(reader[4]);
                            }
                            if (reader[5] != DBNull.Value)
                            {
                                PZ = Convert.ToString(reader[5]);
                            }
                            if (reader[6] != DBNull.Value)
                            {
                                GPMETU = Convert.ToString(reader[6]);
                            }
                            if (reader[7] != DBNull.Value)
                            {
                                GPSUN = Convert.ToString(reader[7]);
                            }
                            if (reader[8] != DBNull.Value)
                            {
                                出庫 = Convert.ToString(reader[8]);
                            }
                            if (reader[9] != DBNull.Value)
                            {
                                積込 = Convert.ToString(reader[9]);
                            }
                            if (reader[10] != DBNull.Value)
                            {
                                目標 = Convert.ToString(reader[10]);
                            }
                            ((Shipping_information)Application.OpenForms["Shipping_information"]).Coil_Info(積込NO, 現品NO, RFID, PX, PY, PZ, GPMETU, GPSUN, 出庫, 積込, 目標, 1);
                            Shipping_information.count++;
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        
                        reader.Dispose();
                        

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("出庫情報(積込)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 8://出庫情報表示（本日）
                    sqlNo = "8";

                    //sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.GPMETSUKERYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D ,WKOKBSYSREN@NCOM_LINK E where C.SHUKOKBN= 0 and A.tag(+) = B.RFIDtag and B.ZAIKONO = C.ZAIKONO and B.ZAIKONOEDANO = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and D. TSUMIYMD	= to_char(sysdate,'RRRRMMDD') and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is  null Order by D.TSUMINO, B.GENPINNO";
                    sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D ,WKOKBSYSREN@NCOM_LINK E where";
                    sql += " A.tag(+) = B.RFIDtag and B.ZAIKONO(+) = C.ZAIKONO and B.ZAIKONOEDANO(+) = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and D. TSUMIYMD	<= to_char(sysdate,'RRRRMMDD') and D.ENDKBN <> 2 and D.SOKOCD='" + OperationScreen.YARDID+"'";
                    sql +=" and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is  null Order by D.TSUMINO, B.GENPINNO";




                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();



                        while (reader.Read())
                        {

                            ((Shipping_information)Application.OpenForms["Shipping_information"]).Coil_Info(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10]), 2);
                            Shipping_information.count++;
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("出庫情報(本日)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 9://出庫情報表示（翌日）
                    sqlNo = "9";

                    sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D ";
                    sql += ",WKOKBSYSREN@NCOM_LINK E where  A.tag(+) = B.RFIDtag and B.ZAIKONO(+) = C.ZAIKONO and B.ZAIKONOEDANO(+) = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and D. TSUMIYMD	= to_char(sysdate+1,'RRRRMMDD') and ";
                    sql+="D.SOKOCD='" + OperationScreen.YARDID + "' and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is  null Order by D.TSUMINO, B.GENPINNO";

                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();



                        while (reader.Read())
                        {
                            ((Shipping_information)Application.OpenForms["Shipping_information"]).Coil_Info(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10]), 3);
                            Shipping_information.count++;
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("出庫情報(翌日)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 10://出庫情報表示（その他）
                    sqlNo = "10";

                    // sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.GPMETSUKERYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D where C.SHUKOKBN= 0 and A.tag(+) = B.RFIDtag and B.ZAIKONO = C.ZAIKONO and B.ZAIKONOEDANO = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO and D. TSUMIYMD	< to_char(sysdate+1,'RRRRMMDD') and D. TSUMIYMD	> to_char(sysdate+" + Properties.Settings.Default.Add_day + ",'RRRRMMDD') and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is not null Order by D.TSUMINO, B.GENPINNO";
                    sql = "Select D.TSUMINO,B.GENPINNO ,B.RFIDTAG,A.pointX,A.pointY,A.pointZ,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D ";
                    sql += ",WKOKBSYSREN@NCOM_LINK E where  A.tag(+) = B.RFIDtag and B.ZAIKONO(+) = C.ZAIKONO and B.ZAIKONOEDANO(+) = C.ZAIKONOEDANO and C.SHUKONO = D.SHUKONO  and D. TSUMIYMD	> to_char(sysdate+" + 1 + ",'RRRRMMDD')and ";
                    sql+="D.SOKOCD='" + OperationScreen.YARDID + "' and D. TSUMIYMD	<= to_char(sysdate+" + Properties.Settings.Default.Add_day + ",'RRRRMMDD') and D.TSUMINO = E.TSUMINO(+) and E.TSUMINO is  null Order by D.TSUMINO, B.GENPINNO";

                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            //if (Convert.ToDateTime(tumikomidate) != OperationScreen.dateTime&&Convert.ToDateTime(tumikomidate) != OperationScreen.dateTime.AddDays(1))
                            //{
                            ((Shipping_information)Application.OpenForms["Shipping_information"]).Coil_Info(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[10]), 4);
                            //}
                            Shipping_information.count++;
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("出庫情報(その他)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 11://コイル詳細表示
                    sqlNo = "11";
                    sql = "Select A.pointY, A.pointZ,A.cdTarget,NVL(B.GENPINNO,0) ,B.RFIDTAG,B.GPKIKAKU ,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,TSHUKO@NCOM_LINK D ";
                    sql+="where A.pointX = " + Detail_View.SelectX + " and A.tag = B.RFIDtag(+) and B.ZAIKONO = C.ZAIKONO(+) and B.ZAIKONOEDANO = C.ZAIKONOEDANO(+) and C.SHUKONO = D.SHUKONO(+) and Latest=1 and IDYARD=" + OperationScreen.idYard + " Order by pointZ,A.pointY";
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();




                        while (reader.Read())
                        {
                            string b = Convert.ToString(reader[3]);
                            if (Convert.ToString(reader[3]) == "0")
                            {
                                ((Detail_View)Application.OpenForms["Detail_View"]).Addcoil(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), 0, "", "", "", "", "", "", "");
                            }
                            else
                            {
                                ((Detail_View)Application.OpenForms["Detail_View"]).Addcoil(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]), Convert.ToDouble(reader[6]), Convert.ToString(reader[3]), Convert.ToString(reader[4]), Convert.ToString(reader[5]), Convert.ToString(reader[7]), Convert.ToString(reader[8]), Convert.ToString(reader[9]), Convert.ToString(reader[2]));
                            }
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル詳細表示"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 12://目標コイル設定
                    sqlNo = "12";
                    sql = "Update TS_tag set cdTarget = 0,processUpdate ='目標コイル初期化処理',dtUpdate = sysdate where cdTarget = 1 and idYard = "+OperationScreen.idYard;
                    string sql2 = "Update TS_tag set cdTarget = 1,processUpdate ='目標コイル設定処理',dtUpdate =(select sysdate from dual@ncom_LINK) where tag = " + "\'" + OperationScreen.Targetcoil + "\'" + " and idYard = "+OperationScreen.idYard;
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();

                        cmd.Parameters.Clear();
                        cmd.Dispose();
                       
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標コイル設定"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    try
                    {
                        OracleCommand cmd2 = new OracleCommand(sql2);
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();

                        cmd2.Parameters.Clear();
                        cmd2.Dispose();
                        
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標コイル設定"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }

                    break;

                case 13://目標座標取得
                    sqlNo = "13";
                    //いずれコイルの距離の値も取得
                    if (OperationScreen.Targetcoil == "")
                    {
                        return;
                    }
                    sql = "select pointx,pointy,pointz,distx,disty,distz from TS_tag where cdtarget=1 and tag=" + OperationScreen.Targetcoil +" and IDYARD="+OperationScreen.idYard;
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                           
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).targetdisp(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToInt32(reader[5]));
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標座標取得"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;

                case 14://コイルタグ区分表示
                    sqlNo = "14";
                   // OperationScreen.tagId = "000001";//test
                    //OperationScreen.tagId = "000001";//test
                    //NVL
                    // sql = "select C.SHUKOYMD,C.TSUMIYMD,C.SHUKOKBN,D.tag,D.pointX,pointY,pointZ,sysdate,A.GENPINNO,A.RYO,A.GPSUNPO,C.TSUMINO,E.TSUMINO from TZAIKOG@NCOM_LINK A, TSHUKOG@NCOM_LINK B,TSHUKO@NCOM_LINK C, TS_tag D,WKOKBSYSREN@NCOM_LINK E Where		A.RFIDTAG =" + OperationScreen.tagId + "And			A.ZAIKONO = B.ZAIKONO And			A.ZAIKONOEDANO = B.ZAIKONOEDANO And			B.SHUKONO = C.SHUKONO And			A.RFIDtag = D.tag And			D. Latest = 1 And			C.TSUMINO=E.TSUMINO(+)";
                    //sql = "select NCOM.SHUKOYMD,NCOM.TSUMIYMD,NCOM.SHUKOKBN,COIL.tag,COIL.pointX,COIL.pointY,COIL.pointZ,(select sysdate from dual@ncom_LINK),NCOM.GENPINNO,NCOM.RYO,NCOM.GPSUNPO,NCOM.TSUMINO,NCOM.TSUMINO_WKOKBSYSREN from(select A.RFIDtag as RFIDtag,A.GENPINNO as GENPINNO,A.RYO as RYO,A.GPSUNPO as GPSUNPO,C.TSUMIYMD as TSUMIYMD,C.SHUKOKBN as SHUKOKBN,C.SHUKOYMD as SHUKOYMD,C.TSUMINO as TSUMINO,D.TSUMINO as TSUMINO_WKOKBSYSREN from TZAIKOG@NCOM_LINK A,TSHUKOG@NCOM_LINK B,TSHUKO@NCOM_LINK C left join WKOKBSYSREN@NCOM_LINK D ON C.TSUMINO = D.TSUMINO WHERE A.ZAIKONO = B.ZAIKONO And A.ZAIKONOEDANO = B.ZAIKONOEDANO And B.SHUKONO = C.SHUKONO AND A.rfidtag = '" + OperationScreen.tagId + "' ) NCOM FULL JOIN(select * from TS_tag where tag = '" + OperationScreen.tagId + "' ) COIL ON COIL.tag = NCOM.RFIDtag";
                    sql = "select";
                    sql+= " A.tag,B.RFIDtag,A.pointX,A.pointY,A.pointZ,B.TSUMINO,B.GENPINNO,B.ryo,B.GPSUNPO,(select sysdate from dual@ncom_LINK)";
                    sql+= " from";
                    sql+= " (select tag, pointx, pointy, pointz from TS_tag Where tag = '" + OperationScreen.tagId + "')A";
                    sql+=" FULL Join";
                    sql+=" (select  N.RFIDtag, N.GENPINNO, N.GPSUNPO, N.ryo, TSUMINO";
                    sql+= " from TZAIKOG@NCOM_LINK N";
                    sql+=" left join(select A.ZAIKONO, A.ryo, A.GPSUNPO, A.GENPINNO, C.TSUMINO";
                    sql+= " from TZAIKOG@NCOM_LINK A, TSHUKOG@NCOM_LINK B, TSHUKO@NCOM_LINK C, WKOKBSYSREN@NCOM_LINK D";
                    sql+= " WHERE A.RFIDtag = '" + OperationScreen.tagId + "'";
                    sql+= " and A.ZAIKONO = B.ZAIKONO";
                    sql+= " and B.SHUKONO = C.SHUKONO";
                    sql+= " and C.TSUMINO = D.TSUMINO)";
                    sql+= " NCOM ON NCOM.ZAIKONO = N.ZAIKONO";
                    sql+= " WHERE RFIDtag = '" + OperationScreen.tagId + "')B ON A.tag = B.RFIDtag";
                    try
                    {
                        int sqlcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //OperationScreen.移動開始時刻 = Convert.ToDateTime(reader[7]);
                            string a = Convert.ToString(reader[9]);
                            sqlcnt++;
                            //if (reader[0] == DBNull.Value || reader[1] == DBNull.Value || reader[2] == DBNull.Value || reader[7] == DBNull.Value || reader[8] == DBNull.Value || reader[9] == DBNull.Value || reader[10] == DBNull.Value)//データがなかった場合
                            //{


                            //    ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("入庫", Convert.ToString(reader[3]), "--", "--", "--");
                            //}
                            OperationScreen.移動開始時刻 = Convert.ToDateTime(reader[9]);
                            if (reader[2] == DBNull.Value && reader[3] == DBNull.Value && reader[4] == DBNull.Value)//POINTX,Y,ZがNULLの時
                            {
                                if (reader[0]!= DBNull.Value) {
                                    ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("入庫", Convert.ToString(reader[0]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]));
                                }
                                else
                                {
                                    ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("入庫", Convert.ToString(reader[1]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]));
                                }
                            }
                            else if (reader[2] != DBNull.Value && reader[3] != DBNull.Value && reader[4] != DBNull.Value  && reader[5]!=DBNull.Value)//POINTX,Y,Zに値があり出庫区分が出庫の値の場合
                            {
                                OperationScreen.移動前X = Convert.ToString(reader[2]);
                                OperationScreen.移動前Y = Convert.ToString(reader[3]);
                                OperationScreen.移動前Z = Convert.ToString(reader[4]);
                                ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("出庫", Convert.ToString(reader[0]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]));
                            }
                            else if (reader[2] != DBNull.Value && reader[3] != DBNull.Value && reader[4] != DBNull.Value  && reader[5] ==DBNull.Value)//POINTX,Y,Zに値があり出庫区分が出庫の値のではない場合
                            {
                                OperationScreen.移動前X = Convert.ToString(reader[2]);
                                OperationScreen.移動前Y = Convert.ToString(reader[3]);
                                OperationScreen.移動前Z = Convert.ToString(reader[4]);
                                ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("配替", Convert.ToString(reader[0]), Convert.ToString(reader[6]), Convert.ToString(reader[7]), Convert.ToString(reader[8]));
                            }
                        }
                        if (sqlcnt == 0)
                        {
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("入庫", " ", "--", "--", "--");
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイルタグ区分表示"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 15://コイル移動更新(入庫)

                   


                    sqlNo = "15";

                    
                    sql = "Update TS_tag Set Latest = 0 Where pointX ="+OperationScreen.Location_x +" and pointY="+OperationScreen.Location_y +" and pointZ="+OperationScreen.Location_z + " and IDYARD=" + OperationScreen.idYard;
                    sql2 = "Insert into TS_tag (Tag,idYard,pointX,pointY,pointZ,distX,distY,distZ,Latest,termInsert, dtInsert,PROCESSINSERT) VALUES(" + "\'" + OperationScreen.tagId + "\'" + "," + OperationScreen.idYard + "," + OperationScreen.Location_x;
                    sql2+=","+OperationScreen.Location_y+","+OperationScreen.Location_z+","+OperationScreen.Crane_point_x+","+OperationScreen.Crane_point_y+","+OperationScreen.Crane_point_z+",1,'"+OperationScreen.PC名+ "',(select sysdate from dual@ncom_LINK),'IOタスク')  ";
                    sql3 = "select COUNT(*) from TS_tag WHERE Latest = 1 and IDYARD=" + OperationScreen.idYard + " and  pointX =" + OperationScreen.Location_x + " and pointY=" + OperationScreen.Location_y + " and pointZ=" + OperationScreen.Location_z;
                    
                    try
                    {
                        //フリーエリア処理
                        if (OperationScreen.フリーエリア判定結果 == true)
                        {
                            string 登録モード = "0";
                            if (Properties.Settings.Default.Free_manual_mode == false)
                            {
                                段数 = Convert.ToString(OperationScreen.Location_z);
                            }
                            else
                            {
                                登録モード = "1";
                            }
                            sql2 = "Insert into TS_tag (Tag,idYard,pointX,pointY,pointZ,distX,distY,distZ,Latest,termInsert, dtInsert,PROCESSINSERT,FreeRegistMode) VALUES(" + "\'" + OperationScreen.tagId + "\'" + "," + OperationScreen.idYard + "," + OperationScreen.Location_x;
                            sql2 += "," + OperationScreen.Location_y + "," + 段数 + "," + OperationScreen.Crane_point_x + "," + OperationScreen.Crane_point_y + "," + OperationScreen.Crane_point_z + ",1,'" + OperationScreen.PC名 + "',(select sysdate from dual@ncom_LINK),'IOタスク',"+登録モード+")"  ;
                            OracleCommand cmdFree = new OracleCommand(sql2);
                            cmdFree.Connection = conn;
                            cmdFree.CommandType = CommandType.Text;
                            cmdFree.ExecuteNonQuery();
                            cmdFree.Parameters.Clear();
                            cmdFree.Dispose();
                            break;
                        }
                        OracleCommand cmd3 = new OracleCommand(sql3);
                        cmd3.Connection = conn;
                        cmd3.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd3.ExecuteReader();
                       
                        while(reader.Read())
                        {
                            if (Convert.ToString(reader["COUNT(*)"]) != "0")
                            {
                                重複 = true;
                            }
                           
                        }

                        if (重複 == true)
                        {
                           
                            //1段目の場合
                            if (OperationScreen.Location_z == "1")
                            {
                                


                                sql4 = "Select A.pointX,A.pointY from TM_location A where idYard =" + OperationScreen.idYard + " and distXFrom <= " + OperationScreen.Crane_point_x + " and distXTo     > " + OperationScreen.Crane_point_x ;
                                sql4+=" and distYFrom <= " + OperationScreen.Crane_point_y + " and distYTo     > " + OperationScreen.Crane_point_y + " and POINTZ=2" ;
                                OracleCommand cmd4 = new OracleCommand(sql4);
                                cmd4.Connection = conn;
                                cmd4.CommandType = CommandType.Text;
                                OracleDataReader reader2 = cmd4.ExecuteReader();
                                string X = "";
                                string Y = "";
                                while (reader2.Read())
                                {
                                    X = Convert.ToString(reader2["POINTX"]);
                                    Y = Convert.ToString(reader2["POINTY"]);

                                }

                                sql = "Update TS_tag Set Latest = 0 Where pointX =" + X + " and pointY=" + Y + " and pointZ=" + 二段 + " and IDYARD="+ OperationScreen.idYard;
                                sql2 = "Insert into TS_tag (Tag,idYard,pointX,pointY,pointZ,distX,distY,distZ,Latest,termInsert, dtInsert,PROCESSINSERT) VALUES(" + "\'" + OperationScreen.tagId + "\'" + "," + OperationScreen.idYard + "," + X + "," + Y + "," + 二段 + ",";
                                sql2 += OperationScreen.Crane_point_x + "," + OperationScreen.Crane_point_y + "," + OperationScreen.Crane_point_z + ",1,'" + OperationScreen.PC名 + "',(select sysdate from dual@ncom_LINK),'IOタスク')  ";
                            }
                            //2段目の場合
                            else if (OperationScreen.Location_z == "2")
                            {
               
                                sql = "Update TS_tag Set Latest = 0 Where pointX =" + OperationScreen.Location_x + " and pointY=" + OperationScreen.Location_y + " and pointZ=" + 三段 +" and IDYARD=" + OperationScreen.idYard;
                                sql2 = "Insert into TS_tag (Tag,idYard,pointX,pointY,pointZ,distX,distY,distZ,Latest,termInsert, dtInsert,PROCESSINSERT) VALUES(" + "\'" + OperationScreen.tagId + "\'" + "," + OperationScreen.idYard + "," + OperationScreen.Location_x + "," + OperationScreen.Location_y + "," + 三段 + ",";
                                sql2 += OperationScreen.Crane_point_x + "," + OperationScreen.Crane_point_y + "," + OperationScreen.Crane_point_z + ",1,'" + OperationScreen.PC名 + "',(select sysdate from dual@ncom_LINK),'IOタスク')  ";
                            }
                        }

                       
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        

                        OracleCommand cmd2 = new OracleCommand(sql2);
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                        cmd2.Parameters.Clear();
                        cmd2.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル移動更新(入庫)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 16://コイル移動更新(配替)
                    
                    sqlNo = "16";
                    sql= "Update TS_tag Set Latest = 0 Where pointX =" + OperationScreen.Location_x + " and pointY=" + OperationScreen.Location_y + " and pointZ=" + OperationScreen.Location_z + " and IDYARD=" + OperationScreen.idYard;
                    sql2 = "Update TS_tag Set pointX=" + OperationScreen.Location_x + ",pointY=" + OperationScreen.Location_y + ",pointZ=" + OperationScreen.Location_z + ",distX=" + OperationScreen.Crane_point_x + ",distY=" + OperationScreen.Crane_point_y + ",distZ=";
                    sql2 +=OperationScreen.Crane_point_z+",cdtarget=0,Latest= 1,termUpdate='"+OperationScreen.PC名+ "',dtUpdate=(select sysdate from dual@ncom_LINK) Where Tag=" + "'"+OperationScreen.tagId+"'";
                    sql3 = "select COUNT(*) from TS_tag WHERE Latest = 1 and IDYARD=" + OperationScreen.idYard + " and  pointX =" + OperationScreen.Location_x + " and pointY=" + OperationScreen.Location_y + " and pointZ=" + OperationScreen.Location_z +" and not TAG= "+ OperationScreen.tagId;
                    try
                    {
                        //フリーエリア処理
                        if (OperationScreen.フリーエリア判定結果 == true)
                        {
                            string 登録モード = "0";
                            if (Properties.Settings.Default.Free_manual_mode == false)
                            {
                                段数 = Convert.ToString(OperationScreen.Location_z);
                            }
                            else
                            {
                                登録モード = "1";
                            }
                            
                           
                            sql2 = "Update TS_tag Set pointX=" + OperationScreen.Location_x + ",pointY=" + OperationScreen.Location_y + ",pointZ=" + 段数 + ",distX=" + OperationScreen.Crane_point_x + ",distY=" + OperationScreen.Crane_point_y + ",distZ=";
                            sql2 += OperationScreen.Crane_point_z + ",cdtarget=0,Latest= 1,termUpdate='" + OperationScreen.PC名 + "',dtUpdate=(select sysdate from dual@ncom_LINK),FreeRegistMode="+登録モード+" Where Tag=" + "'" + OperationScreen.tagId + "'";
                            OracleCommand cmdFree = new OracleCommand(sql2);
                            cmdFree.Connection = conn;
                            cmdFree.CommandType = CommandType.Text;
                            cmdFree.ExecuteNonQuery();
                            cmdFree.Parameters.Clear();
                            cmdFree.Dispose();
                            break;
                        }

                        OracleCommand cmd3 = new OracleCommand(sql3);
                        cmd3.Connection = conn;
                        cmd3.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd3.ExecuteReader();
                        

                            while (reader.Read())
                            {
                                if (Convert.ToString(reader["COUNT(*)"]) != "0")
                                {
                                    重複 = true;
                                }

                            }

                        

                        if (重複 == true)
                        {
                            
                            //1段目の場合
                            if (OperationScreen.Location_z == "1")
                            {

                                sql4 = "Select A.pointX,A.pointY from TM_location A where idYard =" + OperationScreen.idYard + " and distXFrom <= " + OperationScreen.Crane_point_x + " and distXTo     > " + OperationScreen.Crane_point_x;
                                sql4 += " and distYFrom <= " + OperationScreen.Crane_point_y + " and distYTo     > " + OperationScreen.Crane_point_y + " and POINTZ=2";
                                OracleCommand cmd4 = new OracleCommand(sql4);
                                cmd4.Connection = conn;
                                cmd4.CommandType = CommandType.Text;
                                OracleDataReader reader2 = cmd4.ExecuteReader();
                                string X = "";
                                string Y = "";
                                while (reader2.Read())
                                {
                                    X = Convert.ToString(reader2["POINTX"]);
                                    Y = Convert.ToString(reader2["POINTY"]);

                                }


                                sql = "Update TS_tag Set Latest = 0 Where pointX =" + X + " and pointY=" + Y + " and pointZ=" + 二段 + " and IDYARD=" + OperationScreen.idYard;
                                sql2 = "Update TS_tag Set pointX=" + OperationScreen.Location_x + ",pointY=" + OperationScreen.Location_y + ",pointZ=" + 二段 + ",distX=" + OperationScreen.Crane_point_x + ",distY=" + OperationScreen.Crane_point_y + ",distZ=" + OperationScreen.Crane_point_z;
                                sql2 +=",cdtarget=0,Latest= 1,termUpdate='" + OperationScreen.PC名 + "',dtUpdate=(select sysdate from dual@ncom_LINK) Where Tag=" + "'" + OperationScreen.tagId + "'";
                            }
                            //2段目の場合
                            else if (OperationScreen.Location_z == "2")
                            {
                                
                                sql = "Update TS_tag Set Latest = 0 Where pointX =" + OperationScreen.Location_x + " and pointY=" + OperationScreen.Location_y + " and pointZ=" + 三段 + " and IDYARD=" + OperationScreen.idYard;
                                sql2 = "Update TS_tag Set pointX=" + OperationScreen.Location_x + ",pointY=" + OperationScreen.Location_y + ",pointZ=" + 三段 + ",distX=" + OperationScreen.Crane_point_x + ",distY=" + OperationScreen.Crane_point_y + ",distZ=" + OperationScreen.Crane_point_z;
                                sql2 += ",cdtarget=0,Latest= 1,termUpdate='" + OperationScreen.PC名 + "',dtUpdate=(select sysdate from dual@ncom_LINK) Where Tag=" + "'" + OperationScreen.tagId + "'";
                            }
                        }
                        
                            OracleCommand cmd = new OracleCommand(sql);
                            cmd.Connection = conn;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            cmd.Dispose();
                        
                       
                       
                        

                        OracleCommand cmd2 = new OracleCommand(sql2);
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        cmd2.ExecuteNonQuery();
                        cmd2.Parameters.Clear();
                        cmd2.Dispose();

                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル移動更新(配替)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 17://コイル移動更新(出庫)
                    sqlNo = "17";
                    sql = "Delete TS_tag where Tag="+"'"+OperationScreen.tagId+"'";

                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル移動更新(出庫)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 18://目標コイル取得
                    sqlNo = "18";
                    sql = "select tag from ts_tag Where cdtarget=1 and IDYARD="+ OperationScreen.idYard;
                    int cnt18 = 0;
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();




                        while (reader.Read())
                        {
                            cnt18++;
                            OperationScreen.Targetcoil = Convert.ToString(reader[0]);
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                        if (cnt18 == 0)
                        {
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).targetdisp("-", "-", "-", 0, 0, 0);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標コイル取得"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }

                    sql2 = "select pointx,pointy,pointz,distx,disty,distz from TS_tag where tag=" + OperationScreen.Targetcoil;
                    try
                    {
                        OracleCommand cmd1 = new OracleCommand(sql2);
                        cmd1.Connection = conn;
                        cmd1.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd1.ExecuteReader();
                        while (reader.Read())
                        {
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).targetdisp(Convert.ToString(reader[0]), Convert.ToString(reader[1]), Convert.ToString(reader[2]), Convert.ToInt32(reader[3]), Convert.ToInt32(reader[4]), Convert.ToInt32(reader[5]));
                        }
                        cmd1.Parameters.Clear();
                        cmd1.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標コイル取得"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;

                case 19://目標コイル更新
                    sqlNo = "19";
                    sql = "Update TS_tag set cdTarget = 0,processUpdate ='目標コイル初期化処理',dtUpdate = (select sysdate from dual@ncom_LINK) where cdTarget = 1 and idYard = "+OperationScreen.idYard;

                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("目標コイル更新"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 20://未設定エリア、禁止エリア
                    sqlNo = "20";
                    //sql = "select pointx,pointy from TM_LOCATION Where cdlocation=9 and IDYARD="+OperationScreen.idYard;
                    sql = "select pointx,pointy from TM_LOCATION Where cdlocation=9 and IDYARD=" + OperationScreen.idYard;
                    try
                    {
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).Location_Not_set_disp(Convert.ToInt32(reader[0]), Convert.ToInt32(reader[1]));
                        }
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("ロケーション取得(未設定)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }

                    //sql2 = "select pointx,pointy from TM_LOCATION Where cdstatus=1 and IDYARD="+OperationScreen.idYard;
                    sql2 = "select pointx,pointy from TM_LOCATION Where cdstatus=1 and IDYARD=" + OperationScreen.idYard;
                    try
                    {
                        OracleCommand cmd2 = new OracleCommand(sql2);
                        cmd2.Connection = conn;
                        cmd2.CommandType = CommandType.Text;
                        OracleDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            ((OperationScreen)Application.OpenForms["OperationScreen"]).Location_ban_disp(Convert.ToInt32(reader2[0]), Convert.ToInt32(reader2[1]));
                        }
                        reader2.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("ロケーション取得(禁止エリア)"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }

                    break;
                case 21://読み取りタグロケーション位置確認
                    sqlNo = "21";
                    break;
                case 22://タグ確認
                    //コイルロケーションの確認
                    //DISTX,Y,Zの取得
                    //現品番号の取得
                    sqlNo = "22";
                    // OperationScreen.tagId = "000001";//test
                    //OperationScreen.tagId = "000001";//test
                    //NVL
                    // sql = "select C.SHUKOYMD,C.TSUMIYMD,C.SHUKOKBN,D.tag,D.pointX,pointY,pointZ,sysdate,A.GENPINNO,A.RYO,A.GPSUNPO,C.TSUMINO,E.TSUMINO from TZAIKOG@NCOM_LINK A, TSHUKOG@NCOM_LINK B,TSHUKO@NCOM_LINK C, TS_tag D,WKOKBSYSREN@NCOM_LINK E Where		A.RFIDTAG =" + OperationScreen.tagId + "And			A.ZAIKONO = B.ZAIKONO And			A.ZAIKONOEDANO = B.ZAIKONOEDANO And			B.SHUKONO = C.SHUKONO And			A.RFIDtag = D.tag And			D. Latest = 1 And			C.TSUMINO=E.TSUMINO(+)";
                    //sql = "select NCOM.SHUKOYMD,NCOM.TSUMIYMD,NCOM.SHUKOKBN,COIL.tag,COIL.pointX,COIL.pointY,COIL.pointZ,(select sysdate from dual@ncom_LINK),NCOM.GENPINNO,NCOM.RYO,NCOM.GPSUNPO,NCOM.TSUMINO,NCOM.TSUMINO_WKOKBSYSREN from(select A.RFIDtag as RFIDtag,A.GENPINNO as GENPINNO,A.RYO as RYO,A.GPSUNPO as GPSUNPO,C.TSUMIYMD as TSUMIYMD,C.SHUKOKBN as SHUKOKBN,C.SHUKOYMD as SHUKOYMD,C.TSUMINO as TSUMINO,D.TSUMINO as TSUMINO_WKOKBSYSREN from TZAIKOG@NCOM_LINK A,TSHUKOG@NCOM_LINK B,TSHUKO@NCOM_LINK C left join WKOKBSYSREN@NCOM_LINK D ON C.TSUMINO = D.TSUMINO WHERE A.ZAIKONO = B.ZAIKONO And A.ZAIKONOEDANO = B.ZAIKONOEDANO And B.SHUKONO = C.SHUKONO AND A.rfidtag = '" + OperationScreen.tagId + "' ) NCOM FULL JOIN(select * from TS_tag where tag = '" + OperationScreen.tagId + "' ) COIL ON COIL.tag = NCOM.RFIDtag";
                    sql = "select";
                    sql += " A.tag,B.RFIDtag,A.pointX,A.pointY,A.pointZ,B.TSUMINO,B.GENPINNO,B.ryo,B.GPSUNPO,(select sysdate from dual@ncom_LINK),A.distX,A.distY,A.distZ";
                    sql += " from";
                    sql += " (select tag, pointx, pointy, pointz,DISTX,DISTY,DISTZ from TS_tag Where tag = '" + OperationScreen.tagId + "')A";
                    sql += " FULL Join";
                    sql += " (select  N.RFIDtag, N.GENPINNO, N.GPSUNPO, N.ryo, TSUMINO";
                    sql += " from TZAIKOG@NCOM_LINK N";
                    sql += " left join(select A.ZAIKONO, A.ryo, A.GPSUNPO, A.GENPINNO, C.TSUMINO";
                    sql += " from TZAIKOG@NCOM_LINK A, TSHUKOG@NCOM_LINK B, TSHUKO@NCOM_LINK C, WKOKBSYSREN@NCOM_LINK D";
                    sql += " WHERE A.RFIDtag = '" + OperationScreen.tagId + "'";
                    sql += " and A.ZAIKONO = B.ZAIKONO";
                    sql += " and B.SHUKONO = C.SHUKONO";
                    sql += " and C.TSUMINO = D.TSUMINO)";
                    sql += " NCOM ON NCOM.ZAIKONO = N.ZAIKONO";
                    sql += " WHERE RFIDtag = '" + OperationScreen.tagId + "')B ON A.tag = B.RFIDtag";
                    try
                    {
                        int sqlcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            //OperationScreen.移動開始時刻 = Convert.ToDateTime(reader[7]);
                            string a = Convert.ToString(reader[9]);
                            sqlcnt++;
                            //if (reader[0] == DBNull.Value || reader[1] == DBNull.Value || reader[2] == DBNull.Value || reader[7] == DBNull.Value || reader[8] == DBNull.Value || reader[9] == DBNull.Value || reader[10] == DBNull.Value)//データがなかった場合
                            //{


                            //    ((OperationScreen)Application.OpenForms["OperationScreen"]).tag_show("入庫", Convert.ToString(reader[3]), "--", "--", "--");
                            //}
                           
                            if (reader[10] == DBNull.Value || reader[11] == DBNull.Value || reader[12] == DBNull.Value)//DISTX,Y,ZがNULLの時
                            {
                                OperationScreen.coilloc = "0-0-0";
                                if(reader[6] != DBNull.Value)
                                {
                                    OperationScreen.現品番号 = Convert.ToString(reader[6]);
                                }
                                //if(reader[10] == DBNull.Value && reader[11] == DBNull.Value && reader[12] == DBNull.Value)
                                //{

                                //}
                            }
                            else if (reader[10] != DBNull.Value && reader[11] != DBNull.Value && reader[12] != DBNull.Value)//POINTX,Y,Zに値あり
                            {
                                OperationScreen.coilloc = reader[2] + "-" + reader[3] + "-" + reader[4];
                                OperationScreen.coilpointX = Convert.ToInt32(reader[10]);
                                OperationScreen.coilpointY = Convert.ToInt32(reader[11]);
                                OperationScreen.coilpointZ = Convert.ToInt32(reader[12]);
                                if (reader[6] != DBNull.Value)
                                {
                                    OperationScreen.現品番号 = Convert.ToString(reader[6]);
                                }
                            }
                          
                        }
                        if (sqlcnt == 0)
                        {
                            OperationScreen.coilloc = "0-0-0";
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("タグ確認処理"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 23://各フリーエリアボタン名に設定するコイル数取得 //2024.6.5 OGURI ADD STRAT↓
                    sqlNo = "23";
                    foreach (string area in OperationScreen.arrayFreeArea)
                    {
                        sql = "SELECT COUNT(TAG) FROM TS_TAG WHERE IDYARD=" + IDYARD + " AND POINTX || '-' || POINTY='" + area + "'";

                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                ((OperationScreen)Application.OpenForms["OperationScreen"]).SetCoilCnt(area, Convert.ToInt32(reader[0]));
                            }
                        }
                        catch (Exception ex)
                        {
                            Show_Message(5);
                            System_log(Convert.ToString("各フリーエリアコイル数取得"), "2", "SQL処理(" + sqlNo + ")", "kanri");
                        }
                        finally
                        {
                            cmd.Dispose();
                            reader.Dispose();
                        }
                    }
                    break;//2024.6.5 OGURI ADD END↑
                case 24://各フリーエリアのボタン色を設定 //2024.6.5 OGURI ADD STRAT↓
                    sqlNo = "24";
                    foreach (string area in OperationScreen.arrayFreeArea)
                    {
                        sql = "SELECT COUNT(TAG) FROM TS_TAG WHERE CDTARGET=1 AND IDYARD=" + IDYARD + " AND POINTX || '-' || POINTY='" + area + "'";//CDTARGET=1：選択されたコイルが存在する場合、該当フリーエリアボタン色を赤にする

                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();

                        try
                        {
                            while (reader.Read())
                            {
                                if (Convert.ToString(reader[0]) == "1")
                                {
                                    ((OperationScreen)Application.OpenForms["OperationScreen"]).SetBtnColor(area);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Show_Message(5);
                            System_log(Convert.ToString("各フリーエリアボタン色取得"), "2", "SQL処理(" + sqlNo + ")", "kanri");
                        }
                        finally
                        {
                            cmd.Dispose();
                            reader.Dispose();
                        }
                    }
                    break;//2024.6.5 OGURI ADD END↑

                //フリーエリア画面コイルリスト（積込日）
                case 25:
                    sqlNo = "25";
                    sql = "Select A.DISTX,A.DISTY,A.DISTZ,A.pointZ,D.TSUMINO,B.GENPINNO ,A.TAG,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.FreeRegistMode,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,";
                    sql += "TSHUKO@NCOM_LINK D where A.pointX =" + Properties.Settings.Default.Free_X + " and A.pointY=" + フリーエリア画面.Yロケーション + " and A.IDYARD=" + OperationScreen.idYard + " and A.tag = B.RFIDtag(+) and ";
                    sql+="B.ZAIKONO = C.ZAIKONO(+) and B.ZAIKONOEDANO = C.ZAIKONOEDANO(+) and C.SHUKONO = D.SHUKONO(+) and Latest=1 Order by D.TSUMIYMD,D.SHUKOYMD";
                    
                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                            string 横行 = "";
                            string 走行 = "";
                            string 高さ = "";
                            string 段数 = "";
                            string 積込NO = "";
                            string 現品NO = "";
                            string タグID = "";
                            string 重量 = "";
                            string 寸法 = "";
                            int 出庫日 = 0;
                            int 積込日 = 0;
                            string 備考 = "";
                            string モード = "";
                            string 目標 = "";

                            if (reader[0] != DBNull.Value)
                            {
                                横行 = Convert.ToString(reader[0]);
                            }
                            if (reader[1] != DBNull.Value)
                            {
                                走行 = Convert.ToString(reader[1]);
                            }
                            if (reader[2] != DBNull.Value)
                            {
                                高さ = Convert.ToString(reader[2]);
                            }
                            if (reader[3] != DBNull.Value)
                            {
                                段数 = Convert.ToString(reader[3]);
                            }
                            if (reader[4] != DBNull.Value)
                            {
                                積込NO = Convert.ToString(reader[4]);
                            }
                            if (reader[5] != DBNull.Value)
                            {
                                現品NO = Convert.ToString(reader[5]);
                            }
                            if (reader[6] != DBNull.Value)
                            {
                                タグID = Convert.ToString(reader[6]);
                            }
                            if (reader[7] != DBNull.Value)
                            {
                                重量 = Convert.ToString(reader[7]);
                            }
                            if (reader[8] != DBNull.Value)
                            {
                                寸法 = Convert.ToString(reader[8]);
                            }
                            if (reader[9] != DBNull.Value)
                            {
                                出庫日 = Convert.ToInt32(reader[9]);
                            }
                            if (reader[10] != DBNull.Value)
                            {
                                備考 = Convert.ToString(reader[10]);
                            }
                            if (reader[11] != DBNull.Value)
                            {
                                モード = Convert.ToString(reader[11]);
                            }
                            if (reader[12] != DBNull.Value)
                            {
                                目標 = Convert.ToString(reader[12]);
                            }
                            ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).ADDList(横行, 走行, 高さ, 段数, 積込NO, 現品NO, タグID, 重量, 寸法, 出庫日,積込日, モード,目標);

                           
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("フリーエリアコイルリスト作成（積込）"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                //フリーエリア画面コイルリスト（重量）
                case 26:
                    sqlNo = "26";
                    sql = "Select A.DISTX,A.DISTY,A.DISTZ,A.pointZ,D.TSUMINO,B.GENPINNO ,A.TAG,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.FreeRegistMode,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,";
                    sql += "TSHUKO@NCOM_LINK D where A.pointX =" + Properties.Settings.Default.Free_X + " and A.pointY=" + フリーエリア画面.Yロケーション + " and A.IDYARD=" + OperationScreen.idYard + " and A.tag = B.RFIDtag(+) and ";
                    sql += "B.ZAIKONO = C.ZAIKONO(+) and B.ZAIKONOEDANO = C.ZAIKONOEDANO(+) and C.SHUKONO = D.SHUKONO(+) and Latest=1 Order by B.RYO";

                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                            string 横行 = "";
                            string 走行 = "";
                            string 高さ = "";
                            string 段数 = "";
                            string 積込NO = "";
                            string 現品NO = "";
                            string タグID = "";
                            string 重量 = "";
                            string 寸法 = "";
                            int 出庫日 = 0;
                            int 積込日 = 0;
                            string 備考 = "";
                            string モード = "";
                            string 目標 = "";

                            if (reader[0] != DBNull.Value)
                            {
                                横行 = Convert.ToString(reader[0]);
                            }
                            if (reader[1] != DBNull.Value)
                            {
                                走行 = Convert.ToString(reader[1]);
                            }
                            if (reader[2] != DBNull.Value)
                            {
                                高さ = Convert.ToString(reader[2]);
                            }
                            if (reader[3] != DBNull.Value)
                            {
                                段数 = Convert.ToString(reader[3]);
                            }
                            if (reader[4] != DBNull.Value)
                            {
                                積込NO = Convert.ToString(reader[4]);
                            }
                            if (reader[5] != DBNull.Value)
                            {
                                現品NO = Convert.ToString(reader[5]);
                            }
                            if (reader[6] != DBNull.Value)
                            {
                                タグID = Convert.ToString(reader[6]);
                            }
                            if (reader[7] != DBNull.Value)
                            {
                                重量 = Convert.ToString(reader[7]);
                            }
                            if (reader[8] != DBNull.Value)
                            {
                                寸法 = Convert.ToString(reader[8]);
                            }
                            if (reader[9] != DBNull.Value)
                            {
                                出庫日 = Convert.ToInt32(reader[9]);
                            }
                            if (reader[10] != DBNull.Value)
                            {
                                備考 = Convert.ToString(reader[10]);
                            }
                            if (reader[11] != DBNull.Value)
                            {
                                モード = Convert.ToString(reader[11]);
                            }
                            if (reader[12] != DBNull.Value)
                            {
                                目標 = Convert.ToString(reader[12]);
                            }
                            ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).ADDList(横行, 走行, 高さ, 段数, 積込NO, 現品NO, タグID, 重量, 寸法, 出庫日, 積込日, モード, 目標);

                            
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("フリーエリアコイルリスト作成（重量）"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;

                //フリーエリア画面コイルリスト（タグID）
                case 27:
                    sqlNo = "27";
                    sql = "Select A.DISTX,A.DISTY,A.DISTZ,A.pointZ,D.TSUMINO,B.GENPINNO ,A.TAG,B.RYO ,B.GPSUNPO,D.SHUKOYMD,D.TSUMIYMD,A.FreeRegistMode,A.cdTarget from TS_tag A, TZAIKOG@NCOM_LINK B, TSHUKOG@NCOM_LINK C,";
                    sql += "TSHUKO@NCOM_LINK D where A.pointX =" + Properties.Settings.Default.Free_X + " and A.pointY=" + フリーエリア画面.Yロケーション + " and A.IDYARD=" + OperationScreen.idYard + " and A.tag = B.RFIDtag(+) and ";
                    sql += "B.ZAIKONO = C.ZAIKONO(+) and B.ZAIKONOEDANO = C.ZAIKONOEDANO(+) and C.SHUKONO = D.SHUKONO(+) and Latest=1 Order by A.tag";

                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                            string 横行 = "";
                            string 走行 = "";
                            string 高さ = "";
                            string 段数 = "";
                            string 積込NO = "";
                            string 現品NO = "";
                            string タグID = "";
                            string 重量 = "";
                            string 寸法 = "";
                            int 出庫日 = 0;
                            int 積込日 = 0;
                            string 備考 = "";
                            string モード = "";
                            string 目標 = "";

                            if (reader[0] != DBNull.Value)
                            {
                                横行 = Convert.ToString(reader[0]);
                            }
                            if (reader[1] != DBNull.Value)
                            {
                                走行 = Convert.ToString(reader[1]);
                            }
                            if (reader[2] != DBNull.Value)
                            {
                                高さ = Convert.ToString(reader[2]);
                            }
                            if (reader[3] != DBNull.Value)
                            {
                                段数 = Convert.ToString(reader[3]);
                            }
                            if (reader[4] != DBNull.Value)
                            {
                                積込NO = Convert.ToString(reader[4]);
                            }
                            if (reader[5] != DBNull.Value)
                            {
                                現品NO = Convert.ToString(reader[5]);
                            }
                            if (reader[6] != DBNull.Value)
                            {
                                タグID = Convert.ToString(reader[6]);
                            }
                            if (reader[7] != DBNull.Value)
                            {
                                重量 = Convert.ToString(reader[7]);
                            }
                            if (reader[8] != DBNull.Value)
                            {
                                寸法 = Convert.ToString(reader[8]);
                            }
                            if (reader[9] != DBNull.Value)
                            {
                                出庫日 = Convert.ToInt32(reader[9]);
                            }
                            if (reader[10] != DBNull.Value)
                            {
                                備考 = Convert.ToString(reader[10]);
                            }
                            if (reader[11] != DBNull.Value)
                            {
                                モード = Convert.ToString(reader[11]);
                            }
                            if (reader[12] != DBNull.Value)
                            {
                                目標 = Convert.ToString(reader[12]);
                            }
                            ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).ADDList(横行, 走行, 高さ, 段数, 積込NO, 現品NO, タグID, 重量, 寸法, 出庫日, 積込日, モード, 目標);

                            
                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("フリーエリアコイルリスト作成（タグ）"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                    //フリーエリア画面ロケーション値取得
                case 28:
                    sqlNo = "28";
                    sql = "select DISTXFROM,DISTXTO,DISTYFROM,DISTYTO from TM_LOCATION where POINTZ=1 and IDYARD="+ OperationScreen.idYard +" and POINTX=" + Properties.Settings.Default.Free_X +" and POINTY="+フリーエリア画面.Yロケーション;
                   

                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                             

                            if (reader[0] != DBNull.Value)
                            {
                                フリーエリア画面.From_FreeX = Convert.ToInt32(reader[0]);
                            }
                            if (reader[1] != DBNull.Value)
                            {
                                フリーエリア画面.To_FreeX = Convert.ToInt32(reader[1]);
                            }
                            if (reader[2] != DBNull.Value)
                            {
                                フリーエリア画面.From_FreeY = Convert.ToInt32(reader[2]);
                            }
                            if (reader[3] != DBNull.Value)
                            {
                                フリーエリア画面.To_FreeY = Convert.ToInt32(reader[3]);
                            }

                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("フリーエリアロケーション情報"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                    //フリーエリア画面コイル描画
                case 29:
                    sqlNo = "29";
                    sql = "select DISTX,DISTY,POINTZ,CDTARGET from TS_TAG where  IDYARD=" + OperationScreen.idYard + " and POINTX=" + Properties.Settings.Default.Free_X;
                    sql +=" and POINTY=" + フリーエリア画面.Yロケーション+" and POINTZ="+フリーエリア画面.段;


                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                           
                            int X値 = 0;
                            int Y値 = 0;
                            string 段数 = "";
                            string 目標 = "";
                            bool err = false;

                            if (reader[0] != DBNull.Value)
                            {
                                フリーエリア画面.DISX = Convert.ToInt32(reader[0]);
                            }
                            else { err = true; }
                            if (reader[1] != DBNull.Value)
                            {
                                フリーエリア画面.DISY = Convert.ToInt32(reader[1]);
                            }
                            else { err = true; }
                            if (reader[2] != DBNull.Value)
                            {
                                フリーエリア画面.段 = Convert.ToInt32(reader[2]);
                            }
                            else { err = true; }
                            if (reader[3] != DBNull.Value)
                            {
                                フリーエリア画面.目標 = Convert.ToInt32(reader[3]);
                            }
                            else { err = true; }
                            if (err == true)
                            {
                                continue;
                            }
                            else
                            {
                                ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).CoilDraw();
                            }

                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        //Show_Message(5);
                        //System_log(Convert.ToString("コイル描画処理"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;
                case 30:
                    sqlNo = "30";
                    if (フリーエリア画面.目標 == 99)
                    {
                        sql = "select DISTX,DISTY,POINTZ,CDTARGET from TS_TAG where  TAG=" + フリーエリア画面.目標コイル;
                    }
                    else
                    {
                        sql = "select DISTX,DISTY,POINTZ,CDTARGET from TS_TAG where  TAG=" + フリーエリア画面.選択コイル;
                    }
                   


                    try
                    {
                        OperationScreen.targetcntNo = -1;
                        OperationScreen.targetcnt = 0;
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        OracleDataReader reader = cmd.ExecuteReader();
                        Shipping_information.count = 0;
                        while (reader.Read())
                        {
                            int X値 = 0;
                            int Y値 = 0;
                            string 段数 = "";
                            string 目標 = "";
                            bool err = false;

                            if (reader[0] != DBNull.Value)
                            {
                                フリーエリア画面.DISX = Convert.ToInt32(reader[0]);
                            }
                            else { err = true; }
                            if (reader[1] != DBNull.Value)
                            {
                                フリーエリア画面.DISY = Convert.ToInt32(reader[1]);
                            }
                            else { err = true; }
                            if (reader[2] != DBNull.Value)
                            {
                                フリーエリア画面.段 = Convert.ToInt32(reader[2]);
                            }
                            else { err = true; }
                            if (reader[3] != DBNull.Value)
                            {
                                
                               
                            }
                            else { err = true; }
                            if (err == true)
                            {
                                continue;
                                //システムログ入れるか検討
                            }
                            else
                            {
                                ((フリーエリア画面)Application.OpenForms["フリーエリア画面"]).CoilDraw();
                            }

                        }
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                        reader.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                        System_log(Convert.ToString("コイル描画処理"), "2", "SQL処理(" + sqlNo + ")", "main");
                    }
                    break;

                case 99://システムログ
                    return;//20240529test
                    sqlNo = "99";
                    sql = "insert into TL_system(terminsert,processinsert,dtinsert,cdlog,txtlogprocess,txtlogheader,txtlog) values('"+ OperationScreen.PC名+"','"+対象スレ+ "',(select sysdate from dual@ncom_LINK)," + 区分+",'操作APP','"+項目+"','"+明細情報+"')";
                    try
                    {
                        int countplus = 0;
                        //for(int i = 0; i < 100; i++) { countplus++; }
                        OracleCommand cmd = new OracleCommand(sql);
                        cmd.Connection = conn;
                        cmd.CommandType = CommandType.Text;
                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        cmd.Dispose();
                    }
                    catch (Exception ex)
                    {
                        Show_Message(5);
                       
                    }
                    break;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            formChange(1);
        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }
        void FormSwap(string name)
        {

        }
        public void System_log(string log ,string 区分名,string 項目名,string 対象スレ名)
        {

            区分 = 区分名;
            項目 = 項目名;
            明細情報 = log;
            対象スレ = 対象スレ名;
            OracleDBsql(99);


        }

        private void Operation_Screen_Load(object sender, EventArgs e)
        {
            Console.WriteLine("test");

            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            //MessageBox.Show("ロード処理");
            Show_msg.Text = "";
            oracleDBopen();
            ////MessageBox.Show("DBOK");
            OracleDBsql(1);
            //MessageBox.Show("時刻OK");
            //操作画面
            f.Location = new Point(3, 47);
            f.TopLevel = false;
            this.Controls.Add(f);
            f.Show();
            //MessageBox.Show("操作室SHOWOK");
            //メニュー
            f1.Location = new Point(3, 47);
            f1.TopLevel = false;
            this.Controls.Add(f1);
            f1.Show();
            //MessageBox.Show("メニューSHOWOK");
            //機器チェック
            f2.Location = new Point(3, 47);
            //TopLevelをFalseにする
            f2.TopLevel = false;
            //フォームのコントロールに追加する
            this.Controls.Add(f2);
            //フォームを表示する
            f2.Show();
            //MessageBox.Show("機器チェックOK");
            //機器設定
            f3.Location = new Point(3, 47);
            //TopLevelをFalseにする
            f3.TopLevel = false;
            //フォームのコントロールに追加する
            this.Controls.Add(f3);
            //フォームを表示する
            f3.Show();
            //MessageBox.Show("機器設定OK");

            
           

            OracleDBsql(18);
            //formChange(0);
            //テスト用
            formChange(0);
            //System_log("起動","1","アプリ","main");
           
            TimesofDay_timer.Start();
            
        }

        public void formChange(int form_id)
        {
            //Select form_id
            //    case 1

            //    end
            switch (form_id)
            {
                case 0://OperaionScreen
                    Title.Text = "操作画面";
                    //最前面へ移動
                    f.BringToFront();

                    break;

                case 1: //Menu
                    Title.Text = "メニュー";
                    //最前面へ移動
                    f1.BringToFront();

                    break;

                case 2: //MachineCheck
                    Title.Text = "機器チェック";
                    //最前面へ移動
                    f2.BringToFront();

                    break;

                case 3: //setting_Device
                    Title.Text = "機器設定";
                    //最前面へ移動
                    //f3.timer1.Start();
                    f3.BringToFront();
                   

                    break;

                //case 4: //setting_Device
                //    Title.Text = "フリーエリア";
                //    //最前面へ移動
                //    //f3.timer1.Start();
                //    f4.BringToFront();


                //    break;


            }
        }
        public void Show_Message(int No)
        {
            Show_msg.ForeColor = Color.Black;
            switch (No)
            {
                case 0:
                    Show_msg.Text = "";
                    break;
                case 1:
                    Show_msg.Text = "機器の登録が完了しました";
                    break;
                case 2:
                    Show_msg.Text = "機器が設定できませんでした、設定値を見直してください";
                    break;
                case 3:
                    Show_msg.Text = "サーバーに接続できませんでした";
                    Show_msg.Text = "";//test
                    break;
                case 4:
                    Show_msg.Text = "サーバーに接続できませんでした";
                    Show_msg.Text = "";//test
                    break;
                case 5:
                    if (sqlNo != "3")
                    {
                        Show_msg.Text = "DB関連エラー:サポートにご連絡ください(" + sqlNo + ")";
                    }
                    break;
                case 6:
                    Show_msg.Text = "X軸シリアルポートOpenエラー";
                    break;
                case 7:
                    Show_msg.Text = "Y軸シリアルポートOpenエラー";
                    break;
                case 8:
                    Show_msg.Text = "Z軸シリアルポートOpenエラー";
                    break;
                case 9:
                    Show_msg.Text = "X軸値取得エラー";
                    break;
                case 10:
                    Show_msg.Text = "Y軸値取得エラー";
                    break;
                case 11:
                    Show_msg.Text = "Z軸値取得エラー";
                    break;
                case 12:
                    Show_msg.Text = "警告エリアに入っています";
                    Show_msg.ForeColor = Color.Red;
                    break;
                case 13:
                    Show_msg.Text = "注意エリアに入っています";
                    Show_msg.ForeColor = Color.Red;
                    break;
                case 14:
                    Show_msg.Text = "oracle接続エラー";
                    break;
                case 15:
                    Show_msg.Text = "X軸取得正常復帰";
                    break;
                case 16:
                    Show_msg.Text = "Y軸取得正常復帰";
                    break;
                case 17:
                    Show_msg.Text = "Z軸取得正常復帰";
                    break;
                case 18:
                    Show_msg.Text = "IO取得エラー";
                    break;
                case 19:
                    Show_msg.Text = "IO取得正常復帰";
                    break;
                case 20:
                    Show_msg.Text = "タグ読み取り中・・・";
                    break;
                case 21:
                    Show_msg.Text = "出力を上げてタグを読み取り中("+ Properties.Settings.Default.antena_decibel+")";
                    break;
                case 22:
                    Show_msg.Text ="X軸距離計との接続に失敗しました";
                    break;
                case 23:
                    Show_msg.Text = "Y軸距離計との接続に失敗しました";
                    break;
                case 24:
                    Show_msg.Text = "Z軸距離計との接続に失敗しました";
                    break;
                case 25:
                    Show_msg.Text = "X軸距離計再接続";
                    break;
                case 26:
                    Show_msg.Text = "Y軸距離計再接続";
                    break;
                case 27:
                    Show_msg.Text = "Z軸距離計再接続";
                    break;
                case 28:
                    Show_msg.Text = "初期処理中";
                    break;
                case 29:
                    Show_msg.Text = "サーバー再接続";
                    break;
                case 30:
                    Show_msg.Text = "複数タグを読み取っています";
                    Show_msg.ForeColor = Color.Red;
                    break;

            }
        }
        private void MainScreen_Shown(object sender, EventArgs e)
        {
            //formChange(0);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TimesofDay_timer_Tick(object sender, EventArgs e)
        {
            //もしかしたらフラグチェックでストップ
            TimesofDay_timer.Stop();
            OracleDBsql(1);
            TimesofDay_timer.Start();
        }
    }
}
