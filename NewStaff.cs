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
    public partial class NewStaff : Form
    {
        public NewStaff()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String fname = txtFname.Text;
            String lname = txtLname.Text;

            String gender = "";
            bool isChecked = radioButton1.Checked;
            if (isChecked)
            {
                gender = radioButton1.Text;
            }
            else
            {
                gender = radioButton2.Text;
            }
            String dob = dateTimePickerDOB.Text;
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String email = txtEmail.Text;
            String joindate = dateTimePickerJOINDate.Text;
            String state = txtState.Text;
            String city = txtCity.Text;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into NewStaff (Fname, Lname, Gender, Dob, Mobile, Email, JoinDate, Statee, City) values ('" + fname + "','" + lname + "','" + gender + "','" + dob + "', '" + mobile + "', '" + email + "', '" + joindate + "', '" + state + "','" + city + "') ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            MessageBox.Show("Data Saved Successfully.");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtFname.Clear();
            txtLname.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtMobile.Clear();
            txtCity.Clear();
            txtEmail.Clear();

            dateTimePickerDOB.Value = DateTime.Now;
            dateTimePickerJOINDate.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Staff oq = new Staff();
            oq.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DeleteStaff ds = new DeleteStaff();
            ds.Show();
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

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
