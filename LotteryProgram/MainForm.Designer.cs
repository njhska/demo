namespace LotteryProgram
{
    partial class MainForm
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
            this.SplitContainer = new System.Windows.Forms.SplitContainer();
            this.BtnOpenManageForm = new System.Windows.Forms.Button();
            this.BtnOpenLotteryForm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).BeginInit();
            this.SplitContainer.Panel1.SuspendLayout();
            this.SplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer
            // 
            this.SplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainer.Location = new System.Drawing.Point(0, 0);
            this.SplitContainer.Name = "SplitContainer";
            // 
            // SplitContainer.Panel1
            // 
            this.SplitContainer.Panel1.Controls.Add(this.BtnOpenLotteryForm);
            this.SplitContainer.Panel1.Controls.Add(this.BtnOpenManageForm);
            this.SplitContainer.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // SplitContainer.Panel2
            // 
            this.SplitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.SplitContainer.Size = new System.Drawing.Size(826, 505);
            this.SplitContainer.SplitterDistance = 167;
            this.SplitContainer.TabIndex = 0;
            // 
            // BtnOpenManageForm
            // 
            this.BtnOpenManageForm.Location = new System.Drawing.Point(37, 27);
            this.BtnOpenManageForm.Name = "BtnOpenManageForm";
            this.BtnOpenManageForm.Size = new System.Drawing.Size(95, 41);
            this.BtnOpenManageForm.TabIndex = 0;
            this.BtnOpenManageForm.Text = "管理界面";
            this.BtnOpenManageForm.UseVisualStyleBackColor = true;
            this.BtnOpenManageForm.Click += new System.EventHandler(this.BtnOpenManageForm_Click);
            // 
            // BtnOpenLotteryForm
            // 
            this.BtnOpenLotteryForm.Location = new System.Drawing.Point(37, 74);
            this.BtnOpenLotteryForm.Name = "BtnOpenLotteryForm";
            this.BtnOpenLotteryForm.Size = new System.Drawing.Size(95, 40);
            this.BtnOpenLotteryForm.TabIndex = 0;
            this.BtnOpenLotteryForm.Text = "抽奖";
            this.BtnOpenLotteryForm.UseVisualStyleBackColor = true;
            this.BtnOpenLotteryForm.Click += new System.EventHandler(this.BtnOpenLotteryForm_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 505);
            this.Controls.Add(this.SplitContainer);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.SplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainer)).EndInit();
            this.SplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer SplitContainer;
        private System.Windows.Forms.Button BtnOpenLotteryForm;
        private System.Windows.Forms.Button BtnOpenManageForm;
    }
}