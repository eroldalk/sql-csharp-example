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

        private void button1_Click(object sender, EventArgs e)
        {
            // verileri yenilemek için button 1 i çalıştırıp verigetir fonksiyonunu kapatabiliriz.

            //baglanti.Open();
            //string Select = "Select * From personel";
            //SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //dataGridView1.DataSource = dt;
            //baglanti.Close();


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



        private void verigetir()
        {
            try
            {
                baglanti.Open();
                string Select = "Select * From personel";
                SqlDataAdapter da = new SqlDataAdapter(Select, baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                baglanti.Close();
            }
            catch (Exception ex)
            {

               MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            verigetir();
        }


    }
}
