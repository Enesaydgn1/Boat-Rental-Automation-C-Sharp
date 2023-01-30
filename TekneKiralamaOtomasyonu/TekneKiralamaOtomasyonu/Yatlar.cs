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
using System.IO;
using System.Drawing;
namespace TekneKiralamaOtomasyonu
{
    public partial class Yatlar : Form
    {
        public Yatlar()
        {
            InitializeComponent();
            comboBox1.Text = "--İl Seçin--";
        }
        SqlConnection baglan = new SqlConnection("Server=DESKTOP-H48G92F;Database=TekneKiralama;Integrated Security=True");

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        Button btn;
      

        private void Yatlar_Load(object sender, EventArgs e)
        {

          
            baglan.Open();

            SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri ", baglan);
      
            SqlDataReader dr = sorgu.ExecuteReader();
            

            while (dr.Read())
            {
                PictureBox pictureBox1 = new PictureBox();
                if (dr["TekneResim"].ToString() != null)
                {
                  pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());
                    
                }
                pictureBox1.Size = new Size(250, 200);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                string tekneadı = dr["TekneAd"].ToString();
                string deger = dr["id"].ToString();
                btn = new Button();
                Label baslik = new Label();
                btn.Text = "Fiyat Sorgula";
                btn.Height = 25;
                btn.Width = 200;
                btn.BackColor = Color.Transparent;
                btn.ForeColor = Color.Black;
                btn.Font = new Font("Times New Roman" , 9 , FontStyle.Bold);
                btn.Dock = DockStyle.Bottom;
                btn.Click += Btn_Click;
                btn.TabIndex += int.Parse(deger);
                baslik.Text = tekneadı;
                baslik.BackColor= Color.FromArgb(210,155,75);
                baslik.TextAlign = ContentAlignment.MiddleCenter;
                baslik.Width = 80;
                baslik.Font = new Font("Times New Roman", 9, FontStyle.Bold);

                flowLayoutPanel1.Controls.Add(pictureBox1);
                pictureBox1.Controls.Add(baslik);
                pictureBox1.Controls.Add(btn);
              
            }
            dr.Close();
            baglan.Close();

       
        }
       
     

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                flowLayoutPanel1.Controls.Clear();

                baglan.Open();

                SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri ", baglan);

                SqlDataReader dr = sorgu.ExecuteReader();

                while (dr.Read())
                {

                    PictureBox pictureBox1 = new PictureBox();
                    if (dr["TekneResim"].ToString() != null)
                    {
                        pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());

                    }
                    pictureBox1.Size = new Size(250, 200);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                    string tekneadı = dr["TekneAd"].ToString();
                    string deger = dr["id"].ToString();
                    btn = new Button();
                    Label baslik = new Label();
                    btn.Text = "Fiyat Sorgula";
                    btn.Height = 25;
                    btn.Width = 200;
                    btn.BackColor = Color.Transparent;
                    btn.ForeColor = Color.Black;
                    btn.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                    btn.Dock = DockStyle.Bottom;
                    btn.Click += Btn_Click;
                    btn.TabIndex += int.Parse(deger);
                    baslik.Text = tekneadı;
                    baslik.BackColor = Color.FromArgb(210, 155, 75);
                    baslik.TextAlign = ContentAlignment.MiddleCenter;
                    baslik.Width = 80;
                    baslik.Font = new Font("Times New Roman", 9, FontStyle.Bold);

                    flowLayoutPanel1.Controls.Add(pictureBox1);
                    pictureBox1.Controls.Add(baslik);
                    pictureBox1.Controls.Add(btn);
                    
