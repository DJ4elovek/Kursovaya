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
    public partial class Pacient : Form
    {
        DataBase database = new DataBase();
        public Pacient()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "")
            {
                MessageBox.Show("Введите полные данные о пациенте!");
                return;
            }
            

            if (checkuser1())
                return;
            var FIO = textBox1.Text;
            var Pol = textBox2.Text;
            var Pasport = textBox3.Text;
            var Polis = textBox4.Text;
            var Adres = textBox5.Text;
            var Rogz = textBox6.Text;
            var Inv = textBox7.Text;
            var Chron = textBox8.Text;

            string querystring = $"insert into pacient(Pol,FIO,Data_rogz,Adress,Polis,pasport,invalidnost,chron_zab) values('{Pol}','{FIO}','{Rogz}','{Adres}','{Polis}','{Pasport}','{Inv}','{Chron}')";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Пациент успешно добавлен!", "Успешно");
                Пациенты frm_pac = new Пациенты();
                this.Hide();
                frm_pac.ShowDialog();

            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
            database.closeConnection();
        }


        private Boolean checkuser1()
        {
            var Pasport_pac = textBox3.Text;
            var Polis_pac = textBox4.Text;
            

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from pacient where Polis = '{Polis_pac}'and pasport = '{Pasport_pac}'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пациент уже добавлен!");
                return true;
            }
            else
            {
                return false;
            }


        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Пациенты frm_pac = new Пациенты();
            frm_pac.Show();
            this.Hide();
        }
    }
}
