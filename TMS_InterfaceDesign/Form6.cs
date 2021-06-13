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

namespace TMS_InterfaceDesign
{
    public partial class Form6 : Form
    {
        int staff_id = 0;
        database db;
        string connection = "Data Source=.;Initial Catalog=TMS_FINAL_DB;Integrated Security=True";
        SqlConnection con;
        bool isAccountRegistered = false;
        public Form6(int s_id)
        {
            db = new database();
            con = new SqlConnection(connection);
            InitializeComponent();
            staff_id = s_id;
            setUsername();
            initializeNotificationBox();
            initializeBuildings();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton26_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton24_Click_1(object sender, EventArgs e)
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
            bunifuThinButton24.Visible = false;
        }

        private void bunifuThinButton25_Click_1(object sender, EventArgs e)
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
            bunifuThinButton25.Visible = false;
        }

        private void bunifuThinButton26_Click_1(object sender, EventArgs e)
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
            bunifuThinButton26.Visible = false;
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

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            string notification_receiver = "staff";
            int index = 0;
            string message = null;
            string subject = null;

            string item = listBox1.SelectedItem.ToString();

            string sqlID = "SELECT * FROM notfication_template WHERE subject LIKE ('" + item + "') and receiver_id = " + staff_id + ";";
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

        private void initializeNotificationBox()
        {
            int number = 0;
            string notification_receiver = "staff";
            int index = 0;
            string message = null;
            string subject = null;
            string sqlID = "SELECT * FROM notfication_template WHERE receiver_type =('" + notification_receiver + "');";
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

        private void setUsername()
        {
            string name = null;
            string sqlID = "SELECT firstname,lastname FROM staff WHERE staffID =  " + staff_id + ";";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                name = "[" + staff_id + "] " + rs["firstname"].ToString() + " " + rs["lastname"].ToString();
            }
            con.Close();

            label2.Text = name;
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || richTextBox1.TextLength == 0)
            {
                MessageBox.Show("All Text Fields must not be Empty!");
                return;
            }
            int report_id = 0;
            string sqlID = "SELECT id FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                report_id = int.Parse(rs["id"].ToString());
            }
            con.Close();
            ++report_id;
            string subject = textBox1.Text.ToString();
            if(subject.Length > 20)
            {
                MessageBox.Show("Subject Character Lenght Exceeded!");
                return;

            }
            string message = richTextBox1.Text.ToString();
            sqlID = "INSERT INTO report_template VALUES ('" + report_id + "','" + subject + "','" + message + "','manager' );";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();

            sqlID = "INSERT INTO idGen VALUES (" + report_id + ")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();

            int not_id = 0;
            string sqlNot = "select max(notification_id) as result from notfication_template";
            SqlCommand cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            var rsNot = cmNot.ExecuteReader();
            while (rsNot.Read())
            {
                not_id = int.Parse(rsNot["result"].ToString());
            }
            con.Close();
            not_id++;
            sqlNot = "INSERT INTO notfication_template VALUES ('" + not_id + "','Staff[" + staff_id.ToString() + "] IR["+not_id+"]','" + subject + "','manager',null);";
            cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            cmNot.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Report Sent Successfully!");
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength == 0 || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Text Fields Must Not remain Empty!");
                return;
            }
            int maint_id = 0;
            string sqlID = "SELECT id FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                maint_id = int.Parse(rs["id"].ToString());
            }
            con.Close();
            ++maint_id;



            int apartmentNum = 0;
            string date = dateTimePicker1.Value.ToString();
            sqlID = "SELECT appartment_number FROM appartment WHERE appartment_number = " + int.Parse(textBox2.Text.ToString()) + ";";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var resultSet = cm1.ExecuteReader();
            while (resultSet.Read())
            {
                apartmentNum = int.Parse(resultSet["appartment_number"].ToString());
            }
            con.Close();
            if (comboBox2.SelectedItem.ToString().Equals("Maintenance"))
            {
                sqlID = "INSERT INTO Maintenance VALUES ('" + apartmentNum + "','" + maint_id + "','" + date + "');";
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

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            int rent_id = 0;
            int rental_fee = 10000;
            int late_fee = 1200;
            
            string dateToPay = dateTimePicker2.Value.ToShortDateString();
            int leaseID = 0;
            bool status;
            bool leaseAvailable = true;
            int counter = 0;

            string sqlID3 = "SELECT leaseId FROM lease;";
            SqlCommand cmd2 = new SqlCommand(sqlID3, con);
            con.Open();
            var resultSet3 = cmd2.ExecuteReader();
            while (resultSet3.Read())
            { 
                counter++;
            }
            con.Close();



            for(int i = 0; i < counter; i++)
            {
                
                string sqlID = "SELECT leaseId FROM lease;";
                SqlCommand cmd = new SqlCommand(sqlID, con);
                con.Open();
                var resultSet = cmd.ExecuteReader();
                while (resultSet.Read())
                {
                    leaseID = int.Parse(resultSet["leaseId"].ToString());
                    leaseAvailable = true;
                }
                con.Close();

                leaseID = i + 1;

                string sqlID2 = "SELECT id FROM idGen;";
                SqlCommand cm1 = new SqlCommand(sqlID2, con);
                con.Open();
                var rs = cm1.ExecuteReader();
                while (rs.Read())
                {
                    rent_id = int.Parse(rs["id"].ToString());
                }
                con.Close();
                ++rent_id;


                string sqlID1 = "INSERT INTO rent VALUES ('" + rent_id + "','" + rental_fee + "','" + late_fee + "','" + dateToPay + "','" + leaseID + "','" + rent_id + "','0');";
                SqlCommand cmd1 = new SqlCommand(sqlID1, con);
                con.Open();
                var resultSet1 = cmd1.ExecuteNonQuery();
                con.Close();

                sqlID = "INSERT INTO idGen VALUES (" + rent_id + ")";
                cm1 = new SqlCommand(sqlID, con);
                con.Open();
                cm1.ExecuteNonQuery();
                con.Close();
                leaseAvailable = false;
            }

            int not_id = 0;
            string sqlNot = "select max(notification_id) as result from notfication_template";
            SqlCommand cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            var rsNot = cmNot.ExecuteReader();
            while (rsNot.Read())
            {
                not_id = int.Parse(rsNot["result"].ToString());
            }
            con.Close();
            not_id++;
            sqlNot = "INSERT INTO notfication_template VALUES ('" + not_id + "','Rent["+dateToPay+"]','Your Current Bill for "+dateToPay+" has been Uploaded!','tenants',null);";
            cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            cmNot.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Rent/Bills have been Processed to Tenant!");
            //con.Close();

        
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            LoginFrame f2 = new LoginFrame();
            this.Hide();
            f2.ShowDialog();

            this.Close();
            con.Close();
        }

        private void initializeBuildings()
        {
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
            }
            con.Close();
            sqlStatement = "UPDATE building SET freeAppartments=" + availableA + " where building_name='A'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableB + " where building_name='B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableC + " where building_name='C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
