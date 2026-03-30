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
    public partial class multicoil : Form
    {
        public multicoil()
        {
            InitializeComponent();
        }

        private void multicoil_Load(object sender, EventArgs e)
        {
            タグ表示画面.AllowUserToAddRows = false;
            //クレーン座標.Text=OperationScreen.Clocation;
           
            //ヘッダーは自分で作成し、ヘッダーは選択できないようにする
            タグ表示画面.Columns.Clear();
            タグ表示画面.Rows.Clear();
            //ヘッダーとすべてのセルの内容に合わせて、列の幅を自動調整する
            タグ表示画面.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            //ヘッダーとすべてのセルの内容に合わせて、行の高さを自動調整する
            タグ表示画面.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;


            タグ表示画面.ColumnHeadersVisible = false;
            タグ表示画面.RowHeadersVisible = false;
            //タグ表示画面.DefaultCellStyle.Font = new Font("Tahoma", 18);
            //タグ表示画面.ColumnHeadersHeight = 50;
            //タグ表示画面.RowHeadersWidth = 50;
            
            タグ表示画面.ColumnCount = 3;
            タグ表示画面.RowCount = 1;
            //タグ表示画面.Columns[0].HeaderText ="タグID";
            //タグ表示画面.Columns[1].HeaderText = "現品NO";
            //タグ表示画面.Columns[2].HeaderText = "ロケーション";
            //タグ表示画面.Rows[0].Height = 30;
            //タグ表示画面.Rows[1].Height = 30;
            
            タグ表示画面.Columns[0].Width = 150;
            タグ表示画面.Columns[1].Width = 640;
            タグ表示画面.Columns[2].Width = 200;

            クレーン座標.Text = OperationScreen.Location_x + "-" + OperationScreen.Location_y + "-" + OperationScreen.Location_z;

            タグ表示画面.Rows[0].Visible = false;
            //タグ表示画面.Rows[1].Visible = false;
            //タグ表示画面.Rows[1].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;

            //タグ表示画面.Rows.Add("000000", "キーエンスPLC－XXXXXXXX", "00-00-00");
            //タグ表示画面.Rows[1].DefaultCellStyle.Alignment =DataGridViewContentAlignment.MiddleCenter;
            //タグ表示画面.Rows[1].Height = 30;

            //タグ表示画面.Rows.Add("000001", "三菱電機PLC－XXXXXXXX", "00-00-00");
            //タグ表示画面.Rows[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //タグ表示画面.Rows[2].Height = 30;

            //int count = 1;//テストプログラム
            //for (int i = 0; i < 3; i++)
            //{
            //    OperationScreen.tagname[i] = "00000"+count;
            //    count++;
            //}
           
            for (int i = 0; i < OperationScreen.tagname.Length; i++)
            {
                if (OperationScreen.tagname[i] == string.Empty)
                {
                    break;
                }
                else
                {
                    OperationScreen.coilpointX = -99999;             //コイル座標X
                    OperationScreen.coilpointY = -99999;             //コイル座標Y
                    OperationScreen.coilpointZ = -99999;             //コイル座標Z
                    OperationScreen.coillocX = "0";               //コイルロケX
                    OperationScreen.coillocY = "0";               //コイルロケY
                    OperationScreen.coillocZ = "0";               //コイルロケZ
                    OperationScreen.coilloc = "0-0-0";            //コイルロケ
                    OperationScreen.ClenpointX = OperationScreen.Crane_point_x; //クレーン座標X
                    OperationScreen.ClenpointY = OperationScreen.Crane_point_y; //クレーン座標Y
                    OperationScreen.ClenpointZ = OperationScreen.Crane_point_z; //クレーン座標Z

                    OperationScreen.現品番号 = "現品情報無し";
                    OperationScreen.tagId = OperationScreen.tagname[i];
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(22);
                    if (OperationScreen.coilloc == "0-0-0")
                    {
                        OperationScreen.coilloc = "ロケ情報なし";
                    }
                    タグ表示画面.Rows.Add(OperationScreen.tagname[i], OperationScreen.現品番号, OperationScreen.coilloc);
                    //タグ表示画面.Rows[i+1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    タグ表示画面.Rows[i+1].Height = 50;

                }
            }
            タグ表示画面.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OperationScreen.tagId = "-";

            // //重複起動処理フラグ追加　20240626 山﨑
            OperationScreen.重複処理フラグ = false;
            //ここまで

            this.Close();
        }

        private void タグ表示画面_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 決定_Click(object sender, EventArgs e)
        {
            OperationScreen.tagId = Convert.ToString(タグ表示画面.CurrentRow.Cells[0].Value);

            // //重複起動処理フラグ追加　20240626 山﨑
            OperationScreen.重複処理フラグ = false;
            //ここまで

            this.Close();

        }
    }
}
