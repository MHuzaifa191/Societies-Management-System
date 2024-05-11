using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Iteration_1
{
    public partial class Mentor_Home : Form
    {
        private string username;
        public Mentor_Home(string username)
        {
            this.username = username;
            InitializeComponent();
        }

        private void Mentor_Home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Approve_events form = new Approve_events(username);
            form.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Form1 form = new Form1();
           form.Show();
           this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Assign_president form = new Assign_president(username);
            form.Show();
            this.Hide();
        }
    }
}
