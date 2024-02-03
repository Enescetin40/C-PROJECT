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
    public partial class UPDATESTUDENT : Form
    {
        public UPDATESTUDENT()
        {
            InitializeComponent();
        }

        private void UPDATESTUDENT_Load(object sender, EventArgs e)
        {
            SqlConnection bond=new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");
            string sql = "select*from student";
            SqlCommand komut = new SqlCommand(sql, bond);
            SqlDataReader dataReader = komut.ExecuteReader();
            while(dataReader.Read())
            {
                comboBox1.Items.Add(dataReader["ıd"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection bond = new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");
            string sql = "update student set okulno=@prm1 where okulno=@prm1";
            SqlCommand komut = new SqlCommand( sql, bond);
            komut.Parameters.AddWithValue("@prm1", comboBox1.SelectedItem);
            komut.ExecuteNonQuery();

        }
    }
}
