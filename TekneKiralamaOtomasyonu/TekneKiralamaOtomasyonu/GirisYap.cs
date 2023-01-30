using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TekneKiralamaOtomasyonu
{
    public partial class GirisYap : Form
    {
        public GirisYap()
        {
            InitializeComponent();
         
        }

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");
     

        private void GirisYap_Load(object sender, EventArgs e)
        {
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;


            SqlCommand komut2 = new SqlCommand(" select * from  Kullanici where  KullaniciAdi= '" + kullaniciAdi + "'and Sifre= '" + sifre + "'", baglanti);
            SqlDataReader oku2 = komut2.ExecuteReader();


            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (oku2.Read())
            {
                if (oku2["Yetki"].ToString() == "1")
                {
                    YoneticiSayfasi yoneticiSayfasi = new YoneticiSayfasi();
                    yoneticiSayfasi.Show();
                    this.Hide();
                }
                else
                {
                    Anasayfa anasayfa = new Anasayfa();
                    anasayfa.Show();
                    anasayfa.panel3.Controls.Clear();
                    Yatlarimiz yatlarimiz = new Yatlarimiz();
                    yatlarimiz.TopLevel = false;
                    anasayfa.panel3.Controls.Add(yatlarimiz);
                    yatlarimiz.Show();
                    yatlarimiz.Dock = DockStyle.Fill;
                    yatlarimiz.BringToFront();
                    this.Hide();
                }


            }



            else
            {
                MessageBox.Show("Kullanıcı Adı ya da şifre yanlış.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            baglanti.Close();

        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            KayitOl kayitOl = new KayitOl();
            kayitOl.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
