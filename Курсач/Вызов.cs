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
    public partial class Вызов : Form
    {
        DataBase dataBase = new DataBase();
        public Вызов()
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


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Введите полные данные о вызове!");
                return;
            }

            if (checkuser1())
                return;
            var ID_pac = comboBox4.Text;
            var FIO_pac = comboBox1.Text;
            var Adres = textBox2.Text;
            var ID_vrach = comboBox5.Text;
            var FIO_vrach = comboBox2.Text;
            var Dolznost = comboBox3.Text;
            var Data_vuz = textBox5.Text;
            var Prich_vuz = textBox6.Text;
            var Dop_inf = textBox7.Text;


            string querystring = $"insert into vuzov(id_pac,FIO_pac,Adress,id_vracha,FIO_vracha,Dolznost,Data_vuzova,Prichina_vuzova,Dop_infa) values('{ID_pac}','{FIO_pac}','{Adres}','{ID_vrach}','{FIO_vrach}','{Dolznost}','{Data_vuz}','{Prich_vuz}','{Dop_inf}')";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            dataBase.openConnection();


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Вызов успешно создан!", "Успешно");
                Главная frm_1 = new Главная();
                this.Hide();
                frm_1.ShowDialog();

            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkuser1()
        {
            
            var FIO_pac = comboBox1.Text;
            var Data_vuz = textBox5.Text;
            

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from vuzov where FIO_pac = '{FIO_pac}'and Data_vuzova = '{Data_vuz}'";

            SqlCommand command = new SqlCommand(querystring, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Вызов уже сделан!");
                return true;
            }
            else
            {
                return false;
            }


        }

        private void Вызов_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zdorovieDataSet3.vrachi". При необходимости она может быть перемещена или удалена.
            this.vrachiTableAdapter.Fill(this.zdorovieDataSet3.vrachi);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "zdorovieDataSet3.pacient". При необходимости она может быть перемещена или удалена.
            this.pacientTableAdapter.Fill(this.zdorovieDataSet3.pacient);

        }
    }
}
