
namespace TC_CoilOperation
{
    partial class CoilShowDialog
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
            this.ShowMSG = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tagname = new System.Windows.Forms.Label();
            this.現在ロケ = new System.Windows.Forms.Label();
            this.登録ロケ = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ShowMSG
            // 
            this.ShowMSG.AutoSize = true;
            this.ShowMSG.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ShowMSG.Location = new System.Drawing.Point(103, 33);
            this.ShowMSG.Name = "ShowMSG";
            this.ShowMSG.Size = new System.Drawing.Size(558, 56);
            this.ShowMSG.TabIndex = 0;
            this.ShowMSG.Text = "ロケーションデータのないコイルを読み取りました。\r\nこのコイルで作業を行いますか？";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Location = new System.Drawing.Point(600, 338);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(184, 95);
            this.button1.TabIndex = 1;
            this.button1.Text = "作業する";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("MS UI Gothic", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Location = new System.Drawing.Point(12, 338);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(184, 95);
            this.button2.TabIndex = 2;
            this.button2.Text = "再読取り";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tagname
            // 
            this.tagname.AutoSize = true;
            this.tagname.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.tagname.Location = new System.Drawing.Point(382, 135);
            this.tagname.Name = "tagname";
            this.tagname.Size = new System.Drawing.Size(143, 40);
            this.tagname.TabIndex = 3;
            this.tagname.Text = "000987";
            this.tagname.Click += new System.EventHandler(this.label2_Click);
            // 
            // 現在ロケ
            // 
            this.現在ロケ.AutoSize = true;
            this.現在ロケ.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.現在ロケ.Location = new System.Drawing.Point(382, 193);
            this.現在ロケ.Name = "現在ロケ";
            this.現在ロケ.Size = new System.Drawing.Size(209, 40);
            this.現在ロケ.TabIndex = 4;
            this.現在ロケ.Text = "XX-XX-XX";
            // 
            // 登録ロケ
            // 
            this.登録ロケ.AutoSize = true;
            this.登録ロケ.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.登録ロケ.Location = new System.Drawing.Point(382, 242);
            this.登録ロケ.Name = "登録ロケ";
            this.登録ロケ.Size = new System.Drawing.Size(209, 40);
            this.登録ロケ.TabIndex = 5;
            this.登録ロケ.Text = "XX-XX-XX";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(239, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 38);
            this.label1.TabIndex = 6;
            this.label1.Text = "タグID：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(195, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 38);
            this.label2.TabIndex = 7;
            this.label2.Text = "現在ロケ：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(195, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 38);
            this.label3.TabIndex = 8;
            this.label3.Text = "登録ロケ：";
            // 
            // CoilShowDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.登録ロケ);
            this.Controls.Add(this.現在ロケ);
            this.Controls.Add(this.tagname);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowMSG);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CoilShowDialog";
            this.Text = "確認";
            this.Load += new System.EventHandler(this.CoilShowDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ShowMSG;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label tagname;
        private System.Windows.Forms.Label 現在ロケ;
        private System.Windows.Forms.Label 登録ロケ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}