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
using System.Collections;
using System.Linq;


namespace TMS_InterfaceDesign
{
    public partial class Form2 : Form
    {
        database db;
        string connection = "Data Source=.;Initial Catalog=TMS_FINAL_DB;Integrated Security=True";
        SqlConnection con;
        SqlConnection con2;
        int selectedLease = 0;
        int selectedLeaseIndex = 0;
        public Form2()
        {
            InitializeComponent();
            db = new database();
            con = new SqlConnection(connection);
            con2 = new SqlConnection(connection);
            initializeNotificationBox();
            initializeReportBox();
            initializeEmployees();
            setUsername();
            updateTables();
            initializeBuildings();
            initializeRenewalInfo();
        }
        private int totalAppartments = 100;

      

        private void bunifuCustomDataGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void getAvailableAppartments()
        {
            
                
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            float total = 0;
            float freeAppartments = 0;
            string buildingA = "A";
            string buildingB = "B";
            string buildingC = "C";
            string sqlStatement = "select building_name,freeAppartments,totalAppartments from building where building_name=" + "'" + buildingA + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                freeAppartments = float.Parse(resultset.GetValue(1).ToString());
                total = float.Parse(resultset.GetValue(2).ToString());
                float result = (freeAppartments / total) * 100;
                bunifuGauge1.Value = (int)result;

            }
            con.Close();
            initializeBuildingA();
            bunifuThinButton21.Visible = false;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            float total = 0;
            float freeAppartments = 0;
            string buildingA = "A";
            string buildingB = "B";
            string buildingC = "C";
            string sqlStatement = "select building_name,freeAppartments,totalAppartments from building where building_name=" + "'" + buildingB + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                freeAppartments = float.Parse(resultset.GetValue(1).ToString());
                total = float.Parse(resultset.GetValue(2).ToString());
                float result = (freeAppartments / total) * 100;
                bunifuGauge2.Value = (int)result;

            }
            con.Close();
            initializeBuildingB();
            bunifuThinButton22.Visible = false;
        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            float total = 0;
            float freeAppartments = 0;
            string buildingA = "A";
            string buildingB = "B";
            string buildingC = "C";
            string sqlStatement = "select building_name,freeAppartments,totalAppartments from building where building_name=" + "'" + buildingC + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                freeAppartments = float.Parse(resultset.GetValue(1).ToString());
                total = float.Parse(resultset.GetValue(2).ToString());
                float result = (freeAppartments / total) * 100;
                bunifuGauge3.Value = (int)result;

            }
            con.Close();
            initializeBuildingC();
            bunifuThinButton23.Visible = false;
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tenant Id");
            dt.Columns.Add("tenant name");
            dt.Columns.Add("appartment number");
            dt.Columns.Add("rent status");
            dt.Columns.Add("building name");
            int i = 0;
            string building = "A";
            int tenant_id;
            int appartment_no;
            string building_name;
            bool rent_status;
            string tenantName;
            string sqlStatement = "select appartment.tenant_id,appartment.rentStatus,appartment.appartment_number,appartment.building_name,tenant.firstname from appartment inner join tenant on appartment.tenant_id=tenant.tenant_id where appartment.building_name=" + "'" + building + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {

                tenant_id = int.Parse(resultset["tenant_id"].ToString());
                appartment_no = int.Parse(resultset["appartment_number"].ToString());
                rent_status = bool.Parse(resultset["rentStatus"].ToString());
                building_name = resultset["building_name"].ToString();
                tenantName = resultset["firstname"].ToString();
                dt.Rows.Add(tenant_id, tenantName, appartment_no, rent_status, building_name);
                dataGridView1.DataSource = dt;

            }
            con.Close();
            float count = 0;
            float total = 0;
            sqlStatement = "select count(appartment_number) as result from appartment WHERE rentStatus = 1 and building_name = 'A'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                count = float.Parse(resultset["result"].ToString());
            }
            con.Close();

            sqlStatement = "select count(appartment_number) as result from appartment WHERE building_name = 'A'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                total = float.Parse(resultset["result"].ToString());
            }
            con.Close();
            float result = (count / total) * 100;
            bunifuCircleProgressbar1.Value = (int)result;
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tenant Id");
            dt.Columns.Add("Tenant Name");
            dt.Columns.Add("Appartment Number");
            dt.Columns.Add("Rent Status");
            dt.Columns.Add("Building Name");
            int i = 0;
            string building = "B";
            int tenant_id;
            int appartment_no;
            string building_name;
            bool rent_status;
            string tenantName;
            string sqlStatement = "select appartment.tenant_id,appartment.rentStatus,appartment.appartment_number,appartment.building_name,tenant.firstname from appartment inner join tenant on appartment.tenant_id=tenant.tenant_id where appartment.building_name=" + "'" + building + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {

                tenant_id = int.Parse(resultset["tenant_id"].ToString());
                appartment_no = int.Parse(resultset["appartment_number"].ToString());
                rent_status = bool.Parse(resultset["rentStatus"].ToString());
                building_name = resultset["building_name"].ToString();
                tenantName = resultset["firstname"].ToString();
                dt.Rows.Add(tenant_id, tenantName, appartment_no, rent_status, building_name);
                dataGridView2.DataSource = dt;

            }
            con.Close();

            float count = 0;
            float total = 0;
            sqlStatement = "select count(appartment_number) as result from appartment WHERE rentStatus = 1 and building_name = 'B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                count = float.Parse(resultset["result"].ToString());
            }
            con.Close();

            sqlStatement = "select count(appartment_number) as result from appartment WHERE building_name = 'B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            { 
                total = float.Parse(resultset["result"].ToString());
            }
            con.Close();
            float rentRatio = (count/total)*100;
            bunifuCircleProgressbar2.Value = (int)rentRatio;
        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("tenant Id");
            dt.Columns.Add("tenant name");
            dt.Columns.Add("appartment number");
            dt.Columns.Add("rent status");
            dt.Columns.Add("building name");
            int i = 0;
            string building = "C";
            int tenant_id;
            int appartment_no;
            string building_name;
            bool rent_status;
            string tenantName;
            string sqlStatement = "select appartment.tenant_id,appartment.rentStatus,appartment.appartment_number,appartment.building_name,tenant.firstname from appartment inner join tenant on appartment.tenant_id=tenant.tenant_id where appartment.building_name=" + "'" + building + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {

                tenant_id = int.Parse(resultset["tenant_id"].ToString());
                appartment_no = int.Parse(resultset["appartment_number"].ToString());
                rent_status = bool.Parse(resultset["rentStatus"].ToString());
                building_name = resultset["building_name"].ToString();
                tenantName = resultset["firstname"].ToString();
                dt.Rows.Add(tenant_id,tenantName ,appartment_no, rent_status, building_name);
                dataGridView3.DataSource = dt;

            }
            con.Close();

            float count = 0;
            float total = 0;
            sqlStatement = "select count(appartment_number) as result from appartment WHERE rentStatus = 1 and building_name = 'C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                count = float.Parse(resultset["result"].ToString());
            }
            con.Close();

            sqlStatement = "select count(appartment_number) as result from appartment WHERE building_name = 'C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                total = float.Parse(resultset["result"].ToString());
            }
            con.Close();
            float result = (count / total) * 100;
            bunifuCircleProgressbar3.Value = (int)result;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || comboBox1.SelectedItem == null || textBox3.TextLength == 0)
            {
                MessageBox.Show("Text Fields Are Empty!");
                return;
            }
            string accountType = comboBox1.SelectedItem.ToString();
            int accountID = 0;
            string firstName = textBox1.Text.ToString();
            string lastName = textBox2.Text.ToString();
            string password = textBox3.Text.ToString();

            string sqlID = "SELECT id FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while(rs.Read())
            {
                accountID = int.Parse(rs["id"].ToString());
            }   
            con.Close();
            ++accountID;
            if (accountType.Equals("Staff"))
            {
                string sqlStatement = "INSERT INTO staff VALUES(" + "'" + accountID + "'," + "'" + firstName + "'," + "'" + lastName + "'," + "'" + password + "'," + "'" + 1 +"'," + "'" + (accountID + 1) + "');";
                SqlCommand cmd = new SqlCommand(sqlStatement, con);
                con.Open();
                var resultset = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Staff Added Successfully!");
            }
            else if (accountType.Equals("Manager"))
            {
                string sqlStatement = "INSERT INTO manager VALUES(" + "'" + accountID + "'," + "'" + firstName + "'," + "'" + lastName + "'," + "'" + password + "'," + "'" + 1 + "');";
                SqlCommand cmd = new SqlCommand(sqlStatement, con);
                con.Open();
                var resultset = cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Manager Added Successfully!");
            }
            sqlID = "INSERT INTO idGen VALUES ("+ accountID+")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();
            initializeEmployees();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void initializeNotificationBox()
        {
            int number = 0;
            string notification_receiver = "landlord";
            int index = 0;
            string message = null;
            string subject = null;
            string sqlID = "SELECT * FROM notfication_template WHERE receiver_type LIKE('"+ notification_receiver + "');";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                index = int.Parse(resultSet["notification_id"].ToString());
                subject = resultSet["subject"].ToString();
                message = resultSet["message"].ToString();
                listBox2.Items.Add(subject);
                number++;
            }
            label1.Text = ("Notification - ["+number+"]");
            con.Close();
        }

        private void initializeReportBox()
        {
            string report_receiver = "landlord";
            int index = 0;
            string message = null;
            string subject = null;
            string sqlID = "SELECT * FROM report_template WHERE receiver_type LIKE('" + report_receiver + "');";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                index = int.Parse(resultSet["report_id"].ToString());
                subject = resultSet["subject"].ToString();
                message = resultSet["message"].ToString();
                listBox1.Items.Add(subject);
            }
            con.Close();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string report_receiver = "landlord";
            int index = 0;
            string message = null;
            string subject = listBox1.SelectedItem.ToString();
            index = listBox1.SelectedIndex;
            
            string sqlID = "SELECT * FROM report_template WHERE subject = '"+ subject + "';";
            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
               // index = int.Parse(resultSet["notification_id"].ToString());
                subject = rs["subject"].ToString();
                message = rs["message"].ToString();
                groupBox4.Text = subject;
                richTextBox1.Text = message;
            }
            con.Close();
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            string notification_receiver = "landlord";
            int index = 0;
            string message = null;
            string subject = null;
            index = listBox2.SelectedIndex;
            string item = listBox2.SelectedItem.ToString();
            string sqlID = "SELECT * FROM notfication_template WHERE subject = ('" + item +"') and receiver_type = '" + notification_receiver + "';";

            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                // index = int.Parse(resultSet["notification_id"].ToString());
                subject = rs["subject"].ToString();
                message = rs["message"].ToString();
                //groupBox4.Text = subject;
                //richTextBox1.Text = message;
                MessageBox.Show(subject+ "\n" + message);
                break;
            }
            con.Close();
        }

        private void initializeEmployees()
        {
            int id = 0;
            string fName;
            string lName;
            DataTable dt = new DataTable();
            dt.Columns.Add("StaffID");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("ManagerID");
            dt2.Columns.Add("First Name");
            dt2.Columns.Add("Last Name");
            string sqlID = "SELECT staffID,firstname,lastname FROM staff;";
            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                id = int.Parse(rs["staffID"].ToString());
                fName = rs["firstname"].ToString();
                lName = rs["lastname"].ToString();
                dt.Rows.Add(id, fName,lName);
                
            }
            dataGridView4.DataSource = dt;
            con.Close();
            sqlID = "SELECT managerID,firstname,lastname FROM manager;";
            cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                id = int.Parse(rs["managerID"].ToString());
                fName = rs["firstname"].ToString();
                lName = rs["lastname"].ToString();
                dt2.Rows.Add(id, fName, lName);
                
            }
            dataGridView5.DataSource = dt2;
            con.Close();
        }

        private void initializeBuildingA()
        {
            int apartment_number = 0;
            string availibility;
            string sqlStatement = "select appartment_number,available from appartment where building_name='A'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availibility = "Available";
                }
                else
                {
                    availibility = "Occupied";
                }
                
                listBox3.Items.Add("Apartment Number: " + apartment_number + " " + availibility);

            }
            con.Close();
        }

        private void initializeBuildingB()
        {
            int apartment_number = 0;
            string availibility;
            string sqlStatement = "select appartment_number,available from appartment where building_name='B'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availibility = "Available";
                }
                else
                {
                    availibility = "Occupied";
                }
                
                listBox4.Items.Add("Apartment Number: " + apartment_number + " " + availibility);

            }
            con.Close();
        }

        private void initializeBuildingC()
        {
            int apartment_number = 0;
            string availibility;
            string sqlStatement = "select appartment_number,available from appartment where building_name='C'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availibility = "Available";
                }
                else
                {
                    availibility = "Occupied";
                }
              
                listBox5.Items.Add("Apartment Number: " + apartment_number + " " + availibility);

            }
            con.Close();
        }

        private void setUsername()
        {
            string name = "[1] LandLord";

            label2.Text = name;
        }

        private void bunifuThinButton27_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null || comboBox3.SelectedItem == null)
            {
                MessageBox.Show("Combo Fields cannot be Empty!");
                return;
            }
            string building = comboBox2.SelectedItem.ToString();
            int app_fee = 0;
            int app_size = int.Parse(comboBox3.SelectedItem.ToString());
            
            int counter = 0;
            string sqlStatement = "select COUNT(appartment_number) as result from appartment";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                counter = int.Parse(resultset["result"].ToString());
            }
            con.Close();
            ++counter;

            sqlStatement = "INSERT INTO appartment VALUES ('" +counter+ "',"+app_size +",1000 , 10000,'"+building+"',1,0,2)";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Appartment: "+counter+" Added Successfully in Building "+building+"!");
            con.Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoginFrame f2 = new LoginFrame();
            this.Hide();
            f2.ShowDialog();

            this.Close();
            con.Close();
        }

        private void bunifuThinButton29_Click(object sender, EventArgs e)
        {
            string username = listBox7.GetItemText(listBox7.SelectedItem);
            MessageBox.Show(username);

            ArrayList availableAppartments = new ArrayList();

            string sqlStatement= "select appartment.appartment_number from appartment where appartment.available = 1";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                // apartment_number = int.Parse(resultset.GetValue(0).ToString());


                listBox7.Items.Add(int.Parse(resultset["appartment_number"].ToString()));
                availableAppartments.Add(resultset["appartment_number"]);

            }
            con.Close();
            double Max = double.MinValue;
            double Min = double.MaxValue;

            foreach (int x in availableAppartments) 
            {
                if (Max < x)
                {
                    Max = x;
                }
                if (Min > x)
                {
                    Min = x;
                }
            }






            string sqlStatement2 = "update tenant set appartment_number=" +Min+" where username like "+"'"+username+"'" ;
            SqlCommand cmd2 = new SqlCommand(sqlStatement2, con);
            con.Open();
            cmd2.ExecuteNonQuery();
            con.Close();

            int tenant_id = 0;
            sqlStatement2 = "select tenant_id from tenant where username = " + "'" + username + "'";
            cmd2 = new SqlCommand(sqlStatement2, con);
            con.Open();
            var rss1 = cmd2.ExecuteReader();
            while (rss1.Read())
            {
                tenant_id = int.Parse(rss1["tenant_id"].ToString());
            }
            con.Close();

            string sqlStatement3 = "update appartment set available=0, rentStatus=1,tenant_id="+tenant_id+" where appartment_number="+Min;
            SqlCommand cmd3 = new SqlCommand(sqlStatement3, con);
            con.Open();
            cmd3.ExecuteNonQuery();

            con.Close();

            
            string sqlStatement5 = "update tenant set account_confirmation=1 where username like " + "'" + username + "'";
            SqlCommand cmd5 = new SqlCommand(sqlStatement5, con);
            con.Open();
            cmd5.ExecuteNonQuery();
            con.Close();


            int tenantID = 0;
            sqlStatement5 = "select tenant_id from tenant where username like " + "'" + username + "'";
            cmd5 = new SqlCommand(sqlStatement5, con);
            con.Open();
            var rss = cmd5.ExecuteReader();
            while(rss.Read())
            {
                tenantID = int.Parse(rss["tenant_id"].ToString());
            }
            con.Close();

            string sqlStatement6 = "select count(leaseId) as result from lease";
            SqlCommand cmd6 = new SqlCommand(sqlStatement6, con2);
            con2.Open();
            int leaseID = 0;
            var rs1 = cmd6.ExecuteReader();
            
            while(rs1.Read())
            {
                leaseID = int.Parse(rs1["result"].ToString());
            }
            ++leaseID;
            int terminationID = leaseID;
            con2.Close();

            string startDate = DateTime.Now.ToShortDateString();
            string endDate = DateTime.Now.AddYears(1).ToShortDateString();

            sqlStatement6 = "INSERT INTO termination VALUES ('"+terminationID+"','"+endDate+"','-');";
            cmd6 = new SqlCommand(sqlStatement6, con);
            con.Open();
            cmd6.ExecuteNonQuery();
            con.Close();

            sqlStatement6 = "INSERT INTO lease VALUES ('"+leaseID+"','"+startDate+"','"+endDate+"',10000,5000,'"+startDate+"','"+tenantID+"','"+Min+"','"+terminationID+"');";
            cmd6 = new SqlCommand(sqlStatement6, con);
            con.Open();
            cmd6.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Appartment Alloted Successfully!");
        }
        
       

        private void updateTables()
        {
            //int count = listBox6.Items.Count;
            //for(int i  = 0; i < count; i++)
            //{
            //    listBox6.Items.RemoveAt(i);
            //}
            int apartment_number = 0;
            string availibility;
            string sqlStatement = "select appartment_number,available from appartment where building_name='A' or building_name = 'B' or building_name = 'C'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availibility = "Available";
                    listBox6.Items.Add("Apartment Number: " + apartment_number + " " + availibility);
                }
            }
            con.Close();

            sqlStatement = "select username from tenant WHERE appartment_number is null";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                // apartment_number = int.Parse(resultset.GetValue(0).ToString());


                listBox7.Items.Add(resultset["username"].ToString());

            }
            con.Close();
        }

        private void listBox7_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void initializeBuildings()
        {
            int totalA = 0;
            int totalB = 0;
            int totalC = 0;
            int availableA = 0;
            int availableB = 0;
            int availableC = 0;
            int apartment_number = 0;
            string sqlStatement = "select appartment_number,available from appartment where building_name='A'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availableA++;
                }
                totalA++;
            }
            con.Close();
            sqlStatement = "select appartment_number,available from appartment where building_name='B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availableB++;
                }
                totalB++;
            }
            con.Close();
            sqlStatement = "select appartment_number,available from appartment where building_name='C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                apartment_number = int.Parse(resultset.GetValue(0).ToString());
                if (bool.Parse(resultset.GetValue(1).ToString()) == true)
                {
                    availableC++;
                }
                totalC++;
            }
            con.Close();
            sqlStatement = "UPDATE building SET freeAppartments=" + availableA + ",totalAppartments= "+totalA+" where building_name='A'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableB + ",totalAppartments= "+totalB+" where building_name='B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableC + ",totalAppartments= "+totalC+" where building_name='C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void bunifuThinButton210_Click(object sender, EventArgs e)
        {
            if (listBox8.SelectedItem == null)
            {
                MessageBox.Show("You Must Select a Lease!");
                return;
            }
            string renewalDate = DateTime.Now.AddYears(1).ToShortDateString();
            string sqlID = "UPDATE lease SET endDate='"+renewalDate+"' WHERE leaseID=  "+selectedLease+";";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            listBox8.Items.RemoveAt(listBox8.SelectedIndex);
            MessageBox.Show("Lease Renewed for Lease ID: "+ selectedLease);

            sqlID = "DELETE FROM renewal WHERE leaseID=  '" + selectedLease + "';";
            cmd = new SqlCommand(sqlID, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void initializeRenewalInfo()
        {
            int renewalID = 0;
            int leaseID = 0;
            string startDate = null;
            string sqlID = "SELECT * FROM renewal;";
            SqlCommand cmd = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cmd.ExecuteReader();
            while (resultSet.Read())
            {
                renewalID = int.Parse(resultSet["renewalID"].ToString());
                startDate = resultSet["renewalDate"].ToString();
                leaseID = int.Parse(resultSet["leaseID"].ToString());

                listBox8.Items.Add("Renewal ID: " + renewalID + " Renewal Date: " + startDate + " Lease ID: " + leaseID);
            }
            con.Close();
            selectedLease = leaseID;


        }

        private void bunifuGauge1_Load(object sender, EventArgs e)
        {

        }
    }
}
