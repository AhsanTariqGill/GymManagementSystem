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
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            String EquipName = txtEquipName.Text;
            String Description = txtDescription.Text;
            String MUsed = txtUsed.Text;
            String DDate = dateTimePickerDD.Text;
            Int64 cost = Int64.Parse(txtCost.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "insert into Equipment (EquipName, EDescription, MUsed, DDate, Cost) values ('" + EquipName + "','" + Description + "','" + MUsed + "','" + DDate + "', '" + cost + "') ";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            MessageBox.Show("Data Saved Successfully.", "Inserted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtEquipName.Clear();
            txtDescription.Clear();
            txtUsed.Clear();
            txtCost.Clear();
            dateTimePickerDD.Value = DateTime.Now;
        }

        private void btnViewEq_Click(object sender, EventArgs e)
        {
            ViewEquipment ve = new ViewEquipment();
            ve.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteEquipment de = new DeleteEquipment();
            de.Show();
        }

        private void txtCost_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCost_KeyPress(object sender, KeyPressEventArgs e)
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
