using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ikinci_Sql_Calismalari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\İkinci Sql Çalışmaları\Ikinci_Sql_Calismalari\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select product_name, c.cat_id from category c, product p where c.cat_id=p.cat_id", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            listBox1.DataSource = dt;
            dataGridView1.DataSource = dt;
            listBox1.DisplayMember = "product_name";
            
            
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\İkinci Sql Çalışmaları\Ikinci_Sql_Calismalari\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select product_name, c.cat_id from category c, product p where c.cat_id=p.cat_id", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "product_name";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MessageBox.Show(comboBox1.SelectedText.ToString());
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\İkinci Sql Çalışmaları\Ikinci_Sql_Calismalari\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select sum(unit_price) from category c, product p group by c.cat_id, p.cat_id having c.cat_id=p.cat_id", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\İkinci Sql Çalışmaları\Ikinci_Sql_Calismalari\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select product_name, c.cat_id from product p, category c where c.cat_id=p.cat_id and c.cat_id<@p1", con);
            com.Parameters.AddWithValue("@p1", textBox1.Text);
            SqlDataReader dr = com.ExecuteReader();

            dataGridView1.Columns.Add("Product_Id", "Ürün Numarası");
            dataGridView1.Columns.Add("Product_Name", "Ürün Adı");
            dataGridView1.Columns.Add("Unit_Price", "Birim Fiyat");
            dataGridView1.Columns.Add("Cat_Id", "Kategori Numarası");

            //DataTable dt = new DataTable();
            //dt.Load(dr);
            //dataGridView1.DataSource = dt;
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1]);
                listBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\toshıba\Desktop\Görsel Programlama Çalışmalarım\İkinci Sql Çalışmaları\Ikinci_Sql_Calismalari\Database1.mdf;Integrated Security=True");
            con.Open();
            SqlCommand com = new SqlCommand("select product_name from product where cat_id=(select cat_id from category where cat_name = 'mobilya')", con);
            SqlDataReader dr = com.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);

            dataGridView1.DataSource = dt;
            

        }
    }
}
