using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Iteration_1
{
    public partial class Register_event : Form
    {
        private DateTime event_datetime;
        private DateTime deadline_datetime;
        private string description;
        private string name;
        private string location;
        private string username;

        public Register_event(string username)
        {
            InitializeComponent();
            this.username = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            event_datetime = dateTimePicker1.Value;
        }

        private void Register_event_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            deadline_datetime = dateTimePicker2.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;");

            string query = "INSERT INTO Events (ename, edescription, edate, deadline, elocation, approval_status) \n" +
                   "VALUES (@Name, @Description, @DateTime, @Deadline, @Location, 'Waiting')";



            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DateTime", event_datetime);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Description", description);
            command.Parameters.AddWithValue("@Deadline", deadline_datetime);
            command.Parameters.AddWithValue("@Location", location);

            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Event sent for approval successfully.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            description = richTextBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            location = textBox2.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            name = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            President_Home form2 = new President_Home(username);
            form2.Show();
            this.Hide();
        }
    }
}
