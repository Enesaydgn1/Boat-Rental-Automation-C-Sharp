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
    public partial class Rezervasyon : Form
    {
        public Rezervasyon()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");

        private void rezerve()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From FiyatSorgu ", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["TekneAdı"].ToString());
                ekle.SubItems.Add(oku["KiralamaSüresi"].ToString());
                ekle.SubItems.Add(oku["KiralamaSüresi"].ToString());

                ekle.SubItems.Add(oku["Lokasyon"].ToString());
                ekle.SubItems.Add(oku["KişiSayısı"].ToString());
                ekle.SubItems.Add(oku["Menü"].ToString());
                ekle.SubItems.Add(oku["Alkol"].ToString());
                ekle.SubItems.Add(oku["Saat"].ToString());
                ekle.SubItems.Add(oku["Fiyat"].ToString());
                ekle.SubItems.Add(oku["Tarih"].ToString());
                ekle.SubItems.Add(oku["Pasta"].ToString());
                ekle.SubItems.Add(oku["MasaSüsleme"].ToString());
                ekle.SubItems.Add(oku["Cicek"].ToString());
                ekle.SubItems.Add(oku["Balon"].ToString());
                ekle.SubItems.Add(oku["Oryantal"].ToString());
                ekle.SubItems.Add(oku["Kemancı"].ToString());
                ekle.SubItems.Add(oku["Fasıl"].ToString());
               

                listView1.Items.Add(ekle);
                listView1.Refresh();
            }
            baglanti.Close();
        }
        private void Rezervasyon_Load(object sender, EventArgs e)
        {
            rezerve();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            txt_id.Text = listView1.SelectedItems[0].SubItems[0].Text;
            txt_teknead.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txt_tarih.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox1.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txt_teknekişisayısı.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txt_tekneücreti.Text = listView1.SelectedItems[0].SubItems[7].Text;



        }
    }
}
