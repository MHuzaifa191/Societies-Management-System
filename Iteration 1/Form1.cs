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

namespace Iteration_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;");
            conn.Open();
            string username = textBox1.Text;
            string password = textBox2.Text;
            string query = "select* from USERS where ID= '" + username + "'  and PASSWORD='" + password + "'";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                dr.Close();
                string type = "SELECT Type FROM Users WHERE ID = '"+username+"'";
                SqlCommand command = new SqlCommand(type, conn);
                object result = command.ExecuteScalar();
                int utype = Convert.ToInt32(result);
                if(utype == 1)
                {
                    label3.Text = "Successfull";
                    Admin_Home form = new Admin_Home(username);
                    form.Show();
                    this.Hide();
                }
                if (utype == 2)
                {
                    label3.Text = "Successfull";
                    President_Home form = new President_Home(username);
                    form.Show();
                    this.Hide();
                }
                else if(utype == 3)
                {
                    Student_Home form = new Student_Home(username);
                    form.Show();
                    this.Hide();
                }
                else if (utype == 4)
                {
                    Mentor_Home form = new Mentor_Home(username);
                    form.Show();
                    this.Hide();
                }

            }
            else
            {
                MessageBox.Show("Incorrect credentials.");
            }

        }
    }
}
