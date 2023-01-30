using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TekneKiralamaOtomasyonu
{
    public partial class KayitOl : Form
    {
        public KayitOl()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");

        private void KayitOl_Load(object sender, EventArgs e)
        {

        }
    

        bool durum;
        void mukerrer()
        {
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("select * from Kullanici where KullaniciAdi=@KullaniciAdi ", baglan);
            sorgu.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);

            SqlDataReader dr = sorgu.ExecuteReader();

            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglan.Close();
        }

        
        private void button1_Click_1(object sender, EventArgs e)
        {
            mukerrer();

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                boslukhata.Text = "Lüfen Boşluk Bırakmayınız !";
            }
            else
            {
                if (durum == true)
                {  
                DateTime tarih = DateTime.Now;
                baglan.Open();
                string sorgu = "Insert into Kullanici(Ad,Soyad,KullaniciAdi,Sifre,Tarih,Mail)" +
              "values (@Ad,@Soyad,@KullaniciAdi,@Sifre,@Tarih,@Mail)";
                SqlCommand komut = new SqlCommand(sorgu, baglan);
                
                komut.Parameters.AddWithValue("@Ad", textBox1.Text);
                komut.Parameters.AddWithValue("@Soyad", textBox2.Text);
                komut.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);
                komut.Parameters.AddWithValue("@Sifre", textBox4.Text);
                komut.Parameters.AddWithValue("@Mail", textBox5.Text);
                komut.Parameters.AddWithValue("@Tarih", tarih);
                komut.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Oluşturulmuştur. Hoşgeldiniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GirisYap girisyap = new GirisYap();
                girisyap.Show();
                this.Hide();
                baglan.Close();

                }
                else
                {
                    MessageBox.Show("Bu kayıt zaten var!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             
            } 
            

        }
   
        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void girisyap_Click(object sender, EventArgs e)
        {
            GirisYap girisyap = new GirisYap();
            girisyap.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
