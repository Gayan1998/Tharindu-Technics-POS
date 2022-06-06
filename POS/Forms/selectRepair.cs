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
    public partial class selectRepair : Form
    {
        public selectRepair()
        {
            InitializeComponent();
        }
        DataTable dataset;
        private void repair_out_Load(object sender, EventArgs e)
        {

            load_datagrid();
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                try
                {
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    var get = new getData();
                    sda = get.returnData("Select id,rp_id,cust_name,contact_no,manufacture,model,ime,other_issues,include,in_date,fault from repair where state = '" + "Pending" + "';");
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dataset;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dataset);
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["rp_id"].HeaderText = "Repair ID";
                    dataGridView1.Columns["cust_name"].HeaderText = "Customer Name";
                    dataGridView1.Columns["manufacture"].HeaderText = "Manufacture";
                    dataGridView1.Columns["model"].HeaderText = "Model";
                    dataGridView1.Columns["ime"].HeaderText = "IMEI";
                    dataGridView1.Columns["other_issues"].HeaderText = "Faults";
                    dataGridView1.Columns["fault"].HeaderText = "Other issues";
                    dataGridView1.Columns["in_date"].HeaderText = "In Date";
                    dataGridView1.Columns["include"].HeaderText = "Includs";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    var get = new getData();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda = get.returnData("Select id,rp_id,cust_name,contact_no,manufacture,model,ime,fault,other_issues,include,in_date,note from repair where state = '" + "Job Done" + "';");
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dataset;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dataset);
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["rp_id"].HeaderText = "Repair ID";
                    dataGridView1.Columns["cust_name"].HeaderText = "Customer Name";
                    dataGridView1.Columns["manufacture"].HeaderText = "Manufacture";
                    dataGridView1.Columns["model"].HeaderText = "Model";
                    dataGridView1.Columns["ime"].HeaderText = "IMEI";
                    dataGridView1.Columns["other_issues"].HeaderText = "Faults";
                    dataGridView1.Columns["fault"].HeaderText = "Other issues";
                    dataGridView1.Columns["in_date"].HeaderText = "In Date";
                    dataGridView1.Columns["include"].HeaderText = "Includs";
                    dataGridView1.Columns["note"].HeaderText = "Note";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    var get = new getData();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda = get.returnData("Select id,rp_id,cust_name,contact_no,manufacture,model,ime,fault,other_issues,include,in_date,note from repair where state = '" + "paid" + "';");
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dataset;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dataset);
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["rp_id"].HeaderText = "Repair ID";
                    dataGridView1.Columns["cust_name"].HeaderText = "Customer Name";
                    dataGridView1.Columns["manufacture"].HeaderText = "Manufacture";
                    dataGridView1.Columns["model"].HeaderText = "Model";
                    dataGridView1.Columns["ime"].HeaderText = "IMEI";
                    dataGridView1.Columns["other_issues"].HeaderText = "Faults";
                    dataGridView1.Columns["fault"].HeaderText = "Other issues";
                    dataGridView1.Columns["in_date"].HeaderText = "In Date";
                    dataGridView1.Columns["include"].HeaderText = "Includs";
                    dataGridView1.Columns["note"].HeaderText = "Note";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if (comboBox1.SelectedIndex == 3)
            {
                try
                {
                    var get = new getData();
                    MySqlDataAdapter sda = new MySqlDataAdapter();
                    sda = get.returnData("Select id,rp_id,cust_name,contact_no,manufacture,model,ime,fault,other_issues,include,in_date,note from repair where state = '" + "Reject" + "';");
                    dataset = new DataTable();
                    sda.Fill(dataset);
                    BindingSource bsource = new BindingSource();

                    bsource.DataSource = dataset;
                    dataGridView1.DataSource = bsource;
                    sda.Update(dataset);
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["rp_id"].HeaderText = "Repair ID";
                    dataGridView1.Columns["cust_name"].HeaderText = "Customer Name";
                    dataGridView1.Columns["manufacture"].HeaderText = "Manufacture";
                    dataGridView1.Columns["model"].HeaderText = "Model";
                    dataGridView1.Columns["ime"].HeaderText = "IMEI";
                    dataGridView1.Columns["other_issues"].HeaderText = "Faults";
                    dataGridView1.Columns["fault"].HeaderText = "Other issues";
                    dataGridView1.Columns["in_date"].HeaderText = "In Date";
                    dataGridView1.Columns["include"].HeaderText = "Includs";
                    dataGridView1.Columns["note"].HeaderText = "Note";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView Dv = new DataView(dataset);
                Dv.RowFilter = string.Format("rp_id LIKE '%{0}%'", textBox5.Text);
                dataGridView1.DataSource = Dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView Dv = new DataView(dataset);
                Dv.RowFilter = string.Format("cust_name LIKE '%{0}%'", textBox6.Text);
                dataGridView1.DataSource = Dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void load_datagrid()
        {
            MySqlConnection mycon = new MySqlConnection(connection.con);
            MySqlCommand cmd = new MySqlCommand("Select * from repair;", mycon);
            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter();
                sda.SelectCommand = cmd;
                dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bsource = new BindingSource();

                bsource.DataSource = dataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dataset);
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["rp_id"].HeaderText = "Repair ID";
                dataGridView1.Columns["cust_name"].HeaderText = "Customer Name";
                dataGridView1.Columns["manufacture"].HeaderText = "Manufacture";
                dataGridView1.Columns["model"].HeaderText = "Model";
                dataGridView1.Columns["ime"].HeaderText = "IMEI";
                dataGridView1.Columns["other_issues"].HeaderText = "Faults";
                dataGridView1.Columns["fault"].HeaderText = "Other issues";
                dataGridView1.Columns["in_date"].HeaderText = "In Date";
                dataGridView1.Columns["include"].HeaderText = "Includs";
                dataGridView1.Columns["note"].HeaderText = "Note";
                dataGridView1.Columns["out_date"].HeaderText = "Out Date";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                    textBox1.Text = row.Cells["cust_name"].Value.ToString();
                    textBox3.Text = row.Cells["manufacture"].Value.ToString();
                    textBox8.Text = row.Cells["fullAmmount"].Value.ToString();
                    textBox9.Text = row.Cells["advance"].Value.ToString();
                    textBox4.Text = row.Cells["other_issues"].Value.ToString();
                    textBox7.Text = row.Cells["fault"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
