using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace IPTAPI.Models
{
    public class Category
    {
        public string cName { get; set; }
    }
    public class CreateCategory:Category
    {

    }
    public class ReadCategory:Category
    {
        public ReadCategory(DataRow row)
        {
            cName = row["cName"].ToString();
        }
        public string cName { get; set; }
    }
}