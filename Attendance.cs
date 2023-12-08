using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// Attendance page to handle the students presence.
namespace GYMSYS
    #system that can record attendance
{
    public partial class Attendance : MetroFramework.Forms.MetroForm
    {



        public Attendance()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Attendance_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select SID,Fname from NewStaff";
            SqlDataReader rd22 = cmd.ExecuteReader();
            while (rd22.Read())
            {
                comboBox1.Items.Add(rd22.GetValue(1));
            }
            rd22.Close();

            SqlConnection con1 = new SqlConnection();
            con1.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            con1.Open();
            cmd1.CommandText = "Select Distinct(Att_Date) from record";
            SqlDataReader rd21 = cmd1.ExecuteReader();
            while (rd21.Read())
            {
                comboBox2.Items.Add(rd21.GetValue(0));
               
            }
            rd21.Close();

            SqlConnection con2 = new SqlConnection();
            con2.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd2 = new SqlCommand();
            cmd2.Connection = con2;
            con2.Open();
            cmd2.CommandText = "Select Distinct(MID) from record";
            SqlDataReader rd211 = cmd2.ExecuteReader();
            while (rd211.Read())
            {
                comboBox3.Items.Add(rd211.GetValue(0));

            }
            rd211.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "Select Attendance.AID, NewMember.MID,NewMember.Fname as Name,' ' as Status from NewMember,Attendance where NewMember.MID = Attendance.MID";
            SqlDataAdapter da1 = new SqlDataAdapter();
            da1.SelectCommand = cmd;
            DataTable dt = new DataTable();
            dt.Clear();
            da1.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;

        }

        private void btnIN_Click(object sender, EventArgs e)
        {
            String stn = comboBox1.Text;
            String dat = dateTimePicker1.Text;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MM/dd/yyyy";
            dateTimePicker1.ShowUpDown = true;
            String dt = dateTimePicker1.Value.ToString("MM/dd/yyyy");
            String datetime = DateTime.Now.ToString("hh:mm:ss tt");
            String stat = "In";
            String comar1 = "P";
            String comar2 = "p";
            String empty = " ";
            String dat1 = comboBox2.Text;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";

            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                if (dataGridView1.Rows[item].Cells[3].Value.ToString() == comar1 || dataGridView1.Rows[item].Cells[3].Value.ToString() == comar2)
                {
                    SqlCommand cmd2 = new SqlCommand("update Attendance set Staff_Name = @stn, Att_Date = @dat, InTime = @dtime,OutTime=@otime, Att_Status=@Att_Status, Time_Status=@time_status where AID=@mid", con);

                    cmd2.Parameters.AddWithValue("@stn", stn);
                    cmd2.Parameters.AddWithValue("@dat", dat);
                    cmd2.Parameters.AddWithValue("@dtime", datetime);
                    cmd2.Parameters.AddWithValue("@otime", empty);
                    cmd2.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd2.Parameters.AddWithValue("@time_status", stat);
                    cmd2.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[0].Value);


                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();
                    SqlConnection con6 = new SqlConnection();
                    con6.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                    SqlCommand cmdd1 = new SqlCommand();
                    cmdd1.Connection = con6;
                   
                        
                       
                       
                    cmdd1.CommandText = "insert into record (MID, Staff_Name, Att_Date, InTime, OutTime, Att_Status, Time_Status) values ('" + dataGridView1.Rows[item].Cells[1].Value + "','" + stn + "','" + dat + "','" + datetime + "','" + empty + "', '" + dataGridView1.Rows[item].Cells[3].Value + "', '" + stat + "') select record.MID,ATtendance.MID from  record, Attendance where record.MID = Attendance.MID ";
                    SqlDataAdapter DA = new SqlDataAdapter(cmdd1);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                       
                    
                }
                else if (dataGridView1.Rows[item].Cells[3].Value.ToString() == "a" || dataGridView1.Rows[item].Cells[3].Value.ToString() == "A")
                {
                    SqlCommand cmd2 = new SqlCommand("update Attendance set Staff_Name = @stn, Att_Date = @dat, InTime = @dtime, OutTime=@otime, Att_Status=@Att_Status, Time_Status=@time_status where AID=@mid", con);

                    cmd2.Parameters.AddWithValue("@stn", empty);
                    cmd2.Parameters.AddWithValue("@dat", dat);
                    cmd2.Parameters.AddWithValue("@dtime", empty);
                    cmd2.Parameters.AddWithValue("@otime", empty);
                    cmd2.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd2.Parameters.AddWithValue("@time_status", empty);
                    cmd2.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[0].Value);


                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    SqlConnection con5 = new SqlConnection();
                    con5.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                    
                       
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con5;

                    cmd.CommandText = "insert into record (MID, Staff_Name, Att_Date, InTime, OutTime, Att_Status, Time_Status) values ('" + dataGridView1.Rows[item].Cells[1].Value + "','" + empty + "','" + dat + "','" + empty + "','" + empty + "', '" + dataGridView1.Rows[item].Cells[3].Value + "', '" + empty + "') ";
                    SqlDataAdapter DA = new SqlDataAdapter(cmd);
                    DataSet DS = new DataSet();
                    DA.Fill(DS);
                }
            }
           
            
            
            
            MessageBox.Show("Data Entered Successfully.");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will Delete all your attendance record. Confirm?", "CLOSE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from record";

                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
            }
            else
            {
                MessageBox.Show("Data not Deleted", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }

        private void btnOUT_Click(object sender, EventArgs e)
        {
            String stn = comboBox1.Text;
            String dat = dateTimePicker1.Text;
            String datetime = DateTime.Now.ToString("hh:mm:ss tt");
            String stat = "Out";
            String comar1 = "P";
            String comar2 = "p";
            String empty = " ";
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";

            for (int item = 0; item <= dataGridView1.Rows.Count - 1; item++)
            {
                if (dataGridView1.Rows[item].Cells[3].Value.ToString() == comar1 || dataGridView1.Rows[item].Cells[3].Value.ToString() == comar2)
                {
                    SqlCommand cmd2 = new SqlCommand("update Attendance set Staff_Name = @stn, Att_Date = @dat, OutTime = @dtime, Att_Status=@Att_Status, Time_Status=@time_status where AID=@mid", con);

                    cmd2.Parameters.AddWithValue("@stn", stn);
                    cmd2.Parameters.AddWithValue("@dat", dat);
                    cmd2.Parameters.AddWithValue("@dtime", datetime);
                    cmd2.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd2.Parameters.AddWithValue("@time_status", stat);
                    cmd2.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[0].Value);


                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    SqlConnection con8 = new SqlConnection();
                    con8.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";




                    SqlCommand cmd3 = new SqlCommand("update record set Staff_Name = @stn, Att_Date = @dat, OutTime = @dtime, Att_Status=@Att_Status, Time_Status=@time_status where MID=@mid", con8);

                    cmd3.Parameters.AddWithValue("@stn", stn);
                    cmd3.Parameters.AddWithValue("@dat", dat);
                    cmd3.Parameters.AddWithValue("@dtime", datetime);
                    cmd3.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd3.Parameters.AddWithValue("@time_status", stat);
                    cmd3.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[1].Value);
                    cmd3.Parameters.AddWithValue("@daat", dat);


                    con8.Open();
                    cmd3.ExecuteNonQuery();
                    con8.Close();


                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("update Attendance set Staff_Name = @stn, Att_Date = @dat, OutTime = @dtime, Att_Status=@Att_Status, Time_Status=@time_status where AID=@mid", con);

                    cmd2.Parameters.AddWithValue("@stn", empty);
                    cmd2.Parameters.AddWithValue("@dat", dat);
                    cmd2.Parameters.AddWithValue("@dtime", empty);
                    cmd2.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd2.Parameters.AddWithValue("@time_status", empty);
                    cmd2.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[0].Value);


                    con.Open();
                    cmd2.ExecuteNonQuery();
                    con.Close();


                    SqlConnection con8 = new SqlConnection();
                    con8.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";




                    SqlCommand cmd3 = new SqlCommand("update record set Staff_Name = @stn, Att_Date = @dat, OutTime = @dtime, Att_Status=@Att_Status, Time_Status=@time_status where RID=@mid", con8);

                    cmd3.Parameters.AddWithValue("@stn", empty);
                    cmd3.Parameters.AddWithValue("@dat", dat);
                    cmd3.Parameters.AddWithValue("@dtime", empty);
                    cmd3.Parameters.AddWithValue("@Att_Status", dataGridView1.Rows[item].Cells[3].Value);
                    cmd3.Parameters.AddWithValue("@time_status", empty);
                    cmd3.Parameters.AddWithValue("@mid", dataGridView1.Rows[item].Cells[0].Value);


                    con8.Open();
                    cmd3.ExecuteNonQuery();
                    con8.Close();

                }
            }
                MessageBox.Show("Data Entered Successfully.");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String IDD = comboBox3.Text;
            String at = comboBox2.Text;
            
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = DESKTOP-424A8J1; database = gym; integrated security =True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from record where MID = '"+ IDD+"'  and Att_Date = '" + at + "'";


            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView2.DataSource = DS.Tables[0];
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
