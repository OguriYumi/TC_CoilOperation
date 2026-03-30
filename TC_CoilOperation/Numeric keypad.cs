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
    public partial class Numeric_keypad : Form
    {

        bool flag = false;
        public Numeric_keypad()
        {
            InitializeComponent();
        }

        private void Numeric_keypad_Load(object sender, EventArgs e)
        {
            Show_Num.Text = Properties.Settings.Default.BackNum;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            double Num = Convert.ToDouble(Show_Num.Text);
            if (flag == true)
            {
                Num = Num * -1;
            }
            Properties.Settings.Default.BackNum = Convert.ToString(Num);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "1";
            }
            else
            {
                Show_Num.Text += "1";
            }
        }

        private void insert10_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {

            }
            else { Show_Num.Text += "0"; }
            
        }

        private void insert2_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "2";
            }
            else
            {
                Show_Num.Text += "2";
            }
        }

        private void insert3_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "3";
            }
            else
            {
                Show_Num.Text += "3";
            }
        }

        private void insert4_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "4";
            }
            else
            {
                Show_Num.Text += "4";
            }
        }

        private void insert5_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "5";
            }
            else
            {
                Show_Num.Text += "5";
            }
        }

        private void insert6_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "6";
            }
            else
            {
                Show_Num.Text += "6";
            }
        }

        private void insert7_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "7";
            }
            else
            {
                Show_Num.Text += "7";
            }
        }

        private void insert8_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "8";
            }
            else
            {
                Show_Num.Text += "8";
            }
        }

        private void insert9_Click(object sender, EventArgs e)
        {
            if (Show_Num.Text.Length == 1 && Show_Num.Text == "0")
            {
                Show_Num.Text = "9";
            }
            else
            {
                Show_Num.Text += "9";
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            Show_Num.Text = "0";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (flag == true)
            {
                flag = false;
                minus.ForeColor = Color.Black;
            }
            else if (flag == false)
            {
              flag=true  ;
              minus.ForeColor= Color.Red;

            }
        }
    }
}
