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
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TekneKiralamaOtomasyonu
{
    public partial class Yatlar_Admin : Form
    {
        public Yatlar_Admin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");

        private void yatlar()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TekneBilgileri ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["EklenmeTarihi"].ToString());
                ekle.SubItems.Add(oku["TekneAd"].ToString());
                ekle.SubItems.Add(oku["TekneBoyu"].ToString());
                ekle.SubItems.Add(oku["TekneKisiSayisi"].ToString());
                ekle.SubItems.Add(oku["TekneUcret"].ToString());
                ekle.SubItems.Add(oku["TekneKonum"].ToString());
                ekle.SubItems.Add(oku["TekneResim"].ToString());
                ekle.SubItems.Add(oku["TekneIcerik"].ToString());
                listView1.Items.Add(ekle);
                listView1.Refresh();
            }
            baglanti.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Yatlar_Admin_Load(object sender, EventArgs e)
        {
            yatlar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Resim Seç";
            openFileDialog1.Filter = " Jpg Dosyaları(*.jpg)|*.jpg| Png Dosyaları(*.png)|*.png| Tif Dosyaları(*.tif)|*.tif | Jpeg Dostayaları (*.jpeg)|*.jpeg";
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                txt_tekneresmi.Text = openFileDialog1.FileName;
            }
       
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        bool durum;
        void mukerrer()
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri where TekneAd=@TekneAd", baglanti);
            sorgu.Parameters.AddWithValue("@TekneAd", txt_teknead.Text);

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

        private void button2_Click(object sender, EventArgs e)
        {
            mukerrer();
                  
            if (txt_teknead.Text.Trim() == "" || txt_tekneboyu.Text.Trim() == "" ||comboBox1.Text.Trim() == "" || txt_tekneücreti.Text.Trim() == "" )

                MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);


            else
            {

                DateTime tarih = DateTime.Now;

                if (durum == true)
                {
                    string selectedItem = comboBox1.SelectedItem.ToString();
                    baglanti.Open();
                    string sorgu = "Insert into TekneBilgileri(TekneAd,TekneKisiSayisi,TekneKonum,TekneUcret,TekneResim,TekneIcerik,EklenmeTarihi,TekneBoyu)" +
                  "values (@TekneAd,@TekneKisiSayisi,@TekneKonum,@TekneUcret,@TekneResim,@TekneIcreik,@EklenmeTarihi,@TekneBoyu)";
                    SqlCommand komut = new SqlCommand(sorgu, baglanti);

        
                    komut.Parameters.AddWithValue("@TekneAd", txt_teknead.Text);
                    komut.Parameters.AddWithValue("@TekneUcret", txt_tekneücreti.Text);
                    komut.Parameters.AddWithValue("@TekneKisiSayisi", txt_teknekişisayısı.Text);
                    komut.Parameters.AddWithValue("@TekneBoyu", txt_tekneboyu.Text);
                    komut.Parameters.AddWithValue("@TekneKonum", selectedItem);
                    komut.Parameters.AddWithValue("@TekneResim", txt_tekneresmi.Text);
                    komut.Parameters.AddWithValue("@TekneIcreik", txt_icerik.Text);
                    komut.Parameters.AddWithValue("@EklenmeTarihi", tarih);
                   
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Oluşturulmuştur.");
                    textClear();
                    string[] row = { txt_id.Text, txt_tarih.Text, txt_teknead.Text, txt_tekneboyu.Text, txt_teknekişisayısı.Text, txt_tekneücreti.Text,comboBox1.Text, txt_tekneresmi.Text, txt_icerik.Text };
                    var satir = new ListViewItem(row);
                    
                    baglanti.Close();
                    listView1.Items.Clear();
                    yatlar();
                }
                else
                {
                    MessageBox.Show("Bu kayıt zaten var", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

             

            } 
        
        }    
        void textClear()
                {
                    txt_id.Clear();
                    txt_tarih.Clear();
                    txt_teknead.Clear();
                    txt_tekneücreti.Clear();
                    txt_tekneboyu.Clear();
                    txt_tekneresmi.Clear();
                   comboBox1.Text="";
                    txt_icerik.Clear();
                    txt_tarih.Clear();
                    txt_teknekişisayısı.Clear();
                    pictureBox1.Image = null;
        }


        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            
                txt_id.Text = listView1.SelectedItems[0].SubItems[0].Text;
                txt_tarih.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_teknead.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_tekneboyu.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_teknekişisayısı.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txt_tekneücreti.Text = listView1.SelectedItems[0].SubItems[5].Text;
                comboBox1.Text = listView1.SelectedItems[0].SubItems[6].Text;
                txt_tekneresmi.Text = listView1.SelectedItems[0].SubItems[7].Text;
                pictureBox1.ImageLocation = listView1.SelectedItems[0].SubItems[7].Text;
                txt_icerik.Text = listView1.SelectedItems[0].SubItems[8].Text;
            
        }
       

        private void button3_Click(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            if (txt_teknead.Text.Trim() == "" || txt_tekneboyu.Text.Trim() == "" ||comboBox1.Text.Trim() == "" || txt_tekneücreti.Text.Trim() == "")
                MessageBox.Show("Kullanıcı Bilgilerini Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);

            else
            {

                DateTime tarih = DateTime.Now;


                baglanti.Open();
                string sorgu = "Update TekneBilgileri set TekneAd=@TekneAd,TekneUcret=@TekneUcret,TekneKisiSayisi=@TekneKisiSayisi,TekneBoyu=@TekneBoyu,TekneKonum=@TekneKonum,TekneResim=@TekneResim,TekneIcerik=@TekneIcerik,EklenmeTarihi=@EklenmeTarihi where id=@id ";
                SqlCommand komut = new SqlCommand(sorgu, baglanti);

                komut.Parameters.AddWithValue("@id", txt_id.Text);
                komut.Parameters.AddWithValue("@TekneAd", txt_teknead.Text);
                komut.Parameters.AddWithValue("@TekneUcret", txt_tekneücreti.Text);
                komut.Parameters.AddWithValue("@TekneKisiSayisi", txt_teknekişisayısı.Text);
                komut.Parameters.AddWithValue("@TekneBoyu", txt_tekneboyu.Text);
                komut.Parameters.AddWithValue("@TekneKonum", selectedItem);
                komut.Parameters.AddWithValue("@TekneResim", txt_tekneresmi.Text);
                komut.Parameters.AddWithValue("@TekneIcerik", txt_icerik.Text);
                komut.Parameters.AddWithValue("@EklenmeTarihi", tarih);

                komut.ExecuteNonQuery();
                baglanti.Close();
                listView1.Items.Clear();
                yatlar();
                MessageBox.Show("Yat Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                textClear();



            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult durum = MessageBox.Show("kaydı silmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (durum == DialogResult.Yes)
                {
                    baglanti.Open();
                    DateTime tarih = DateTime.Now;
                    SqlCommand sorgu = new SqlCommand("DELETE from TekneBilgileri where id=@id2", baglanti);
                    sorgu.Parameters.AddWithValue("@id2", txt_id.Text);
                    sorgu.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Başarıyla Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();
                    listView1.Items.Remove(listView1.SelectedItems[0]);
                    listView1.Items.Clear();
                    yatlar();
                    textClear();
                    
                }


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Listeden bir seçim yapmalısınız.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textClear();
        }

        private void txt_tekneresmi_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
