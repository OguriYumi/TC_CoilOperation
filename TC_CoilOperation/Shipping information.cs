using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TC_CoilOperation
{
   
    

    public partial class Shipping_information : Form
    {
       static public int count = 0;//grid数カウント用
        int selectbutton=0;
        bool selectflag = false;
        
        public Shipping_information()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperationScreen.targetcnt = 0;
            selectflag = false;
            disp(1);
            selectbutton = 1;
        }

        private void Shipping_information_Load(object sender, EventArgs e)
        {
            disp(1);
            selectbutton = 1;
        }
        public void Coil_Info(string TSMINO,string GENPINNO,string RFIDTAG, string x, string y, string z, string GPMETSUKERYO, string GPSUNPO, string SHUKOYMD, string TSUMIYMD, string CDTARGET,int モード) 
        {
            OperationScreen.targetcnt++;
            string date="";
            string day="";
            string day2 = "";
            if (TSUMIYMD != "") {
                date = TSUMIYMD;
                date = date.Insert(4, "/");
                date = date.Insert(7, "/");
                day = TSUMIYMD;
                 day2 = day.Remove(0, 4);
                day2 = day2.Insert(2, "/");
                day = day.Remove(0, 6);
                
            }
            string loc = x + "-" + y + "-" + z;
            if (loc == "--")
            {
                loc = "";
            }
            switch (モード)
            {
               
                case 1:
                    if (CDTARGET == "1")
                    {
                        OperationScreen.targetcntNo = OperationScreen.targetcnt;
                        if (SHUKOYMD != TSUMIYMD) { Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ","目標"); }
                        else if (Convert.ToDateTime(date) <= OperationScreen.dateTime.AddDays(Properties.Settings.Default.Add_day)) Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, day2,"目標");
                        else Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "目標");
                    }
                    else if (SHUKOYMD != TSUMIYMD) { Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ",""); }
                    else if (Convert.ToDateTime(date)<= OperationScreen.dateTime.AddDays(Properties.Settings.Default.Add_day)) Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, day2,"");
                    else Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "","");
                    break;
                case 2:
                    if (CDTARGET == "1") 
                    {
                        if(SHUKOYMD != TSUMIYMD) { OperationScreen.targetcntNo = OperationScreen.targetcnt; Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ", "目標"); }
                        else { OperationScreen.targetcntNo = OperationScreen.targetcnt; Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "", "目標"); }
                        

                    }
                    else if (SHUKOYMD!=TSUMIYMD) { Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ",""); }
                    else Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "","");
                    break;
                case 3:
                    if (CDTARGET == "1") 
                    {
                        if (SHUKOYMD != TSUMIYMD) { OperationScreen.targetcntNo = OperationScreen.targetcnt; Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ", "目標"); }
                        else
                        { OperationScreen.targetcntNo = OperationScreen.targetcnt; Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "", "目標"); } 
                    }
                    else if (SHUKOYMD != TSUMIYMD) { Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "ヨ",""); }
                    else Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, "","");
                    break;
                case 4:
                    if (CDTARGET == "1") { OperationScreen.targetcntNo = OperationScreen.targetcnt; Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, day2, "目標"); }
                    else Coil_Grid_Info.Rows.Add(TSMINO, GENPINNO, RFIDTAG, loc, GPMETSUKERYO, GPSUNPO, day2,"");
                    break;
            }
           
        }
        void disp(int disp_id)
        {
            OperationScreen.targetcntNo = -1;
            Coil_Grid_Info.Columns.Clear();
            Coil_Grid_Info.Rows.Clear();
            Coil_Grid_Info.RowHeadersVisible = false;

            Coil_Grid_Info.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            Coil_Grid_Info.ColumnCount = 8;
            //Coil_Grid_Info.RowCount = 3;

            //for (int i = 0; i < 3; i++)
            //{
            //    // dataGridView1.Columns[i].HeaderText = (i + 1).ToString();
            //    Coil_Grid_Info.Rows[i].Height = 45;
            //    Coil_Grid_Info.Rows[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}

            Coil_Grid_Info.Columns[0].HeaderText = ("積込票No").ToString();
            Coil_Grid_Info.Columns[1].HeaderText = ("現品No").ToString();
            Coil_Grid_Info.Columns[2].HeaderText = ("タグID").ToString();
            Coil_Grid_Info.Columns[3].HeaderText = ("ロケ").ToString();
            Coil_Grid_Info.Columns[4].HeaderText = ("重量[kg]").ToString();
            Coil_Grid_Info.Columns[5].HeaderText = ("寸法").ToString();
            Coil_Grid_Info.Columns[6].HeaderText = ("備考").ToString();
            Coil_Grid_Info.Columns[7].HeaderText = ("目標").ToString();


            //積込票No
            Coil_Grid_Info.Columns[0].Width = 120;
            //現品No
            Coil_Grid_Info.Columns[1].Width = 210;
            //タグID
            Coil_Grid_Info.Columns[2].Width = 100;
            //ロケーション
            Coil_Grid_Info.Columns[3].Width = 120;
            //重量
            Coil_Grid_Info.Columns[4].Width = 120;
            //寸法
            Coil_Grid_Info.Columns[5].Width = 200;
            //積日
            Coil_Grid_Info.Columns[6].Width = 88;
            //目標
            Coil_Grid_Info.Columns[7].Width = 50;
            Coil_Grid_Info.Columns[7].Visible = false;


            Coil_Grid_Info.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            Coil_Grid_Info.AlternatingRowsDefaultCellStyle.BackColor = Color.LightCyan;
            Coil_Grid_Info.Columns[4].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleRight;
            Coil_Grid_Info.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            switch (disp_id)
            {
                case 1://積込待ちテーブルの表示
                   
                        //dataGridView1[0, 0].Value = Convert.ToString("XX");
                        //dataGridView1[1, 1].Value = Convert.ToString("20XXXXXXXXXXXXXXXXX");
                        //dataGridView1[2, 2].Value = Convert.ToString("XXXXX");
                        //dataGridView1[3, 3].Value = Convert.ToString("XX-XX-XX");
                        //dataGridView1[4, 4].Value = Convert.ToString("999,99");
                        //dataGridView1[5, 5].Value = Convert.ToString("999,99");

                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(7);
                    

                    break;
                case 2://本日予定テーブルの表示
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(8);
                    break;
                    
                case 3://翌日予定テーブルの表示
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(9);
                    break;

                case 4://2日以降予定テーブルの表示
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(10);
                    break;


            }
           // Coil_Grid_Info.Rows.Add("XXXXXX", "XXXXXXXXXXXXXXX", "XXXXXX", "XX-XX-XX", "XXXXX", "XXXXXXXXXXXXXXXXXXXXXXXXXXX","XXXX");

            if (OperationScreen.targetcntNo != -1)
            {
                //Coil_Grid_Info.Columns[OperationScreen.targetcntNo].DefaultCellStyle.BackColor = Color.Red;
                //Coil_Grid_Info.Item[OperationScreen.targetcntNo].DefaultCellStyle.BackColor = Color.Red;
                Coil_Grid_Info.Rows[OperationScreen.targetcntNo-1].DefaultCellStyle.BackColor = Color.Red;
            }

            selectflag = true;
            }
      
        private void button2_Click(object sender, EventArgs e)
        {
            
            OperationScreen.targetcnt = 0;
            selectflag = false;
            disp(2);
            selectbutton = 2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OperationScreen.targetcnt = 0;
            selectflag = false;
            disp(3);
            selectbutton = 3;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OperationScreen.targetcnt = 0;
            selectflag = false;
            disp(4);
            selectbutton = 4;
        }

        private void Shipping_information_Shown(object sender, EventArgs e)
        {
            Coil_Grid_Info.CurrentCell = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //セルクリック時のイベント

            
        }

        private void Coil_Grid_Info_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void Coil_Grid_Info_DoubleClick(object sender, EventArgs e)
        {
            OperationScreen.targetcnt = 0;
            if (selectflag == true)
            {
                if (Coil_Grid_Info.CurrentRow.Cells[2].Value != DBNull.Value)
                {
                    if (OperationScreen.Targetcoil == Convert.ToString(Coil_Grid_Info.CurrentRow.Cells[2].Value))
                    {
                        OperationScreen.Targetcoil = "";
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(19);
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
                    }
                    else
                    {
                        OperationScreen.Targetcoil = Convert.ToString(Coil_Grid_Info.CurrentRow.Cells[2].Value);
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(12);
                        ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);
                    }
                }
                switch (selectbutton)
                {
                    case 1:
                        disp(1);
                        break;
                    case 2:
                        disp(2);
                        break;
                    case 3:
                        disp(3);
                        break;
                    case 4:
                        disp(4);
                        break;
                }
            }
        }

        private void Coil_Grid_Info_SelectionChanged(object sender, EventArgs e)
        {
            Coil_Grid_Info.ClearSelection();
        }

        private void Coil_Grid_Info_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
           string coil= Convert.ToString(Coil_Grid_Info.CurrentCellAddress.Y+1);
            if (coil != "0")
            {
                OperationScreen.targetcnt = 0;
                if (selectflag == true)
                {
                    if (Coil_Grid_Info.CurrentRow.Cells[2].Value != DBNull.Value)
                    {
                        if (OperationScreen.Targetcoil == Convert.ToString(Coil_Grid_Info.CurrentRow.Cells[2].Value))
                        {
                            OperationScreen.Targetcoil = "";
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(19);
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);
                        }
                        else
                        {
                            OperationScreen.Targetcoil = Convert.ToString(Coil_Grid_Info.CurrentRow.Cells[2].Value);
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(12);
                            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);
                        }
                    }
                    switch (selectbutton)
                    {
                        case 1:
                            disp(1);
                            break;
                        case 2:
                            disp(2);
                            break;
                        case 3:
                            disp(3);
                            break;
                        case 4:
                            disp(4);
                            break;
                    }
                }
            }
        }
    }
}
