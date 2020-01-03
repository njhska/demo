using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LotteryProgram
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnOpenManageForm_Click(object sender, EventArgs e)
        {
            SplitContainer.Panel2.Controls.Clear();
            ManageForm manageForm = new ManageForm();
            manageForm.TopLevel = false;
            manageForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            manageForm.Dock = DockStyle.Fill;
            manageForm.Parent = SplitContainer.Panel2;
            SplitContainer.Panel2.Controls.Add(manageForm);
            manageForm.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void BtnOpenLotteryForm_Click(object sender, EventArgs e)
        {
            SplitContainer.Panel2.Controls.Clear();
            LotteryForm form = new LotteryForm();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.Fixed3D;
            form.Dock = DockStyle.Fill;
            form.Parent = SplitContainer.Panel2;
            SplitContainer.Panel2.Controls.Add(form);
            form.Show();
        }
    }
}
