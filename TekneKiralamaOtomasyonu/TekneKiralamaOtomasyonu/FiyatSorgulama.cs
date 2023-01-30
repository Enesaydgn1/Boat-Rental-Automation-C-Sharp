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
    public partial class FiyatSorgulama : Form
    {
       

        public FiyatSorgulama()
        {

         
            InitializeComponent();
           
            checkBox1.Tag = 250;
            checkBox2.Tag = 350;
            checkBox3.Tag = 1000;
            checkBox4.Tag = 1500;
            checkBox5.Tag = 2000;
            checkBox6.Tag = 1000;
            checkBox7.Tag = 750;
            checkBox8.Tag = 300;
            
            checkBox1.CheckedChanged += CheckBox_CheckedChanged;
            checkBox2.CheckedChanged += CheckBox_CheckedChanged;
            checkBox3.CheckedChanged += CheckBox_CheckedChanged;
            checkBox4.CheckedChanged += CheckBox_CheckedChanged;
            checkBox5.CheckedChanged += CheckBox_CheckedChanged;
            checkBox6.CheckedChanged += CheckBox_CheckedChanged;
            checkBox7.CheckedChanged += CheckBox_CheckedChanged;
            checkBox8.CheckedChanged += CheckBox_CheckedChanged;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox3.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            comboBox5.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
           

        }
        SqlConnection baglan = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");
        public string YatchId;
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }
        private void CalculateTotal()
        {
            baglan.Close();
            baglan.Open();
            SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri where id='" + int.Parse(YatchId) + "'", baglan);

            SqlDataReader dr = sorgu.ExecuteReader();
            while (dr.Read())
            {
                int total = int.Parse(dr["TekneUcret"].ToString());
                label14.Text = total.ToString();
                if (checkBox1.Checked)
                {
                    total += int.Parse(checkBox1.Tag.ToString());
                }
                if (checkBox2.Checked)
                {
                    total += int.Parse(checkBox2.Tag.ToString());

                }
                if (checkBox3.Checked)
                {
                    total += int.Parse(checkBox3.Tag.ToString());
                }
                if (checkBox4.Checked)
                {
                    total += int.Parse(checkBox4.Tag.ToString());
                }
                if (checkBox5.Checked)
                {
                    total += int.Parse(checkBox5.Tag.ToString());
                }
                if (checkBox6.Checked)
                {
                    total += int.Parse(checkBox6.Tag.ToString());
                }
                if (checkBox7.Checked)
                {
                    total += int.Parse(checkBox7.Tag.ToString());
                }
                if (checkBox8.Checked)
                {
                    total += int.Parse(checkBox8.Tag.ToString());
                }  
            
                if (comboBox1.SelectedIndex == 0)
                {
                    total += 0;
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    total += 200 * (comboBox4.SelectedIndex + 1);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    total += 250 * (comboBox4.SelectedIndex + 1);
                }
                if (comboBox1.SelectedIndex == 3)
                {
                    total += 500* (comboBox4.SelectedIndex + 1);
                }
                if (comboBox2.SelectedIndex == 0)
                {
                    total += 350 * (comboBox4.SelectedIndex + 1);
                }
                if (comboBox2.SelectedIndex == 1)
                {
                    total += 0 ;
                }
                if (comboBox3.SelectedIndex == 0)
                {
                    total += 0;
                }
                if (comboBox3.SelectedIndex == 1)
                {
                    total *= 2;
                }
                if (comboBox3.SelectedIndex == 2)
                {
                    total *= 3;
                }
                if (comboBox3.SelectedIndex == 3)
                {
                    total *= 4;
                }

                label14.Text = total.ToString() + " " + "TL";

             
                
            }
            dr.Close();
            baglan.Close();

         

        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

            DateTime nextAvailableDate = DateTime.Today;

        private void FiyatSorgulama_Load(object sender, EventArgs e)
        {
            dateTimePicker2.MinDate = DateTime.Now;

            baglan.Open();

            SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri where id='"+ int.Parse(YatchId) + "'", baglan);

            SqlDataReader dr = sorgu.ExecuteReader();
          

            while (dr.Read())
            {
                for (int i = 1; i <= int.Parse(dr["TekneKisiSayisi"].ToString()); i++)
                {
                    comboBox4.Items.Add(i);

                    comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
                }
             
                label1.Text = dr["TekneAd"].ToString();
                richTextBox1.Text = dr["TekneIcerik"].ToString();
                label14.Text = dr["TekneUcret"].ToString() + " " + "TL";
                label17.Text = dr["TekneKisiSayisi"].ToString() +" " +" Kişilik";
                label15.Text = dr["TekneBoyu"].ToString();
                label22.Text = dr["TekneKonum"].ToString();

                if (dr["TekneResim"].ToString() != null)
                {
                    pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());

                }
                
            }
            dr.Close();
            baglan.Close();

       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult durum = MessageBox.Show("Geri dönmek istediğinizden emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (durum == DialogResult.Yes)
            {
               
                this.Hide();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            CalculateTotal();

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculateTotal();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
     
        private void button2_Click(object sender, EventArgs e)
        {
            CalculateTotal();
         
            if (comboBox3.SelectedItem == null || comboBox2.SelectedItem == null || comboBox1.SelectedItem == null || comboBox4.SelectedItem == null || comboBox5.SelectedItem == null)
            {

                MessageBox.Show(" Bilgileri Eksiksiz Doldurun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                string selectedsure = comboBox3.SelectedItem.ToString();
                string selectedmenu = comboBox1.SelectedItem.ToString();
                string selectedkisi = comboBox4.SelectedItem.ToString();
                string selectedalkol = comboBox2.SelectedItem.ToString();

                string selectedalsaat = comboBox5.SelectedItem.ToString();

                baglan.Open();
                string sorgu2 = "Insert into FiyatSorgu(KiralamaSüresi,KişiSayısı,Menü,Alkol,Tarih,Pasta,MasaSüsleme,Cicek,Balon,Oryantal,Lazer,Kemancı,Fasıl,Fiyat,Saat,TekneAdı,Lokasyon)" +
                 "values (@KiralamaSüresi,@KişiSayısı,@Menü,@Alkol,@Tarih,@Pasta,@MasaSüsleme,@Cicek,@Balon,@Oryantal,@Lazer,@Kemancı,@Fasıl,@Fiyat,@Saat,@TekneAdı,@Lokasyon)";
                SqlCommand komut = new SqlCommand(sorgu2, baglan);
           
                komut.Parameters.AddWithValue("@KiralamaSüresi", selectedsure);
                komut.Parameters.AddWithValue("@KişiSayısı", selectedkisi);
                komut.Parameters.AddWithValue("@Menü", selectedmenu);
                komut.Parameters.AddWithValue("@Alkol", selectedalkol);
                komut.Parameters.AddWithValue("@Saat", selectedalsaat);
                komut.Parameters.AddWithValue("@TekneAdı", label1.Text);
                komut.Parameters.AddWithValue("@Fiyat", label14.Text);
                komut.Parameters.AddWithValue("@Tarih", dateTimePicker2.Value);
                komut.Parameters.AddWithValue("@Pasta", checkBox8.Checked);
                komut.Parameters.AddWithValue("@MasaSüsleme", checkBox1.Checked);
                komut.Parameters.AddWithValue("@Cicek", checkBox2.Checked);
                komut.Parameters.AddWithValue("@Balon", checkBox3.Checked);
                komut.Parameters.AddWithValue("@Oryantal", checkBox4.Checked);
                komut.Parameters.AddWithValue("@Kemancı", checkBox6.Checked);
                komut.Parameters.AddWithValue("@Fasıl", checkBox5.Checked);
                komut.Parameters.AddWithValue("@Lazer", checkBox7.Checked);
                komut.Parameters.AddWithValue("@Lokasyon", label22.Text);

                clearselect();
                komut.ExecuteNonQuery();
                MessageBox.Show("Rezervasyon işlemi Başarılı.");
                
                baglan.Close();
                
               
            }
        }

        public void clearselect()
        {
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            comboBox4.Text = "";

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
        }

        private void dateTimePicker2_ValueeChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
          
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
