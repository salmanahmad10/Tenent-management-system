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
    public partial class Form5 : Form
    {
        int man_id = 0;
        database db;
        string connection = "Data Source=.;Initial Catalog=TMS_FINAL_DB;Integrated Security=True";
        SqlConnection con;
        public Form5(int m_id)
        {
            db = new database();
            con = new SqlConnection(connection);
            InitializeComponent();
            man_id = m_id;
            initializeNotificationBox();
            initializeReportBox();
            setUsername();
            initializeBuildings();
        }

        private void bunifuThinButton25_Click(object sender, EventArgs e)
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

        private void bunifuThinButton24_Click(object sender, EventArgs e)
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

        private void bunifuThinButton26_Click(object sender, EventArgs e)
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

        private void initializeNotificationBox()
        {
            int number = 0;
            string notification_receiver = "manager";
            int index = 0;
            string message = null;
            string subject = null;
            string sqlID = "SELECT * FROM notfication_template WHERE receiver_type LIKE('" + notification_receiver + "');";
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
            con.Close();
            label1.Text = ("Notification - [" + number + "]");
        }

        private void listBox2_MouseClick(object sender, MouseEventArgs e)
        {
            string notification_receiver = "manager";
            int index = 0;
            string message = null;
            string subject = null;
            index = listBox2.SelectedIndex;
            string item = listBox2.SelectedItem.ToString();
            string sqlID = "SELECT * FROM notfication_template WHERE subject = ('" + item + "');";

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
                MessageBox.Show(subject + "\n" + message);
                break;
            }
            con.Close();
        }

        private void initializeReportBox()
        {
            string report_receiver = "manager";
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
            string report_receiver = "manager";
            int index = 0;
            string message = null;
            string subject = null;
            subject = listBox1.SelectedItem.ToString();
            index = listBox1.SelectedIndex;

            string sqlID = "SELECT * FROM report_template WHERE subject = ('" + subject + "') and receiver_type = '"+report_receiver+"'; ";
            SqlCommand cmd1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cmd1.ExecuteReader();
            while (rs.Read())
            {
                // index = int.Parse(resultSet["notification_id"].ToString());
                subject = rs["subject"].ToString();
                message = rs["message"].ToString();
                groupBox6.Text = subject;
                richTextBox1.Text = message;
            }
            con.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("You Must Select a Report First!");
                return;
            }
            int index = listBox1.SelectedIndex;
            string report_receiver = "landlord";
            string message = null;
            string subject = null;
            subject = listBox1.SelectedItem.ToString();
            string sqlID = "UPDATE report_template SET receiver_type = '" + report_receiver + "' WHERE subject LIKE ('" + subject + "');";
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

            int not_id = 0;
            string sqlNot = "select max(notification_id) as result from notfication_template";
            SqlCommand cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            var rsNot = cmNot.ExecuteReader();
            while(rsNot.Read())
            {
                not_id = int.Parse(rsNot["result"].ToString());
            }
            con.Close();
            not_id++;
            sqlNot = "INSERT INTO notfication_template VALUES ('"+not_id+"','Manager["+man_id.ToString()+"] IR["+not_id+"]','"+subject+"','landlord',1);";
            cmNot = new SqlCommand(sqlNot, con);
            con.Open();
            cmNot.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Report Sent Successfully!");
        }

        private void bunifuThinButton28_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength == 0 || textBox2.TextLength == 0 || textBox3.TextLength == 0)
            {
                MessageBox.Show("Text Fields Cannot Be Empty!");
                return;
            }
            int accountID = 0;
            string firstName = textBox1.Text.ToString();
            string lastName = textBox2.Text.ToString();
            string password = textBox3.Text.ToString();

            string sqlID = "SELECT id FROM idGen;";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                accountID = int.Parse(rs["id"].ToString());
            }
            con.Close();
            ++accountID;

            string sqlStatement = "INSERT INTO staff VALUES(" + "'" + accountID + "'," + "'" + firstName + "'," + "'" + lastName + "'," + "'" + password + "'," + "'" + man_id + "'," + "'" + (accountID + 1) + "');";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Staff Added Successfully!");


            sqlID = "INSERT INTO idGen VALUES (" + accountID + ")";
            cm1 = new SqlCommand(sqlID, con);
            con.Open();
            cm1.ExecuteNonQuery();
            con.Close();
        }

        private void setUsername()
        {
            string name = null;
            string sqlID = "SELECT firstname,lastname FROM manager WHERE managerID =  " + man_id + ";";
            SqlCommand cm1 = new SqlCommand(sqlID, con);
            con.Open();
            var rs = cm1.ExecuteReader();
            while (rs.Read())
            {
                name = "[" + man_id + "] " + rs["firstname"].ToString() + " " + rs["lastname"].ToString();
            }
            con.Close();

            label2.Text = name;
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
            sqlStatement = "UPDATE building SET freeAppartments=" + availableA+" where building_name='A'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableB+" where building_name='B'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            sqlStatement = "UPDATE building SET freeAppartments=" + availableC+" where building_name='C'";
            cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
