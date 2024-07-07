using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Curd_Operation.Models;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using System.Security.Policy;

namespace Curd_Operation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        // GET: Employee/Create
        public ActionResult  listEmployee()
        {
           EmployeeModel Dash = new EmployeeModel();
            Properties objpro= new Properties();
            Properties emp = new Properties();
            objpro.Listemployee = Dash.getlstemplist(objpro);
            return View(objpro);
        }
     
        public ActionResult AddEmployee( string stringempid="")
        {
            EmployeeModel Dash = new EmployeeModel();
            Properties objpro = new Properties();
            encriptTex _objen = new encriptTex();
            if (stringempid != "")
            {
                string strempid = _objen.Decrypt(stringempid);
                objpro.empid = Convert.ToInt64(strempid);
                Dash.ReturnempDtl(objpro);
            }
            string issucces = "";
            if (TempData["issucces"] != null)
            {
                issucces = TempData["issucces"].ToString();
                ViewBag.issucces = issucces;
            }
            return View(objpro);
            
        }
        [HttpPost]
        public ActionResult AddEmployee(Properties objpro)
        {
            EmployeeModel Dash = new EmployeeModel();
             Dash.addEmployee(objpro);
            return View(objpro);
        }
        public void removeEmployee(string stringempid)
        {
            EmployeeModel Dash = new EmployeeModel();
            encriptTex _objen = new encriptTex();
            Properties objpro = new Properties();
            if (stringempid != "")
            {

                objpro.strempid = stringempid;
                Dash.removeEmployee(objpro);
            }
            
        }




    }
}
