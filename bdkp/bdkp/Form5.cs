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

    public partial class Form5 : Form
    {
        string login = "admin";
        string password = "1234";
        public Form5()
        {
            InitializeComponent();
        }

        private void наушникиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.наушникиBindingSource.EndEdit();
            this.наушникиTableAdapter.Update(this.database2DataSet);
            MessageBox.Show("Обновление успешно завершено");

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "database2DataSet.Наушники". При необходимости она может быть перемещена или удалена.
            this.наушникиTableAdapter.Fill(this.database2DataSet.Наушники);
            наушникиBindingNavigator.Hide();
            закончитьРедактированиеToolStripMenuItem.Visible = false;
            наушникиDataGridView.ReadOnly = true;
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
            наушникиBindingNavigator.Hide();
            закончитьРедактированиеToolStripMenuItem.Visible = false;
            изменитьЛогинИПарольToolStripMenuItem.Visible = false;
            panel2.Hide();
            наушникиDataGridView.Update();
            наушникиDataGridView.ReadOnly = true;
            редактироватьToolStripMenuItem.Enabled = true;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            наушникиBindingSource.EndEdit();
            наушникиTableAdapter.Update(this.database2DataSet.Наушники);
        
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == login) && (textBox2.Text == password))
            {
                panel1.Hide();
                наушникиBindingNavigator.Show();
                закончитьРедактированиеToolStripMenuItem.Visible = true;
                наушникиDataGridView.ReadOnly = false;
                изменитьЛогинИПарольToolStripMenuItem.Visible = true;
                редактироватьToolStripMenuItem.Enabled = false;
                textBox1.Text = "";
                textBox2.Text = "";
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
