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
    public partial class フリーエリア_確認画面 : Form
    {
        public bool 選択フラグ=false;
        public フリーエリア_確認画面()
        {
            InitializeComponent();
            if(OperationScreen.Location_z == "1")
            {
                button3.BackColor = Color.SkyBlue;
            }
            else if (OperationScreen.Location_z == "2")
            {
                button2.BackColor = Color.SkyBlue;
            }
            else if (OperationScreen.Location_z == "3")
            {
                button1.BackColor = Color.SkyBlue;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.SkyBlue;
            button2.BackColor = Color.White;
            button1.BackColor = Color.White;
            MainScreen.段数 = "1";
            選択フラグ = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackColor = Color.SkyBlue;
            button1.BackColor = Color.White;
            button3.BackColor = Color.White;
            MainScreen.段数 = "2";
            選択フラグ = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.BackColor = Color.SkyBlue;
            button2.BackColor = Color.White;
            button3.BackColor = Color.White;
            MainScreen.段数 = "3";
            選択フラグ = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (選択フラグ == false)
            {
                MainScreen.段数 = "1";
            }

            this.Close();
        }

        private void フリーエリア_確認画面_Load(object sender, EventArgs e)
        {

        }
    }
}
