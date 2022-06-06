using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRINT_SHOP.Forms
{
    public partial class setRpId : Form
    {
        public setRpId()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        DataTable dataset;
        private void setRpId_Load(object sender, EventArgs e)
        {
            if(id == 1)
            {
                MySqlConnection mycon = new MySqlConnection(connection.con);
                MySqlCommand cmd = new MySqlCommand("Select rp_id ,cust_name,contact_no,manufacture,model,other_issues from repair where state = '" + "Job Done" + "';", mycon);

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
                    this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].HeaderText = "Repair ID";
                    dataGridView1.Columns[1].HeaderText = "Customer Name";
                    dataGridView1.Columns[2].HeaderText = "Contact Number";
                    dataGridView1.Columns[3].HeaderText = "Manufacture";
                    dataGridView1.Columns[4].HeaderText = "Model";
                    dataGridView1.Columns[5].HeaderText = "Other Issues";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }else if(id == 2)
            {
                MySqlConnection mycon = new MySqlConnection(connection.con);
                MySqlCommand cmd = new MySqlCommand("Select rp_id ,cust_name,contact_no,manufacture,model,other_issues from repair where state = '" + "Pending" + "';", mycon);

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
                    this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    this.dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].HeaderText = "Repair ID";
                    dataGridView1.Columns[1].HeaderText = "Customer Name";
                    dataGridView1.Columns[2].HeaderText = "Contact Number";
                    dataGridView1.Columns[3].HeaderText = "Manufacture";
                    dataGridView1.Columns[4].HeaderText = "Model";
                    dataGridView1.Columns[5].HeaderText = "Other Issues";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         if(id == 1)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string cust_id = row.Cells["rp_id"].Value.ToString();
                Whole_Sales.instance.rpid.Text = cust_id.ToString();
                this.Close();
            }else if(id == 2)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                string cust_id = row.Cells["rp_id"].Value.ToString();
                RepairOut.instance.rpid.Text = cust_id.ToString();
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                try
                {
                    DataView Dv = new DataView(dataset);
                    Dv.RowFilter = string.Format("rp_id LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = Dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                try
                {
                    DataView Dv = new DataView(dataset);
                    Dv.RowFilter = string.Format("cust_name LIKE '%{0}%'", textBox1.Text);
                    dataGridView1.DataSource = Dv;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
