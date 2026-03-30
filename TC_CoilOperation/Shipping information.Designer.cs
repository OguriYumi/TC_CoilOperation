namespace TC_CoilOperation
{
    partial class Shipping_information
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.othersInfo = new System.Windows.Forms.Button();
            this.NextdayInfo = new System.Windows.Forms.Button();
            this.TodayInfo = new System.Windows.Forms.Button();
            this.loadinfo = new System.Windows.Forms.Button();
            this.Coil_Grid_Info = new System.Windows.Forms.DataGridView();
            this.Back = new System.Windows.Forms.Button();
            this.Tagcoil = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Coil_Grid_Info)).BeginInit();
            this.SuspendLayout();
            // 
            // othersInfo
            // 
            this.othersInfo.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.othersInfo.Location = new System.Drawing.Point(507, 30);
            this.othersInfo.Name = "othersInfo";
            this.othersInfo.Size = new System.Drawing.Size(163, 77);
            this.othersInfo.TabIndex = 140;
            this.othersInfo.Text = "2日目以降予定";
            this.othersInfo.UseVisualStyleBackColor = true;
            this.othersInfo.Click += new System.EventHandler(this.button5_Click);
            // 
            // NextdayInfo
            // 
            this.NextdayInfo.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.NextdayInfo.Location = new System.Drawing.Point(342, 30);
            this.NextdayInfo.Name = "NextdayInfo";
            this.NextdayInfo.Size = new System.Drawing.Size(159, 77);
            this.NextdayInfo.TabIndex = 139;
            this.NextdayInfo.Text = "翌日予定";
            this.NextdayInfo.UseVisualStyleBackColor = true;
            this.NextdayInfo.Click += new System.EventHandler(this.button4_Click);
            // 
            // TodayInfo
            // 
            this.TodayInfo.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TodayInfo.Location = new System.Drawing.Point(177, 30);
            this.TodayInfo.Name = "TodayInfo";
            this.TodayInfo.Size = new System.Drawing.Size(159, 77);
            this.TodayInfo.TabIndex = 138;
            this.TodayInfo.Text = "本日予定";
            this.TodayInfo.UseVisualStyleBackColor = true;
            this.TodayInfo.Click += new System.EventHandler(this.button2_Click);
            // 
            // loadinfo
            // 
            this.loadinfo.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.loadinfo.Location = new System.Drawing.Point(12, 30);
            this.loadinfo.Name = "loadinfo";
            this.loadinfo.Size = new System.Drawing.Size(159, 77);
            this.loadinfo.TabIndex = 137;
            this.loadinfo.Text = "積込待ち";
            this.loadinfo.UseVisualStyleBackColor = true;
            this.loadinfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // Coil_Grid_Info
            // 
            this.Coil_Grid_Info.AllowUserToAddRows = false;
            this.Coil_Grid_Info.AllowUserToDeleteRows = false;
            this.Coil_Grid_Info.AllowUserToResizeColumns = false;
            this.Coil_Grid_Info.AllowUserToResizeRows = false;
            this.Coil_Grid_Info.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Coil_Grid_Info.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.Coil_Grid_Info.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Coil_Grid_Info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Coil_Grid_Info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Coil_Grid_Info.DefaultCellStyle = dataGridViewCellStyle2;
            this.Coil_Grid_Info.Location = new System.Drawing.Point(12, 113);
            this.Coil_Grid_Info.Name = "Coil_Grid_Info";
            this.Coil_Grid_Info.ReadOnly = true;
            this.Coil_Grid_Info.RowTemplate.Height = 21;
            this.Coil_Grid_Info.Size = new System.Drawing.Size(984, 501);
            this.Coil_Grid_Info.TabIndex = 136;
            this.Coil_Grid_Info.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Coil_Grid_Info_CellClick);
            this.Coil_Grid_Info.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.Coil_Grid_Info.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.Coil_Grid_Info_RowEnter);
            this.Coil_Grid_Info.SelectionChanged += new System.EventHandler(this.Coil_Grid_Info_SelectionChanged);
            this.Coil_Grid_Info.DoubleClick += new System.EventHandler(this.Coil_Grid_Info_DoubleClick);
            // 
            // Back
            // 
            this.Back.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Back.Location = new System.Drawing.Point(830, 638);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(166, 77);
            this.Back.TabIndex = 135;
            this.Back.Text = "戻る";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.button3_Click);
            // 
            // Tagcoil
            // 
            this.Tagcoil.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Tagcoil.Location = new System.Drawing.Point(12, 638);
            this.Tagcoil.Name = "Tagcoil";
            this.Tagcoil.Size = new System.Drawing.Size(196, 77);
            this.Tagcoil.TabIndex = 141;
            this.Tagcoil.Text = "目標コイル設定";
            this.Tagcoil.UseVisualStyleBackColor = true;
            this.Tagcoil.Visible = false;
            this.Tagcoil.Click += new System.EventHandler(this.button6_Click);
            // 
            // Shipping_information
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.ControlBox = false;
            this.Controls.Add(this.Tagcoil);
            this.Controls.Add(this.othersInfo);
            this.Controls.Add(this.NextdayInfo);
            this.Controls.Add(this.TodayInfo);
            this.Controls.Add(this.loadinfo);
            this.Controls.Add(this.Coil_Grid_Info);
            this.Controls.Add(this.Back);
            this.Name = "Shipping_information";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "出庫情報";
            this.Load += new System.EventHandler(this.Shipping_information_Load);
            this.Shown += new System.EventHandler(this.Shipping_information_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.Coil_Grid_Info)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button othersInfo;
        private System.Windows.Forms.Button NextdayInfo;
        private System.Windows.Forms.Button TodayInfo;
        private System.Windows.Forms.Button loadinfo;
        private System.Windows.Forms.DataGridView Coil_Grid_Info;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Tagcoil;
    }
}