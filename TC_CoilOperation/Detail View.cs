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
    public partial class Detail_View : Form
    {
        public static decimal SelectX = 0;
        public static bool CFlag = false;
        List<coil> button = new List<coil>();
        List<Graphics> Circle1 = new List<Graphics>();
        List<SolidBrush> Circle2 = new List<SolidBrush>();
        List<Rectangle> Circle3 = new List<Rectangle>();
        string test = "";
        static public string select_retu = "";
        static public string select_ren = "";
        static public string select_dan = "";
        public void Addcoil(int ren, int dan, double weight, string genpin, string tag, string kikaku, string sunpou, string syuko, string tumikomi, string mokuhyou)
        {
            if (tumikomi == "" || syuko=="") 
            {
                if (dan == 1)
                {

                    coil f = new coil();
                    f.Name = ren + "-" + dan;
                    f.zyuuryou = Convert.ToString(weight);
                    f.genpin = genpin;
                    f.tag = tag;
                    f.kikaku = kikaku;
                    f.sunpou = sunpou;
                    f.retu = Convert.ToString(SelectX);
                    f.ren = Convert.ToString(ren);
                    f.dan = Convert.ToString(dan);
                    f.Location = new Point((ren - 1) * 57 + 30, 173);
                    f.button1.Text = Convert.ToString(weight);
                    button.Add(f);
                    pictureBox1.Controls.Add(f);
                    f.Show();
                    if (mokuhyou == "1")
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.Red);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);

                    }
                    else {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);
                    }
                }
                if (dan == 2)
                {
                    coil f = new coil();
                    f.Name = ren + "-" + dan;
                    f.zyuuryou = Convert.ToString(weight);
                    f.genpin = genpin;
                    f.tag = tag;
                    f.kikaku = kikaku;
                    f.sunpou = sunpou;
                    f.retu = Convert.ToString(SelectX);
                    f.ren = Convert.ToString(ren);
                    f.dan = Convert.ToString(dan);
                    f.Location = new Point((ren - 1) * 57 + 63, 123);
                    f.button1.Text = Convert.ToString(weight);
                    button.Add(f);
                    pictureBox1.Controls.Add(f);
                    f.Show();
                    if (mokuhyou == "1")
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.Red);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);
                    }
                    else
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);
                    }
                }
                if (dan == 3)
                {
                    coil f = new coil();
                    f.Name = ren + "-" + dan;
                    f.zyuuryou = Convert.ToString(weight);
                    f.genpin = genpin;
                    f.tag = tag;
                    f.kikaku = kikaku;
                    f.sunpou = sunpou;
                    f.retu = Convert.ToString(SelectX);
                    f.ren = Convert.ToString(ren);
                    f.dan = Convert.ToString(dan);
                    f.Location = new Point((ren - 1) * 57 + 93, 73);
                    f.button1.Text = Convert.ToString(weight);
                    button.Add(f);
                    pictureBox1.Controls.Add(f);
                    f.Show();
                    if (mokuhyou == "1")
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.Red);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);
                    }
                    else
                    {
                        Graphics g = pictureBox1.CreateGraphics();
                        SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                        Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                        g.FillEllipse(GreenBrush, rect6);
                        Circle1.Add(g);
                        Circle2.Add(GreenBrush);
                        Circle3.Add(rect6);
                    }

                }
                return;
                }
            syuko = syuko.Insert(4, "/");
            syuko = syuko.Insert(7, "/");
            tumikomi = tumikomi.Insert(4, "/");
            tumikomi = tumikomi.Insert(7, "/");
            if (dan == 1)
            {
                coil f = new coil();
                f.Name = ren + "-" + dan;
                f.zyuuryou = Convert.ToString(weight);
                f.genpin = genpin;
                f.tag = tag;
                f.kikaku = kikaku;
                f.sunpou = sunpou;
                f.syuko = syuko;
                f.tumikomi = tumikomi;
                f.retu = Convert.ToString(SelectX);
                f.ren = Convert.ToString(ren);
                f.dan = Convert.ToString(dan);
                f.Location = new Point((ren - 1) * 57 + 30, 173);
                f.button1.Text = Convert.ToString(weight);
                button.Add(f);
                pictureBox1.Controls.Add(f);


                f.Show();

                if (mokuhyou == "1")
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Red);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);

                }
                else if (Convert.ToDateTime(tumikomi) <= OperationScreen.dateTime)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else if (Convert.ToDateTime(tumikomi) == OperationScreen.dateTime.AddDays(1))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.LightGreen);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 30, 155, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }

            }

            if (dan == 2)
            {
                coil f = new coil();
                f.Name = ren + "-" + dan;
                f.zyuuryou = Convert.ToString(weight);
                f.genpin = genpin;
                f.tag = tag;
                f.kikaku = kikaku;
                f.sunpou = sunpou;
                f.syuko = syuko;
                f.tumikomi = tumikomi;
                f.Location = new Point((ren - 1) * 57 + 63, 123);
                f.button1.Text = Convert.ToString(weight);
                button.Add(f);
                pictureBox1.Controls.Add(f);
                f.Show();

                if (mokuhyou == "1")
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Red);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else if (Convert.ToDateTime(tumikomi) <= OperationScreen.dateTime)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else if (Convert.ToDateTime(tumikomi) == OperationScreen.dateTime.AddDays(1))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.LightGreen);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 63, 105, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
            }
            if (dan == 3)
            {
                coil f = new coil();
                f.Name = ren + "-" + dan;
                f.zyuuryou = Convert.ToString(weight);
                f.genpin = genpin;
                f.tag = tag;
                f.kikaku = kikaku;
                f.sunpou = sunpou;
                f.syuko = syuko;
                f.tumikomi = tumikomi;
                f.Location = new Point((ren - 1) * 57 + 93, 73);
                f.button1.Text = Convert.ToString(weight);
                button.Add(f);
                pictureBox1.Controls.Add(f);
                f.Show();

                if (mokuhyou == "1")
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Red);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else if (Convert.ToDateTime(tumikomi) <= OperationScreen.dateTime)
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else if (Convert.ToDateTime(tumikomi) == OperationScreen.dateTime.AddDays(1))
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.LightGreen);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }
                else
                {
                    Graphics g = pictureBox1.CreateGraphics();
                    SolidBrush GreenBrush = new SolidBrush(Color.SkyBlue);
                    Rectangle rect6 = new Rectangle((ren - 1) * 57 + 93, 58, 50, 50);
                    g.FillEllipse(GreenBrush, rect6);
                    Circle1.Add(g);
                    Circle2.Add(GreenBrush);
                    Circle3.Add(rect6);
                }


            }

            //if (dan == 1)
            //{
            //    if (ren == 1)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(27, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(22, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 2)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(96, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(91, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 3)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(165, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(160, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 4)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(235, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(230, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 5)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(305, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(298, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 6)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(374, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(367, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 7)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(443, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(436, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 8)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(512, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(505, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 9)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(581, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(574, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 10)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(650, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(643, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 11)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(719, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(712, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 12)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(788, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(782, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 13)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(857, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(850, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 14)
            //    {
            //        coil f = new coil();
            //        f.Name = ren + "-" + dan;
            //        f.Location = new Point(926, 188);
            //        f.button1.Text = Convert.ToString(weight);
            //        pictureBox1.Controls.Add(f);
            //        f.Show();

            //        Graphics g = pictureBox1.CreateGraphics();
            //        SolidBrush GreenBrush = new SolidBrush(Color.Yellow);
            //        Rectangle rect6 = new Rectangle(919, 172, 55, 55);
            //        g.FillEllipse(GreenBrush, rect6);
            //    }
            //    if (ren == 15)
            //    {

            //    }
            //}
        }
        public Detail_View()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void coil_Yellow1_Load(object sender, EventArgs e)
        {

        }

        private void coil_Blue2_Load(object sender, EventArgs e)
        {
            label1.Text = "5";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tag.Text != string.Empty)
            {
                if(OperationScreen.Targetcoil == tag.Text)
                {
                    OperationScreen.Targetcoil = "";
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(19);//目標コイル更新
                    ((Detail_View)Application.OpenForms["Detail_View"]).Allclear();
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(11);//コイル詳細表示
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);//目標座標取得
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(18);//目標コイル取得
                }
                else
                {
                    OperationScreen.Targetcoil = tag.Text;



                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(12);//目標コイル設定
                    ((Detail_View)Application.OpenForms["Detail_View"]).Allclear();
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(11);//コイル詳細表示
                    ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(13);//目標座標取得
                }
                
                
            }





        }
        public void Allclear()
        {

            for (int i = 0; i < button.Count; i++)
            {
                pictureBox1.Controls.Remove(button[i]);
            }
            pictureBox1.Refresh();
            //pictureBox1.Invalidate();
        }
        public void syousai(string cgenpin, string ctag, string ckikaku, string csunnpou, string czyuryou, string csyuko, string ctumikomi)
        {
            genpin.Text = cgenpin;
            tag.Text = ctag;
            kikaku.Text = ckikaku;
            sunpou.Text = csunnpou;
            zyuryou.Text = czyuryou;
            syuko.Text = csyuko;
            tumikomi.Text = ctumikomi;
        }
        private void Detail_View_Load(object sender, EventArgs e)
        {
           // timer1.Start();
        }

        private void Detail_View_Shown(object sender, EventArgs e)
        {
            
            
        }

        public void view()
        {
            ColNo.Value = Convert.ToDecimal(SelectX);
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(11);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            
           

            ColNo.Value = Convert.ToDecimal(SelectX);
            ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(11);
           
            timer1.Stop();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            if (CFlag == true)
            {
                SelectX = Convert.ToDecimal(ColNo.Value);
                //表示内容を全クリア
                ((Detail_View)Application.OpenForms["Detail_View"]).Allclear();
                genpin.Text ="";
                tag.Text = "";
                kikaku.Text = "";
                sunpou.Text = "";
                zyuryou.Text = "";
                syuko.Text = "";
                tumikomi.Text = "";
                ((MainScreen)Application.OpenForms["MainScreen"]).OracleDBsql(11);
            }
            CFlag = true;

        }

        private void Coil_Syousai_Enter(object sender, EventArgs e)
        {

        }

        private void genpin_Click(object sender, EventArgs e)
        {

        }

        private void tag_Click(object sender, EventArgs e)
        {

        }

        private void Coil_Syousai_Enter_1(object sender, EventArgs e)
        {

        }
    }
}
