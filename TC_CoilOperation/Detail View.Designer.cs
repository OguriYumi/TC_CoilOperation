namespace TC_CoilOperation
{
    partial class Detail_View
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
            this.targCoil = new System.Windows.Forms.Button();
            this.ColNo = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Back = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Coil_Syousai = new System.Windows.Forms.GroupBox();
            this.tumikomi = new System.Windows.Forms.Label();
            this.syuko = new System.Windows.Forms.Label();
            this.zyuryou = new System.Windows.Forms.Label();
            this.sunpou = new System.Windows.Forms.Label();
            this.kikaku = new System.Windows.Forms.Label();
            this.tag = new System.Windows.Forms.Label();
            this.genpin = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ColNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.Coil_Syousai.SuspendLayout();
            this.SuspendLayout();
            // 
            // targCoil
            // 
            this.targCoil.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.targCoil.Location = new System.Drawing.Point(12, 659);
            this.targCoil.Name = "targCoil";
            this.targCoil.Size = new System.Drawing.Size(169, 58);
            this.targCoil.TabIndex = 73;
            this.targCoil.Text = "目標設定";
            this.targCoil.UseVisualStyleBackColor = true;
            this.targCoil.Click += new System.EventHandler(this.button2_Click);
            // 
            // ColNo
            // 
            this.ColNo.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ColNo.Location = new System.Drawing.Point(162, 22);
            this.ColNo.Maximum = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.ColNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ColNo.Name = "ColNo";
            this.ColNo.Size = new System.Drawing.Size(126, 51);
            this.ColNo.TabIndex = 64;
            this.ColNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColNo.Value = new decimal(new int[] {
            46,
            0,
            0,
            0});
            this.ColNo.ValueChanged += new System.EventHandler(this.numericUpDown9_ValueChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("メイリオ", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label19.Location = new System.Drawing.Point(23, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(106, 44);
            this.label19.TabIndex = 63;
            this.label19.Text = "列番号";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(52, 542);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 48;
            this.label4.Text = "1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(63, 400);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 18);
            this.label3.TabIndex = 47;
            this.label3.Text = "3段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(39, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "2段";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(18, 497);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 45;
            this.label1.Text = "1段";
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("メイリオ", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Back.Location = new System.Drawing.Point(916, 659);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(121, 58);
            this.Back.TabIndex = 44;
            this.Back.Text = "戻る";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label5.Location = new System.Drawing.Point(110, 542);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 24);
            this.label5.TabIndex = 76;
            this.label5.Text = "2";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(168, 542);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 24);
            this.label6.TabIndex = 77;
            this.label6.Text = "3";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(226, 542);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 24);
            this.label7.TabIndex = 78;
            this.label7.Text = "4";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label8.Location = new System.Drawing.Point(284, 542);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 24);
            this.label8.TabIndex = 79;
            this.label8.Text = "5";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label9.Location = new System.Drawing.Point(342, 542);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 24);
            this.label9.TabIndex = 80;
            this.label9.Text = "6";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label10.Location = new System.Drawing.Point(400, 542);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 24);
            this.label10.TabIndex = 81;
            this.label10.Text = "7";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label11.Location = new System.Drawing.Point(457, 542);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 24);
            this.label11.TabIndex = 82;
            this.label11.Text = "8";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.White;
            this.label12.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(514, 542);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 24);
            this.label12.TabIndex = 83;
            this.label12.Text = "9";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.White;
            this.label13.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(571, 542);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 24);
            this.label13.TabIndex = 84;
            this.label13.Text = "10";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.White;
            this.label14.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(628, 542);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(45, 24);
            this.label14.TabIndex = 85;
            this.label14.Text = "11";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.White;
            this.label15.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label15.Location = new System.Drawing.Point(685, 542);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(45, 24);
            this.label15.TabIndex = 86;
            this.label15.Text = "12";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.White;
            this.label16.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label16.Location = new System.Drawing.Point(742, 542);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(45, 24);
            this.label16.TabIndex = 87;
            this.label16.Text = "13";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.White;
            this.label17.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label17.Location = new System.Drawing.Point(799, 542);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(45, 24);
            this.label17.TabIndex = 88;
            this.label17.Text = "14";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.White;
            this.label18.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label18.Location = new System.Drawing.Point(856, 542);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(45, 24);
            this.label18.TabIndex = 89;
            this.label18.Text = "15";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TC_CoilOperation.Properties.Resources.coilLINE;
            this.pictureBox1.Location = new System.Drawing.Point(20, 327);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1017, 281);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Coil_Syousai
            // 
            this.Coil_Syousai.Controls.Add(this.tumikomi);
            this.Coil_Syousai.Controls.Add(this.syuko);
            this.Coil_Syousai.Controls.Add(this.zyuryou);
            this.Coil_Syousai.Controls.Add(this.sunpou);
            this.Coil_Syousai.Controls.Add(this.kikaku);
            this.Coil_Syousai.Controls.Add(this.tag);
            this.Coil_Syousai.Controls.Add(this.genpin);
            this.Coil_Syousai.Controls.Add(this.label26);
            this.Coil_Syousai.Controls.Add(this.label25);
            this.Coil_Syousai.Controls.Add(this.label24);
            this.Coil_Syousai.Controls.Add(this.label23);
            this.Coil_Syousai.Controls.Add(this.label22);
            this.Coil_Syousai.Controls.Add(this.label21);
            this.Coil_Syousai.Controls.Add(this.label20);
            this.Coil_Syousai.Location = new System.Drawing.Point(21, 89);
            this.Coil_Syousai.Name = "Coil_Syousai";
            this.Coil_Syousai.Size = new System.Drawing.Size(1017, 190);
            this.Coil_Syousai.TabIndex = 99;
            this.Coil_Syousai.TabStop = false;
            this.Coil_Syousai.Enter += new System.EventHandler(this.Coil_Syousai_Enter_1);
            // 
            // tumikomi
            // 
            this.tumikomi.AutoSize = true;
            this.tumikomi.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tumikomi.Location = new System.Drawing.Point(516, 127);
            this.tumikomi.Name = "tumikomi";
            this.tumikomi.Size = new System.Drawing.Size(37, 36);
            this.tumikomi.TabIndex = 13;
            this.tumikomi.Text = "--";
            // 
            // syuko
            // 
            this.syuko.AutoSize = true;
            this.syuko.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.syuko.Location = new System.Drawing.Point(127, 127);
            this.syuko.Name = "syuko";
            this.syuko.Size = new System.Drawing.Size(37, 36);
            this.syuko.TabIndex = 12;
            this.syuko.Text = "--";
            // 
            // zyuryou
            // 
            this.zyuryou.AutoSize = true;
            this.zyuryou.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.zyuryou.Location = new System.Drawing.Point(516, 82);
            this.zyuryou.Name = "zyuryou";
            this.zyuryou.Size = new System.Drawing.Size(37, 36);
            this.zyuryou.TabIndex = 11;
            this.zyuryou.Text = "--";
            // 
            // sunpou
            // 
            this.sunpou.AutoSize = true;
            this.sunpou.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.sunpou.Location = new System.Drawing.Point(735, 82);
            this.sunpou.Name = "sunpou";
            this.sunpou.Size = new System.Drawing.Size(37, 36);
            this.sunpou.TabIndex = 10;
            this.sunpou.Text = "--";
            // 
            // kikaku
            // 
            this.kikaku.AutoSize = true;
            this.kikaku.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.kikaku.Location = new System.Drawing.Point(127, 82);
            this.kikaku.Name = "kikaku";
            this.kikaku.Size = new System.Drawing.Size(37, 36);
            this.kikaku.TabIndex = 9;
            this.kikaku.Text = "--";
            // 
            // tag
            // 
            this.tag.AutoSize = true;
            this.tag.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tag.Location = new System.Drawing.Point(516, 34);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(37, 36);
            this.tag.TabIndex = 8;
            this.tag.Text = "--";
            // 
            // genpin
            // 
            this.genpin.AutoSize = true;
            this.genpin.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.genpin.Location = new System.Drawing.Point(127, 34);
            this.genpin.Name = "genpin";
            this.genpin.Size = new System.Drawing.Size(37, 36);
            this.genpin.TabIndex = 7;
            this.genpin.Text = "--";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label26.Location = new System.Drawing.Point(388, 127);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(135, 36);
            this.label26.TabIndex = 6;
            this.label26.Text = "積込日   ：";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label25.Location = new System.Drawing.Point(13, 127);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(119, 36);
            this.label25.TabIndex = 5;
            this.label25.Text = "出庫日 ：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label24.Location = new System.Drawing.Point(388, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(137, 36);
            this.label24.TabIndex = 4;
            this.label24.Text = "重量[kg]：";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label23.Location = new System.Drawing.Point(663, 82);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(87, 36);
            this.label23.TabIndex = 3;
            this.label23.Text = "寸法：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label22.Location = new System.Drawing.Point(13, 82);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(119, 36);
            this.label22.TabIndex = 2;
            this.label22.Text = "規格    ：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label21.Location = new System.Drawing.Point(388, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(139, 36);
            this.label21.TabIndex = 1;
            this.label21.Text = "タグID   ：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label20.Location = new System.Drawing.Point(13, 34);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 36);
            this.label20.TabIndex = 0;
            this.label20.Text = "現品No：";
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.White;
            this.label27.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label27.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label27.Location = new System.Drawing.Point(913, 542);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(45, 24);
            this.label27.TabIndex = 100;
            this.label27.Text = "16";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.White;
            this.label28.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label28.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label28.Location = new System.Drawing.Point(970, 542);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(45, 24);
            this.label28.TabIndex = 101;
            this.label28.Text = "17";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Detail_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 729);
            this.ControlBox = false;
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.Coil_Syousai);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.targCoil);
            this.Controls.Add(this.ColNo);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Detail_View";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "列情報";
            this.Load += new System.EventHandler(this.Detail_View_Load);
            this.Shown += new System.EventHandler(this.Detail_View_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ColNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.Coil_Syousai.ResumeLayout(false);
            this.Coil_Syousai.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button targCoil;
        private System.Windows.Forms.NumericUpDown ColNo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.GroupBox Coil_Syousai;
        public System.Windows.Forms.Label tumikomi;
        public System.Windows.Forms.Label syuko;
        public System.Windows.Forms.Label zyuryou;
        public System.Windows.Forms.Label sunpou;
        public System.Windows.Forms.Label kikaku;
        public System.Windows.Forms.Label tag;
        public System.Windows.Forms.Label genpin;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
    }
}