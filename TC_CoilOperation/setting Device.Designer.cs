namespace TC_CoilOperation
{
    partial class setting_Device
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LSI = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.LSOFF = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.LSON = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.LM = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.OffS_Z = new System.Windows.Forms.NumericUpDown();
            this.IV_Z = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.OffS_Y = new System.Windows.Forms.NumericUpDown();
            this.IV_Y = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.OffS_X = new System.Windows.Forms.NumericUpDown();
            this.IV_X = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LSI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSOFF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSON)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_Z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_Z)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_Y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_Y)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_X)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_X)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LSI);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LSOFF);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.LSON);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.LM);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(23, 312);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 236);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "リフター信号取り込み機器設定";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // LSI
            // 
            this.LSI.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LSI.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.LSI.Location = new System.Drawing.Point(52, 121);
            this.LSI.Maximum = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.LSI.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.LSI.Name = "LSI";
            this.LSI.Size = new System.Drawing.Size(126, 31);
            this.LSI.TabIndex = 33;
            this.LSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LSI.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LSI.ValueChanged += new System.EventHandler(this.numericUpDown9_ValueChanged);
            this.LSI.Click += new System.EventHandler(this.LSI_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.Location = new System.Drawing.Point(49, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(289, 24);
            this.label9.TabIndex = 32;
            this.label9.Text = "リフター信号取込インターバル（ms）";
            // 
            // LSOFF
            // 
            this.LSOFF.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LSOFF.Location = new System.Drawing.Point(617, 121);
            this.LSOFF.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LSOFF.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LSOFF.Name = "LSOFF";
            this.LSOFF.Size = new System.Drawing.Size(122, 31);
            this.LSOFF.TabIndex = 31;
            this.LSOFF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LSOFF.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.LSOFF.ValueChanged += new System.EventHandler(this.numericUpDown8_ValueChanged);
            this.LSOFF.Click += new System.EventHandler(this.LSOFF_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.Location = new System.Drawing.Point(614, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 24);
            this.label8.TabIndex = 30;
            this.label8.Text = "OFF信号判定回数";
            // 
            // LSON
            // 
            this.LSON.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LSON.Location = new System.Drawing.Point(392, 121);
            this.LSON.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.LSON.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.LSON.Name = "LSON";
            this.LSON.Size = new System.Drawing.Size(126, 31);
            this.LSON.TabIndex = 29;
            this.LSON.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LSON.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.LSON.ValueChanged += new System.EventHandler(this.numericUpDown7_ValueChanged);
            this.LSON.Click += new System.EventHandler(this.LSON_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.Location = new System.Drawing.Point(389, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 24);
            this.label7.TabIndex = 28;
            this.label7.Text = "ON信号判定回数";
            // 
            // LM
            // 
            this.LM.AutoSize = true;
            this.LM.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LM.Location = new System.Drawing.Point(52, 193);
            this.LM.Name = "LM";
            this.LM.Size = new System.Drawing.Size(173, 28);
            this.LM.TabIndex = 0;
            this.LM.Text = "リフター手動モード";
            this.LM.UseVisualStyleBackColor = true;
            this.LM.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox7);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(23, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(984, 290);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "レーザ距離計設定";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.OffS_Z);
            this.groupBox7.Controls.Add(this.IV_Z);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox7.Location = new System.Drawing.Point(691, 30);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(271, 252);
            this.groupBox7.TabIndex = 27;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Z軸距離設定";
            // 
            // OffS_Z
            // 
            this.OffS_Z.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OffS_Z.Location = new System.Drawing.Point(122, 181);
            this.OffS_Z.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OffS_Z.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.OffS_Z.Name = "OffS_Z";
            this.OffS_Z.Size = new System.Drawing.Size(134, 31);
            this.OffS_Z.TabIndex = 32;
            this.OffS_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OffS_Z.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            this.OffS_Z.Click += new System.EventHandler(this.OffS_Z_Click);
            // 
            // IV_Z
            // 
            this.IV_Z.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IV_Z.Location = new System.Drawing.Point(122, 94);
            this.IV_Z.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.IV_Z.Name = "IV_Z";
            this.IV_Z.Size = new System.Drawing.Size(134, 31);
            this.IV_Z.TabIndex = 30;
            this.IV_Z.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IV_Z.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            this.IV_Z.Click += new System.EventHandler(this.IV_Z_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(16, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 24);
            this.label5.TabIndex = 31;
            this.label5.Text = "オフセット値";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(16, 98);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 24);
            this.label6.TabIndex = 29;
            this.label6.Text = "反転数値";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.OffS_Y);
            this.groupBox5.Controls.Add(this.IV_Y);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox5.Location = new System.Drawing.Point(351, 30);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(271, 252);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Y軸距離設定";
            // 
            // OffS_Y
            // 
            this.OffS_Y.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OffS_Y.Location = new System.Drawing.Point(122, 181);
            this.OffS_Y.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OffS_Y.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.OffS_Y.Name = "OffS_Y";
            this.OffS_Y.Size = new System.Drawing.Size(134, 31);
            this.OffS_Y.TabIndex = 32;
            this.OffS_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OffS_Y.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            this.OffS_Y.Click += new System.EventHandler(this.OffS_Y_Click);
            // 
            // IV_Y
            // 
            this.IV_Y.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IV_Y.Location = new System.Drawing.Point(122, 94);
            this.IV_Y.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.IV_Y.Name = "IV_Y";
            this.IV_Y.Size = new System.Drawing.Size(134, 31);
            this.IV_Y.TabIndex = 30;
            this.IV_Y.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IV_Y.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            this.IV_Y.Click += new System.EventHandler(this.IV_Y_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(16, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 31;
            this.label2.Text = "オフセット値";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(16, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 24);
            this.label4.TabIndex = 29;
            this.label4.Text = "反転数値";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.OffS_X);
            this.groupBox3.Controls.Add(this.IV_X);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox3.Location = new System.Drawing.Point(17, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(271, 252);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "X軸距離設定";
            // 
            // OffS_X
            // 
            this.OffS_X.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.OffS_X.Location = new System.Drawing.Point(128, 184);
            this.OffS_X.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.OffS_X.Minimum = new decimal(new int[] {
            99999,
            0,
            0,
            -2147483648});
            this.OffS_X.Name = "OffS_X";
            this.OffS_X.Size = new System.Drawing.Size(134, 31);
            this.OffS_X.TabIndex = 28;
            this.OffS_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.OffS_X.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            this.OffS_X.Click += new System.EventHandler(this.OffS_X_Click);
            // 
            // IV_X
            // 
            this.IV_X.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.IV_X.Location = new System.Drawing.Point(128, 97);
            this.IV_X.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.IV_X.Name = "IV_X";
            this.IV_X.Size = new System.Drawing.Size(134, 31);
            this.IV_X.TabIndex = 27;
            this.IV_X.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.IV_X.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            this.IV_X.Click += new System.EventHandler(this.IV_X_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(22, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 27;
            this.label1.Text = "オフセット値";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(22, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 26;
            this.label3.Text = "反転数値";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(25, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 77);
            this.button1.TabIndex = 38;
            this.button1.Text = "登録";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(841, 584);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 77);
            this.button3.TabIndex = 37;
            this.button3.Text = "戻る";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // setting_Device
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 680);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "setting_Device";
            this.Load += new System.EventHandler(this.setting_Device_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LSI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSOFF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LSON)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_Z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_Z)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_Y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_Y)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.OffS_X)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IV_X)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox LM;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.NumericUpDown LSI;
        public System.Windows.Forms.NumericUpDown LSOFF;
        public System.Windows.Forms.NumericUpDown LSON;
        public System.Windows.Forms.NumericUpDown OffS_Z;
        public System.Windows.Forms.NumericUpDown IV_Z;
        public System.Windows.Forms.NumericUpDown OffS_Y;
        public System.Windows.Forms.NumericUpDown IV_Y;
        public System.Windows.Forms.NumericUpDown OffS_X;
        public System.Windows.Forms.NumericUpDown IV_X;
        public System.Windows.Forms.Timer timer1;
    }
}