using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсач
{
    public partial class Главная : Form
    {
        public Главная()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_pacient_Click(object sender, EventArgs e)
        {
            Пациенты frm_pacient = new Пациенты();
            frm_pacient.Show();
            this.Hide();
        }

        private void btnVrach_Click(object sender, EventArgs e)
        {
            Врачи frm_Vrach = new Врачи();
            frm_Vrach.Show();
            this.Hide();
        }

        private void btnVuzov_Click(object sender, EventArgs e)
        {
            Вызов frm_Vuzov = new Вызов();
            frm_Vuzov.Show();
            this.Hide();
        }

        private void btnOtchet_Click(object sender, EventArgs e)
        {
            Отчёт frm_Otchet = new Отчёт();
            frm_Otchet.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
