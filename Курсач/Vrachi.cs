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
    public partial class Vrachi : Form
    {
        DataBase database = new DataBase();
        public Vrachi()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Введите полные данные о враче!");
                return;
            }

            if (checkuser1())
                return;

            var FIO = textBox1.Text;
            var Pol = textBox2.Text;
            var Dolznost = textBox3.Text;
            var Rogz = textBox4.Text;
            var Staz = textBox5.Text;


            string querystring = $"insert into vrachi(Pol, FIO, Dolznost, Data_rogz, Staz) values ('{Pol}','{FIO}','{Dolznost}','{Rogz}','{Staz}')";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Врач успешно добавлен!", "Успешно");
                Врачи frm_vrach = new Врачи();
                this.Hide();
                frm_vrach.ShowDialog();

            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
            database.closeConnection();

        }


        private Boolean checkuser1()
        {
            var FIO_vrach = textBox1.Text;
            var Dolznost_vrach = textBox3.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from vrachi where FIO = '{FIO_vrach}'and Dolznost = '{Dolznost_vrach}'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Врач уже добавлен!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Врачи frm_vrach = new Врачи();
            frm_vrach.Show();
            this.Hide();
        }

    }
}
