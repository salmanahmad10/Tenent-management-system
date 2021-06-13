using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace TMS_InterfaceDesign
{
    public partial class Form4 : Form
    {
        database db;
        string connection = "Data Source=.;Initial Catalog=TMS_FINAL_DB;Integrated Security=True";
        SqlConnection con;
        int t_id = 0;
        DateTime aDate = DateTime.Now;
        DataTable dt = new DataTable();
        DataTable dt2 = new DataTable();
        int pay_id = 0;
        int rentId = 0;
        int payAmount = 0;
        int selectedBill = 0;
        public Form4(int tenant_id)
        {
            db = new database();
            con = new SqlConnection(connection);
            InitializeComponent();
            t_id = tenant_id;
            initializeNotificationBox();
            initalizeCurrentBill();
            bunifuThinButton22.Visible = false;
            groupBox4.Visible = false;
            setUsername();
            initializeLeaseInfo();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoginFrame f2 = new LoginFrame();
            this.Hide();
            f2.ShowDialog();

            this.Close();
            con.Close();
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {

            
        }

        private int getNotificationIndex()
        {
            int index = 0;
            string sqlID = "SELECT * FROM notfication_template WHERE receiver_id = " + t_id + ";";
            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                index = int.Parse(rs["notification_id"].ToString());
                break;
            }
            con.Close();

            return index;
        }

        private void initializeNotificationBox()
        {
            int number = 0;
            string notification_receiver = "tenants";
            int index = 0;
            string message = null;
            string subject = null;
            string sqlID = "SELECT * FROM notfication_template WHERE receiver_type = ('" + notification_receiver + "');";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                index = int.Parse(resultSet["notification_id"].ToString());
                subject = resultSet["subject"].ToString();
                message = resultSet["message"].ToString();
                listBox1.Items.Add(subject);
                number++;
            }
            con.Close();
            label1.Text = ("Notification - [" + number + "]");
        }
        private void initalizeCurrentBill()
        {
            int rent_id = 0;
            int rental_fee = 0;
            int late_fee = 0;
            string dateToPay;
            int leaseID = 0;
            int payID = 0;
            bool status;
            dt.Columns.Add("Rent ID");
            dt.Columns.Add("Rental Fee");
            dt.Columns.Add("Date To Pay");
            dt.Columns.Add("Lease ID");
            dt.Columns.Add("Status");
            dt2.Columns.Add("Rent ID");
            dt2.Columns.Add("Rental Fee");
            dt2.Columns.Add("Date To Pay");
            dt2.Columns.Add("Lease ID");
            dt2.Columns.Add("Status");
            string sqlID = "SELECT leaseId FROM lease WHERE tenantId = " + t_id + ";";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                leaseID = int.Parse(resultSet["leaseId"].ToString());
            }
            con.Close();

            sqlID = "SELECT * FROM rent WHERE leaseId = " + leaseID + ";";
            cmd = new SqlCommand(sqlID, con);
            con.Open();
            resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                rent_id = int.Parse(resultSet["rentID"].ToString());
                rentId = rent_id;
                rental_fee = int.Parse(resultSet["rentalFee"].ToString());
                
                late_fee = int.Parse(resultSet["lateFee"].ToString());
                dateToPay = resultSet["daytopay"].ToString();
                payID = int.Parse(resultSet["payId"].ToString());
                pay_id = payID;
                status = bool.Parse(resultSet["status"].ToString());
                if (status == false)
                {
                    payAmount = rental_fee;
                    listBox2.Items.Add("Rent ID: " + rent_id + " Pay Before: " + dateToPay);
                    //dt2.Rows.Add(rent_id, rental_fee, dateToPay, leaseID, status);
                    //dataGridView2.DataSource = dt2;
                }
                dt.Rows.Add(rent_id, rental_fee, dateToPay, leaseID, status);
            }
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string notification_receiver = "tenants";
            int index = 0;
            string message = null;
            string subject = null;

            string item = listBox1.SelectedItem.ToString();

            string sqlID = "SELECT * FROM notfication_template WHERE subject = ('" + item + "');";
            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {

                subject = rs["subject"].ToString();
                message = rs["message"].ToString();

                MessageBox.Show(subject + "\n" + message);
                break;
            }
            con.Close();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //if (comboBox2.SelectedItem == null)
            //{
            //    MessageBox.Show("Must Select Payment Method!");
            //    return;
            //}
            string payDate;
            int payMethod = 0;
            if (comboBox1.SelectedItem.ToString().Equals("Challan"))
            {
                payMethod = 0;
            }
            if (comboBox1.SelectedItem.ToString().Equals("CreditCard"))
            {
                payMethod = 1;
            }
            else
            {
                MessageBox.Show("Must Select Payment Method!");
                return;
            }


            int leaseID = 0;
            int payID = 0;
            string sqlID = "SELECT id FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                payID = int.Parse(rs["id"].ToString());
            }
            con.Close();
            ++payID;

            sqlID = "INSERT INTO payment VALUES ('"+ payID+"','" + aDate.ToString("MM / dd / yyyy") + "','"+ payAmount+ "','"+ rentId+"','"+ payMethod+"')";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();


            sqlID = "INSERT INTO idGen VALUES (" + payID + ")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Bill Paid!");

            listBox2.Items.RemoveAt(selectedBill);

            sqlID = "SELECT leaseId FROM lease WHERE tenantId = " + t_id + ";";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cm1.ExecuteReader();
            while (resultSet.Read())
            {
                leaseID = int.Parse(resultSet["leaseId"].ToString());
            }
            con.Close();

            sqlID = "UPDATE rent SET status = 1 WHERE leaseID = "+leaseID+"";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();
            reUpdateTable();
          //  initalizeCurrentBill();
        }

        private void listBox2_MouseClick_1(object sender, MouseEventArgs e)
        {
            selectedBill = listBox2.SelectedIndex;
            bunifuThinButton22.Visible = true;
            groupBox4.Visible = true;
        }

        private void reUpdateTable()
        {
            int rent_id = 0;
            int rental_fee = 0;
            int late_fee = 0;
            string dateToPay;
            int leaseID = 0;
            int payID = 0;
            bool status;

            string sqlID = "SELECT leaseId FROM lease WHERE tenantId = " + t_id + ";";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                leaseID = int.Parse(resultSet["leaseId"].ToString());
            }
            con.Close();

            sqlID = "SELECT * FROM rent WHERE leaseId = " + leaseID + ";";
            cmd = new SqlCommand(sqlID, con);
            con.Open();
            resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                rent_id = int.Parse(resultSet["rentID"].ToString());
                rentId = rent_id;
                rental_fee = int.Parse(resultSet["rentalFee"].ToString());

                late_fee = int.Parse(resultSet["lateFee"].ToString());
                dateToPay = resultSet["daytopay"].ToString();
                payID = int.Parse(resultSet["payId"].ToString());
                pay_id = payID;
                status = bool.Parse(resultSet["status"].ToString());
                if (status == false)
                {
                    payAmount = rental_fee;
                    listBox2.Items.Add("Rent ID: " + rent_id + " Pay Before: " + dateToPay);
                    //dt2.Rows.Add(rent_id, rental_fee, dateToPay, leaseID, status);
                    //dataGridView2.DataSource = dt2;
                }
                dt.Rows.Add(rent_id, rental_fee, dateToPay, leaseID, status);
            }
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("You Must Select Type!");
                return;
            }
            int maint_id = 0;
            string sqlID = "SELECT MAX(id) as result FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                maint_id = int.Parse(rs["result"].ToString());
            }
            con.Close();
            ++maint_id;



            int apartmentNum = 0;
            
            string date = dateTimePicker1.Value.ToShortDateString();
            
            //dateTimePicker1.Format = DateTimePickerFormat.Custom;
            //DateTime.ParseExact(date, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            sqlID = "SELECT appartment_number FROM appartment WHERE tenant_id = " + t_id + ";";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cm1.ExecuteReader();
            while (resultSet.Read())
            {
                apartmentNum = int.Parse(resultSet["appartment_number"].ToString());
            }
            con.Close();
            if(comboBox2.SelectedItem.ToString().Equals("Maintenance"))
            {
                sqlID = "INSERT INTO Maintenance VALUES ('"+ apartmentNum +"','"+ maint_id+"','"+ date+"');";
                MessageBox.Show("Maintenance Scheduled !");
            }
            else
            {
                sqlID = "INSERT INTO inspection VALUES ('" + apartmentNum + "','" + maint_id + "','" + date + "','Not Inspected Yet');";
                MessageBox.Show("Inspection Scheduled !");
            }
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();

            sqlID = "INSERT INTO idGen VALUES (" + maint_id + ")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || richTextBox1.TextLength == 0)
            {
                MessageBox.Show("Text Fields Cannot Be Empty!");
                return;
            }
            if(textBox1.TextLength > 20)
            {
                MessageBox.Show("Character Length Exceeded!");
                return;
            }
            int notification_id = 0;
            string sqlID = "SELECT max(id) as result FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                notification_id = int.Parse(rs["result"].ToString());
            }
            con.Close();
            ++notification_id;
            string subject = textBox1.Text.ToString();
            if(subject.Length > 20)
            {
                MessageBox.Show("Subject Character Lenght Exceeded!");
                return;
            }
            string message = richTextBox1.Text.ToString();
            sqlID = "INSERT INTO notfication_template VALUES ('"+ notification_id+"','Tenant["+t_id+"]: "+ subject+ "','"+ message+ "','manager',null );";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();

            sqlID = "INSERT INTO idGen VALUES (" + notification_id + ")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Message Sent Successfully!");
        }

        private void setUsername()
        {
            string name = null;
            string sqlID = "SELECT firstname,lastname FROM tenant WHERE tenant_id =  "+ t_id+ ";";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                name = "[" + t_id + "] " + rs["firstname"].ToString() + " " + rs["lastname"].ToString();
            }
            con.Close();

            label2.Text = name;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initializeLeaseInfo()
        {
            int leaseID = 0;
            string startDate = null;
            string endDate = null;
            int balance = 0;
            int securityDeposit = 0;
            int appartmentNumber = 0;
            int terminationID = 0;
            string sqlID = "SELECT * FROM lease WHERE tenantId = " + t_id + ";";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                leaseID = int.Parse(resultSet["leaseId"].ToString());
                startDate = resultSet["startDate"].ToString();
                endDate = resultSet["endDate"].ToString();
                balance = int.Parse(resultSet["balance"].ToString());
                securityDeposit = int.Parse(resultSet["securityDeposit"].ToString());
                appartmentNumber = int.Parse(resultSet["apartmentNumber"].ToString());
                terminationID = int.Parse(resultSet["terminationID"].ToString());
            }
            con.Close();
            listBox3.Items.Add("Lease ID: " + leaseID + " Start Date: " + startDate + " End Date: " + endDate);
            listBox3.Items.Add("Balance: " + balance + " Security Deposit: " + securityDeposit + " Appartment Number: " + appartmentNumber + " Termination ID: " + terminationID);
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            int leaseID = 0;
            string sqlID = "SELECT * FROM lease WHERE tenantId = " + t_id + ";";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                leaseID = int.Parse(resultSet["leaseId"].ToString());
            }
            con.Close();

            int renewalID = 0;
            sqlID = "select max(renewalID) as result from renewal";
            cmd = new SqlCommand(sqlID, con);
            con.Open();
            resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                renewalID = int.Parse(resultSet["result"].ToString());
            }
            renewalID++;
            con.Close();
            string renwalDate = DateTime.Now.AddYears(1).ToShortDateString();
            sqlID = "INSERT INTO renewal VALUES ('"+ renewalID + "','"+ renwalDate + "','1','"+leaseID+"')";
            cmd = new SqlCommand(sqlID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Request for Lease Renewal Sent!");
        }
    }
}
