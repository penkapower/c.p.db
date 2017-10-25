using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace bdkp
{

    public partial class Form4 : Form
    {
        string login = "admin";
        string password = "1234";
        public Form4()
        {
            InitializeComponent();
        }

        private void мышиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.мышиBindingSource.EndEdit();
            this.мышиTableAdapter.Update(this.database2DataSet);
            MessageBox.Show("Обновление успешно завершено");

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database2DataSet.Мыши". При необходимости она может быть перемещена или удалена.
            this.мышиTableAdapter.Fill(this.database2DataSet.Мыши);
            мышиBindingNavigator.Hide();
            закончитьРедактированиеToolStripMenuItem.Visible = false;
            мышиDataGridView.ReadOnly = true;
            изменитьЛогинИПарольToolStripMenuItem.Visible = false;
            panel1.Hide();
            panel2.Hide();
            textBox3.Text = password;
            textBox4.Text = login; 
        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel1.Show();
        }

        private void закончитьРедактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            мышиBindingNavigator.Hide();
            закончитьРедактированиеToolStripMenuItem.Visible = false;
            изменитьЛогинИПарольToolStripMenuItem.Visible = false;
            panel2.Hide();
         мышиDataGridView.Update();
            мышиDataGridView.ReadOnly = true;
            редактироватьToolStripMenuItem.Enabled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            мышиBindingSource.EndEdit();
           мышиTableAdapter.Update(this.database2DataSet.Мыши);
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == login) && (textBox2.Text == password))
            {
                panel1.Hide();
                мышиBindingNavigator.Show();
                закончитьРедактированиеToolStripMenuItem.Visible = true;
                мышиDataGridView.ReadOnly = false;
                изменитьЛогинИПарольToolStripMenuItem.Visible = true;
                textBox1.Text = "";
                textBox2.Text = "";
                редактироватьToolStripMenuItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login = textBox4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            password = textBox3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void изменитьЛогинИПарольToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.panel2.Show();
        }
    }
}
