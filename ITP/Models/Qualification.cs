using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IPTAPI.Models
{
    public class Qualification
    {
        public string qName { get; set; }
        public int qID { get; set; }
    }
    public class ReadQualification : Qualification
    {
         public ReadQualification(DataRow row) 
         {
            qName = row["fName"].ToString();
            cID= int.Parse(row["lName"].ToString());
         }
        public string qName { get; set; }
        public int cID { get; set; }
    }

}