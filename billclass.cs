using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medicines1
{
    public class billclass
    {
        public string mname{get;set;}
        public string batchno { get; set; }
        public string expirydate { get; set; }
        public double mrp { get; set; }
        public int qty { get; set; }
        public double amount { get; set; }
        public double total { get; set; }
    }
}