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
    public partial class sign : Form
    {
        DataBase database = new DataBase();
        public sign()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Регистрация_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';

        }

        private void btnCreate_Click_1(object sender, EventArgs e)
        {
            if (textBox_login2.Text == "")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (textBox_password2.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }
            if (checkuser())
                return;
            var login = textBox_login2.Text;
            var password = textBox_password2.Text;

            string querystring = $"insert into dispetcher(login_dis,password_dis) values('{login}','{password}')";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            database.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт успешно создан!", "Успешно");
                Log_in frm_login = new Log_in();
                this.Hide();
                frm_login.ShowDialog();

            }
            else
            {
                MessageBox.Show("Ошибка ввода данных!");
            }
            database.closeConnection();
        }

        private Boolean checkuser()
        {
            string loginUser = textBox_login2.Text;
            string passwordUser = textBox_password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string querystring = $"select * from dispetcher where login_dis = '{loginUser}'and password_dis = '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Аккаунт уже существует!");
                return true;
            }
            else
            {
                return false;
            }


        }


    }
}
