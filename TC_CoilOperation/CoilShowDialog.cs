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
    public partial class CoilShowDialog : Form
    {
        public CoilShowDialog()
        {
            InitializeComponent();
        }

        private void CoilShowDialog_Load(object sender, EventArgs e)
        {
            ShowMSG.Text = OperationScreen.ShowMSG;
            tagname.Text = OperationScreen.tagname[0];
            現在ロケ.Text = OperationScreen.Clocation;
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(22);
            if (OperationScreen.coilloc == "0-0-0")
            {
                登録ロケ.Text = "ロケ情報なし";
            }
            else
            {
                登録ロケ.Text = OperationScreen.coilloc;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OperationScreen.tagId = Convert.ToString(tagname.Text);
            // //重複起動処理フラグ追加　20240626 山﨑
            OperationScreen.重複処理フラグ = false;
            //ここまで
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OperationScreen.tagId = "-";
            // //重複起動処理フラグ追加　20240626 山﨑
            OperationScreen.重複処理フラグ = false;
            //ここまで
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
