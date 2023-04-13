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
    public partial class NewMember : Form
    {
        public NewMember()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String mid = comboBox1.Text;
            String fname = txtFirstName.Text;
            String lname = txtLastName.Text;
            String gender = "";

            bool isChacked = radioButton1.Checked;
            if (isChacked)
            {
                gender = radioButton1.Text;

            }
            else
            {
                gender = radioButton2.Text;
            }

            String dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String emaill = txtEmail.Text;
            String joindate = dateTimePickerJoinDate.Text;
            String gymeTime = comboBoxGymTime.Text;
            String address = txtAdddress.Text;
            String membership = comboBoxMembership.Text;
            Int64 amout = Int64.Parse(textBox_Amount.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewMember (MID, Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, Gymtime, Maddress, MembershipTime, Payment) values ('" + mid + "','" + fname +"','" + lname + "','" + gender + "','" + dob + "', '" + mobile + "', '" + emaill + "', '" + joindate + "', '" + gymeTime + "','" + address + "', '" + membership + "','" + amout + "') ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);


            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con;

            cmd1.CommandText = "insert into Attendance (MID) values ('" + mid + "') ";
            SqlDataAdapter DA1 = new SqlDataAdapter(cmd1);
            DataSet DS1 = new DataSet();
            DA1.Fill(DS1);
            MessageBox.Show("Data Saved Successfully.");



        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMobile.Clear();
            txtEmail.Clear();

            comboBoxGymTime.ResetText();
            comboBoxMembership.ResetText();
            txtAdddress.Clear();
            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJoinDate.Value = DateTime.Now;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SearchMember nc = new SearchMember();
            nc.Show();
        }

        private void NewMember_Load(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            con1.Open();
            cmd1.CommandText = "Select MID,Fname from NewMember";
            SqlDataReader rd2 = cmd1.ExecuteReader();
            while (rd2.Read())
            {
                comboBox1.Items.Add(rd2.GetValue(0));
            }
            rd2.Close();
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;

            if (!char.IsDigit(ch) && ch != 8 && ch != 46)
            {
                e.Handled = true;
                MessageBox.Show("Enter a valid Entity!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteMember dm = new DeleteMember();
            dm.Show();
        }

        private void textBox_Amount_TextChanged(object sender, EventArgs e)
        {

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
    }
}
