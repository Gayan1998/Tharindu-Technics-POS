using MySql.Data.MySqlClient;
using PRINT_SHOP.Forms;
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
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
        }
        private string Emp;

        public string emp
        {
            get { return Emp; }
            set { Emp = value; }
        }

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }
        private void Dash_Load(object sender, EventArgs e)
        {
            Whole_Sales child = new Whole_Sales();
            child.MdiParent = this;
            child.Emp = Emp;
            child.Show();
            if (type == "Admin")
            {
                profitReportToolStripMenuItem.Enabled = true;
                salesReportToolStripMenuItem.Enabled = true;
                inventoryManagementToolStripMenuItem.Enabled = true;
                addNewUserToolStripMenuItem.Enabled = true;
                itemRegisterToolStripMenuItem.Enabled = true;
                salesReportCategoryViseToolStripMenuItem.Enabled = true;
                profitReport2ToolStripMenuItem.Enabled = true;
            }
            else if (type == "Top lavel emp")
            {
                inventoryManagementToolStripMenuItem.Enabled = true;
                itemRegisterToolStripMenuItem.Enabled = true;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\backup\\backup.sql";
                string p = "C:\\Users\\user\\Dropbox\\backup.sql";
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=taridu_tecnics; convert zero datetime = true;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = con;
                            con.Open();
                            mb.ExportToFile(path);
                            con.Close();
                            MessageBox.Show("Backup Compleated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Application.Exit();
        }

        private void itemRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Item_Register child = new Item_Register();
            child.MdiParent = this;
            child.Show();
        }

        private void customerRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_customer child = new add_customer();
            child.MdiParent = this;
            child.Show();
        }

        private void retialSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Whole_Sales child = new Whole_Sales();
            child.MdiParent = this;
            child.Emp = Emp;
            child.Show();
        }

        private void sattleBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settle_Balance child = new Settle_Balance();
            child.MdiParent = this;
            child.Show();
        }

        private void addStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GRN child = new GRN();
            child.Type = type;
            child.MdiParent = this;
            child.Show();
        }

        private void returnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_from_bill child = new Return_from_bill();
            child.MdiParent = this;
            child.Show();
        }

        private void acceptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Repair_in child = new Repair_in();
            child.MdiParent = this;
            child.Show();
        }

        private void repairDeviceDetialsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepairOut child = new RepairOut();
            child.MdiParent = this;
            child.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 1;
            child.MdiParent = this;
            child.Show();
        }

        private void shortageOfGoodsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 2;
            child.MdiParent = this;
            child.Show();
        }

        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 3;
            child.MdiParent = this;
            child.Show();
        }

        private void profitReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 4;
            child.MdiParent = this;
            child.Show();
        }

        private void customerInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cashBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 5;
            child.MdiParent = this;
            child.Show();
        }

        private void outstandingPaymentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 6;
            child.MdiParent = this;
            child.Show();
        }

        private void backupDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "C:\\backup\\backup.sql";
                string p2 ="C:\\Users\\user\\Dropbox\\backup.sql";
                string connectionString = "datasource=localhost;port=3306;username=root;password=;database=taridu_tecnics; convert zero datetime = true;";
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = con;
                            con.Open();
                            mb.ExportToFile(path);
                            con.Close();
                            MessageBox.Show("Backup Compleated");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void enterChequeDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ceque_Data child = new Ceque_Data();
            child.MdiParent = this;
            child.Show();
        }

        private void outstandingChecksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 7;
            child.MdiParent = this;
            child.Show();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_new_user child = new add_new_user();
            child.MdiParent = this;
            child.Show();
        }

        private void addSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add_supplier child = new add_supplier();
            child.MdiParent = this;
            child.Show();
        }

        private void trackPhonesByImeiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Track__phone_by_imei child = new Track__phone_by_imei();
            child.MdiParent = this;
            child.Show();
        }

        private void returnToSupplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Return_to_Supplier child = new Return_to_Supplier();
            child.MdiParent = this;
            child.Show();
        }

        private void deleteProfitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete_profit child = new Delete_profit();
            child.MdiParent = this;
            child.Show();
        }

        private void binCardToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void cardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCards child = new AddCards();
            child.MdiParent = this;
            child.Show();
        }

        private void cardSaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 8;
            child.MdiParent = this;
            child.Show();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salesReportCategoryViseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 9;
            child.MdiParent = this;
            child.Show();
        }

        private void repairAdvanceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 10;
            child.MdiParent = this;
            child.Show();
        }

        private void repairDeviceDetialsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectRepair child = new selectRepair();
            child.MdiParent = this;
            child.Show();
        }

        private void salesByPersonReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 11;
            child.MdiParent = this;
            child.Show();
        }

        private void profitReport2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_rpt_v child = new Stock_rpt_v();
            child.Val = 12;
            child.MdiParent = this;
            child.Show();
        }

        private void markAttendenceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            atendence child = new atendence();
            child.MdiParent = this;
            child.Show();
        }
    }
}
