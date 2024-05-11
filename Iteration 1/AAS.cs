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
    public partial class AAS : Form
    {
        private DataTable dataTable;
        private string AID;
        public AAS(string username)
        {
            InitializeComponent();
            this.AID = username;
            LoadData();
        }


        private void LoadData()
        {
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;Trust Server Certificate=True");
            conn.Open();
            string query = "SELECT ACR,Name,Purpose FROM Societies_Pending where Condition = 'P'";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.HeaderText = "Approve";
            checkboxColumn.Name = "checkboxColumn";
            dataGridView1.Columns.Insert(3, checkboxColumn);
            dataGridView1.AllowUserToAddRows = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell checkbox = row.Cells["checkboxColumn"] as DataGridViewCheckBoxCell;
                if (checkbox.Value != null && (bool)checkbox.Value)
                {
                    string id = row.Cells["ACR"].Value.ToString(); // Assuming 'ID' is the column name
                    string name = row.Cells["Name"].Value.ToString();
                    string purpose = row.Cells["Purpose"].Value.ToString();
                    SqlConnection conn = new SqlConnection("Data Source=DESKTOP-QDMT8M4\\SQLEXPRESS;Initial Catalog=SE_Project;Integrated Security=True");
                    conn.Open();
                    string updateQuery = "UPDATE Societies_Pending SET condition = 'A' WHERE ACR = '"+ id + "'";
                    SqlCommand command = new SqlCommand(updateQuery, conn);
                    command.ExecuteNonQuery();
                    string insert = "insert into Societies (Acr,Name,Purpose) Values ('" + id + "', '" + name + '"' + purpose + "')";
                    SqlCommand cmd = new SqlCommand(insert, conn);
                    cmd.ExecuteNonQuery();
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Home form2 = new Admin_Home(this.AID);
            form2.Show();
            this.Hide();
        }
    }
}
