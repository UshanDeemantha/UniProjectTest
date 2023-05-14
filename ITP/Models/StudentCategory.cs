using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IPTAPI.Models
{
    public class StudentCategory
    {
        public int sID{ get; set; }
        public string cID { get; set; }
    }
    public class CreateStdCat : StudentCategory
    {

    }
    public class ReadStdCat : StudentCategory
    {
        public ReadStdCat(DataRow row)
        {
            sID = int.Parse(row["sID"].ToString());
            cID= row["cID"].ToString();
         
        }

        public int sID { get; set; }
        public string cID { get; set; }
    }
}