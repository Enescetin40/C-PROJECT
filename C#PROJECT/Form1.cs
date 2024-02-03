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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bond =new SqlConnection(@"Data Source = MONSTERABRA\SQLEXPRESS03; Initial Catalog = student; Integrated Security = True; Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            show();
        }

        void show()
        {
            string sql = "SELECT * FROM STUDENT;";
            SqlDataAdapter da =new SqlDataAdapter(sql,bond);
            DataTable dt=new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ADDSTUDENT add= new ADDSTUDENT();
            add.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           UpdateStudentcs updt= new UpdateStudentcs();
            updt.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DELETE sil= new DELETE();
            sil.ShowDialog();
        }
    }
}
