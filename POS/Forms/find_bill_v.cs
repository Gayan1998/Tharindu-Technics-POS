using MySql.Data.MySqlClient;
using PRINT_SHOP.repot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRINT_SHOP
{
    public partial class find_bill_v : Form
    {
        public find_bill_v()
        {
            InitializeComponent();
        }

        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private void find_bill_v_Load(object sender, EventArgs e)
        {
            checkBillType();
        }
        string rpID;
        private void checkBillType()
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(connection.con);
                MySqlCommand select = new MySqlCommand("select * from invoice where id = '" + id + "';", mycon);
                MySqlDataReader reader;
                mycon.Open();
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    rpID = reader["rpID"].ToString();
                }
                if (string.IsNullOrEmpty(rpID))
                {
                    loadBill();
                }
                else
                {
                    loadRepairBill();
                }
            }
            catch
            {

            }
        }

        private void loadRepairBill()
        {
            MySqlDataAdapter dr;
            try
            {
                DataTable dt = new DataTable();
                var get = new getData();
                dr = get.returnData("select * from item ");
                dr.Fill(dt);

                DataTable dt1 = new DataTable();
                dr = get.returnData("select * from detialed_invoice where inv_id ='" + id + "'");
                dr.Fill(dt1);

                DataTable dt3 = new DataTable();
                dr = get.returnData("select * from invoice where id  = '" + id+ "'");
                dr.Fill(dt3);

                DataTable dt4 = new DataTable();
                dr = get.returnData("select * from repair where rp_id = '" + rpID + "'");
                dr.Fill(dt4);

                repairOutBill cr2 = new repairOutBill();
                cr2.Database.Tables["item"].SetDataSource(dt);
                cr2.Database.Tables["detialed_invoice"].SetDataSource(dt1);
                cr2.Database.Tables["invoice"].SetDataSource(dt3);
                cr2.Database.Tables["repair"].SetDataSource(dt4);
                this.crystalReportViewer1.ReportSource = cr2;
            }
            catch
            {

            }
        }

        private void loadBill()
        {
            MySqlDataAdapter dr;
            try
            {
                DataTable dt = new DataTable();
                var get = new getData();
                dr = get.returnData("select * from item ");
                dr.Fill(dt);

                DataTable dt1 = new DataTable();
                dr = get.returnData("select * from detialed_invoice where inv_id ='" + id.ToString() + "'");
                dr.Fill(dt1);

                DataTable dt3 = new DataTable();
                dr = get.returnData("select * from invoice where id  = '" + id.ToString() + "'");
                dr.Fill(dt3);

                Bill_rpt cr2 = new Bill_rpt();
                cr2.Database.Tables["item"].SetDataSource(dt);
                cr2.Database.Tables["detialed_invoice"].SetDataSource(dt1);
                cr2.Database.Tables["invoice"].SetDataSource(dt3);
                this.crystalReportViewer1.ReportSource = cr2;
            }
            catch
            {

            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection mycon = new MySqlConnection(connection.con);
                MySqlCommand select = new MySqlCommand("select * from invoice where id = '" + id + "';", mycon);
                MySqlDataReader reader;
                mycon.Open();
                reader = select.ExecuteReader();
                while (reader.Read())
                {
                    rpID = reader["rpID"].ToString();
                }
                if (string.IsNullOrEmpty(rpID))
                {
                    printBill();
                }
                else
                {
                    printRepairBill();
                }
            }
            catch
            {

            }
        }

        private void printRepairBill()
        {
            MySqlDataAdapter dr;
            try
            {
                DataTable dt = new DataTable();
                var get = new getData();
                dr = get.returnData("select * from item ");
                dr.Fill(dt);

                DataTable dt1 = new DataTable();
                dr = get.returnData("select * from detialed_invoice where inv_id ='" + id + "'");
                dr.Fill(dt1);

                DataTable dt3 = new DataTable();
                dr = get.returnData("select * from invoice where id  = '" + id + "'");
                dr.Fill(dt3);

                DataTable dt4 = new DataTable();
                dr = get.returnData("select * from repair where rp_id = '" + rpID + "'");
                dr.Fill(dt4);

                repairOutBill cr2 = new repairOutBill();
                cr2.Database.Tables["item"].SetDataSource(dt);
                cr2.Database.Tables["detialed_invoice"].SetDataSource(dt1);
                cr2.Database.Tables["invoice"].SetDataSource(dt3);
                cr2.Database.Tables["repair"].SetDataSource(dt4);
                cr2.PrintToPrinter(1,false,0,0);
            }
            catch
            {

            }
        }

        private void printBill()
        {
            MySqlDataAdapter dr;
            try
            {
                DataTable dt = new DataTable();
                var get = new getData();
                dr = get.returnData("select * from item ");
                dr.Fill(dt);

                DataTable dt1 = new DataTable();
                dr = get.returnData("select * from detialed_invoice where inv_id ='" + id.ToString() + "'");
                dr.Fill(dt1);

                DataTable dt3 = new DataTable();
                dr = get.returnData("select * from invoice where id  = '" + id.ToString() + "'");
                dr.Fill(dt3);

                Bill_rpt cr2 = new Bill_rpt();
                cr2.Database.Tables["item"].SetDataSource(dt);
                cr2.Database.Tables["detialed_invoice"].SetDataSource(dt1);
                cr2.Database.Tables["invoice"].SetDataSource(dt3);
                cr2.PrintToPrinter(1, false, 0, 0);
            }
            catch
            {

            }
        }
    }
}
