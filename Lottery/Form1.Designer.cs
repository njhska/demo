namespace Lottery
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
            this.TextExcelPath = new System.Windows.Forms.TextBox();
            this.BtnChoseFile = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.PersonsGridView = new System.Windows.Forms.DataGridView();
            this.CheckboxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.BtnOpenLottery = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PersonsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // TextExcelPath
            // 
            this.TextExcelPath.Location = new System.Drawing.Point(69, 73);
            this.TextExcelPath.Name = "TextExcelPath";
            this.TextExcelPath.Size = new System.Drawing.Size(226, 20);
            this.TextExcelPath.TabIndex = 1;
            // 
            // BtnChoseFile
            // 
            this.BtnChoseFile.Location = new System.Drawing.Point(301, 71);
            this.BtnChoseFile.Name = "BtnChoseFile";
            this.BtnChoseFile.Size = new System.Drawing.Size(115, 23);
            this.BtnChoseFile.TabIndex = 2;
            this.BtnChoseFile.Text = "选择导入Excel";
            this.BtnChoseFile.UseVisualStyleBackColor = true;
            this.BtnChoseFile.Click += new System.EventHandler(this.BtnChoseFile_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(422, 70);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(96, 23);
            this.BtnImport.TabIndex = 3;
            this.BtnImport.Text = "导入";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // PersonsGridView
            // 
            this.PersonsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonsGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckboxColumn});
            this.PersonsGridView.Location = new System.Drawing.Point(69, 126);
            this.PersonsGridView.Name = "PersonsGridView";
            this.PersonsGridView.Size = new System.Drawing.Size(552, 349);
            this.PersonsGridView.TabIndex = 4;
            this.PersonsGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PersonsGridView_CellContentClick);
            // 
            // CheckboxColumn
            // 
            this.CheckboxColumn.HeaderText = "选择";
            this.CheckboxColumn.Name = "CheckboxColumn";
            // 
            // BtnOpenLottery
            // 
            this.BtnOpenLottery.Location = new System.Drawing.Point(524, 70);
            this.BtnOpenLottery.Name = "BtnOpenLottery";
            this.BtnOpenLottery.Size = new System.Drawing.Size(97, 23);
            this.BtnOpenLottery.TabIndex = 5;
            this.BtnOpenLottery.Text = "抽奖";
            this.BtnOpenLottery.UseVisualStyleBackColor = true;
            this.BtnOpenLottery.Click += new System.EventHandler(this.BtnOpenLottery_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 550);
            this.Controls.Add(this.BtnOpenLottery);
            this.Controls.Add(this.PersonsGridView);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnChoseFile);
            this.Controls.Add(this.TextExcelPath);
            this.Name = "MainForm";
            this.Text = "首页";
            ((System.ComponentModel.ISupportInitialize)(this.PersonsGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextExcelPath;
        private System.Windows.Forms.Button BtnChoseFile;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.DataGridView PersonsGridView;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckboxColumn;
        private System.Windows.Forms.Button BtnOpenLottery;
    }
}

