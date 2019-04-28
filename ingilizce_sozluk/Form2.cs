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

namespace ingilizce_sozluk
{
    public partial class Form2 : Form
    {

        OleDbConnection baglantim = new OleDbConnection("provider=Microsoft.ACE.OleDb.12.0;Data Source=veri_sozluk.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();

        public Form2()
        {
            InitializeComponent();
        }














        private void button2_Click(object sender, EventArgs e)
        {
            
          
                komut = new OleDbCommand();
                baglantim.Open();
                komut.Connection = baglantim;
                komut.CommandText = "update ingturkce set turkce= ' " + textBox2.Text + " ' , where ingilize= ' " + textBox1.Text + " ' ";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglantim.Close();
                ds.Clear();

                /*
                baglantim.Open();
                OleDbCommand guncelleKomutu = new OleDbCommand("update ingturkce set turkce=' " + textBox2.Text + " 'where ingilize=' " + textBox1.Text + " '", baglantim);
                guncelleKomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("sozluk veri tabanina guncellendi", "veri tabani islemleri");
                textBox1.Clear();
                textBox2.Clear(); */
            
        }


















        private void Form2_Load(object sender, EventArgs e)
        {

        }























        private void button1_Click(object sender, EventArgs e)
        {
                
                komut.Connection = baglantim;
                komut.CommandText = "insert into ingturkce(ingilize,turkce) values(' " + textBox1.Text + " ' ,'" + textBox2.Text + " ')";
                baglantim.Open();
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglantim.Close();
                ds.Clear();

                /* baglantim.Open();
                 OleDbCommand ekleKomutu = new OleDbCommand("insert into ingturkce(ingilize,turkce)values(' " + textBox1.Text + " ' ,'" + textBox2.Text + " ')", baglantim);
                 ekleKomutu.ExecuteNonQuery();
                 baglantim.Close();
                 MessageBox.Show("sozcuk veri tabanina eklendi");
                 textBox1.Clear();
                 textBox2.Clear(); */
            

            
        }



























        private void button3_Click(object sender, EventArgs e)
        {
                baglantim.Open();
                komut.Connection = baglantim;
                komut.CommandText = "delete from ingturkce where ingilize =" + textBox1.Text + "";
                komut.ExecuteNonQuery();
                komut.Dispose();
                baglantim.Close();
                ds.Clear();
                /*baglantim.Open();
                OleDbCommand silKomutu = new OleDbCommand("delete from ingturkce where ingilize= "+ textBox1.Text + " " , baglantim);
                silKomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("sozcuk veri tabanindan silindi", "veri tabani islemleri");
                textBox1.Clear();
                textBox2.Clear(); */
            

        }
    }
}
