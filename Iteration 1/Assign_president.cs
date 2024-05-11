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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Security.Cryptography;


namespace Iteration_1
{
    public partial class Assign_president : Form
    {
        private string value;
        private string username;
        public Assign_president(string username)
        {
            this.username = username;
            InitializeComponent();
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            string query = "SELECT ID, CONCAT(Fname, Lname) as 'Name' FROM STUDENTS";
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            DataTable StudentsTable = new DataTable();
            adapter.Fill(StudentsTable);

            comboBox1.DataSource = StudentsTable;
            comboBox1.DisplayMember = "Fname"; 
            comboBox1.ValueMember = "ID";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Assign_president_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            value = comboBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True");
            conn.Open();
            string query = "select * from Presidents where society_id = (select ACR from Society_Mentors where MID = '" + username + "')";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show("Society already has a president. Updating the current one.");
                query = "UPDATE Presidents SET president_id = '" + value + "' WHERE society_id = (select ACR from Society_Mentors where MID = '" + username + "')";
                dr.Close();
                SqlCommand cmd1 = new SqlCommand(query, conn);
                try
                {
                    cmd1.ExecuteNonQuery();
                    MessageBox.Show("President updated successfully.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {

                SqlConnection connection = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;TrustServerCertificate=True");
                MessageBox.Show("Username: " + username + ", Student: " + value);
                query = "INSERT INTO Presidents (society_id, president_id)\r\nVALUES ((SELECT SM.ACR FROM Faculty F JOIN Society_Mentors SM \r\nON F.ID = SM.MID WHERE F.Fname = '" + username + "'), '" + value + "')";
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("President assigned successfully.");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Mentor_Home form = new Mentor_Home(username);
            form.Show();
            this.Hide();
        }
    }
}
