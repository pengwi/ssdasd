using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;

namespace УчетКТ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.ktechTableAdapter.Fill(this.DataSet1.ktech);
            dataGridView1.DataSource = DataSet1.ktech;
            dataGridView2.DataSource = DataSet1.rem_ob;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void файлToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            DataView dv = DataSet1.ktech.DefaultView;
            dv.RowFilter = "type LIKE '" + checkedListBox1.SelectedItem + "%'";
            dataGridView1.DataSource = dv;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "DataSet1.ktech". При необходимости она может быть перемещена или удалена.
            this.ktechTableAdapter.Fill(this.DataSet1.ktech);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ktechTableAdapter.Update(DataSet1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataRow row = DataSet1.ktech.NewRow();
            DataSet1.ktech.Rows.Add(row);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                DataSet1.rem_ob.Rows.Add(row);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ktechTableAdapter.Update(DataSet1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }
        }

        private void отчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
                exApp.Visible = true;
                exApp.Workbooks.Add();
                Worksheet workSheet = (Worksheet)exApp.ActiveSheet;
                //workSheet.EnableSelection = Microsoft.Office.Interop.Excel.XlEnableSelection.xlNoSelection;
                workSheet.Cells[1, "A"] = "ID";
                workSheet.Cells[1, 2] = "type";
                workSheet.Cells[1, 3] = "us";
                workSheet.Cells[1, 4] = "techchar";
                workSheet.Cells[1, 5] = "uch_num";
                workSheet.Cells[1, 6] = "price";
                workSheet.Cells[1, 7] = "date_p";
                workSheet.Cells[1, 8] = "garant";
                workSheet.Cells[1, 9] = "auditory";
                int rowExcel = 2;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    workSheet.Cells[rowExcel, "A"] = dataGridView1.Rows[i].Cells["ID"].Value;
                    workSheet.Cells[rowExcel, "B"] = dataGridView1.Rows[i].Cells["type"].Value;
                    workSheet.Cells[rowExcel, "C"] = dataGridView1.Rows[i].Cells["us"].Value;
                    workSheet.Cells[rowExcel, "D"] = dataGridView1.Rows[i].Cells["techchar"].Value;
                    workSheet.Cells[rowExcel, "E"] = dataGridView1.Rows[i].Cells["uch_num"].Value;
                    workSheet.Cells[rowExcel, "F"] = dataGridView1.Rows[i].Cells["price"].Value;
                    workSheet.Cells[rowExcel, "G"] = dataGridView1.Rows[i].Cells["date_p"].Value.ToString();
                    workSheet.Cells[rowExcel, "H"] = dataGridView1.Rows[i].Cells["garant"].Value;
                    workSheet.Cells[rowExcel, "I"] = dataGridView1.Rows[i].Cells["auditory"].Value;
                    ++rowExcel;
                    exApp.Columns.AutoFit();
                }
                workSheet.SaveAs("MyFile.xls");
                exApp.Quit();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
