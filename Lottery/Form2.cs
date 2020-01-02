using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery
{
    public partial class LotteryForm : Form
    {
        private List<Person> ChoosePersons;

        private List<string> Luckies;

        private Label[] labels;

        private List<string> showList;

        public LotteryForm()
        {
            InitializeComponent();
            Luckies = new List<string>();
            showList = new List<string>();
            ChoosePersons = Persons.List.Where(x => x.Selected).ToList();
            labels = new Label[] { lab1,lab2,lab3,lab4,lab5,lab6,lab7,lab8,lab9,lab10};
        }

        private async void BtnLottery_Click(object sender, EventArgs e)
        {
            if (BtnLottery.Text == "开始")
            {
                showList.Clear();
                BtnLottery.Text = "结束";
                timer.Start();
                await Task.Run(() => {

                    var random = new Random();
                    if (ChoosePersons.Count > 3)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            Luckies.Add(ChoosePersons[i].Id);
                        }
                        ChoosePersons.RemoveAll(t => Luckies.Contains(t.Id));
                    }
                    while (showList.Count < 10)
                    {
                        var temp = Persons.List.Where(x => !Luckies.Contains(x.Id)).ToList();
                        var n = random.Next(1, Persons.List.Count - Luckies.Count);
                        Luckies.Add(temp[n].Id);
                        showList.Add(temp[n].Id);
                    }
                });
            }
            else if (BtnLottery.Text == "结束")
            {
                BtnLottery.Text = "开始";
                timer.Stop();
                
                for (int i = 0; i < labels.Length; i++)
                {
                    labels[i].Text = showList[i];
                }
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
    }
}
