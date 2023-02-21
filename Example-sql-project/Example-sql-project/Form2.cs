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


namespace Example_sql_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //SqlConnection baglanti = new SqlConnection("Data Source = LAPTOP - EL1FCCD2\\SQLEXPRESS;Initial Catalog = okul; Integrated Security = True");

        SqlConnection baglanti =new SqlConnection("Server=.\\SQLEXPRESS;Database=okul;Integrated Security = True");


        //private void verigetir()
        //{
        //    try
        //    {
        //        baglanti.Open();
        //        string Select = "Select * From personel";
        //        SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        dataGridView1.DataSource = dt;
        //        baglanti.Close();
        //    }
        //    catch (Exception ex)
        //    {

        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private void Form2_Load(object sender, EventArgs e)
        //{
        //    verigetir();
        //}


        private void button1_Click(object sender, EventArgs e)
        {
            // verileri yenilemek için button 1 i çalıştırıp verigetir fonksiyonunu kapatabiliriz.

            baglanti.Open();
            string Select = "Select * From personel";
            SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
              //button 2 çaışır durumda        

            try
            {
                baglanti.Open();

                string save = "INSERT INTO personel (KisiNo,Ad,Soyad,Meslek,Sehir,Maas) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)";
                SqlCommand cmd = new SqlCommand(save, baglanti);
                cmd.Parameters.AddWithValue("@p1", textBox1.Text);
                cmd.Parameters.AddWithValue("@p2", textBox2.Text);
                cmd.Parameters.AddWithValue("@p3", textBox3.Text);
                cmd.Parameters.AddWithValue("@p4", textBox4.Text);
                cmd.Parameters.AddWithValue("@p5", textBox5.Text);
                cmd.Parameters.AddWithValue("@p6", textBox6.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("kayıt edildi.");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand delete  = new SqlCommand("Delete From personel where Ad=@adi or Soyad = @soyad ", baglanti);
            delete.Parameters.AddWithValue("@adi", textBox2.Text);
            delete.Parameters.AddWithValue("@soyad", textBox2.Text); 
            delete.ExecuteNonQuery ();
            baglanti.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            baglanti.Open();
            SqlCommand cmdupdate = new SqlCommand("update Personel set KisiNo=@p1, Ad=@p2,Soyad=@p3,Meslek=@p4,Sehir=@p5,Maas=@p6 where KisiNo=@p1", baglanti);
            cmdupdate.Parameters.AddWithValue("@p1", textBox1.Text);
            cmdupdate.Parameters.AddWithValue("@p2", textBox2.Text);
            cmdupdate.Parameters.AddWithValue("@p3", textBox3.Text);
            cmdupdate.Parameters.AddWithValue("@p4", textBox4.Text);
            cmdupdate.Parameters.AddWithValue("@p5", textBox5.Text);
            cmdupdate.Parameters.AddWithValue("@p6", textBox6.Text);
            cmdupdate.ExecuteNonQuery();
            baglanti.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int x = dataGridView1.SelectedCells[0].RowIndex;

            string KisiNo = dataGridView1.Rows[x].Cells[0].Value.ToString();
            string Ad = dataGridView1.Rows[x].Cells[1].Value.ToString();
            string Soyad = dataGridView1.Rows[x].Cells[2].Value.ToString();
            string Meslek = dataGridView1.Rows[x].Cells[3].Value.ToString();
            string Sehir = dataGridView1.Rows[x].Cells[4].Value.ToString();
            string Maas = dataGridView1.Rows[x].Cells[5].Value.ToString();

            textBox1.Text= KisiNo;
            textBox2.Text= Ad;
            textBox3.Text= Soyad;
            textBox4.Text= Meslek;
            textBox5.Text= Sehir;
            textBox6.Text= Maas;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlDataAdapter search = new SqlDataAdapter("Select * from personel where Ad='" + textBox7.Text + "'", baglanti);
            DataSet ds = new DataSet();
            search.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand max = new SqlCommand("Select max(Maas) from personel", baglanti);
            SqlDataReader reader = max.ExecuteReader();
            while (reader.Read())
            {
                label8.Text = reader[0].ToString();
            }
            baglanti.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand max = new SqlCommand("Select count(Ad) from personel", baglanti);
            SqlDataReader reader = max.ExecuteReader();
            while (reader.Read())
            {
                label9.Text = reader[0].ToString();
            }
            baglanti.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand max = new SqlCommand("Select sum(Maas) from personel", baglanti);
            SqlDataReader reader = max.ExecuteReader();
            while (reader.Read())
            {
                label11.Text = reader[0].ToString();
            }
            baglanti.Close();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            baglanti.Open();
           // SqlCommand max = new SqlCommand("Select sum(Maas)/count(Ad) from personel", baglanti);
            SqlCommand max = new SqlCommand("Select avg(Maas) from personel", baglanti);
            SqlDataReader reader = max.ExecuteReader();
            while (reader.Read())
            {
                label13.Text = reader[0].ToString();
            }
            baglanti.Close();
        }
    }
}
