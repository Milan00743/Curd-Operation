using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Data.SqlClient;
using System.Runtime.Remoting;
using System.Reflection.Emit;
using System.Runtime.InteropServices;

namespace Curd_Operation.Models
{
    public class EmployeeModel
    {
        SQL_Connection _objcon = new SQL_Connection();
        SqlCommand _cmd;

        public void addEmployee(Properties objpro)
        {
            encriptTex objen = new encriptTex();
                _objcon.con_Execute();
                _cmd = new SqlCommand("saveEmployee", _objcon.Sqlcon);
                _cmd.CommandType = CommandType.StoredProcedure;
                _cmd.CommandTimeout = 0;
                _cmd.Parameters.AddWithValue("@empid",objpro.empid);
            _cmd.Parameters.AddWithValue("@empcode", (objpro.empcode + "").Trim());
            _cmd.Parameters.AddWithValue("@empname", (objpro.empname + "").Trim());
            _cmd.Parameters.AddWithValue("@designation", (objpro.designation + "").Trim());
            _cmd.Parameters.AddWithValue("@empdescription ", (objpro.description+ "").Trim());
            _cmd.ExecuteNonQuery();
            _objcon.con_close();

        }
      
        public List<Properties> getlstemplist(Properties objpro)
        {
            _cmd = new SqlCommand("select * from EmployeeTb", _objcon.con_open());
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandType = CommandType.Text;
            _cmd.CommandTimeout = 0;
            DataSet ds = new DataSet();

            SqlDataAdapter sqlda = new SqlDataAdapter(_cmd);
            sqlda.Fill(ds);
            encriptTex objen = new encriptTex();
            List<Properties> emplist = new List<Properties>();
            Properties _model;
            foreach (DataRow _drow in ds.Tables[0].Rows)
            {
                _model = new Properties();

                _model.empcode = _drow["empcode"].ToString();
                _model.empname = _drow["empname"].ToString();
                _model.designation = _drow["designation"].ToString();
                _model.description = _drow["empdescription"].ToString();
                _model.empid= Convert.ToInt64(_drow["empid"].ToString());
                _model.strempid = objen.Encrypt(_drow["empid"].ToString());
                emplist.Add(_model);
            }
            return emplist;

        }

        public void ReturnempDtl(Properties objpro)
        {
            _objcon.con_Execute();
            _cmd = new SqlCommand("ReturnEmployee", _objcon.Sqlcon);
            _cmd.CommandType = CommandType.StoredProcedure;
            encriptTex _objen = new encriptTex();
            
            _cmd.Parameters.AddWithValue("@empid",objpro.empid);
            DataTable dt = new DataTable();
            SqlDataAdapter sqlda = new SqlDataAdapter(_cmd);
            sqlda.Fill(dt);
            foreach (DataRow _drow in dt.Rows)
            {

                objpro.empcode = _drow["empcode"].ToString();
                objpro.empname = _drow["empname"].ToString();
                objpro.designation = _drow["designation"].ToString();
                objpro.description = _drow["empdescription"].ToString();

            }
        }

        public void removeEmployee(Properties objpro)
        {
            _objcon.con_Execute();
            encriptTex _objen = new encriptTex();
            _cmd = new SqlCommand("delete  from EmployeeTb where empid=" + _objen.Decrypt(objpro.strempid), _objcon.Sqlcon);
            _cmd.CommandType = CommandType.Text;
            _cmd.ExecuteNonQuery();
            _objcon.con_close();

        }






    }
}