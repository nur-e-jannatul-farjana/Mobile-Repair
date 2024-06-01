﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MobileRepair
{
     class Functions
    {
        private SqlConnection Con;
        private SqlCommand cmd;
        private DataTable dt;
        private SqlDataAdapter sda;
        private string ConStr;

        public Functions()
        {

            ConStr = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\janna\Documents\MobileRepairDb.mdf;Integrated Security=True;Connect Timeout=30";
            Con = new SqlConnection(ConStr);
            cmd = new SqlCommand();
            cmd.Connection = Con;
        }
        public DataTable GetData(string Query)
        {
            dt = new DataTable();
            sda = new SqlDataAdapter(Query, ConStr);
            sda.Fill(dt);
            return dt;
        }
        public int SetData(string Query)
        {
            int Cnt = 0;
            if (Con.State == ConnectionState.Closed)
            {
                Con.Open();
            }
            cmd.CommandText = Query;
            Cnt = cmd.ExecuteNonQuery();
            Con.Close();
            return Cnt;
        }
    }
}
