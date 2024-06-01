using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileRepair
{
    public partial class Repair : Form
    {
        Functions Con;
        public Repair()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRepairs();
            GetCustomer();
            GetSpare();
            GetCost();
        }
        private void GetCost()
        {
            string Query = "select * from SpareTbl where SpCode = {0}";
            Query = string.Format(Query,SpareCb.SelectedValue.ToString());
            foreach(DataRow dr in Con.GetData(Query).Rows)
            {
                SpareCostTb.Text = dr["SpCost"].ToString();
            }
           // MessageBox.Show("Hello");

        }
        private void GetCustomer()
        {
            string Query = "Select * from CustomerTbl";
            CustCb.DisplayMember = Con.GetData(Query).Columns["CustName"].ToString();
            CustCb.ValueMember = Con.GetData(Query).Columns["CustCode"].ToString();
            CustCb.DataSource = Con.GetData(Query);
        }

        private void GetSpare()
        {
            string Query = "Select * from SpareTbl";
            SpareCb.DisplayMember = Con.GetData(Query).Columns["SpName"].ToString();
            SpareCb.ValueMember = Con.GetData(Query).Columns["SpCode"].ToString();
            SpareCb.DataSource = Con.GetData(Query);
        }
        private void ShowRepairs()
        {
            string Query = "select * from RepairTbl";
            RepairsList.DataSource = Con.GetData(Query);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (CustCb.SelectedIndex == -1 || DNameTb.Text == "" || ModelTb.Text == ""|| ProblemTb.Text == ""|| SpareCb.SelectedIndex == -1|| SpareCostTb.Text ==""||TotalTb.Text=="" )
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string RDate = RepDateTb.Value.Date.ToString();
                    int Customer = Convert.ToInt32(CustCb.SelectedValue.ToString());
                    string Cphone = PhoneTb.Text;
                    string DeviceName = DNameTb.Text;
                    string DeviceModel = ModelTb.Text;
                    string Problem = ProblemTb.Text;
                    int Spare = Convert.ToInt32(SpareCb.SelectedValue.ToString());
                    int Total = Convert.ToInt32(TotalTb.Text);
                    int GrdTotal = Convert.ToInt32(SpareCostTb.Text) + Total;
      
                    string Query = "Insert into RepairTbl values( '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')";
                    Query = string.Format(Query, RDate, Customer, Cphone,DeviceName,DeviceModel,Problem,Spare,GrdTotal);
                    // int i = Con.SetData(Query);
                    Con.SetData(Query);
                    MessageBox.Show("Repair Added!!!");
                    ShowRepairs();
                   // Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void SpareCb_SelectedChangeCommitted(object sender,EventArgs e)
        {
            GetCost();
        }

        private void SpareCostTb_TextChanged(object sender, EventArgs e)
        {

        }
       // int key = 0;
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
           /* if (key == 0)
            {
                MessageBox.Show("Select a repair!!!");
            }
            else
            {
                try
                {
                    string Query = "DELETE FROM RepairTbl WHERE RepCode = @RepCode";
                    using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\janna\\Documents\\MobileRepairDb.mdf;Integrated Security=True;Connect Timeout=30"))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(Query, con))
                        {
                            cmd.Parameters.AddWithValue("@RepCode", key);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Repair deleted!!!");
                    ShowRepairs();
                    // Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }*/

              if (key == 0)
              {
                  MessageBox.Show("Select a repair!!!");
              }
              else
              {
                  try
                  {
                    

                      string Query = "Delete from RepairTbl where RepCode = {0}";
                      Query = string.Format(Query, key);

                      Con.SetData(Query);
                      MessageBox.Show("Repair deleted!!!");
                      ShowRepairs();
                      // Clear();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show(ex.Message);
                  }
              }



        } 

         int key = 0;

        private void RepairsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < RepairsList.Rows.Count)
            {
                 RepDateTb.Text = RepairsList.Rows[e.RowIndex].Cells[1].Value.ToString();
                 CustCb.Text  = RepairsList.Rows[e.RowIndex].Cells[2].Value.ToString();
                 DNameTb.Text = RepairsList.Rows[e.RowIndex].Cells[3].Value.ToString();
                 ModelTb.Text = RepairsList.Rows[e.RowIndex].Cells[4].Value.ToString();
                 ProblemTb.Text = RepairsList.Rows[e.RowIndex].Cells[5].Value.ToString();
                 SpareCb.Text = RepairsList.Rows[e.RowIndex].Cells[6].Value.ToString();
                 SpareCostTb.Text = RepairsList.Rows[e.RowIndex].Cells[7].Value.ToString();
                 TotalTb.Text = RepairsList.Rows[e.RowIndex].Cells[8].Value.ToString();

                if (RepDateTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(RepairsList.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }
           // key = Convert.ToInt32 (RepairsList.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Spares Obj = new Spares();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Customers Obj = new Customers();
            Obj.Show();
            this.Hide();
        }
    }
}
