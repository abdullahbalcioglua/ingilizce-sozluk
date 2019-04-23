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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection (@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\acer\Desktop\dbSozluk.mdb");

        private void Form1_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizce from sozluk", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            
            while(dr.Read())
            {
                listBox1.Items.Add(dr[0].ToString());
            }
            baglanti.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select turkce from sozluk where ingilizce=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1",listBox1.SelectedItem);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text=dr[0].ToString();
            }
            baglanti.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("Select ingilizce from sozluk where ingilizce like '"+textBox1.Text+"%'", baglanti);
            OleDbDataReader dr = komut.ExecuteReader(); 
            while(dr.Read())
            {
                listBox1.Items.Add(dr[0]);
            }
            baglanti.Close(); 
        }
    }
}
