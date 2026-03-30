using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace TC_CoilOperation
{
    public partial class Menu : Form
    {
        int 終了フラグ = 0;
       
        //public Operation_Screen formMain;

        public Menu()
        {
           
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((MainScreen)Application.OpenForms["MainScreen"]).formChange(3);
        }

        private void button1_Click(object sender, EventArgs e)
        {

           ((MainScreen)Application.OpenForms["MainScreen"]).formChange(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((MainScreen)Application.OpenForms["MainScreen"]).formChange(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //終了するかの確認
            DialogResult result = MessageBox.Show("本当に終了しますか？","質問",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                ((MainScreen)Application.OpenForms["MainScreen"]).formChange(0);
                OperationScreen.lazerflag = true;
                Close.Enabled=true;






                //((MainScreen)Application.OpenForms["MainScreen"]).System_log("終了", "1", "アプリ", "main");
                //Application.Exit();


            }
            
        }

        private void Close_Tick(object sender, EventArgs e)
        {
            Close.Stop();
            if (OperationScreen.lazerCloseflag == true)
            {


                OperationScreen.X_serialPort.Close();
                OperationScreen.X_serialPort.Dispose();
                OperationScreen.Y_serialPort.Close();
                OperationScreen.Y_serialPort.Dispose();
                OperationScreen.Z_serialPort.Close();
                OperationScreen.Z_serialPort.Dispose();


                ((MainScreen)Application.OpenForms["MainScreen"]).System_log("終了", "1", "アプリ", "main");
                Application.Exit();
            }
            else if (終了フラグ == 5)
            {
                ((MainScreen)Application.OpenForms["MainScreen"]).System_log("強制終了", "1", "アプリ", "main");
                Application.Exit();
                Process.Start(Properties.Settings.Default.Shutdownpass, "/s /f /t 0");
            }
            else 終了フラグ++;
            Close.Start();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
