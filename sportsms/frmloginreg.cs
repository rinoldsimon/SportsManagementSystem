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
    public partial class frmloginreg : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmloginreg()
        {
            InitializeComponent();
        }

        private void frmloginreg_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
            loadgrid();

        }
        private void  loadgrid()
        {
        //sql = "select * from tbl_reg"
        //If rs.State = 1 Then rs.Close()
        //rs.Open(sql, conn)
        DataGridView1.Rows.Clear();
            cn.Open ();
             cmd.CommandText = "select * from tbl_reg";
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
        private void  clear()
        {
        cmdutype.SelectedIndex = -1;
        txtuname.Text = "";
        txtpass.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmdutype.Text = DataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtuname.Text = DataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtpass.Text = DataGridView1.CurrentRow.Cells[3].Value.ToString();
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
            if (cmdutype.Text == "" )
            {
            MessageBox .Show ("select usertype");
            }
        else
            if (txtuname.Text == "" )
            {
            MessageBox .Show ("enter username");
            }
        else
                if (txtpass.Text == "")
                {
                    MessageBox.Show("enter password");
                }
                else
                {
                    string q = "insert into tbl_reg(usertype,username,password) values('" + cmdutype.Text + "','" + txtuname.Text + "','" + txtpass.Text + "')";
                    dosomething(q);
                    MessageBox.Show("Record Added");
                    clear();
                    loadgrid();
                }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
           string q = "update tbl_reg set usertype='" + cmdutype.Text + "',username='" + txtuname.Text + "',password='" + txtpass.Text + "' where id= '" + DataGridView1.CurrentRow.Cells[0].Value + "'";
        dosomething(q);
        MessageBox.Show("Record Updated");
        clear();
        loadgrid();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string q = "delete from tbl_reg where id='" + DataGridView1.CurrentRow.Cells[0].Value + "'";
        dosomething(q);
      MessageBox.Show("Record Deleted");
        clear();
        loadgrid();
        }

        private void cmdutype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
