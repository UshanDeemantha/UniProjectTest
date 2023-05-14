using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IPTAPI.Models
{
    public class Student
    {
        // dan add karapu eka;
        
        public string NIC { get; set; }
        public string Name { get; set; }
        public string prof { get; set; }
        public string em { get; set; }
        public string aff { get; set; }
        public string ty { get; set; }
        public string pw { get; set; }
        
    }
    public class CreateStudent:Student
    {

    }
    public class ReadStudent:Student
    {
        public ReadStudent(DataRow row)
        {
            stID = int.Parse(row["stID"].ToString());
            NIC = row["NIC"].ToString();
            Name = row["Name"].ToString();  
            prof = row["prof"].ToString();
            em = row["em"].ToString();
            aff = row["aff"].ToString();
            ty = row["ty"].ToString();
            pw = row["pw"].ToString();
           
        }

        public int stID { get; set; }
        public string NIC { get; set; }
        public string Name { get; set; }
        public string prof { get; set; }
        public string em { get; set; }
        public string aff { get; set; }
        public string ty { get; set; }
        public string pw { get; set; }
    }
}