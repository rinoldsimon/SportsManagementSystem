using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sportsms
{
    public partial class frmstudentreg : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmstudentreg()
        {
            InitializeComponent();
        }

        private void frmstudentreg_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadgrid();
            //sno ();
        }
        private void loadgrid()
        {
            //sql = "select * from tbl_reg"
            //If rs.State = 1 Then rs.Close()
            //rs.Open(sql, conn)
            DataGridView1.Rows.Clear();
            cn.Open();
            cmd.CommandText = "select * from tbl_streg";
            int i;
            i = 0;
            //Do While Not rs.EOF
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    DataGridView1.Rows.Add();
                    DataGridView1.Rows[i].Cells[0].Value = dr[0];
                    DataGridView1.Rows[i].Cells[1].Value = dr[1];
                    DataGridView1.Rows[i].Cells[2].Value = dr[2];
                    DataGridView1.Rows[i].Cells[3].Value = dr[3];
                    DataGridView1.Rows[i].Cells[4].Value = dr[4];
                    DataGridView1.Rows[i].Cells[5].Value = dr[5];
                    DataGridView1.Rows[i].Cells[6].Value = dr[6];
                    DataGridView1.Rows[i].Cells[7].Value = dr[7];
                   // DataGridView1.Rows[i].Cells[8].Value = dr[8];
                    i = i + 1;
                }
            }
            cn.Close();
        }
        
        private void clear()
        {
            txtsno.Text = "";
        txtname.Text = "";
        txtclgname.Text = "";
        cmdsport.SelectedIndex = -1;
        DateTimePicker1.Value = DateTime.Today;
        txtage.Text = "";
        cmdgender.SelectedIndex = -1;
        txttname.Text = "";
       // txtphoto.Text = "";

        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtsno.Text = DataGridView1.CurrentRow.Cells[0].Value.ToString();
        txtname.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
        txtclgname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
        cmdsport.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
        DateTimePicker1.Value  =DateTime.Parse( DataGridView1.CurrentRow.Cells[4].Value.ToString ());
        txtage.Text = DataGridView1.CurrentRow.Cells[5].Value.ToString();
        cmdgender.Text = DataGridView1.CurrentRow.Cells[6].Value.ToString();
        txttname.Text = DataGridView1.CurrentRow.Cells[7].Value.ToString();
       // txtphoto.Text = DataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

       
        private void dosomething(String q)
        {
            try
            {
                cn.Open();
                cmd.CommandText = q;
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception e)
            {
                cn.Close();
                MessageBox.Show(e.Message.ToString());
            }
        }

     
      
        

        private void txtage_Click(object sender, EventArgs e)
        {
            
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            int myAge = DateTime.Today.Year - DateTimePicker1.Value.Year; // CurrentYear - YourBirthDate
            txtage.Text = myAge.ToString();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            if (txtsno.Text == "")
            {
                MessageBox.Show("enter student no");
            }
            else
                if (txtname.Text == "")
                {
                    MessageBox.Show("enter student name");
                }
                else
                    if (txtclgname.Text == "")
                    {
                        MessageBox.Show("enter college name");
                    }
                    else
                        if (txtage.Text == "")
                        {
                            MessageBox.Show("age is not calculated");
                        }
                        else
                            if (cmdsport.Text == "")
                            {
                                MessageBox.Show("select sport");
                            }
                            else
                                if (cmdgender.Text == "")
                                {
                                    MessageBox.Show("select gender");
                                }
                                else
                                    if (txttname.Text == "")
                                    {
                                        MessageBox.Show("select team name");
                                    }

                                    else
                                    {
                                        string q = "insert into tbl_streg(sno,name,clgname,sport,dob,age,gender,tname) values('" + txtsno.Text + "','" + txtname.Text + "','" + txtclgname.Text + "','" + cmdsport.Text + "', convert(date,'" + DateTimePicker1.Value + "',103),'" + txtage.Text + "','" + cmdgender.Text + "','" + txttname.Text + "')";
                                        dosomething(q);
                                        MessageBox.Show("Record Added");
                                        clear();
                                        //sno();
                                        loadgrid();
                                    }
        }

      

        private void Button4_Click_1(object sender, EventArgs e)
        {
            clear();
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            string q = "update tbl_streg set name='" + txtname.Text + "',clgname='" + txtclgname.Text + "', sport='" + cmdsport.Text + "',dob=convert(date,'" + DateTimePicker1.Text + "',103),age='" + txtage.Text + "',gender='" + cmdgender.Text + "',tname='" + txttname.Text + "' where sno='" + txtsno.Text + "'";
            dosomething(q);
            MessageBox.Show("Record Updated");
            clear();
            loadgrid();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            string q = "delete from tbl_streg where sno='" + txtsno.Text + "'";
            dosomething(q);
            MessageBox.Show("Record Deleted");
            clear();
            loadgrid();
        }

        
        
        
    }
}
