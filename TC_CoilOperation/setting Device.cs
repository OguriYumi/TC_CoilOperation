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
    public partial class setting_Device : Form
    {
        public string backNum { get; set; }
        public setting_Device()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Valueset();
            ((MainScreen)Application.OpenForms["MainScreen"]).formChange(1);
        }

        private void setting_Device_Load(object sender, EventArgs e)
        {
            Valueset();

            
        }
        void Valueset()
        {
            IV_X.Value = Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_X);
            IV_Y.Value = Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_Y);
            IV_Z.Value = Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_Z);

            OffS_X.Value = Convert.ToDecimal(Properties.Settings.Default.Offset_Value_X);
            OffS_Y.Value = Convert.ToDecimal(Properties.Settings.Default.Offset_Value_Y);
            OffS_Z.Value = Convert.ToDecimal(Properties.Settings.Default.Offset_Value_Z);

            LSI.Value = Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_Interval);
            LSON.Value = Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_ON_Judgment);
            LSOFF.Value = Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_OFF_Judgment);
            if (Properties.Settings.Default.Lifter_Manualmode == true) { LM.Checked = true; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //各入力値の値チェック（必要？）
            //入力値を設定ファイルに保存
            //Xの反転値
            Properties.Settings.Default.Inverted_Value_X= Convert.ToDouble(IV_X.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸反転値:"+ Convert.ToDouble(IV_X.Value), "0", "距離計設定", "main");
            //Xのオフセット
            Properties.Settings.Default.Offset_Value_X = Convert.ToDouble(OffS_X.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("X軸オフセット値:" + Convert.ToDouble(OffS_X.Value), "0", "距離計設定", "main");
            //入力値を設定ファイルに保存
            //Yの反転値
            Properties.Settings.Default.Inverted_Value_Y = Convert.ToDouble(IV_Y.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸反転値:" + Convert.ToDouble(IV_Y.Value), "0", "距離計設定", "main");
            //Yのオフセット
            Properties.Settings.Default.Offset_Value_Y = Convert.ToDouble(OffS_Y.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Y軸オフセット値:" + Convert.ToDouble(OffS_Y.Value), "0", "距離計設定", "main");
            //入力値を設定ファイルに保存
            //Zの反転値
            Properties.Settings.Default.Inverted_Value_Z = Convert.ToDouble(IV_Z.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸反転値:" + Convert.ToDouble(IV_Z.Value), "0", "距離計設定", "main");
            //Zのオフセット
            Properties.Settings.Default.Offset_Value_Z = Convert.ToDouble(OffS_Z.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("Z軸オフセット値:" + Convert.ToDouble(OffS_Z.Value), "0", "距離計設定", "main");
            //リフターインターバル
            Properties.Settings.Default.Lifter_Signal_Interval = Convert.ToInt32(LSI.Value);
           
            //リフタON信号判定回数
            Properties.Settings.Default.Lifter_Signal_ON_Judgment = Convert.ToInt32(LSON.Value);
            //リフタOFF信号判定回数
            Properties.Settings.Default.Lifter_Signal_OFF_Judgment = Convert.ToInt32(LSOFF.Value);
            ((MainScreen)Application.OpenForms["MainScreen"]).System_log("リフターインターバル:" + Convert.ToInt32(LSI.Value) + " ON判定:"+ Convert.ToInt32(LSON.Value)+ " OFF判定:"+ Convert.ToInt32(LSOFF.Value), "0", "リフター設定", "main");
            //リフター手動モード
            if (LM.Checked == true)
            {
                Properties.Settings.Default.Lifter_Manualmode = true;
                ((MainScreen)Application.OpenForms["MainScreen"]).System_log("リフター手動モード:ON" , "0", "リフターモード設定", "main");
            }
            else
            {
                Properties.Settings.Default.Lifter_Manualmode = false;
                ((MainScreen)Application.OpenForms["MainScreen"]).System_log("リフター手動モード:OFF", "0", "リフターモード設定", "main");
            }

            Properties.Settings.Default.Save();
            //MainScreen.Show_msg.Text = "機器設定が無事完了しました";
            ((MainScreen)Application.OpenForms["MainScreen"]).Show_Message(1);
           
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void Value_num(string value)
        {
            Numeric_keypad f = new Numeric_keypad();
            Properties.Settings.Default.BackNum = value;
            f.ShowDialog();
           
        }

        private void IV_X_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if( c.Equals(Cursors.Arrow)){
                OffS_X.Value = 0;
                return;
            }
            Value_num(Convert.ToString(IV_X.Value));
            try
            {
                IV_X.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                OffS_X.Value = 0;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
            //if (Convert.ToDecimal(IV_X.Maximum) <= Convert.ToDecimal(Properties.Settings.Default.BackNum) && Convert.ToDecimal(IV_X.Minimum) >= Convert.ToDecimal(Properties.Settings.Default.BackNum))
            //{

            //    IV_X.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
            //}
            //else
        }

        private void IV_Y_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
                OffS_Y.Value = 0;
                return;
            }
            Value_num(Convert.ToString(IV_Y.Value));
            try
            {
                IV_Y.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                OffS_Y.Value = 0;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void IV_Z_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
                OffS_Z.Value = 0;
                return;
            }
            Value_num(Convert.ToString(IV_Z.Value));
            try
            {
                IV_Z.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                OffS_Z.Value = 0;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void OffS_X_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
                IV_X.Value = 0;
                return;
            }
            Value_num(Convert.ToString(OffS_X.Value));
            try
            {
                OffS_X.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                IV_X.Value = 0;
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void OffS_Y_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
                IV_Y.Value = 0;
                return;
            }
            Value_num(Convert.ToString(OffS_Y.Value));
            try
            {
                OffS_Y.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                IV_Y.Value = 0;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void OffS_Z_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
                IV_Z.Value = 0;
                return;
            }
            Value_num(Convert.ToString(OffS_Z.Value));
            try
            {
                OffS_Z.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
                IV_Z.Value = 0;
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void LSI_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {
              
                return;
            }
            Value_num(Convert.ToString(LSI.Value));
            try
            {
                LSI.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //IV_X.Value=Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_X) ;
            ////Xのオフセット
            //OffS_X.Value= Convert.ToDecimal(Properties.Settings.Default.Offset_Value_X) ;

            ////入力値を設定ファイルに保存
            ////Yの反転値
            //IV_Y.Value= Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_Y) ;
            ////Yのオフセット
            //OffS_Y.Value=Convert.ToDecimal(Properties.Settings.Default.Offset_Value_Y);

            ////入力値を設定ファイルに保存
            ////Zの反転値
            //IV_Z.Value=Convert.ToDecimal(Properties.Settings.Default.Inverted_Value_Z);
            ////Zのオフセット
            //OffS_Z.Value=Convert.ToDecimal(Properties.Settings.Default.Offset_Value_Z);

            ////リフターインターバル
            //LSI.Value=Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_Interval);
            ////リフタON信号判定回数
            //LSON.Value=Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_ON_Judgment);
            ////リフタOFF信号判定回数
            //LSOFF.Value=Convert.ToDecimal(Properties.Settings.Default.Lifter_Signal_OFF_Judgment);
            ////リフター手動モード
            //LM.Checked = Properties.Settings.Default.Lifter_Manualmode;
            Valueset();
            timer1.Stop();


        }

        private void LSON_Click(object sender, EventArgs e)
        {
            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {

                return;
            }
            Value_num(Convert.ToString(LSON.Value));
            try
            {
                LSON.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
            }
            catch (Exception ex)
            {
               
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void LSOFF_Click(object sender, EventArgs e)
        {

            Cursor c = Cursor.Current;
            if (c.Equals(Cursors.Arrow))
            {

                return;
            }
            Value_num(Convert.ToString(LSOFF.Value));
            try
            {
                LSOFF.Value = Convert.ToDecimal(Properties.Settings.Default.BackNum);
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("入力値が正しくない為設定できませんでした");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
    
    
    
    

