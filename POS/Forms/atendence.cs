using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRINT_SHOP.Forms
{
    public partial class atendence : Form
    {
        public atendence()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lookIfDateExist();
            }
        }
        string today = DateTime.Today.ToString("yyyy-MM-dd");
        private void lookIfDateExist()
        {
            try
            {
                
                DataTable dataset;
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select * from attendance where regNo = '" + textBox1.Text + "' and date = '"+today+"';");
                dataset = new DataTable();
                sda.Fill(dataset);
                if (dataset.Rows.Count >=1)
                {
                    markLeaveTime();
                }
                else
                {
                    markcheckInTime();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void markcheckInTime()
        {
            try
            {
                string inTime = DateTime.Now.ToString("HH:mm:ss");
                var ins = new insertData();
                ins.insert("INSERT INTO `attendance`(`regNo`, `date`, `inTime`) VALUES ('" + textBox1.Text + "','" + today + "','" + inTime + "')");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void markLeaveTime()
        {
            try
            {
                DateTime inTime = getIntime();
                string outTime = DateTime.Now.ToString("HH:mm:ss");
                DateTime outTime1 = DateTime.Now;
                MessageBox.Show(inTime.ToString());
                double timeDiffrence = outTime1.Subtract(inTime).TotalMinutes;
                double timeInHourse = timeDiffrence / 60;
                var ins = new insertData();
                ins.insert("UPDATE `attendance` SET `outTime`='"+outTime+"',`workingHoures`='"+timeInHourse+ "' WHERE regNo ='"+textBox1.Text+"' and date ='"+today+"'");
            }
            catch
            {

            }
        }

        private DateTime getIntime()
        {
            DateTime inTime;
            string a="";
            try
            {
                DataTable dataset;
                var getdata = new getData();
                MySqlDataAdapter sda = getdata.returnData("Select * from attendance where regNo = '" + textBox1.Text + "' and date = '"+today+"';");
                dataset = new DataTable();
                sda.Fill(dataset);
                if (dataset != null)
                {
                    foreach (DataRow row in dataset.Rows)
                    {
                        a = row["inTime"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            DateTime dateTime = DateTime.ParseExact(a, "HH:mm:ss",
                                        CultureInfo.InvariantCulture);
            return dateTime;
        }
    }
}
