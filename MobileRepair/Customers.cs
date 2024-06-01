using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileRepair
{
    public partial class Customers : Form
    {
        Functions Con;
        public Customers()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCustomers();

        }
        private void ShowCustomers()
        {
            string Query = "select * from CustomerTbl";
            CustomerList.DataSource = Con.GetData(Query);
        }
        private void SaveBtn_Click(object sender, EventArgs e)
        {

            if(CustNameTb.Text == "" ||CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;
                    
                    string Query = "Insert into CustomerTbl values( '{0}','{1}','{2}')";
                    Query = string.Format(Query, CName, CPhone, CAdd);
                   // int i = Con.SetData(Query);
                    Con.SetData(Query);
                    MessageBox.Show("Customers Added!!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        int key = 0;
        private void CustomerList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < CustomerList.Rows.Count)
            {
                CustNameTb.Text = CustomerList.Rows[e.RowIndex].Cells[1].Value.ToString();
                CustPhoneTb.Text = CustomerList.Rows[e.RowIndex].Cells[2].Value.ToString();
                CustAddTb.Text = CustomerList.Rows[e.RowIndex].Cells[3].Value.ToString();

                if (CustNameTb.Text == "")
                {
                    key = 0;
                }
                else
                {
                    key = Convert.ToInt32(CustomerList.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
            }

            /*  CustNameTb.Text = CustomerList.SelectedRows[0].Cells[0].Value.ToString();   
              CustPhoneTb.Text = CustomerList.SelectedRows[0].Cells[1].Value.ToString();   
              CustAddTb.Text = CustomerList.SelectedRows[0].Cells[2].Value.ToString(); 

              if(CustNameTb.Text == "")
              {
                  key = 0;
              }
              else
              {
                  key = Convert.ToInt32(CustomerList.SelectedRows[0].Cells[0].Value.ToString());
              } */
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {

            if (CustNameTb.Text == "" || CustPhoneTb.Text == "" || CustAddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string CName = CustNameTb.Text;
                    string CPhone = CustPhoneTb.Text;
                    string CAdd = CustAddTb.Text;

                    string Query = "Update CustomerTbl set CustName= '{0}',CustPhone = '{1}',CustAdd = '{2}' where CustCode = {3} ";
                    Query = string.Format(Query, CName, CPhone, CAdd,key);
                    // int i = Con.SetData(Query);
                    Con.SetData(Query);
                    MessageBox.Show("Customers Updated!!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Clear()
        {
            CustNameTb.Text = "";
            CustPhoneTb.Text = "";
            CustAddTb.Text = "";
            key = 0;
        }
        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0 )
            {
                MessageBox.Show("Select a Customer !!!");
            }
            else
            {
                try
                {
                  

                    string Query = "Delete from CustomerTbl where  CustCode = {0} ";
                    Query = string.Format(Query, key);
                    // int i = Con.SetData(Query);
                    Con.SetData(Query);
                    MessageBox.Show("Customers Deleted!!!");
                    ShowCustomers();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Repair  Obj = new Repair();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
