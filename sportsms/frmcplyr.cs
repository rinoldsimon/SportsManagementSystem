﻿using System;
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
    public partial class frmcplyr : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=V:\C#\Visual Studio 2010\Projects\sportsms\sportsms\sps.mdf;Integrated Security=True;User Instance=True");
        SqlCommand cmd = new SqlCommand();
        SqlDataReader dr;
        public frmcplyr()
        {
            InitializeComponent();
        }

        private void frmcplyr_Load(object sender, EventArgs e)
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
            cmd.CommandText = "select * from tbl_streg where (sport = N'CRICKET')";
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
                    i = i + 1;
                }
            }
            cn.Close();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
