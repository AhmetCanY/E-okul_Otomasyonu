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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ödev.mdb");
        private void Öğrencigörüntüle()
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = ("Select * from Öğrenci");
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["Öğrenci_No"].ToString();
                ekle.SubItems.Add(oku["Adı"].ToString());
                ekle.SubItems.Add(oku["Soyadı"].ToString());
                ekle.SubItems.Add(oku["Türkçe_Not"].ToString());
                ekle.SubItems.Add(oku["Matematik_Not"].ToString());
                ekle.SubItems.Add(oku["Hayat_Bilgisi_Not"].ToString());
                ekle.SubItems.Add(oku["Beden_Eğitimi_Not"].ToString());
                listView1.Items.Add(ekle);
            }
            baglantı.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglantı;
            komut.CommandText = "update Öğrenci set Hayat_Bilgisi_Not='" + textBox6.Text + "'where Öğrenci_No='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            baglantı.Close();
            listView1.Items.Clear();
            Öğrencigörüntüle();
            MessageBox.Show("Hayat Bilgisi Notu Başarılı Bir Şekilde Değiştirildi...!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].SubItems[0].Text == textBox1.Text)
                {
                    textBox2.Text = listView1.Items[i].SubItems[1].Text;
                    textBox3.Text = listView1.Items[i].SubItems[2].Text;
                    textBox4.Text = listView1.Items[i].SubItems[3].Text;
                    textBox5.Text = listView1.Items[i].SubItems[4].Text;
                    textBox7.Text = listView1.Items[i].SubItems[6].Text;
                    textBox2.Enabled = false; textBox3.Enabled = false; textBox6.Enabled = true;
                    textBox4.Enabled = false; textBox5.Enabled = false; textBox7.Enabled = false;
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listView1.FullRowSelect = true;
            Öğrencigörüntüle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult yanıt;
            yanıt = MessageBox.Show(" Çıkış Yapmak İstediğinize Emin Misiniz...?", "Dikkat!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yanıt == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
