namespace TC_CoilOperation
{
    partial class MainScreen
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainScreen));
            this.panel2 = new System.Windows.Forms.Panel();
            this.Show_msg = new System.Windows.Forms.Label();
            this.SystemTime = new System.Windows.Forms.Label();
            this.Title = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.Button();
            this.TimesofDay_timer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Show_msg);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 727);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1028, 37);
            this.panel2.TabIndex = 101;
            // 
            // Show_msg
            // 
            this.Show_msg.AutoSize = true;
            this.Show_msg.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Show_msg.Location = new System.Drawing.Point(3, 5);
            this.Show_msg.Name = "Show_msg";
            this.Show_msg.Size = new System.Drawing.Size(574, 31);
            this.Show_msg.TabIndex = 0;
            this.Show_msg.Text = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN";
            this.Show_msg.Click += new System.EventHandler(this.label9_Click);
            // 
            // SystemTime
            // 
            this.SystemTime.BackColor = System.Drawing.Color.White;
            this.SystemTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SystemTime.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.SystemTime.ForeColor = System.Drawing.Color.Black;
            this.SystemTime.Location = new System.Drawing.Point(699, 0);
            this.SystemTime.Name = "SystemTime";
            this.SystemTime.Size = new System.Drawing.Size(279, 42);
            this.SystemTime.TabIndex = 91;
            this.SystemTime.Text = "YYYY/MM/DD 99:99:99";
            this.SystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SystemTime.Click += new System.EventHandler(this.label75_Click);
            // 
            // Title
            // 
            this.Title.BackColor = System.Drawing.Color.Green;
            this.Title.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Title.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(269, 1);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(427, 42);
            this.Title.TabIndex = 90;
            this.Title.Text = "XXXXXX";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Title.Click += new System.EventHandler(this.label74_Click);
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label66.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label66.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(-1, 0);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(267, 42);
            this.label66.TabIndex = 89;
            this.label66.Text = "操作端末";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menu
            // 
            this.menu.Image = global::TC_CoilOperation.Properties.Resources.図4;
            this.menu.Location = new System.Drawing.Point(981, 0);
            this.menu.Margin = new System.Windows.Forms.Padding(2);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(41, 44);
            this.menu.TabIndex = 20;
            this.menu.UseVisualStyleBackColor = true;
            this.menu.Click += new System.EventHandler(this.button8_Click);
            // 
            // TimesofDay_timer
            // 
            this.TimesofDay_timer.Interval = 60000;
            this.TimesofDay_timer.Tick += new System.EventHandler(this.TimesofDay_timer_Tick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.SystemTime);
            this.panel1.Controls.Add(this.Title);
            this.panel1.Controls.Add(this.label66);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 50);
            this.panel1.TabIndex = 100;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 764);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Operation_Screen_Load);
            this.Shown += new System.EventHandler(this.MainScreen_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label SystemTime;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button menu;
        public System.Windows.Forms.Label Title;
        public System.Windows.Forms.Label Show_msg;
        private System.Windows.Forms.Timer TimesofDay_timer;
        private System.Windows.Forms.Panel panel1;
    }
}

