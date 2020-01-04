using System;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace LotteryProgram
{
    public partial class LotteryForm : Form
    {
        private Label[] labels;
        private Task task;
        private int round;
        private List<string> showList;

        public LotteryForm()
        {
            InitializeComponent();
            labels = new Label[] { label1, label10, label2, label3, label4, label5, label6, label7, label8, label9 };
            showList = new List<string>();
        }

        private void BtnLottery_Click(object sender, EventArgs e)
        {
            if (BtnLottery.Text == "开始")
            {
                round++;
                timer.Start();
                BtnLottery.Text = "结束";
                task = Task.Run(() =>
                {
                    LotteryRandom();
                });
            }
            else if (BtnLottery.Text == "结束")
            {
                BtnLottery.Text = "开始";
                timer.Stop();
                for (int i = 0; i < showList.Count; i++)
                {
                    labels[i].Text = showList[i];
                }
                LotteryDataGrid.DataSource = GetDatas();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            var ran = new Random();
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Text = ran.Next(1, 999).ToString();
            }
        }

        private void LotteryRandom()
        {
            showList.Clear();
            var random = new Random();
            var sql = string.Empty;
            DataTable dataTable;
            List<string> list = new List<string>();
            sql = $"select Id from Persons where [Level] = {round}";
            dataTable = SqlHelper.Query(sql);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    showList.Add(row[0].ToString());
                }
            }
            sql = $"update Persons set SelectedTime = getdate() where [Level] = {round}";
            SqlHelper.ExecuteNonquery(sql);
            sql = "select Id from Persons where SelectedTime is null";
            dataTable = SqlHelper.Query(sql);
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    list.Add(row[0].ToString());
                }
                while (showList.Count < 10)
                {
                    var index = random.Next(0, list.Count - 1);
                    showList.Add(list[index]);
                }
            }
            foreach (var item in showList)
            {
                sql = $"update Persons set SelectedTime = getdate() where Id = {item}";
                SqlHelper.ExecuteNonquery(sql);
            }
        }

        private DataTable GetDatas()
        {
            var sql = "select Id as 学号,IdCard as 身份证号,[Name] as 姓名,SelectedTime as 中奖时间 from Persons where SelectedTime is not null order by SelectedTime desc";
            return SqlHelper.Query(sql);
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            LotteryDataGrid.DataSource = GetDatas();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            round = 0;
            var sql = "update Persons set SelectedTime = null";
            SqlHelper.ExecuteNonquery(sql);
        }
    }
}