                    pictureBox1.Controls.Add(btn);

                }
                dr.Close();
                baglan.Close();

            }
           else if (comboBox1.SelectedIndex == 1)
            {
                flowLayoutPanel1.Controls.Clear();
                baglan.Open();

                SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri ", baglan);

                SqlDataReader dr = sorgu.ExecuteReader();

                while (dr.Read())
                {
                   
                    if (dr["TekneKonum"].ToString() == "İstanbul")
                    {

                        PictureBox pictureBox1 = new PictureBox();
                        if (dr["TekneResim"].ToString() != null)
                        {
                            pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());

                        }
                        pictureBox1.Size = new Size(250, 200);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        string tekneadı = dr["TekneAd"].ToString();
                        string deger = dr["id"].ToString();
                        btn = new Button();
                        Label baslik = new Label();
                        btn.Text = "Fiyat Sorgula";
                        btn.Height = 25;
                        btn.Width = 200;
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.Black;
                        btn.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                        btn.Dock = DockStyle.Bottom;
                        btn.Click += Btn_Click;
                        btn.TabIndex += int.Parse(deger);
                        baslik.Text = tekneadı;
                        baslik.BackColor = Color.FromArgb(210, 155, 75);
                        baslik.TextAlign = ContentAlignment.MiddleCenter;
                        baslik.Width = 80;
                        baslik.Font = new Font("Times New Roman", 9, FontStyle.Bold);

                        flowLayoutPanel1.Controls.Add(pictureBox1);
                        pictureBox1.Controls.Add(baslik);
                        pictureBox1.Controls.Add(btn);


                    }
                }
                dr.Close();
                baglan.Close();

            }
            else if(comboBox1.SelectedIndex == 2)
            {
                flowLayoutPanel1.Controls.Clear();
                baglan.Open();

                SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri ", baglan);

                SqlDataReader dr = sorgu.ExecuteReader();

                while (dr.Read())
                {

                    if (dr["TekneKonum"].ToString() == "Bodrum")
                    {

                        PictureBox pictureBox1 = new PictureBox();
                        if (dr["TekneResim"].ToString() != null)
                        {
                            pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());

                        }
                        pictureBox1.Size = new Size(250, 200);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        string tekneadı = dr["TekneAd"].ToString();
                        string deger = dr["id"].ToString();
                        btn = new Button();
                        Label baslik = new Label();
                        btn.Text = "Fiyat Sorgula";
                        btn.Height = 25;
                        btn.Width = 200;
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.Black;
                        btn.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                        btn.Dock = DockStyle.Bottom;
                        btn.Click += Btn_Click;
                        btn.TabIndex += int.Parse(deger);
                        baslik.Text = tekneadı;
                        baslik.BackColor = Color.FromArgb(210, 155, 75);
                        baslik.TextAlign = ContentAlignment.MiddleCenter;
                        baslik.Width = 80;
                        baslik.Font = new Font("Times New Roman", 9, FontStyle.Bold);

                        flowLayoutPanel1.Controls.Add(pictureBox1);
                        pictureBox1.Controls.Add(baslik);
                        pictureBox1.Controls.Add(btn);


                    }
                }
                dr.Close();
                baglan.Close();
            }
           else if(comboBox1.SelectedIndex == 3)
            {
                flowLayoutPanel1.Controls.Clear();
                baglan.Open();

                SqlCommand sorgu = new SqlCommand("select * from TekneBilgileri ", baglan);

                SqlDataReader dr = sorgu.ExecuteReader();

                while (dr.Read())
                {

                    if (dr["TekneKonum"].ToString() == "Antalya")
                    {

                        PictureBox pictureBox1 = new PictureBox();
                        if (dr["TekneResim"].ToString() != null)
                        {
                            pictureBox1.Image = Image.FromFile(dr["TekneResim"].ToString());

                        }
                        pictureBox1.Size = new Size(250, 200);
                        pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                        pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
                        string tekneadı = dr["TekneAd"].ToString();
                        string deger = dr["id"].ToString();
                        btn = new Button();
                        Label baslik = new Label();
                        btn.Text = "Fiyat Sorgula";
                        btn.Height = 25;
                        btn.Width = 200;
                        btn.BackColor = Color.Transparent;
                        btn.ForeColor = Color.Black;
                        btn.Font = new Font("Times New Roman", 9, FontStyle.Bold);
                        btn.Dock = DockStyle.Bottom;
                        btn.Click += Btn_Click;
                        btn.TabIndex += int.Parse(deger);
                        baslik.Text = tekneadı;
                        baslik.BackColor = Color.FromArgb(210, 155, 75);
                        baslik.TextAlign = ContentAlignment.MiddleCenter;
                        baslik.Width = 80;
                        baslik.Font = new Font("Times New Roman", 9, FontStyle.Bold);

                        flowLayoutPanel1.Controls.Add(pictureBox1);
                        pictureBox1.Controls.Add(baslik);
                        pictureBox1.Controls.Add(btn);


                    }
                }
                dr.Close();
                baglan.Close();
            }
            else
            {
                InitializeComponent();
               
            }
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FiyatSorgulama fiyatForm = new FiyatSorgulama();
            fiyatForm.YatchId = btn.TabIndex.ToString();
            fiyatForm.Show();
         
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
