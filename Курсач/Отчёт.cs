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

    enum RoWState2
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }
    public partial class Отчёт : Form
    {
        DataBase dataBase = new DataBase();

        public Отчёт()
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

        private void Отчёт_Load(object sender, EventArgs e)
        {
            CreateColums();
            RefreshDataGrid(dataGridView2);
        }

        private void CreateColums()
        {
            dataGridView2.Columns.Add("id_vuzova", "Номер вызова");
            dataGridView2.Columns.Add("id_pac", "Номер пациента");
            dataGridView2.Columns.Add("FIO_pac", "ФИО пациента");
            dataGridView2.Columns.Add("Adress", "Адрес");
            dataGridView2.Columns.Add("id_vracha", "Номер врача");
            dataGridView2.Columns.Add("FIO_vracha", "ФИО врача");
            dataGridView2.Columns.Add("Dolznost", "Специальность врача");
            dataGridView2.Columns.Add("Data_vuzova", "Дата вызова");
            dataGridView2.Columns.Add("Prichina_vuzova", "Причина вызова");
            dataGridView2.Columns.Add("Dop_infa", "Доп.информация");
            dataGridView2.Columns.Add("IsNew", String.Empty);
        }

        private void ReadSingleRow(DataGridView dwg, IDataRecord record)
        {
            dwg.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetString(2), record.GetString(3), record.GetInt32(4), record.GetString(5), record.GetString(6), record.GetDateTime(7), record.GetString(8), record.GetString(9), RoWState.ModifiedNew);
        }

        private void RefreshDataGrid(DataGridView dwg)
        {
            dwg.Rows.Clear();

            string queryString = $"SELECT * FROM vuzov";

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

            string searchString = $"SELECT * FROM  zdorovie.dbo.vuzov where FIO_pac like '%" + textBox1.Text + "%'";

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
            Search(dataGridView2);
        }

        
    }
}
