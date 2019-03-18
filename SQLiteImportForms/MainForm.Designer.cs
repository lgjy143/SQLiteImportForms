namespace SQLiteImportForms
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpdte = new System.Windows.Forms.Button();
            this.txtSQLite = new System.Windows.Forms.TextBox();
            this.txtBak = new System.Windows.Forms.TextBox();
            this.btnBak = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUpdte
            // 
            this.btnUpdte.Location = new System.Drawing.Point(345, 80);
            this.btnUpdte.Name = "btnUpdte";
            this.btnUpdte.Size = new System.Drawing.Size(75, 23);
            this.btnUpdte.TabIndex = 0;
            this.btnUpdte.Text = "更新";
            this.btnUpdte.UseVisualStyleBackColor = true;
            this.btnUpdte.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSQLite
            // 
            this.txtSQLite.Location = new System.Drawing.Point(12, 80);
            this.txtSQLite.Name = "txtSQLite";
            this.txtSQLite.Size = new System.Drawing.Size(311, 21);
            this.txtSQLite.TabIndex = 1;
            // 
            // txtBak
            // 
            this.txtBak.Location = new System.Drawing.Point(12, 33);
            this.txtBak.Name = "txtBak";
            this.txtBak.Size = new System.Drawing.Size(311, 21);
            this.txtBak.TabIndex = 2;
            // 
            // btnBak
            // 
            this.btnBak.Location = new System.Drawing.Point(345, 31);
            this.btnBak.Name = "btnBak";
            this.btnBak.Size = new System.Drawing.Size(75, 23);
            this.btnBak.TabIndex = 3;
            this.btnBak.Text = "Bak文件";
            this.btnBak.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 138);
            this.Controls.Add(this.btnBak);
            this.Controls.Add(this.txtBak);
            this.Controls.Add(this.txtSQLite);
            this.Controls.Add(this.btnUpdte);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdte;
        private System.Windows.Forms.TextBox txtSQLite;
        private System.Windows.Forms.TextBox txtBak;
        private System.Windows.Forms.Button btnBak;
    }
}

