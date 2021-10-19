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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ödev.mdb");
        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yanıt;
            yanıt = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yanıt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" )
            {
                baglantı.Open();
                OleDbCommand komut = new OleDbCommand("insert into Öğretmen_Kullanıcı (Kullanıcı_Adı,Şifre) values('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "')", baglantı);              
                komut.ExecuteNonQuery();
                baglantı.Close();
                textBox1.Clear();
                textBox2.Clear();
                MessageBox.Show(" Kayıt Başarılı..! ");
            }
            else
            {
                MessageBox.Show("Kayıtda Bir Eksiklik Var...!");
            }
        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }
    }
}
