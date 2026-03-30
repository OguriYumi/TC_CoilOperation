
namespace TC_CoilOperation
{
    partial class multicoil
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.決定 = new System.Windows.Forms.Button();
            this.再読取り = new System.Windows.Forms.Button();
            this.タグ表示画面 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.クレーン座標 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.タグ表示画面)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(147, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "複数のタグを読み取りました。操作を行うタグを選択してください。";
            // 
            // 決定
            // 
            this.決定.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.決定.Location = new System.Drawing.Point(881, 572);
            this.決定.Name = "決定";
            this.決定.Size = new System.Drawing.Size(115, 57);
            this.決定.TabIndex = 1;
            this.決定.Text = "決定";
            this.決定.UseVisualStyleBackColor = true;
            this.決定.Click += new System.EventHandler(this.決定_Click);
            // 
            // 再読取り
            // 
            this.再読取り.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.再読取り.Location = new System.Drawing.Point(3, 572);
            this.再読取り.Name = "再読取り";
            this.再読取り.Size = new System.Drawing.Size(117, 57);
            this.再読取り.TabIndex = 2;
            this.再読取り.Text = "再度\r\n読み取り";
            this.再読取り.UseVisualStyleBackColor = true;
            this.再読取り.Click += new System.EventHandler(this.button2_Click);
            // 
            // タグ表示画面
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.タグ表示画面.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.タグ表示画面.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("MS UI Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.タグ表示画面.DefaultCellStyle = dataGridViewCellStyle4;
            this.タグ表示画面.Location = new System.Drawing.Point(3, 158);
            this.タグ表示画面.MultiSelect = false;
            this.タグ表示画面.Name = "タグ表示画面";
            this.タグ表示画面.RowTemplate.Height = 21;
            this.タグ表示画面.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.タグ表示画面.Size = new System.Drawing.Size(993, 398);
            this.タグ表示画面.TabIndex = 3;
            this.タグ表示画面.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.タグ表示画面_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(209, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 27);
            this.label2.TabIndex = 4;
            this.label2.Text = "現在のクレーン座標";
            // 
            // クレーン座標
            // 
            this.クレーン座標.AutoSize = true;
            this.クレーン座標.Font = new System.Drawing.Font("MS UI Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.クレーン座標.Location = new System.Drawing.Point(558, 86);
            this.クレーン座標.Name = "クレーン座標";
            this.クレーン座標.Size = new System.Drawing.Size(136, 27);
            this.クレーン座標.TabIndex = 5;
            this.クレーン座標.Text = "XX-XX-XX";
            // 
            // multicoil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.ControlBox = false;
            this.Controls.Add(this.クレーン座標);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.タグ表示画面);
            this.Controls.Add(this.再読取り);
            this.Controls.Add(this.決定);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "multicoil";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "multicoil";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.multicoil_Load);
            ((System.ComponentModel.ISupportInitialize)(this.タグ表示画面)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button 決定;
        private System.Windows.Forms.Button 再読取り;
        private System.Windows.Forms.DataGridView タグ表示画面;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label クレーン座標;
    }
}