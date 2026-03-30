namespace TC_CoilOperation
{
    partial class Lbl_Col_No
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

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_Col = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_Col
            // 
            this.lbl_Col.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Col.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lbl_Col.Location = new System.Drawing.Point(0, 0);
            this.lbl_Col.Name = "lbl_Col";
            this.lbl_Col.Size = new System.Drawing.Size(20, 36);
            this.lbl_Col.TabIndex = 12;
            this.lbl_Col.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Col.Click += new System.EventHandler(this.lbl_Col_Click);
            // 
            // Lbl_Col_No
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbl_Col);
            this.Name = "Lbl_Col_No";
            this.Size = new System.Drawing.Size(20, 36);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Label lbl_Col;
    }
}
