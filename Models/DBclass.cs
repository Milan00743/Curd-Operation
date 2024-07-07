using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Curd_Operation.Models
{

        public class SQL_Connection
        {
            public SqlConnection Sqlcon;
            public SqlConnection Webcon;
            string _query = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            public SqlConnection con_open()
            {
                string _query = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                Sqlcon = new SqlConnection(_query);
                try
                {
                    Sqlcon.Open();
                    return Sqlcon;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
                finally
                {
                    Sqlcon.Close();
                    //Sqlcon.Dispose();
                }


                return Sqlcon;
            }

            public void con_close()
            {
                Sqlcon.Close();
                Sqlcon.Dispose();
            }
            public void con_Execute()
            {
                Sqlcon = new SqlConnection(_query);
                try
                {
                    Sqlcon.Open();
                }
                catch (Exception ex)
                {
                    Console.Write(ex.ToString());
                }
            }

        }
}