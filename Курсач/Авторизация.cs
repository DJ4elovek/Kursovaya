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
    public partial class Log_in : Form
    {
        DataBase database = new DataBase();

        public Log_in()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }


        private void Log_in_Load(object sender, EventArgs e)
        {
            textBox_password.PasswordChar = '*';
            textBox_login.MaxLength = 50;
            textBox_password.MaxLength = 50;

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (textBox_login.Text =="")
            {
                MessageBox.Show("Введите логин!");
                return;
            }

            if (textBox_password.Text == "")
            {
                MessageBox.Show("Введите пароль!");
                return;
            }

            string loginUser = textBox_login.Text;
            string pusUser = textBox_password.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string querystring = $"select * from dispetcher where login_dis = '{loginUser}'and password_dis = '{pusUser}' ";

            SqlCommand command = new SqlCommand(querystring, database.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Вход успешно выполнен!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Главная frm1 = new Главная();
                this.Hide();
                frm1.ShowDialog();
            }
            else
            
                MessageBox.Show("Такого аккаунта не существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sign frm_sign = new sign();
            frm_sign.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = true;
            pictureBox3.Visible = false;
            pictureBox1.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            textBox_password.UseSystemPasswordChar = false;
            pictureBox3.Visible = true;
            pictureBox1.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_login.Text = "";
            textBox_password.Text = "";
        }

    }
}
