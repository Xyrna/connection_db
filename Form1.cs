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

namespace connection_db
{
    public partial class Form1 : Form
    {


        private SqlConnection sql = new SqlConnection("Server=DESKTOP-2QKN505\\SQLEXPRESS; Integrated Security=true;");
        private bool isConnected = false;

        public Form1()
        {
            InitializeComponent();
        }

        public void check()
        {
            if (sql.State == ConnectionState.Open)
            {
                label1.Text = "Connected";
                turn.Text = "Disconnect";
                isConnected = true;
            }
            else if (sql.State == ConnectionState.Closed)
            {
                label1.Text = "Disconnected";
                turn.Text = "Connect";
                isConnected = false;
            }
            else
            {
                label1.Text = "Connection error";
                isConnected = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sql.Open();
            check();
        }

        private void turn_Click(object sender, EventArgs e)
        {
            if(isConnected)
            {
                sql.Close();
            }
            else
            {
                sql.Open();
            }
            check();
        }
    }
}
