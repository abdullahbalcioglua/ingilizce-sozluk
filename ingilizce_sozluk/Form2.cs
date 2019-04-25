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
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\veri_sozluk.accdb");

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand guncelleKomutu = new OleDbCommand("update ingturkce set turkce=' " + textBox2.Text + " 'where ingilize=' " + textBox1.Text + " '", baglantim);
                guncelleKomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("sozluk veri tabanina guncellendi", "veri tabani islemleri");
                textBox1.Clear();
                textBox2.Clear();
            }
            catch(Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "veri tabani islemleri");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand ekleKomutu = new OleDbCommand("insert into ingturkce(ingilize,turkce)values(' " + textBox1.Text + " ' ,'" + textBox2.Text + " ')", baglantim);
                ekleKomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("sozcuk veri tabanina eklendi");
                textBox1.Clear();
                textBox2.Clear();
            }

            catch(Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "veri tabani islemleri");
                baglantim.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand silKomutu = new OleDbCommand("delete from ingturkce where ingilize='"+textBox1.Text+"'", baglantim);
                silKomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("sozcuk veri tabanindan silindi", "veri tabani islemleri");
                textBox1.Clear();
                textBox2.Clear(); 
            }
            catch(Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "veri tabani islemleri");
                baglantim.Close();
            }

        }
    }
}
