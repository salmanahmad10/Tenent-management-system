using System;
using System.Collections;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TMS_InterfaceDesign
{
    class database
    {
        private static string connection = "Data Source=DESKTOP-EON545D;Initial Catalog=TMS_FINAL_DB_FiNAL;Integrated Security=True";
        private static SqlConnection con;
        public database()
        {
    
                con = new SqlConnection(connection);

        }
        public string Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }
        public SqlConnection Con
        {
            get
            {
                return con;
            }
            set
            {
                con = value;
            }
        }
       

    }
}
