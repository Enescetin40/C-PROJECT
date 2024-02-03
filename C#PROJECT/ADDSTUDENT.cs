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
    public partial class ADDSTUDENT : Form
    {
        public ADDSTUDENT()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
           SqlConnection bond =new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");
           bond.Open();
            string sql = "Insert into student(ADI,SOYADI,OKULNO)values(@prm1,@prm2,@prm3);";
            SqlCommand komut = new SqlCommand(sql, bond);
            komut.Parameters.AddWithValue("@prm1", textBox1.Text);
            komut.Parameters.AddWithValue("@prm2", textBox2.Text);
            komut.Parameters.AddWithValue("@prm3",textBox3.Text);
            komut.ExecuteNonQuery();
            bond.Close();
            MessageBox.Show("Eklendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
