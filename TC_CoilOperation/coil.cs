using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TC_CoilOperation
{
    public partial class coil : UserControl
    {
        public string genpin="";
        public string tag = "";
        public string kikaku = "";
        public string sunpou = "";
        public string zyuuryou = "";
        public string syuko = "";
        public string tumikomi = "";
        public string retu = "";
        public string ren = "";
        public string dan = "";
        public coil()
        {
            InitializeComponent();
            //Graphics g = this.CreateGraphics();
            //SolidBrush GreenBrush = new SolidBrush(Color.Green);
            //Rectangle rect6 = new Rectangle(0, 0, 100, 100);
            //g.FillEllipse(GreenBrush, rect6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //syuko = syuko.Insert(4, ":");
            //syuko = syuko.Insert(7, ":");
            //tumikomi = tumikomi.Insert(4, ":");
            //tumikomi = tumikomi.Insert(7, ":");
            //((Detail_View)Application.OpenForms["Detail_View"]).syousai(genpin, tag, kikaku, sunpou, zyuuryou, syuko,tumikomi);
        }

        private void Red_coil_Load(object sender, EventArgs e)
        {
            //button1.SetBounds(button1.Left,button1.Top, 10,10,
            //       BoundsSpecified.Size);
            //System.Drawing.Drawing2D.GraphicsPath path =
            //    new System.Drawing.Drawing2D.GraphicsPath();
            ////丸を描く
            //path.AddEllipse(new Rectangle(10, 10, 10, 10));
            ////真ん中を丸くくりぬく
            //path.AddEllipse(new Rectangle(10, 10, 10, 10));
            //button1.Region = new Region(path);
            //button1.Text = "";


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Graphics g = this.CreateGraphics();
            //SolidBrush GreenBrush = new SolidBrush(Color.Green);
            //Rectangle rect6 = new Rectangle(0, 0, 100, 100);
            //g.FillEllipse(GreenBrush, rect6);
            //syuko = syuko.Insert(4, ":");
            //syuko = syuko.Insert(7, ":");
            //tumikomi = tumikomi.Insert(4, ":");
            //tumikomi = tumikomi.Insert(7, ":");
            string kg_zyuuryou = "";
            if (zyuuryou != string.Empty)
            {
                int kg = Convert.ToInt32(zyuuryou);
                 kg_zyuuryou = String.Format("{0:#,0}", kg);
            }
            
            ((Detail_View)Application.OpenForms["Detail_View"]).syousai(genpin, tag, kikaku, sunpou, kg_zyuuryou, syuko, tumikomi);
            Detail_View.select_dan = dan;
            Detail_View.select_ren = ren;
            Detail_View.select_retu = retu;
        }
    }
}
