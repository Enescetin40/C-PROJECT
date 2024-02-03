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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace C_PROJECT
{
    public partial class DELETE : Form
    {
        public DELETE()
        {
            InitializeComponent();
        }
        SqlConnection bond = new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");
        private void DELETE_Load(object sender, EventArgs e)
        {
            string sql = "SELECT*FROM STUDENT;";
            bond.Open();
            SqlCommand komut = new SqlCommand(sql, bond);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["okulno"]);
            }
            bond.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "delete from STUDENT where OKULNO=@prm1";
            bond.Open();
            SqlCommand komut = new SqlCommand( sql, bond);
            komut.Parameters.AddWithValue("@prm1",comboBox1.SelectedItem);
            komut.ExecuteNonQuery();
            MessageBox.Show("Siliniyor","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
