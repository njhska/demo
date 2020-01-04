using NPOI.HSSF.UserModel;
using System;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace LotteryProgram
{
    public partial class ManageForm : Form
    {
        private string filePath;

        public ManageForm()
        {
            InitializeComponent();
        }

        private void BtnOpenDialog_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            filePath = openFileDialog.FileName;
            if (filePath.ToLower().EndsWith(".xls") || filePath.ToLower().EndsWith(".xlsx"))
            {
                TextFile.Text = Path.GetFileName(filePath);
            }
            else
            {
                MessageBox.Show("请选择一个excel文件");
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TextFile.Text))
            {
                MessageBox.Show("请先选择一个excel文件");
            }
            else
            {
                ImportDatas(filePath);
                MessageBox.Show("导入成功！");
                PersonsDataGrid.DataSource = GetDatas();
            }
        }

        private static void ImportDatas(string excelPath)
        {
            using (var fsRead = new FileStream(excelPath, FileMode.Open))
            {
                var sql = string.Empty;
                var wkBook = new HSSFWorkbook(fsRead);
                var sheet = wkBook.GetSheetAt(0);
                for (int i = 1; i < sheet.PhysicalNumberOfRows; i++)
                {
                    var row = sheet.GetRow(i);
                    if (row.GetCell(0) == null)
                        break;
                    sql = "insert into Persons(Id,IdCard,[Name],PhoneNumber) values(@id,@idcard,@name,@phone)";
                    var sqlparmas = new SqlParameter[] {
                        new SqlParameter("@id",row.GetCell(0).StringCellValue),
                        new SqlParameter("@idcard",row.GetCell(1).StringCellValue),
                        new SqlParameter("@name",row.GetCell(2).StringCellValue),
                        new SqlParameter("@phone",row.GetCell(7).StringCellValue)
                    };
                    SqlHelper.ExecuteNonquery(sql,sqlparmas);
                }
            }
        }

        private static DataTable GetDatas()
        {
            var sql = "select [Level] as 优先级,Id as 学号,IdCard as 身份证号,[Name] as 姓名,PhoneNumber as 电话 from Persons order by Id";
            var result = SqlHelper.Query(sql);
            return result;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in PersonsDataGrid?.Rows)
            {
                if(!string.IsNullOrEmpty(row.Cells[0].FormattedValue.ToString()))
                {
                    int level;
                    if(int.TryParse(row.Cells[0].FormattedValue.ToString(),out level))
                    {
                        var sql = "update Persons set [Level] = @level where Id = @id";
                        var sqlparmas = new SqlParameter[] {
                            new SqlParameter("@level",level),
                            new SqlParameter("@id",row.Cells[1].FormattedValue.ToString())
                        };
                        var n = SqlHelper.ExecuteNonquery(sql, sqlparmas);
                    }
                }
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var sql = "select [Level] as 优先级,Id as 学号,IdCard as 身份证号,[Name] as 姓名,PhoneNumber as 电话 from Persons where 1=1";
            if(!string.IsNullOrWhiteSpace(TextNumber.Text))
            {
                sql += $" and Id = '{TextNumber.Text.Trim()}'";
            }
            var result = SqlHelper.Query(sql);
            PersonsDataGrid.DataSource = result;
        }
    }
}
