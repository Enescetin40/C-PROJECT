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

namespace C_PROJECT
{
    public partial class UpdateStudentcs : Form
    {
        public UpdateStudentcs()
        {
            InitializeComponent();
        }
        SqlConnection bond=new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");
        private void UpdateStudentcs_Load(object sender, EventArgs e)
        {
            string sql = "SELECT*FROM STUDENT;";
            bond.Open();
            SqlCommand komut=new SqlCommand(sql,bond);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["okulno"]);
            }
            bond.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select*from STUDENT where OKULNO=@prm1;";
            SqlDataAdapter da = new SqlDataAdapter(sql, bond);
            da.SelectCommand.Parameters.AddWithValue("@prm1", comboBox1.SelectedItem);
            DataTable dt= new DataTable();  
            da.Fill(dt);
            textBox1.Text = dt.Rows[0][1].ToString();
            textBox2.Text = dt.Rows[0][2].ToString();   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bond.Open();
            string sql = "update STUDENT set OKULNO=@prm1,ADI=@prm2,Soyadı=@prm3 where OKULNO=@prm1;";
            SqlCommand komut=new SqlCommand(sql, bond);
            komut.Parameters.AddWithValue("@prm1", comboBox1.SelectedItem);
            komut.Parameters.AddWithValue("@prm2", textBox1.Text);
            komut.Parameters.AddWithValue("@prm3",textBox2.Text);
            komut.ExecuteNonQuery();
            bond.Close();
            MessageBox.Show("Güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}
