using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace log_pass
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bool read;
            SqlDataReader rdr = null;
            string connection = "server=192.168.1.5;database=students;UID=kpv_student;password=GRAgLqO5";
            string FirstName = textBox2.Text, LastName = textBox3.Text, MiddleName = textBox1.Text;
            string query;
            query = (MiddleName == "") ? ("select * from student where FirstName='" + FirstName + "' and LastName='" + LastName+"'") : ("select * from student where FirstName='" + FirstName + "' and LastName='" + LastName + "' and MiddleName='" + MiddleName + "'");
            SqlConnection connect = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand(query, connect);

            connect.Open();
            rdr = cmd.ExecuteReader();
            while (read = rdr.Read())
            {
                if (read == false)
                    MessageBox.Show("Ошибка\nНет данных");
                else
                {
                    string pass = rdr["password"].ToString(), log = rdr["Login"].ToString(), LN=rdr["LastName"].ToString(),FN=rdr["FirstName"].ToString(),MN=rdr["MiddleName"].ToString();
                    string[] user = { LN, FN, MN, log, pass };
                    dataGridView1.Rows.Add(user);
                }
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString()=="Return")
            {
                button1_Click(this, EventArgs.Empty);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Фамилия";
            dataGridView1.Columns[1].Name = "Имя";
            dataGridView1.Columns[2].Name = "Отчество";
            dataGridView1.Columns[3].Name = "Login";
            dataGridView1.Columns[4].Name = "Password";

        }
    }
}
