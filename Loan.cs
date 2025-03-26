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

namespace BankManagement
{
    public partial class Loan : Form
    {
        public Loan()
        {
            InitializeComponent();
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                dateTimePicker3.CustomFormat = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("insert into loans values(@loan_id,@loan_type,@amount,@interest_rate,@loan_date,@customer_name)", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Interest_Rate", textBox4.Text);
            cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker3.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Saved Successfully!");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from loans", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("update loans set loan_type=@loan_type,amount=@amount,interest_rate=@interest_rate,loan_date=@loan_date,customer_name=@customer_name where loan_id=@loan_id", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.Parameters.AddWithValue("@Loan_Type", textBox2.Text);
            cnn.Parameters.AddWithValue("@Amount", int.Parse(textBox3.Text));
            cnn.Parameters.AddWithValue("@Interest_Rate", textBox4.Text);
            cnn.Parameters.AddWithValue("@Loan_Date", dateTimePicker3.Value);
            cnn.Parameters.AddWithValue("@Customer_Name", textBox5.Text);
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("delete loans where loan_id=@loan_id", con);
            cnn.Parameters.AddWithValue("@Loan_ID", int.Parse(textBox1.Text));
            cnn.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Deleted Successfully!");
        }

        private void Loan_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-J5MJRIP\SQLEXPRESS;Initial Catalog=BankDB;Integrated Security=True;Encrypt=False");
            con.Open();
            SqlCommand cnn = new SqlCommand("select * from loans", con);
            SqlDataAdapter da = new SqlDataAdapter(cnn);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
        }
    }
}
