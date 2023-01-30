using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TekneKiralamaOtomasyonu
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      

        public void formgetir(Form frm)
        {
            panel3.Controls.Clear();
            frm.TopLevel = false;
            panel3.Controls.Add(frm);
            frm.Show();
            frm.Dock = DockStyle.Fill;
            frm.BringToFront();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Yatlar yatlar = new Yatlar();
            formgetir(yatlar);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
            Yatlarimiz yatlarimiz = new Yatlarimiz();
            formgetir(yatlarimiz);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
           Organizasyon org = new Organizasyon();
           formgetir(org);
        }

    

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           Galeri galeri = new Galeri();
           formgetir(galeri);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox8_Click_1(object sender, EventArgs e)
        {
            GirisYap login = new GirisYap();
            login.Show();
            this.Hide();
        }

        private void pictureBox8_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
        private void Anasayfa_Load(object sender, EventArgs e)
        {
            Yatlarimiz yatlarimiz = new Yatlarimiz();
            formgetir(yatlarimiz);
        }

        private void pictureBox4_Click_2(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (durum == DialogResult.Yes)
            {
                GirisYap login = new GirisYap();
                login.Show();
                this.Hide();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }
    }
}
