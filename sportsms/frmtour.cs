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
    public partial class frmtour : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmtour()
        {
            InitializeComponent();
        }

        private void frmtour_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadgrid();

        }
        private void loadgrid()
        {
            //sql = "select * from tbl_reg"
            //If rs.State = 1 Then rs.Close()
            //rs.Open(sql, conn)
            DataGridView1.Rows.Clear();
            cn.Open();
            cmd.CommandText = "select * from tbl_tour";
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
                    i = i + 1;
                }
            }
            cn.Close();
        }
        private void clear()
        {
            txttour.SelectedIndex  = -1 ;
        txtvenue.Text = "";
        DateTimePicker1.Value = DateTime.Today;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            clear();
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

        private void Button1_Click(object sender, EventArgs e)
        {
            if (txttour.Text == "")
            {
                MessageBox.Show("enter the tournament name");
            }
            else
                if (txtvenue.Text == "")
                {
                    MessageBox.Show("enter the venue");
                }
                    else
                    {
                        string q = "insert into tbl_tour(tournament,date,venue) values('" + txttour.Text + "',convert(date,'" + DateTimePicker1.Value + "',103),'" + txtvenue.Text + "')";
                        dosomething(q);
                        MessageBox.Show("Record Added");
                        clear();
                        loadgrid();
                    }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string q = "update tbl_tour set tournament = '" + txttour.Text + "',date= convert(date,'" + DateTimePicker1.Value + "',103), venue= '" + txtvenue.Text + "' where tno='" + DataGridView1.CurrentRow.Cells[0].Value + "'";
            dosomething(q);
            MessageBox.Show("Record Updated");
            clear();
            loadgrid();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            string q = "delete from tbl_tour where tno='" + DataGridView1.CurrentRow.Cells[0].Value + "'";
        dosomething(q);
      MessageBox.Show("Record Deleted");
        clear();
        loadgrid();
        
        }

        private void DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            txttour.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            DateTimePicker1.Value = DateTime.Parse(DataGridView1.CurrentRow.Cells[2].Value.ToString());
            txtvenue.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
        }
    }
}
