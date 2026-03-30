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
    public partial class Lbl_Col_No : UserControl
    {
        public Lbl_Col_No()
        {
            InitializeComponent();
            

        }
        public string colNo;
        
        public string ColNo
        {
            
            set { colNo = value; }
            get { return colNo; }
        }

        private void lbl_Col_Click(object sender, EventArgs e)
        {
            this.lbl_Col.Text = colNo;
        }

        private void Lbl_Col_No_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}
