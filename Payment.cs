using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GYMSYS
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select MID,Fname from NewMember";
            SqlDataReader rd22 = cmd.ExecuteReader();
            while (rd22.Read())
            {
                comboBox1.Items.Add(rd22.GetValue(0));
            }
            rd22.Close();


            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            con1.Open();
            cmd1.CommandText = "Select MID,Fname from NewMember";
            SqlDataReader rd2 = cmd1.ExecuteReader();
            while (rd2.Read())
            {
                comboBox2.Items.Add(rd2.GetValue(0));
            }
            rd2.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id = comboBox1.Text;
            Int64 amount = Int64.Parse(textBox2.Text);
            Int64 payment = Int64.Parse(textBox3.Text);
            long remaining = amount-payment;
            long non = 0;
            long neg = -1;
            long balance = neg * remaining;

            if (remaining==0)
            {
                MessageBox.Show("All amount Payed", "Payment Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                SqlCommand cmd2 = new SqlCommand("update NewMember set Payment=@pay Where MID = @ID", con);
                cmd2.Parameters.AddWithValue("@pay", remaining);
                cmd2.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            else if (remaining < 0)
            {
                MessageBox.Show("Give Balance of  "+ balance +" Rupees to customer!", "Amount Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                SqlCommand cmd2 = new SqlCommand("update NewMember set Payment=@pay Where MID = @ID", con);
                cmd2.Parameters.AddWithValue("@pay", non);
                cmd2.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("Enter Correct Amount ", "Incomplete Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            if (comboBox1.Text!="")
            {
                cmd.CommandText = "Select Fname, Payment from NewMember where MID = @ID";
                cmd.Parameters.AddWithValue("@ID", int.Parse(comboBox1.Text));
                SqlDataReader da = cmd.ExecuteReader();
                while (da.Read())
                {
                    textBox1.Text = da.GetValue(0).ToString();
                    textBox2.Text = da.GetValue(1).ToString();
                }
                con.Close();
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select MID, FName, Payment from NewMember";
            
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select MID, FName, Payment from NewMember where MID =" + comboBox2.Text + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            }
            else
            {
                MessageBox.Show("Please Enter Some ID", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Enter a valid Entity!");
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Enter a valid Entity!");
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Enter a valid Entity!");
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
