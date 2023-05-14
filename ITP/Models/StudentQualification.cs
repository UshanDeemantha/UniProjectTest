using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IPTAPI.Models
{
    public class StudentQualification
    {
        public int sID { get; set; }
        public string qID { get; set; }
     
    }
    public class CreateStdQuli: StudentQualification
    {

    }
    public class ReadStdQuli : StudentQualification
    {
        public ReadStdQuli(DataRow row)
        {
            sID = int.Parse(row["sID"].ToString());
            qID= row["qID"].ToString();
      
        }

        public int sID { get; set; }
        public string qID { get; set; }
       
    }
}