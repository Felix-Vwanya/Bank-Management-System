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

namespace BankManagement
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            display();
            display1();
            display2();
        }

        private void display()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM customers", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount1.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount1.Text = "0";
            }
            con.Close();
        }

        private void display1()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM loans", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount2.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount2.Text = "0";
            }
            con.Close();
        }
        private void display2()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM employees", con);
            Int32 count = Convert.ToInt32(comm.ExecuteScalar());
            if (count > 0)
            {
                lblCount3.Text = Convert.ToString(count.ToString());
            }
            else
            {
                lblCount3.Text = "0";
            }
            con.Close();
        }
    }
}
