using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace TMS_InterfaceDesign
{
    public partial class LoginFrame : Form
    {
        int tenantId =0;
        string connection = "Data Source=.;Initial Catalog=TMS_FINAL_DB;Integrated Security=True";
        SqlConnection con;
        bool isAccountRegistered = false;
        public LoginFrame()
        {
           
            InitializeComponent();
            con = new SqlConnection(connection);
            

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//tenant login
        {
            if (comboBox1.SelectedItem.ToString().Equals("Tenant") == true){
                tenantlogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("LandLord") == true)
            {
                landlordLogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("Staff") == true)
            {
                staffLogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("Manager") == true)
            {
                managerLogin();
            }
        }

        private void landlordLogin()
        {
            
               int landlordId = 1;
            
           
            bool landlordIdBool = Int32.TryParse(textBox3.Text.ToString(), out landlordId);
            if (landlordIdBool == false)
            {
                MessageBox.Show("Your ID is Invalid");
                return;
            }
            string password = textBox4.Text.ToString();
            string accType = comboBox1.Text.ToString();
            
            string sqlStatement = "select landlordId,password from Landlord where landlordId=" + "'" + landlordId + "' and password=" + "'" + password + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                MessageBox.Show("SignIn Successfull!");

                Form2 f2 = new Form2();
                this.Hide();
                f2.ShowDialog();

                this.Close();
                con.Close();
            }
            else
            {
                MessageBox.Show("SignIn Failed!");
            }

            con.Close();
        }

        private void staffLogin()
        {
            int id = 0;
            string username = textBox3.Text.ToString();
            string password = textBox4.Text.ToString();
            string accType = comboBox1.Text.ToString();
            System.Diagnostics.Debug.WriteLine("Login Success");
            string sqlStatement = "select staffID from staff where firstname=" + "'" + username + "' and password=" + "'" + password + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                MessageBox.Show("Signin Successfull!");
                id = int.Parse(resultset["staffID"].ToString());
                Form6 f3 = new Form6(id);
                this.Hide();
                f3.ShowDialog();

                this.Close();

            }
            else
            {
                MessageBox.Show("SignIn Failed!");
            }

            con.Close();

        }
        
        private void managerLogin()
        {
            int id = 0;
            string username = textBox3.Text.ToString();
            string password = textBox4.Text.ToString();
            string accType = comboBox1.Text.ToString();
            System.Diagnostics.Debug.WriteLine("Login Success!");
            string sqlStatement = "select managerID from manager where firstname=" + "'" + username + "' and password=" + "'" + password + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                MessageBox.Show("SignIn Successfull!");
                id = int.Parse(resultset["managerID"].ToString());
                Form5 f3 = new Form5(id);
                this.Hide();
                f3.ShowDialog();

                this.Close();

            }
            else
            {
                MessageBox.Show("SignIn Failed!");
            }

            con.Close();
        }
        string accountConfirm = "0";

        String tenantAccountConfirmation(string username)
        {

            string sqlStatement = "select account_confirmation from tenant where username=" + "'" + username + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            while (resultset.Read())
            {
                accountConfirm = resultset["account_confirmation"].ToString();
                con.Close();
                return accountConfirm;

            }
            con.Close();
            return "0";

        }

        
        private void tenantlogin()
        {
            int id = 0;
            string username = textBox3.Text.ToString();
            string password = textBox4.Text.ToString();
            string accType = comboBox1.Text.ToString();
            System.Diagnostics.Debug.WriteLine("Login Success");
            if (tenantAccountConfirmation(username) == "1")
            {
                string sqlStatement = "select username,password,tenant_id from tenant where username=" + "'" + username + "' and password=" + "'" + password + "'";

                SqlCommand cmd = new SqlCommand(sqlStatement, con);
                con.Open();
                var resultset = cmd.ExecuteReader();
                if (resultset.Read())
                {
                    MessageBox.Show("SignIn Successfull!");
                    id = int.Parse(resultset["tenant_id"].ToString());

                    Form4 f4 = new Form4(id);
                    this.Hide();
                    f4.ShowDialog();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("SignIn Failed!");
                }

                con.Close();
            }
            else
            {
                MessageBox.Show("Account Not Confirmed!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//if terms and conditions are accepted
            {
                AddNewTenant();


            }
            //MANAGER
            //LANDLORD
            //STAFF
        }

        public String SsnGenrator(int length)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";//for genrating ssn,genrates unique ssn everytime 
            var stringChars = new char[length];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var ssn = new String(stringChars);
            return ssn;
        }

        public void AddNewTenant()
        {
            if (checkBox1.Checked)
            {
                tenantId = uniqueTenantId();//unique tenant id
                int phoneNo = 0;
                string username = textBox1.Text.ToString();
                string password = textBox2.Text.ToString();
                string email = textBox7.Text.ToString();
                string firstName = textBox5.Text.ToString();
                string lastName = textBox6.Text.ToString();
                string address = richTextBox1.Text.ToString();


                string CNIC = textBox9.Text.ToString();


                bool phoneCheck = Int32.TryParse(textBox8.Text.ToString(), out phoneNo);
                if (phoneCheck == false)
                {
                    MessageBox.Show("Your Number is Invalid!");
                }
                else
                {

                    string appartmentType = "1";


                    if (radioButton1.Checked)
                    {
                        appartmentType = "1 Bedroom";
                    }
                    else if (radioButton2.Checked)
                    {
                        appartmentType = "2 Bedroom";
                    }
                    else if (radioButton3.Checked)
                    {
                        appartmentType = "3 Bedroom";
                    }
                    else if (radioButton4.Checked)
                    {
                        appartmentType = "4 Bedroom";
                    }

                    String ssnId = SsnGenrator(8);
                    bool duplicateSsnId = false;
                    ArrayList ssnArray = new ArrayList();

                    string ssnStatement = "select ssn from tenant";
                    SqlCommand ssnCommand = new SqlCommand(ssnStatement, con);
                    con.Open();
                    var resultset = ssnCommand.ExecuteReader();
                    while (resultset.Read())
                    {
                        ssnArray.Add(resultset["ssn"]);
                    }
                    con.Close();

                    for (int i = 0; i < ssnArray.Count; i++)
                    {
                        if (ssnId.Equals(ssnArray[i]))
                        {
                            duplicateSsnId = true;
                            break;
                        }
                    }
                    if (duplicateSsnId == true)
                    {
                        ssnId = SsnGenrator(8);
                    }
                    if (uniqueTenant(email, username) == true)
                    {

                        string sqlStatement = "INSERT INTO tenant(tenant_id,username,password,firstname,lastname,email,current_address,phone,appartmentType,ssn,account_confirmation)values(" + "'" + tenantId + "'," + "'" + username + "'," + "'" + password + "'," + "'" + firstName + "'," + "'" + lastName + "'," + "'" + email + "'," + "'" + address + "'," + "'" + phoneNo + "'," + "'" + appartmentType + "'," + "'" + ssnId + "'," + "'" + 0 + "'" + ")";
                        MessageBox.Show("Appartment Request Sent To Landlord!");
                        
                        SqlCommand cmd = new SqlCommand(sqlStatement, con);
                        con.Open();
                        int rowsinsert = cmd.ExecuteNonQuery();
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Email/Username is in Use!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Not Checked!");
            }
        }
        private int uniqueTenantId()
        {
            string sqlStatementTenantId = "SELECT TOP 1 tenant_id FROM tenant ORDER BY tenant_id DESC";
            SqlCommand cmdId = new SqlCommand(sqlStatementTenantId, con);
            con.Open();
            var resultset = cmdId.ExecuteReader();
            if (resultset.Read())
            {
                tenantId = int.Parse(resultset.GetValue(0).ToString());
            }
            else
            {
                tenantId = 1;
            }
            con.Close();
            tenantId++;
            return tenantId;
        }
        private bool uniqueTenant(string email,string username)
        {
            string sqlStatement = "select email,username from tenant where username=" + "'" + username + "' OR email=" + "'" + email + "'";
            SqlCommand cmd = new SqlCommand(sqlStatement, con);
            con.Open();
            var resultset = cmd.ExecuteReader();
            if (resultset.Read())
            {
                con.Close();
                return false;
            }
            else
            {
                con.Close();
                return true;
            }

            
            
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if(textBox3.Text == null || textBox4.Text == null || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Missing Fields!");
                return;
            }
            if (comboBox1.SelectedItem.ToString().Equals("Tenant") == true)
            {
                tenantlogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("LandLord") == true)
            {
                landlordLogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("Staff") == true)
            {
                staffLogin();
            }
            if (comboBox1.SelectedItem.ToString().Equals("Manager") == true)
            {
                managerLogin();
            }
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)//if terms and conditions are accepted
            {
                AddNewTenant();


            }
            //MANAGER
            //LANDLORD
            //STAFF
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
