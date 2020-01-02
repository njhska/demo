using System;
using System.IO;
using NPOI;
using NPOI.SS.UserModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NPOI.HSSF.UserModel;
using System.Linq;

namespace Lottery
{
    public partial class MainForm : Form
    {
        private string filePath;

        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnChoseFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            if(filePath.ToLower().EndsWith(".xls") || filePath.ToLower().EndsWith(".xlsx"))
            {
                TextExcelPath.Text = Path.GetFileName(filePath);
            }
            else
            {
                MessageBox.Show("请选择一个excel文件");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(TextExcelPath.Text))
            {
                MessageBox.Show("请先选择一个excel文件");
            }
            else
            {
                ReadDatasFromExcel(filePath);
                MessageBox.Show("导入成功！");
                PersonsGridView.DataSource = Persons.List;
                
            }
        }

        private static void ReadDatasFromExcel(string excelPath)
        {
            using (var fsRead = new FileStream(excelPath,FileMode.Open))
            {
                var wkBook = new HSSFWorkbook(fsRead);
                var sheet = wkBook.GetSheetAt(0);
                for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                {
                    var row = sheet.GetRow(i);
                    var person = new Person();
                    if (row.GetCell(0) == null)
                        break;
                    person.Id = row.GetCell(0).StringCellValue;
                    person.IdCard = row.GetCell(1).StringCellValue;
                    person.Name = row.GetCell(2).StringCellValue;
                    person.PhoneNumber = row.GetCell(7).StringCellValue;
                    Persons.List.Add(person);
                }
            }
        }

        private void PersonsGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if((bool)PersonsGridView.Rows[e.RowIndex].Cells[0].EditedFormattedValue)
            {
                var id = PersonsGridView.Rows[e.RowIndex].Cells[1].EditedFormattedValue.ToString();
                Persons.List.FirstOrDefault(x => x.Id == id).Selected = true;
            }
        }

        private void BtnOpenLottery_Click(object sender, EventArgs e)
        {
            if(Persons.List.Count>0)
            {
                var form = new LotteryForm();
                form.Show();
            }
        }
    }
}
