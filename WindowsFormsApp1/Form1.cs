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
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=LENOVO\SQLEXPRESS;Initial Catalog=Rehber;Integrated Security=True");
       
        void Listele()
        {
            SqlCommand komut = new SqlCommand("Select *From KISILER", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void Temizle()
        {
            TxtAd.Text = " ";
            TxtId.Text = " ";
            TxtSoyad.Text = " ";
            TxtMail.Text = " ";
            maskedTextBox1.Text = " ";
            TxtAd.Focus();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutEkle = new SqlCommand("insert into KISILER(AD,SOYAD,TELEFON,MAİL)values(@p1,@p2,@p3,@p4)", baglanti);
            komutEkle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutEkle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutEkle.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komutEkle.Parameters.AddWithValue("@p4", TxtMail.Text);
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Sisteme Eklendi");
            Listele();
            Temizle();

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
           
            SqlCommand komutsil = new SqlCommand("Delete From KISILER where ID=@p1", baglanti);
           // SqlCommand komutsil = new SqlCommand("Delete From KISILER where ID="+TxtId.Text, baglanti);

            komutsil.Parameters.AddWithValue("@p1", TxtId.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Veri Silindi");
            Listele();
            Temizle();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtMail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {


            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("Update KISILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,MAİL=@p4 where ID=@p5", baglanti);
            komutGuncelle.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@p3", maskedTextBox1.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", TxtMail.Text);
            komutGuncelle.Parameters.AddWithValue("@p5", TxtId.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgi Güncellendi");
            Listele();
            Temizle();
        }
    }
}
