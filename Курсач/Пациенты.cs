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
    enum RoWState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Пациенты : Form
    {
        DataBase dataBase = new DataBase();
        public Пациенты()
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

        private void Пациенты_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView1);
        }
        private void CreateColums()
        {
            dataGridView1.Columns.Add("id_pac", "Номер пациента");
            dataGridView1.Columns.Add("Pol", "Пол");
            dataGridView1.Columns.Add("FIO", "ФИО");
            dataGridView1.Columns.Add("Data_rogz", "Дата рождения");
            dataGridView1.Columns.Add("Adress", "Адрес");
            dataGridView1.Columns.Add("Polis", "Мед.полис");
            dataGridView1.Columns.Add("pasport", "Паспорт");
            dataGridView1.Columns.Add("invalidnost", "Инвалидность");
            dataGridView1.Columns.Add("chron_zab", "Хрон. заболевания");
            dataGridView1.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetDateTime(3), record.GetString(4), record.GetString(5), record.GetString(6), record.GetString(7), record.GetString(8), RoWState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"SELECT * FROM pacient";

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

            string searchString = $"SELECT * FROM  zdorovie.dbo.pacient where Polis like '%" + textBox1.Text + "%'";

            SqlCommand com = new SqlCommand(searchString, dataBase.GetConnection());

            dataBase.openConnection();

            SqlDataReader read = com.ExecuteReader();

            while (read.Read())
            {
                ReadSingleRow(dwg, read);
            }

            read.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Search(dataGridView1);
        }

        private void deleteRow()
        {
            int index = dataGridView1.CurrentCell.RowIndex;

            dataGridView1.Rows[index].Visible = false;

            if (dataGridView1.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView1.Rows[index].Cells[9].Value = RoWState.Deleted;
                return;
            }

            dataGridView1.Rows[index].Cells[9].Value = RoWState.Deleted;

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            deleteRow();
        }
        private void Update1()
        {
            dataBase.openConnection();

            for (int index = 0; index < dataGridView1.Rows.Count; index++)
            {
                var rowState = (RoWState)dataGridView1.Rows[index].Cells[9].Value;

                if (rowState == RoWState.Existed)
                    continue;

                if (rowState == RoWState.Deleted)
                {
                    var ID = Convert.ToInt32(dataGridView1.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from pacient where id_pac = {ID}";

                    var command = new SqlCommand(deleteQuery, dataBase.GetConnection());
                    command.ExecuteNonQuery();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Update1();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Pacient frm_pac = new Pacient();
            frm_pac.Show();
            this.Hide();

        }
    }
}
