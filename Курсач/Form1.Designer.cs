
namespace Курсач
{
    partial class Главная
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnVrach = new System.Windows.Forms.Button();
            this.btnVuzov = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btn_pacient = new System.Windows.Forms.Button();
            this.btnOtchet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnVrach
            // 
            this.btnVrach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVrach.Location = new System.Drawing.Point(325, 194);
            this.btnVrach.Name = "btnVrach";
            this.btnVrach.Size = new System.Drawing.Size(150, 53);
            this.btnVrach.TabIndex = 18;
            this.btnVrach.Text = "Список врачей";
            this.btnVrach.UseVisualStyleBackColor = true;
            this.btnVrach.Click += new System.EventHandler(this.btnVrach_Click);
            // 
            // btnVuzov
            // 
            this.btnVuzov.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnVuzov.Location = new System.Drawing.Point(325, 285);
            this.btnVuzov.Name = "btnVuzov";
            this.btnVuzov.Size = new System.Drawing.Size(150, 53);
            this.btnVuzov.TabIndex = 19;
            this.btnVuzov.Text = "Вызов";
            this.btnVuzov.UseVisualStyleBackColor = true;
            this.btnVuzov.Click += new System.EventHandler(this.btnVuzov_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExit.Location = new System.Drawing.Point(638, 385);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(150, 53);
            this.btnExit.TabIndex = 20;
            this.btnExit.Text = "Выход из приложения";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btn_pacient
            // 
            this.btn_pacient.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_pacient.Location = new System.Drawing.Point(325, 103);
            this.btn_pacient.Name = "btn_pacient";
            this.btn_pacient.Size = new System.Drawing.Size(150, 53);
            this.btn_pacient.TabIndex = 21;
            this.btn_pacient.Text = "Пациенты";
            this.btn_pacient.UseVisualStyleBackColor = true;
            this.btn_pacient.Click += new System.EventHandler(this.btn_pacient_Click);
            // 
            // btnOtchet
            // 
            this.btnOtchet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnOtchet.Location = new System.Drawing.Point(325, 373);
            this.btnOtchet.Name = "btnOtchet";
            this.btnOtchet.Size = new System.Drawing.Size(150, 53);
            this.btnOtchet.TabIndex = 22;
            this.btnOtchet.Text = "Отчёт";
            this.btnOtchet.UseVisualStyleBackColor = true;
            this.btnOtchet.Click += new System.EventHandler(this.btnOtchet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(244, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 39);
            this.label1.TabIndex = 23;
            this.label1.Text = "Вызов врача на дом";
            // 
            // Главная
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOtchet);
            this.Controls.Add(this.btn_pacient);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnVuzov);
            this.Controls.Add(this.btnVrach);
            this.Name = "Главная";
            this.Text = "Главная";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnVrach;
        private System.Windows.Forms.Button btnVuzov;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btn_pacient;
        private System.Windows.Forms.Button btnOtchet;
        private System.Windows.Forms.Label label1;
    }
}