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
    public partial class RepairOut : Form
    {
        public static RepairOut instance;
        public TextBox rpid;
        public RepairOut()
        {
            InitializeComponent();
            instance = this;
            rpid = jobIDtxt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            setRpId se = new setRpId();
            se.MdiParent = this.MdiParent;
            se.ID = 2;
            se.Show();
        }

        private void RepairOut_Load(object sender, EventArgs e)
        {
            this.ActiveControl = jobIDtxt;
            textBox3.Text = "0";
        }

        private void jobIDtxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                getItemdata();
                textBox3.Clear();
            }
        }
        DataTable dataset2;
        private void getItemdata()
        {
            try
            {
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("select * from item where Item_id  = '" + this.textBox1.Text + "' ;");
                dataset2 = new DataTable();
                sda.Fill(dataset2);
                if (dataset2.Rows.Count == 1)
                {
                    foreach (DataRow row in dataset2.Rows)
                    {
                        textBox5.Text = row["Item_name"].ToString();
                        textBox2.Text = row["rate"].ToString();
                        textBox6.Text = row["Cost"].ToString();
                    }
                    textBox2.Focus();
                }
                else
                {
                    MessageBox.Show("No Item Found");
                    ActiveControl = textBox1;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    if (e.KeyChar == 13)
                    {
                        get_retial_price();
                        decimal dis;
                        decimal p = decimal.Parse(textBox2.Text);
                        dis = r - p;
                        textBox3.Text = dis.ToString();
                        ActiveControl = comboBox1;
                    }
                }
                catch
                {

                }
            }
        }
        decimal r;
        private void get_retial_price()
        {
            try
            {
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("select * from item where Item_id  = '" + this.textBox1.Text + "' ;");
                dataset2 = new DataTable();
                sda.Fill(dataset2);
                if (dataset2 != null)
                {
                    foreach (DataRow row in dataset2.Rows)
                    {
                        r = decimal.Parse(row["rate"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("No Item Found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        decimal profit;
        decimal total;
        decimal total_cost;
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                try
                {
                    decimal price = decimal.Parse(textBox2.Text);
                    int qty = int.Parse(textBox4.Text);
                    decimal cost = decimal.Parse(textBox6.Text);
                    total = (price * qty);
                    total_cost = cost * qty;
                    profit = total - total_cost;
                        add_to_datagrid();
                        cal_sub_total();
                        clear_();
                }catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cal_sub_total()
        {
            float sum = 0;

            for (int row = 0; row < dataGridView2.Rows.Count; row++)
            {
                sum = sum + Convert.ToInt32(dataGridView2.Rows[row].Cells[3].Value);
            }
            label8.Text = sum.ToString();
        }

        private void add_to_datagrid()
        {
            try
            {
                string id = textBox1.Text;
                string name = textBox5.Text;
                decimal price = decimal.Parse(textBox2.Text);
                int qty = int.Parse(textBox4.Text);
                decimal dis = decimal.Parse(textBox3.Text);
                string warranty = comboBox1.Text;

                this.dataGridView2.Rows.Add(id, name,warranty, price, dis, qty, total, profit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void clear_()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Text = "0";
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(dataGridView2.Rows.Count == 1)
            {
                MessageBox.Show("Fill all data");
            }
            else
            {
                try
                {
                    var up = new updatData();
                    up.update("update repair set state = '" + "Job Done" + "' where rp_id = '" + jobIDtxt.Text + "';");
                    MessageBox.Show("Done");
                    saveDetailedRepair();
                    dataGridView2.Rows.Clear();
                    comboBox1.Text = "";
                    textBox6.Clear();
                    label8.Text = "0.00";
                    textBox3.Text = "0";
                }
                catch
                {
                }
            }
        }

        private void saveDetailedRepair()
        {
            try
            {
                string item_id;
                for (int row = 0; row < dataGridView2.Rows.Count; row++)
                {

                    item_id = dataGridView2.Rows[row].Cells[0].Value.ToString();
                    string warranty = dataGridView2.Rows[row].Cells[2].Value.ToString();
                    decimal price = decimal.Parse(dataGridView2.Rows[row].Cells[3].Value.ToString());
                    int qty = int.Parse(dataGridView2.Rows[row].Cells[5].Value.ToString());
                    decimal dis = decimal.Parse(dataGridView2.Rows[row].Cells[4].Value.ToString());
                    decimal profit = decimal.Parse(dataGridView2.Rows[row].Cells[7].Value.ToString());
                    decimal tot = decimal.Parse(dataGridView2.Rows[row].Cells[6].Value.ToString());
                    string name = dataGridView2.Rows[row].Cells[1].Value.ToString();
                    var ins = new insertData();
                    ins.insert("INSERT INTO `detailedrepair`( `rpId`, `itemId`,name, `warranty`, `Rate`, `discount`, `qty`, `total`, `profit`) VALUES ('" + jobIDtxt.Text + "','" + item_id + "','" + name + "','" + warranty + "','" + price + "','" + dis + "','" + qty + "','" + tot + "','" + profit + "')");
                }
            }
            catch
            {

            }

        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                textBox4.Focus();
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView2.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                dataGridView2.Rows.Remove(dataGridView2.Rows[e.RowIndex]);
                cal_sub_total();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("", "! Do you want to update this job as can't ?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var up = new updatData();
                up.update("update repair set state = '"+"Reject"+ "' where rp_id ='"+jobIDtxt.Text+"';");
                MessageBox.Show("Done");
                jobIDtxt.Clear();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                textBox6.Focus();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                textBox2.Focus();
            }
        }
    }
}
