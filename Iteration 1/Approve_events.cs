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
    public partial class Approve_events : Form
    {
        private string event_id;
        private string username;
        public Approve_events(string username)
        {
            this.username = username;
            InitializeComponent();
            SqlConnection connection = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;TrustServerCertificate=True");
            connection.Open();
            string query = "SELECT event_id as 'Event ID', ename AS 'Name', edate as 'Date', elocation AS 'Location', deadline AS 'Registration Deadline' FROM EVENTS\r\n WHERE approval_status = 'Waiting'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataTable facultyTable = new DataTable();
            adapter.Fill(facultyTable);
            dataGridView1.DataSource = facultyTable;
        }

        private void Approve_events_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                event_id = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(); 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Events\r\nSET approval_status = 'Approved'\r\nWHERE event_id = " + event_id;
            SqlConnection connection = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;");
            SqlCommand command = new SqlCommand(query, connection);
            try
            {
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show("Event approved.");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
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
