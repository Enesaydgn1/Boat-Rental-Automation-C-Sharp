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

namespace TekneKiralamaOtomasyonu
{
    public partial class Kullanici_Admin : Form
    {
        public Kullanici_Admin()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");

        private void kullanicilar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Kullanici ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Ad"].ToString());
                ekle.SubItems.Add(oku["Soyad"].ToString());
                ekle.SubItems.Add(oku["Mail"].ToString());
                ekle.SubItems.Add(oku["KullaniciAdi"].ToString());
                ekle.SubItems.Add(oku["Sifre"].ToString());
                ekle.SubItems.Add(oku["Yetki"].ToString());
                listView1.Items.Add(ekle);
                listView1.Refresh();
            }
         baglanti.Close();

        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                textBox1.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tarih.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_ad.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_soyad.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_mail.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txt_kad.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txt_sifre.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txt_yetki.Text = listView1.SelectedItems[0].SubItems[7].Text;

            }
        }


        bool durum;
        void mukerrer()
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from Kullanici where KullaniciAdi=@KullaniciAdi", baglanti);
            sorgu.Parameters.AddWithValue("@KullaniciAdi", txt_kad.Text);

            SqlDataReader dr = sorgu.ExecuteReader();

            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            baglanti.Close();
        }




        private void Kullanici_Admin_Load(object sender, EventArgs e)
        {
            kullanicilar();
        }

        private void K_Ekle_Click(object sender, EventArgs e)
        {
            mukerrer();

            if (txt_ad.Text.Trim() == "" || txt_kad.Text.Trim() == "" || txt_mail.Text.Trim() == "" || txt_soyad.Text.Trim() == "" || txt_sifre.Text.Trim() == "")

                MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);


            else
            {

                DateTime tarih = DateTime.Now;

                if (durum == true)
                {
                    baglanti.Open();
                    string sorgu = "Insert into Kullanici(Ad,Soyad,KullaniciAdi,Sifre,Tarih,Mail,Yetki)" +
                  "values (@Ad,@Soyad,@KullaniciAdi,@Sifre,@Tarih,@Mail,@Yetki)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);


                    komut.Parameters.AddWithValue("@Ad", txt_ad.Text);
                    komut.Parameters.AddWithValue("@Soyad", txt_soyad.Text);
                    komut.Parameters.AddWithValue("@KullaniciAdi", txt_kad.Text);
                    komut.Parameters.AddWithValue("@Sifre", txt_sifre.Text);
                    komut.Parameters.AddWithValue("@Mail", txt_mail.Text);
                    komut.Parameters.AddWithValue("@Yetki", txt_yetki.Text);
                    komut.Parameters.AddWithValue("@Tarih", tarih);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Oluşturulmuştur.");
                    textClear();
                    string[] row = { textBox1.Text, txt_tarih.Text, txt_ad.Text, txt_soyad.Text, txt_mail.Text, txt_kad.Text, txt_sifre.Text, txt_yetki.Text };
                    var satir = new ListViewItem(row);
                    listView1.Items.Add(satir);
                    baglanti.Close();
                    listView1.Items.Clear();
                    kullanicilar();
                }
                else
                {
                    MessageBox.Show("Bu kayıt zaten var", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }



            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {

            try
            {

                DialogResult durum = MessageBox.Show("kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (durum == DialogResult.Yes)
                {
                    baglanti.Open();
                    DateTime tarih = DateTime.Now;
                    SqlCommand sorgu = new SqlCommand("DELETE from Kullanici where id=@id2", baglanti);
                    sorgu.Parameters.AddWithValue("@id2", textBox1.Text);
                    sorgu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    listView1.Items.Clear();
                    kullanicilar();
                    textClear();

                }



            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Listeden bir seçim yapmalısınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }
        void textClear()
        {
            textBox1.Clear();
            txt_kad.Clear();
            txt_ad.Clear();
            txt_mail.Clear();
            txt_sifre.Clear();
            txt_soyad.Clear();
            txt_tarih.Clear();
            txt_yetki.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txt_ad.Text.Trim() == "" || txt_kad.Text.Trim() == "" || txt_mail.Text.Trim() == "" || txt_soyad.Text.Trim() == "" || txt_sifre.Text.Trim() == "")

                MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {

                DateTime tarih = DateTime.Now;


                baglanti.Open();
                string sorgu = "Update Kullanici set Ad=@Ad,Soyad=@Soyad,Mail=@Mail,KullaniciAdi=@KullaniciAdi,Sifre=@Sifre,Yetki=@Yetki,Tarih=@Tarih where id=@id ";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@id", textBox1.Text);
                komut.Parameters.AddWithValue("@Ad", txt_ad.Text);
                komut.Parameters.AddWithValue("@Soyad", txt_soyad.Text);
                komut.Parameters.AddWithValue("@KullaniciAdi", txt_kad.Text);
                komut.Parameters.AddWithValue("@Sifre", txt_sifre.Text);
                komut.Parameters.AddWithValue("@Mail", txt_mail.Text);
                komut.Parameters.AddWithValue("@Yetki", txt_yetki.Text);
                komut.Parameters.AddWithValue("@Tarih", tarih);
                komut.ExecuteNonQuery();
                baglanti.Close();
                listView1.Items.Clear();
                kullanicilar();
                MessageBox.Show("Kullanıcı Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textClear();



            }
        }

        private void Clear_button_Click(object sender, EventArgs e)
        {
            textClear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
