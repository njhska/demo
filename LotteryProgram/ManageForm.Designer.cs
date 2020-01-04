namespace LotteryProgram
{
    partial class ManageForm
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
            this.TextFile = new System.Windows.Forms.TextBox();
            this.BtnOpenDialog = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.PersonsDataGrid = new System.Windows.Forms.DataGridView();
            this.BtnSave = new System.Windows.Forms.Button();
            this.TextNumber = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LabNumber = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PersonsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // TextFile
            // 
            this.TextFile.Location = new System.Drawing.Point(54, 32);
            this.TextFile.Name = "TextFile";
            this.TextFile.Size = new System.Drawing.Size(266, 20);
            this.TextFile.TabIndex = 0;
            // 
            // BtnOpenDialog
            // 
            this.BtnOpenDialog.Location = new System.Drawing.Point(345, 30);
            this.BtnOpenDialog.Name = "BtnOpenDialog";
            this.BtnOpenDialog.Size = new System.Drawing.Size(75, 23);
            this.BtnOpenDialog.TabIndex = 1;
            this.BtnOpenDialog.Text = "选择文件";
            this.BtnOpenDialog.UseVisualStyleBackColor = true;
            this.BtnOpenDialog.Click += new System.EventHandler(this.BtnOpenDialog_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(436, 30);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(75, 23);
            this.BtnImport.TabIndex = 1;
            this.BtnImport.Text = "导入";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // PersonsDataGrid
            // 
            this.PersonsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PersonsDataGrid.Location = new System.Drawing.Point(54, 92);
            this.PersonsDataGrid.Name = "PersonsDataGrid";
            this.PersonsDataGrid.Size = new System.Drawing.Size(544, 295);
            this.PersonsDataGrid.TabIndex = 2;
            // 
            // BtnSave
            // 
            this.BtnSave.Location = new System.Drawing.Point(523, 30);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(75, 23);
            this.BtnSave.TabIndex = 1;
            this.BtnSave.Text = "保存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TextNumber
            // 
            this.TextNumber.Location = new System.Drawing.Point(400, 64);
            this.TextNumber.Name = "TextNumber";
            this.TextNumber.Size = new System.Drawing.Size(111, 20);
            this.TextNumber.TabIndex = 3;
            // 
            // BtnSearch
            // 
            this.BtnSearch.Location = new System.Drawing.Point(523, 63);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(75, 23);
            this.BtnSearch.TabIndex = 4;
            this.BtnSearch.Text = "查询";
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LabNumber
            // 
            this.LabNumber.AutoSize = true;
            this.LabNumber.Location = new System.Drawing.Point(351, 67);
            this.LabNumber.Name = "LabNumber";
            this.LabNumber.Size = new System.Drawing.Size(34, 13);
            this.LabNumber.TabIndex = 5;
            this.LabNumber.Text = "学号:";
            // 
            // ManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 454);
            this.Controls.Add(this.LabNumber);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.TextNumber);
            this.Controls.Add(this.PersonsDataGrid);
            this.Controls.Add(this.BtnSave);
            this.Controls.Add(this.BtnImport);
            this.Controls.Add(this.BtnOpenDialog);
            this.Controls.Add(this.TextFile);
            this.Name = "ManageForm";
            this.Text = "ManageForm";
            ((System.ComponentModel.ISupportInitialize)(this.PersonsDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextFile;
        private System.Windows.Forms.Button BtnOpenDialog;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.DataGridView PersonsDataGrid;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.TextBox TextNumber;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.Label LabNumber;
    }
}