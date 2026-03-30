namespace TC_CoilOperation
{
    partial class MachineCheck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Check = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IO4value = new System.Windows.Forms.Label();
            this.Yvalue = new System.Windows.Forms.Label();
            this.IO3value = new System.Windows.Forms.Label();
            this.Zvalue = new System.Windows.Forms.Label();
            this.Xvalue = new System.Windows.Forms.Label();
            this.IO4 = new System.Windows.Forms.Label();
            this.IO3 = new System.Windows.Forms.Label();
            this.ZCheck3 = new System.Windows.Forms.Label();
            this.YCheck3 = new System.Windows.Forms.Label();
            this.XCheck3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MachineCheckList = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.IO2 = new System.Windows.Forms.Label();
            this.RFID2 = new System.Windows.Forms.Label();
            this.ZCheck2 = new System.Windows.Forms.Label();
            this.YCheck2 = new System.Windows.Forms.Label();
            this.XCheck2 = new System.Windows.Forms.Label();
            this.IO1 = new System.Windows.Forms.Label();
            this.RFID1 = new System.Windows.Forms.Label();
            this.ZCheck1 = new System.Windows.Forms.Label();
            this.YCheck1 = new System.Windows.Forms.Label();
            this.XCheck1 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Check.Location = new System.Drawing.Point(538, 584);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(256, 77);
            this.Check.TabIndex = 7;
            this.Check.Text = "機器チェック";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.button1_Click);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Back.Location = new System.Drawing.Point(822, 584);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(166, 77);
            this.Back.TabIndex = 6;
            this.Back.Text = "戻る";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.MachineCheckList);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(24, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 547);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "機器状況";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IO4value);
            this.groupBox3.Controls.Add(this.Yvalue);
            this.groupBox3.Controls.Add(this.IO3value);
            this.groupBox3.Controls.Add(this.Zvalue);
            this.groupBox3.Controls.Add(this.Xvalue);
            this.groupBox3.Controls.Add(this.IO4);
            this.groupBox3.Controls.Add(this.IO3);
            this.groupBox3.Controls.Add(this.ZCheck3);
            this.groupBox3.Controls.Add(this.YCheck3);
            this.groupBox3.Controls.Add(this.XCheck3);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(698, 32);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 236);
            this.groupBox3.TabIndex = 23;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "データ";
            // 
            // IO4value
            // 
            this.IO4value.AutoSize = true;
            this.IO4value.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO4value.Location = new System.Drawing.Point(138, 190);
            this.IO4value.Name = "IO4value";
            this.IO4value.Size = new System.Drawing.Size(40, 23);
            this.IO4value.TabIndex = 57;
            this.IO4value.Text = "XXX";
            // 
            // Yvalue
            // 
            this.Yvalue.AutoSize = true;
            this.Yvalue.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Yvalue.Location = new System.Drawing.Point(138, 71);
            this.Yvalue.Name = "Yvalue";
            this.Yvalue.Size = new System.Drawing.Size(40, 23);
            this.Yvalue.TabIndex = 56;
            this.Yvalue.Text = "XXX";
            this.Yvalue.Click += new System.EventHandler(this.label42_Click);
            // 
            // IO3value
            // 
            this.IO3value.AutoSize = true;
            this.IO3value.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO3value.Location = new System.Drawing.Point(138, 156);
            this.IO3value.Name = "IO3value";
            this.IO3value.Size = new System.Drawing.Size(40, 23);
            this.IO3value.TabIndex = 55;
            this.IO3value.Text = "XXX";
            // 
            // Zvalue
            // 
            this.Zvalue.AutoSize = true;
            this.Zvalue.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Zvalue.Location = new System.Drawing.Point(138, 116);
            this.Zvalue.Name = "Zvalue";
            this.Zvalue.Size = new System.Drawing.Size(40, 23);
            this.Zvalue.TabIndex = 53;
            this.Zvalue.Text = "XXX";
            this.Zvalue.Click += new System.EventHandler(this.label39_Click);
            // 
            // Xvalue
            // 
            this.Xvalue.AutoSize = true;
            this.Xvalue.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Xvalue.Location = new System.Drawing.Point(138, 26);
            this.Xvalue.Name = "Xvalue";
            this.Xvalue.Size = new System.Drawing.Size(40, 23);
            this.Xvalue.TabIndex = 52;
            this.Xvalue.Text = "XXX";
            this.Xvalue.Click += new System.EventHandler(this.label38_Click);
            // 
            // IO4
            // 
            this.IO4.AutoSize = true;
            this.IO4.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO4.Location = new System.Drawing.Point(62, 190);
            this.IO4.Name = "IO4";
            this.IO4.Size = new System.Drawing.Size(30, 23);
            this.IO4.TabIndex = 51;
            this.IO4.Text = "XX";
            // 
            // IO3
            // 
            this.IO3.AutoSize = true;
            this.IO3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO3.Location = new System.Drawing.Point(62, 156);
            this.IO3.Name = "IO3";
            this.IO3.Size = new System.Drawing.Size(30, 23);
            this.IO3.TabIndex = 50;
            this.IO3.Text = "XX";
            this.IO3.Click += new System.EventHandler(this.label36_Click);
            // 
            // ZCheck3
            // 
            this.ZCheck3.AutoSize = true;
            this.ZCheck3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZCheck3.Location = new System.Drawing.Point(62, 117);
            this.ZCheck3.Name = "ZCheck3";
            this.ZCheck3.Size = new System.Drawing.Size(30, 23);
            this.ZCheck3.TabIndex = 48;
            this.ZCheck3.Text = "XX";
            this.ZCheck3.Click += new System.EventHandler(this.label34_Click);
            // 
            // YCheck3
            // 
            this.YCheck3.AutoSize = true;
            this.YCheck3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.YCheck3.Location = new System.Drawing.Point(62, 71);
            this.YCheck3.Name = "YCheck3";
            this.YCheck3.Size = new System.Drawing.Size(30, 23);
            this.YCheck3.TabIndex = 47;
            this.YCheck3.Text = "XX";
            this.YCheck3.Click += new System.EventHandler(this.label33_Click);
            // 
            // XCheck3
            // 
            this.XCheck3.AutoSize = true;
            this.XCheck3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.XCheck3.Location = new System.Drawing.Point(62, 26);
            this.XCheck3.Name = "XCheck3";
            this.XCheck3.Size = new System.Drawing.Size(30, 23);
            this.XCheck3.TabIndex = 46;
            this.XCheck3.Text = "XX";
            this.XCheck3.Click += new System.EventHandler(this.label32_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(8, 171);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 23);
            this.label7.TabIndex = 10;
            this.label7.Text = "信号";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(8, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Z軸";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(8, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Y軸";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(8, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "X軸";
            // 
            // MachineCheckList
            // 
            this.MachineCheckList.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.MachineCheckList.FormattingEnabled = true;
            this.MachineCheckList.ItemHeight = 31;
            this.MachineCheckList.Location = new System.Drawing.Point(6, 295);
            this.MachineCheckList.Name = "MachineCheckList";
            this.MachineCheckList.Size = new System.Drawing.Size(958, 252);
            this.MachineCheckList.TabIndex = 23;
            this.MachineCheckList.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IO2);
            this.groupBox2.Controls.Add(this.RFID2);
            this.groupBox2.Controls.Add(this.ZCheck2);
            this.groupBox2.Controls.Add(this.YCheck2);
            this.groupBox2.Controls.Add(this.XCheck2);
            this.groupBox2.Controls.Add(this.IO1);
            this.groupBox2.Controls.Add(this.RFID1);
            this.groupBox2.Controls.Add(this.ZCheck1);
            this.groupBox2.Controls.Add(this.YCheck1);
            this.groupBox2.Controls.Add(this.XCheck1);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(6, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(686, 241);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接続";
            // 
            // IO2
            // 
            this.IO2.AutoSize = true;
            this.IO2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO2.Location = new System.Drawing.Point(472, 192);
            this.IO2.Name = "IO2";
            this.IO2.Size = new System.Drawing.Size(30, 23);
            this.IO2.TabIndex = 45;
            this.IO2.Text = "XX";
            this.IO2.Click += new System.EventHandler(this.label31_Click);
            // 
            // RFID2
            // 
            this.RFID2.AutoSize = true;
            this.RFID2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RFID2.Location = new System.Drawing.Point(472, 150);
            this.RFID2.Name = "RFID2";
            this.RFID2.Size = new System.Drawing.Size(30, 23);
            this.RFID2.TabIndex = 44;
            this.RFID2.Text = "XX";
            this.RFID2.Click += new System.EventHandler(this.label30_Click);
            // 
            // ZCheck2
            // 
            this.ZCheck2.AutoSize = true;
            this.ZCheck2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZCheck2.Location = new System.Drawing.Point(472, 109);
            this.ZCheck2.Name = "ZCheck2";
            this.ZCheck2.Size = new System.Drawing.Size(30, 23);
            this.ZCheck2.TabIndex = 43;
            this.ZCheck2.Text = "XX";
            this.ZCheck2.Click += new System.EventHandler(this.label29_Click);
            // 
            // YCheck2
            // 
            this.YCheck2.AutoSize = true;
            this.YCheck2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.YCheck2.Location = new System.Drawing.Point(472, 69);
            this.YCheck2.Name = "YCheck2";
            this.YCheck2.Size = new System.Drawing.Size(30, 23);
            this.YCheck2.TabIndex = 42;
            this.YCheck2.Text = "XX";
            this.YCheck2.Click += new System.EventHandler(this.label28_Click);
            // 
            // XCheck2
            // 
            this.XCheck2.AutoSize = true;
            this.XCheck2.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.XCheck2.Location = new System.Drawing.Point(472, 29);
            this.XCheck2.Name = "XCheck2";
            this.XCheck2.Size = new System.Drawing.Size(30, 23);
            this.XCheck2.TabIndex = 41;
            this.XCheck2.Text = "XX";
            this.XCheck2.Click += new System.EventHandler(this.label27_Click);
            // 
            // IO1
            // 
            this.IO1.AutoSize = true;
            this.IO1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IO1.Location = new System.Drawing.Point(117, 192);
            this.IO1.Name = "IO1";
            this.IO1.Size = new System.Drawing.Size(30, 23);
            this.IO1.TabIndex = 40;
            this.IO1.Text = "XX";
            this.IO1.Click += new System.EventHandler(this.label26_Click);
            // 
            // RFID1
            // 
            this.RFID1.AutoSize = true;
            this.RFID1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.RFID1.Location = new System.Drawing.Point(117, 150);
            this.RFID1.Name = "RFID1";
            this.RFID1.Size = new System.Drawing.Size(30, 23);
            this.RFID1.TabIndex = 39;
            this.RFID1.Text = "XX";
            this.RFID1.Click += new System.EventHandler(this.label25_Click);
            // 
            // ZCheck1
            // 
            this.ZCheck1.AutoSize = true;
            this.ZCheck1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ZCheck1.Location = new System.Drawing.Point(117, 109);
            this.ZCheck1.Name = "ZCheck1";
            this.ZCheck1.Size = new System.Drawing.Size(30, 23);
            this.ZCheck1.TabIndex = 38;
            this.ZCheck1.Text = "XX";
            this.ZCheck1.Click += new System.EventHandler(this.label24_Click);
            // 
            // YCheck1
            // 
            this.YCheck1.AutoSize = true;
            this.YCheck1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.YCheck1.Location = new System.Drawing.Point(117, 69);
            this.YCheck1.Name = "YCheck1";
            this.YCheck1.Size = new System.Drawing.Size(30, 23);
            this.YCheck1.TabIndex = 37;
            this.YCheck1.Text = "XX";
            this.YCheck1.Click += new System.EventHandler(this.label17_Click);
            // 
            // XCheck1
            // 
            this.XCheck1.AutoSize = true;
            this.XCheck1.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.XCheck1.Location = new System.Drawing.Point(117, 29);
            this.XCheck1.Name = "XCheck1";
            this.XCheck1.Size = new System.Drawing.Size(30, 23);
            this.XCheck1.TabIndex = 36;
            this.XCheck1.Text = "XX";
            this.XCheck1.Click += new System.EventHandler(this.label15_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(176, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(319, 23);
            this.label19.TabIndex = 35;
            this.label19.Text = "--                   RFID(ping)                     --";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label21.Location = new System.Drawing.Point(536, 192);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 23);
            this.label21.TabIndex = 33;
            this.label21.Text = "--DIモジュール";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label22.Location = new System.Drawing.Point(177, 192);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(275, 23);
            this.label22.TabIndex = 32;
            this.label22.Text = "--         DIモジュール用CPU           --";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label23.Location = new System.Drawing.Point(8, 192);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(84, 23);
            this.label23.TabIndex = 31;
            this.label23.Text = "管理端末--";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.Location = new System.Drawing.Point(536, 150);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(118, 23);
            this.label18.TabIndex = 28;
            this.label18.Text = "--RFID(status)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(8, 150);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 23);
            this.label20.TabIndex = 26;
            this.label20.Text = "管理端末--";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.Location = new System.Drawing.Point(536, 109);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(124, 23);
            this.label12.TabIndex = 18;
            this.label12.Text = "--距離計（Z軸）";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.Location = new System.Drawing.Point(176, 109);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(275, 23);
            this.label13.TabIndex = 17;
            this.label13.Text = "--RS422メディアコンバータ（Z軸）--";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.Location = new System.Drawing.Point(8, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 23);
            this.label14.TabIndex = 16;
            this.label14.Text = "管理端末--";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(536, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "--距離計（Y軸）";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.Location = new System.Drawing.Point(177, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(274, 23);
            this.label10.TabIndex = 12;
            this.label10.Text = "--RS422メディアコンバータ（Y軸）--";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.Location = new System.Drawing.Point(8, 69);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(84, 23);
            this.label11.TabIndex = 11;
            this.label11.Text = "管理端末--";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(536, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 23);
            this.label5.TabIndex = 8;
            this.label5.Text = "--距離計（X軸）";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(177, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(275, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "--RS422メディアコンバータ（X軸）--";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(8, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "管理端末--";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // MachineCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.ControlBox = false;
            this.Controls.Add(this.Check);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(-10, -20);
            this.Name = "MachineCheck";
            this.Load += new System.EventHandler(this.MachineCheck_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label IO4value;
        private System.Windows.Forms.Label Yvalue;
        private System.Windows.Forms.Label IO3value;
        private System.Windows.Forms.Label Zvalue;
        private System.Windows.Forms.Label Xvalue;
        private System.Windows.Forms.Label IO4;
        private System.Windows.Forms.Label IO3;
        private System.Windows.Forms.Label ZCheck3;
        private System.Windows.Forms.Label YCheck3;
        private System.Windows.Forms.Label XCheck3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox MachineCheckList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label IO2;
        private System.Windows.Forms.Label RFID2;
        private System.Windows.Forms.Label ZCheck2;
        private System.Windows.Forms.Label YCheck2;
        private System.Windows.Forms.Label XCheck2;
        private System.Windows.Forms.Label IO1;
        private System.Windows.Forms.Label RFID1;
        private System.Windows.Forms.Label ZCheck1;
        private System.Windows.Forms.Label YCheck1;
        private System.Windows.Forms.Label XCheck1;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}