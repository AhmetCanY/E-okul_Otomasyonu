using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Ödev
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ödev.mdb");
        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult yanıt;
            yanıt = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yanıt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                baglantı.Open();              
                OleDbCommand komut = new OleDbCommand("insert into Öğrenci (Öğrenci_No,Adı,Soyadı) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text + "')", baglantı);
                komut.ExecuteNonQuery();
                baglantı.Close();
                baglantı.Open();
                OleDbCommand komut1 = new OleDbCommand("insert into Öğrenci_Kullanıcı (Öğrenci_No,Şifre) values('" + textBox1.Text.ToString() + "','" + textBox4.Text.ToString() + "')", baglantı);
                komut1.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                MessageBox.Show(" Kayıt Başarılı..! ");
            }
            else
            {
                MessageBox.Show("Kayıtda Bir Eksiklik Var...!");
            }

        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)&& !char.IsSeparator(e.KeyChar);
        }
    }
}
