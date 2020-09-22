namespace Ex05.UI
{
    partial class SetAndStartDialog
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
            this.BoardSizeBtn = new System.Windows.Forms.Button();
            this.StartBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSizeBtn
            // 
            this.BoardSizeBtn.Location = new System.Drawing.Point(8, 8);
            this.BoardSizeBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.BoardSizeBtn.Name = "BoardSizeBtn";
            this.BoardSizeBtn.Size = new System.Drawing.Size(303, 47);
            this.BoardSizeBtn.TabIndex = 0;
            this.BoardSizeBtn.Text = "Board size is 4";
            this.BoardSizeBtn.UseVisualStyleBackColor = true;
            this.BoardSizeBtn.Click += new System.EventHandler(this.BoardSizeBtn_Click);
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(109, 105);
            this.StartBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(99, 30);
            this.StartBtn.TabIndex = 1;
            this.StartBtn.Text = "Start game";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // SetAndStartDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 170);
            this.Controls.Add(this.StartBtn);
            this.Controls.Add(this.BoardSizeBtn);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(339, 209);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(339, 209);
            this.Name = "SetAndStartDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CowsAndBulls";
            this.Load += new System.EventHandler(this.SetAndStartDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BoardSizeBtn;
        private System.Windows.Forms.Button StartBtn;
    }
}