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

namespace PRINT_SHOP
{
    public partial class AddCards : Form
    {
        public AddCards()
        {
            InitializeComponent();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                decimal rate = decimal.Parse(textBox3.Text);
                decimal cost = decimal.Parse(textBox2.Text);
                decimal profit = rate - cost;
                var ins = new insertData();
                ins.insert("INSERT INTO `cards`(`name`, `cost`, `rate`, `profit`, `qty`) VALUES ('"+textBox1.Text+"','"+cost+"','"+rate+"','"+profit+"','"+"0"+"')");
                MessageBox.Show("Done");
                textBox3.Clear();
                textBox2.Clear();
                textBox1.Clear();
                textBox1.Focus();
                loadcmb1();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddCards_Load(object sender, EventArgs e)
        {
            loadcmb1();
            loadDatagrid();
        }
        DataTable dataset;
        private void loadDatagrid()
        {
            try
            {
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select name,qty from cards;");
                dataset = new DataTable();
                sda.Fill(dataset);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dataset;
                dataGridView1.DataSource = bsource;
                sda.Update(dataset);

                this.dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadcmb1()
        {
            DataTable dataset2;
            try
            {
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select * from cards");
                dataset2 = new DataTable();
                sda.Fill(dataset2);
                if (dataset2 != null)
                {
                    foreach (DataRow row in dataset2.Rows)
                    {
                        string name;
                        name = row["name"].ToString();
                        comboBox1.Items.Add(name);
                        comboBox2.Items.Add(name);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var up = new updatData();
                up.update("UPDATE `cards` SET `qty`=qty +'"+textBox4.Text+"' WHERE name = '"+comboBox1.Text+"'");
                MessageBox.Show("Done");
                comboBox1.Text = "";
                textBox4.Clear();
                loadDatagrid();
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int qty = getCardqty();
                int remainingQty = int.Parse(textBox5.Text);
                int soldqty = qty - remainingQty;
                string today = DateTime.Today.ToString("yyyy-MM-dd");
                var ins = new insertData();
                ins.insert("INSERT INTO `dailycardsale`(`date`, `name`, `qty`) VALUES ('" + today + "','" + comboBox2.Text + "','" + soldqty + "')");

                var up = new updatData();
                up.update("UPDATE `cards` SET `qty`='" + remainingQty + "' WHERE name = '" + comboBox2.Text + "'");
                updatedailycardqty();
                comboBox2.Text = "";
                textBox5.Clear();
                loadDatagrid();
                MessageBox.Show("Done");
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updatedailycardqty()
        {
            string today = DateTime.Today.ToString("yyyy-MM-dd");
            var ins = new insertData();
            ins.insert("INSERT INTO `dailycardstock`(`date`, `name`, `qty`) VALUES ('" + today + "','" + comboBox2.Text + "','" + textBox5.Text + "')");
        }

        private int getCardqty()
        {
            int qty=0;
            DataTable dataset;
            try
            {
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select * from cards where name = '" + comboBox2.Text + "';");
                dataset = new DataTable();
                sda.Fill(dataset);
                if (dataset != null)
                {
                    foreach (DataRow row in dataset.Rows)
                    {
                        qty = int.Parse(row["qty"].ToString());
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
            return qty;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataView Dv = new DataView(dataset);
                Dv.RowFilter = string.Format("name LIKE '%{0}%'", textBox6.Text);
                dataGridView1.DataSource = Dv;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                textBox2.Focus();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1.Focus();
            }
        }
        DataTable dataset2;
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select name,qty from dailycardstock where date = '"+dateTimePicker1.Text+"';");
                dataset2 = new DataTable();
                sda.Fill(dataset2);
                BindingSource bsource = new BindingSource();
                bsource.DataSource = dataset2;
                dataGridView2.DataSource = bsource;
                sda.Update(dataset2);

                this.dataGridView2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                this.dataGridView2.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
