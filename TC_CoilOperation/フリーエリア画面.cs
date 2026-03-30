using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace TC_CoilOperation
{
   
    public partial class フリーエリア画面 : Form
    {
        public static bool init_flg = false;//  初期化フラグ
        public static string Yロケ;   //親画面（OperationScreen）で選択されたエリア名を保持
        public static int Yロケーション = 1; //DB検索用
        public static int LISTsort = 25;//リスト絞り込み条件
        public static int Dansort = 0;//段数絞り込み条件
        public static int RowCount = 0;
        public static string 選択コイル = "";
        public static string 目標コイル = "";

        public static int From_FreeX = 0;
        public static int From_FreeY = 0;
        public static int To_FreeX = 0;
        public static int To_FreeY = 0;

        public static float DISX = 0;
        public static float DISY = 0;
        public static int 段 = 0;
        public static int 目標 = 0;
        public static int 対象段 = 0;


        public フリーエリア画面()
        {

            InitializeComponent();
            init_timer.Start();

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void フリーエリア画面_Load(object sender, EventArgs e)
        {

            Dgv_コイルリスト.Columns.Clear();
            Dgv_コイルリスト.Rows.Clear();
            Dgv_コイルリスト.RowHeadersVisible = false;
            
            //Dgv_コイルリスト.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Dgv_コイルリスト.ColumnCount = 13;
            Dgv_コイルリスト.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
            Dgv_コイルリスト.DefaultCellStyle.SelectionBackColor = Color.Orange;
            
            //Dgv_コイルリスト.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;

            Dgv_コイルリスト.RowTemplate.Height = 28;

            Dgv_コイルリスト.Columns[0].Width = 78;
            Dgv_コイルリスト.Columns[1].Width = 78;
            Dgv_コイルリスト.Columns[2].Width = 78;
            Dgv_コイルリスト.Columns[3].Width = 70;
            Dgv_コイルリスト.Columns[4].Width = 100;
            Dgv_コイルリスト.Columns[5].Width = 90;
            Dgv_コイルリスト.Columns[6].Width = 90;
            Dgv_コイルリスト.Columns[7].Width = 95;
            Dgv_コイルリスト.Columns[8].Width = 95;
            Dgv_コイルリスト.Columns[9].Width = 118;
            Dgv_コイルリスト.Columns[10].Width = 80;
            Dgv_コイルリスト.Columns[11].Width = 100;
            Dgv_コイルリスト.Columns[12].Width = 100;

            Dgv_コイルリスト.Columns[0].HeaderText = ("横行").ToString();
            Dgv_コイルリスト.Columns[1].HeaderText = ("走行").ToString();
            Dgv_コイルリスト.Columns[2].HeaderText = ("高さ").ToString();
            Dgv_コイルリスト.Columns[3].HeaderText = ("段数").ToString();
            Dgv_コイルリスト.Columns[4].HeaderText = ("積込票No").ToString();
            Dgv_コイルリスト.Columns[5].HeaderText = ("現品No").ToString();
            Dgv_コイルリスト.Columns[6].HeaderText = ("タグID").ToString();
            Dgv_コイルリスト.Columns[7].HeaderText = ("重量[kg]").ToString();
            Dgv_コイルリスト.Columns[8].HeaderText = ("寸法").ToString();
            Dgv_コイルリスト.Columns[9].HeaderText = ("出庫日").ToString();
            Dgv_コイルリスト.Columns[10].HeaderText = ("備考").ToString();
            Dgv_コイルリスト.Columns[11].HeaderText = ("登録モード").ToString();
            Dgv_コイルリスト.Columns[12].HeaderText = ("目標").ToString();
            Dgv_コイルリスト.Columns[12].Visible = false;

            Dgv_コイルリスト.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Dgv_コイルリスト.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_コイルリスト.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            Dgv_コイルリスト.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            Dgv_コイルリスト.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            Dgv_コイルリスト.DefaultCellStyle.Font = new Font("Arial", 12);
            //Dgv_コイルリスト.Rows.Add(999999, 999999, 999999, "2段", 111627, "S231514", "000001", 1962, 10.5, "04/20","宵積み","手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231515", "000002", 1962, 10.5, "04/21","", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "1段", 111627, "S231516", "000003", 1962, 10.5, "04/22", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "1段", 111627, "S231517", "000004", 1962, 10.5, "04/23", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "3段", 111627, "S231518", "000005", 1962, 10.5, "04/24", "宵積み", "自動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231519", "000006", 1962, 10.5, "04/25", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231520", "000007", 1962, 10.5, "04/26", "", "自動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "1段", 111627, "S231521", "000008", 1962, 10.5, "04/27", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231522", "000009", 1962, 10.5, "04/28", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "3段", 111627, "S231523", "000010", 1962, 10.5, "04/29", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "1段", 111627, "S231524", "000011", 1962, 10.5, "04/30", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231525", "000012", 1962, 10.5, "05/01", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "3段", 111627, "S231526", "000013", 1962, 10.5, "04/21", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "1段", 111627, "S231527", "000014", 1962, 10.5, "04/21", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "2段", 111627, "S231528", "000015", 1962, 10.5, "04/21", "", "手動");
            //Dgv_コイルリスト.Rows.Add(99999, 99999, 99999, "3段", 111627, "S231529", "000016", 1962, 10.5, "04/21", "", "手動");

            //Dgv_コイルリスト.Rows[2].DefaultCellStyle.BackColor = Color.Yellow;
            //Dgv_コイルリスト.Rows[3].DefaultCellStyle.BackColor = Color.LawnGreen;
            //Dgv_コイルリスト.Rows[5].DefaultCellStyle.BackColor = Color.Red;
            Dgv_コイルリスト.MultiSelect = false;
            Dgv_コイルリスト.ReadOnly = true;
            Dgv_コイルリスト.ClearSelection();

            

        }

        private void Btn_出荷_Click(object sender, EventArgs e)
        {
            
            Btn_タグ.BackColor = Color.LightGray;
            Btn_重量.BackColor = Color.LightGray;
            Btn_出荷.BackColor = Color.SkyBlue;
            LISTsort = 25;
            disp();
        }
        /// <summary>
        /// 描画処理
        /// </summary>
        public void disp()
        {
            目標コイル = "";
            選択コイル = "";
            RowCount = 0;
            //Pb_コイル配置.Refresh();
            Dgv_コイルリスト.Rows.Clear();
            CoilList_Disp(LISTsort);
            
            Location_Disp();
           
           
        }
        public void Location_Disp()
        {
            Pb_コイル配置.Refresh();
            //ロケーションデータ取得
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(28);

            //コイル描画　1段目
            if (Dansort == 0 || Dansort == 1){
                段 = 1;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(29);
            }
            if (Dansort == 0 || Dansort == 2)
            {
                段 = 2;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(29);
            }
            if (Dansort == 0 || Dansort == 3)
            {
                段 = 3;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(29);
            }
            if (目標コイル != "")
            {
                目標 = 99;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(30);
                目標 = 0;
            }
            if (選択コイル != "")
            {

                目標 = 98;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(30);
                目標 = 0;
            }
           
        }

        

        public void CoilDraw()
        {
            //----------------------------
            //2024.06.18 morichika
            lblFromX.Text = From_FreeX.ToString();
            lblToX.Text = To_FreeX.ToString();
            lblFromY.Text = From_FreeY.ToString();
            lblToY.Text = To_FreeY.ToString();
            //----------------------------
            float コイルサイズ = 26;
            
            float 全体ロケX = To_FreeX - From_FreeX;
            float 全体ロケY = To_FreeY - From_FreeY;

            float 差分X = DISX-From_FreeX;
            float 差分Y = DISY-From_FreeY;

            float 比率X = (float)Math.Round(差分X / 全体ロケX, 3);
            float 比率Y = (float)Math.Round(差分Y / 全体ロケY, 3);

            //ピクチャボックスサイズ
            float picSizeX = Pb_コイル配置.Size.Width;
            float picSizeY = Pb_コイル配置.Size.Height;

            //ピクチャボックスロケーション値
            float picLocX = Pb_コイル配置.Location.X;
            float picLocY = Pb_コイル配置.Location.Y;

            Graphics g = Pb_コイル配置.CreateGraphics();
            float COILX = (float)Math.Floor(picSizeX * 比率X);
            float COILY = (float)Math.Floor(picSizeY * 比率Y);
       
            //最終センターにコイルを配置する処理に変更
            if (目標 == 99)
            {
                DrawFilledRectangle(g, Brushes.Red, COILX - (コイルサイズ / 2), COILY - (コイルサイズ / 2), コイルサイズ, コイルサイズ);
                return;
            }else if (目標 == 98)
            {
                DrawFilledRectangle(g, Brushes.Orange, COILX - (コイルサイズ / 2), COILY - (コイルサイズ / 2), コイルサイズ, コイルサイズ);
                return;
            }
            if (段 == 1)
            {
                DrawFilledRectangle(g, Brushes.SkyBlue, COILX - (コイルサイズ / 2), COILY - (コイルサイズ / 2), コイルサイズ, コイルサイズ);
            }
            else if (段 == 2)
            {
                DrawFilledRectangle(g, Brushes.Blue, COILX - (コイルサイズ / 2), COILY - (コイルサイズ / 2), コイルサイズ, コイルサイズ);
            }
            else if (段 == 3)
            {
                DrawFilledRectangle(g, Brushes.Purple, COILX - (コイルサイズ / 2), COILY - (コイルサイズ / 2), コイルサイズ, コイルサイズ);
            }



        }

        public void CoilList_Disp(int 並び条件)
        {
            
            RowCount = 0;
            Dgv_コイルリスト.Rows.Clear();
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(並び条件);
            Dgv_コイルリスト.CurrentCell = null;
        }
       public string Datestr(int timeval)
        {

            int dateInt = timeval;
            string dateStr = dateInt.ToString();
            try { 
            // 年、月、日の部分を取り出す
            int year = int.Parse(dateStr.Substring(0, 4));
            int month = int.Parse(dateStr.Substring(4, 2));
            int day = int.Parse(dateStr.Substring(6, 2));

            // DateTimeオブジェクトを作成
            DateTime date = new DateTime(year, month, day);
                
            // 指定のフォーマットで文字列に変換
            return date.ToString("yyyy/MM/dd");
            }catch (Exception ex)
            {
                return "-99999";
            }
        }
        public void ADDList(string 横行, string 走行, string 高さ, string 段数, string 積込NO, string 現品NO, string タグID, string 重量, string 寸法, int 出庫日, int 積込日, string モード,string 目標)
        {
            if (Dansort == 1)
            {
                if (段数 != "1")
                {
                    return;
                }
            }else if(Dansort == 2)
            {
                if (段数 != "2")
                {
                    return;
                }
            }
            else if (Dansort == 3)
            {
                if (段数 != "3")
                {
                    return;
                }
            }
            string 変換出庫日="";

            if (出庫日!= 0)
            {
                変換出庫日=Datestr(出庫日);
            }
            
            string 備考 = "";
             
            if (出庫日 != 積込日 && 積込日!=0)
            {
                備考 = "宵積み";
            }
            
            if (モード == "1")
            {
                モード = "手動";
            }
            else { モード = "自動"; }

            Dgv_コイルリスト.Rows.Add(横行, 走行, 高さ, 段数 += "段" , 積込NO, 現品NO, タグID, 重量, 寸法, 変換出庫日, 備考,モード,目標);
            DateTime specifiedDate=DateTime.Now;
            try
            {
                DateTime.TryParseExact(変換出庫日, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out specifiedDate);
            }catch (Exception e) { }
            if (目標 == "1")
            {
                Dgv_コイルリスト.Rows[RowCount].DefaultCellStyle.BackColor = Color.Red;
                目標コイル = タグID;
            }else if (変換出庫日 == "")
            {
                フリーエリア画面.RowCount++;
                return;
            }
            else if(specifiedDate<= DateTime.Now.Date)
            {
                Dgv_コイルリスト.Rows[RowCount].DefaultCellStyle.BackColor = Color.Yellow;
            }else if (specifiedDate == DateTime.Now.Date.AddDays(-1))
            {
                Dgv_コイルリスト.Rows[RowCount].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            フリーエリア画面.RowCount++;
        }

        private void Pb_コイル配置_Paint(object sender, PaintEventArgs e)
        {
            //画面描画テスト(e);
        }
        private void DrawFilledRectangle(Graphics g, Brush brush, float x, float y, float width, float height)
        {
            // 四角形を塗りつぶす
            g.FillRectangle(brush, x, y, width, height);
        }
        private void 画面描画テスト(PaintEventArgs e)
        {

          

            //1段目上
            for (int i = 0; i < 33; i++)
            {
                DrawFilledRectangle(e.Graphics, Brushes.SkyBlue, i + 10 + i * 28, 30, 28, 28);
            }

            //1段目下
            for (int i = 0; i < 33; i++)
            {
                DrawFilledRectangle(e.Graphics, Brushes.SkyBlue, i + 10 + i * 28, 101, 28, 28);
            }
            int count = 0;
            //2段目上
            for (int i = 0; i < 33; i++)
            {
                if (count == 2)
                {
                    count = 0;
                    continue;
                }
                DrawFilledRectangle(e.Graphics, Brushes.Blue, i + 25 + i * 28, 30, 28, 28);
                count++;
            }
            count = 0;
            //2段目下
            for (int i = 0; i < 33; i++)
            {
                if (count == 2)
                {
                    count = 0;
                    continue;
                }
                DrawFilledRectangle(e.Graphics, Brushes.Blue, i + 25 + i * 28, 101, 28, 28);
                count++;
            }

            ////3段目上
            //for (int i = 0; i < 10; i++)
            //{
            //    DrawFilledRectangle(e.Graphics, Brushes.Purple, 41 + i * 96, 30, 30, 30) ;
            //}

            //3段目下
            for (int i = 0; i < 11; i++)
            {
                DrawFilledRectangle(e.Graphics, Brushes.Purple, 40 + i * 88 - i, 101, 28, 28);
            }

            //DrawFilledRectangle(e.Graphics, Brushes.SkyBlue, 10, 20, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Blue, 25, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Blue, 56, 101, 30, 30);
            DrawFilledRectangle(e.Graphics, Brushes.Orange, 0 + 25 + 0 * 28, 101, 28, 28);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 38, 101, 28, 28);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 126, 101, 28, 28);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 233, 101, 30, 30);
            DrawFilledRectangle(e.Graphics, Brushes.Red, 315, 30, 28, 28);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 425, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 521, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 617, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 713, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 809, 101, 30, 30);
            //DrawFilledRectangle(e.Graphics, Brushes.Purple, 905, 101, 30, 30);

        }

        private void Dgv_コイルリスト_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_コイルリスト_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //// 行が選択された場合
            //if (e.StateChanged == DataGridViewElementStates.Selected)
            //{
            //    // 他のすべての行を選択する
            //    foreach (DataGridViewRow row in Dgv_コイルリスト.Rows)
            //    {
            //        row.Selected = true;
            //    }
            //}
        }

        private void Dgv_コイルリスト_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
           
            
        }

        private void Btn_戻る_Click(object sender, EventArgs e)
        {
            ((OperationScreen)Application.OpenForms["OperationScreen"]).disp();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (DanManualmode.Checked == true)
            {
                Properties.Settings.Default.Free_manual_mode = true;
            }
            else Properties.Settings.Default.Free_manual_mode = false;
           
            Properties.Settings.Default.Save();

        }

        private void init_timer_Tick(object sender, EventArgs e)
        {
            init_timer.Stop();

            CB_エリア.Items.AddRange(OperationScreen.arrayFreeArea);
            

            CB_段.Items.AddRange(new string[] { "全て", "1段", "2段", "3段" });

            
            CB_段.SelectedIndex = 0;

            //段積み手動モード確認
            DanManualmode.Checked = Properties.Settings.Default.Free_manual_mode;

            //エリア設定
            CB_エリア.SelectedItem = Yロケ;



            init_flg = true;

        }

        private void CB_エリア_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init_flg == false)
            {
                return;
            }
            Yロケーション = CB_エリア.SelectedIndex + 1;
            disp();
        }

        private void CB_段_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init_flg == false)
            {
                return;
            }
            Dansort = CB_段.SelectedIndex;
            disp();
        }

        private void Btn_更新_Click(object sender, EventArgs e)
        {

            //test20240613 山﨑
            //((OperationScreen)Application.OpenForms["OperationScreen"]).test();//目標コイル設定  
            disp();

        }

        private void Btn_目標コイル_Click_1(object sender, EventArgs e)
        {
            if (選択コイル != "")
            {
                //選択中のタグIDを基に目標コイルに設定する
                OperationScreen.Targetcoil = 選択コイル;
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(12);//目標コイル設定
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル設定     
               　disp();
            }
           
        }

        private void Btn_タグ_Click(object sender, EventArgs e)
        {
            
            Btn_タグ.BackColor = Color.SkyBlue;
            Btn_重量.BackColor = Color.LightGray;
            Btn_出荷.BackColor = Color.LightGray;
            LISTsort = 27;
            disp();
        }

        private void Btn_重量_Click(object sender, EventArgs e)
        {
            
            Btn_タグ.BackColor = Color.LightGray;
            Btn_重量.BackColor = Color.SkyBlue;
            Btn_出荷.BackColor = Color.LightGray;
            LISTsort = 26;
            disp();
        }

        private void Dgv_コイルリスト_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダー行がクリックされた場合は何もしない
            if (e.RowIndex < 0)
            {
                return;
            }else
            {
                選択コイル = Convert.ToString( Dgv_コイルリスト.Rows[e.RowIndex].Cells[6].Value);
                Location_Disp();
            }
        }

        private void Pb_コイル配置_Click(object sender, EventArgs e)
        {

        }
       
        //20240621 morichika
        //配置後の再表示処理
        private void refresh_timer_Tick(object sender, EventArgs e)
        {            
            if (TC_CoilOperation.OperationScreen.FreeAreaRefreshflg == true)
            {
                disp();
                TC_CoilOperation.OperationScreen.FreeAreaRefreshflg = false;
            }
        }
    }
}
