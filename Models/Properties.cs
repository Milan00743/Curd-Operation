using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace Curd_Operation.Models
{
    public class Properties
    {
        public long empid {  get; set; }
        public string empcode { get; set; }
        public string empname { get; set; }
        public string designation { get;set; }
        public string description { get; set; }
        public string strempid { get; set; }
        public List<Properties> Listemployee { get; set; }

    }
}