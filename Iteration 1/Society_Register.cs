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
    public partial class Society_Register : Form
    {
        private string SID;
        public Society_Register(string username)
        {
            this.SID = username;
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            label6.Text = "";
            label8.Text = "";
            SqlConnection conn = new SqlConnection("Data Source=HUZAIFA;Initial Catalog=SE_Project;Integrated Security=True;Trust Server Certificate=True");
            conn.Open();
            string society_name = textBox1.Text;
            string society_acr = textBox2.Text;
            string general_purpose = textBox3.Text;
            bool name = false, acr = false;
            string query_acr = "select * from Societies where Acr ='" + society_acr + "'";
            string query_name = "select * from Societies where Name ='" + society_name + "'";
            SqlCommand cmd_acr = new SqlCommand(query_acr, conn);
            SqlDataReader dr_acr = cmd_acr.ExecuteReader();
            if (dr_acr.Read())
            {
                acr = true;
                label6.Text = "Acronym already exsists";

            }
            dr_acr.Close();
            SqlCommand cmd_name = new SqlCommand(query_name, conn);
            SqlDataReader dr_name = cmd_name.ExecuteReader();
            if (dr_name.Read())
            {
                name = true;
                label5.Text = "Name already exsists";
            }
            dr_name.Close();    
            if(acr == false && name == false)
            {
                string status = "P";
                //string adddata = "INSERT INTO ATTENDANCE (SID,CID,TID,SECTION,WEEK,STATUS) VALUES ('" + ID + "','" + cid + "','" + tid + "','" + sec + "','" + week + "','" + status + "' )";
                string add_socety = "insert into Societies_Pending (Acr,Name,Purpose,Condition,SID) VALUES  ('" + society_acr + "', '" + society_name +"', '"+general_purpose+ "' , '" +status+"','" + this.SID + "')";
                SqlCommand cmd = new SqlCommand(add_socety, conn);
                cmd.ExecuteNonQuery();
                label8.Text = "Society Registered";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Student_Home form2 = new Student_Home(this.SID);
            form2.Show();
            this.Hide(); 
        }

        private void Society_Register_Load(object sender, EventArgs e)
        {

        }
    }
}
