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
    public partial class frmlogin1 : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmlogin1()
        {
            InitializeComponent();
        }

        private void frmlogin1_Load(object sender, EventArgs e)
        {
            cmd.Connection = cn;
        }
        private void clear()
        {
            ComboBox1.SelectedIndex = -1;
        txtname.Text = "";
        txtpass.Text = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        if (ComboBox1.Text == "" )
        {
            MessageBox .Show  ("Enter usertype");
        }
        else
        if( txtname.Text == "") 
        {
            MessageBox .Show ("Enter the username");
        }
        else
            if (txtpass.Text == "")
            {
                MessageBox.Show("Enter the Password");
            }
            else
            {
                cn.Open();
                cmd.CommandText = "select * from tbl_reg where usertype='" + ComboBox1.Text + "' and username='" + txtname.Text + "' and password='" + txtpass.Text + "'";
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();


                if ((dr.Read() == true))
                {

                    if (ComboBox1.Text == "ADMIN")
                    {

                        this.Hide();
                        frmwelcome f1 = new frmwelcome();
                        f1.Show();
                        //ComboBox1.SelectedIndex = -1
                        txtname.Text = "";
                        txtpass.Text = "";
                    }

                    else
                        if (ComboBox1.Text == "EMPLOYEE")
                        {
                            this.Hide();
                            frmwelcome f1 = new frmwelcome();
                            f1.MASTERToolStripMenuItem.Visible = false;
                            f1.Show();
                            //ComboBox1.SelectedIndex = -1
                            txtname.Text = "";
                            txtpass.Text = "";
                        }

                }
                else
                {
                    MessageBox.Show("Login Failed");
                }
                
            }
       
        cn.Close();
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            clear();
        }
        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmloginreg f1 = new frmloginreg();
            f1.Show();
            f1.cmdutype.Items.Remove("EMPLOYEE");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
