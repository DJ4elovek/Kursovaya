using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Курсач
{
    enum RoWState1
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Врачи : Form
    {
        DataBase dataBase = new DataBase();
        public Врачи()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Главная frm_glavnaya = new Главная();
            frm_glavnaya.Show();
            this.Hide();
        }

        private void Врачи_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }

        private void CreateColums()
        {
            dataGridView1.Columns.Add("id_vracha", "Номер врача");
            dataGridView1.Columns.Add("Pol", "Пол");
            dataGridView1.Columns.Add("FIO", "ФИО");
            dataGridView1.Columns.Add("Dolznost", "Должность врача");
            dataGridView1.Columns.Add("Data_rogz", "Дата рождения");
            dataGridView1.Columns.Add("Staz", "Мед.стаж врача");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), record.GetDateTime(4), record.GetInt32(5), RoWState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"SELECT * FROM vrachi";

            SqlCommand command = new SqlCommand(queryString, dataBase.GetConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow(dwg, reader);
            }
            reader.Close();
        }

        private void Search(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string searchString = $"SELECT * FROM  zdorovie.dbo.vrachi where Dolznost like '%" + textBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dwg, read);
            }

            read.Close();
        }


        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[6].Value = RoWState1.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[6].Value = RoWState1.Deleted;

        }


        private void Update1()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RoWState1)dataGridView1.Rows[index].Cells[6].Value;

                if (rowState == RoWState1.Existed)
                    continue;

                if (rowState == RoWState1.Deleted)
                {
                    var ID = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from vrachi where id_vracha = {ID}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
        }



        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void buttonDelete_Click_1(object sender, EventArgs e)
        {
            deleteRow();
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            Update1();
        }

        private void buttonAdd_Click_1(object sender, EventArgs e)
        {
            Vrachi frm_vrachi = new Vrachi();
            frm_vrachi.Show();
            this.Hide();

        }
    }
}
