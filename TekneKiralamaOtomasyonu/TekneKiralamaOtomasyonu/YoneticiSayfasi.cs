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
    public partial class YoneticiSayfasi : Form
    {
        public YoneticiSayfasi()
        {
            InitializeComponent();
        }

 
        void panelgetr(Form pnl)
        {
            panel3.Controls.Clear();
            pnl.TopLevel = false;
            panel3.Controls.Add(pnl);
            pnl.Show();
            pnl.Dock = DockStyle.Fill;
            pnl.BringToFront();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void YoneticiSayfasi_Load(object sender, EventArgs e)
        {
            Kullanici_Admin kullanicilar = new Kullanici_Admin();
            panelgetr(kullanicilar);
        }


        private void pictureBox8_Click(object sender, EventArgs e)
        {
            GirisYap login = new GirisYap();
            login.Show();
            this.Hide();
        }

   
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Kullanici_Admin kullanicilar = new Kullanici_Admin();
            panelgetr(kullanicilar);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Yatlar_Admin yat_admin = new Yatlar_Admin();
            panelgetr(yat_admin);
        }

 

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (durum == DialogResult.Yes)
            {
                GirisYap login = new GirisYap();
                login.Show();
                this.Hide();
            }
          
        }

      
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Rezervasyon rezerve = new Rezervasyon();
            panelgetr(rezerve);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
