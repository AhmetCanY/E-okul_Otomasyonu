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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }
        OleDbConnection baglantı = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Ödev.mdb");
        private void Form10_Load(object sender, EventArgs e)
        {
            label2.Text=Form3.numara.ToString();
            baglantı.Open();
            OleDbCommand komut = new OleDbCommand("Select * from Öğrenci where Öğrenci_No Like '" + label2.Text + "%'", baglantı);
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            Hide();
        }
    }
}
