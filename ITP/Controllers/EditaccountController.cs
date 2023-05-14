using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTAPI.Models;
using System.Data.SqlClient;

namespace IPTAPI.Controllers
{
    public class EditaccountController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]CreateStudent value)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();

            string query = "update student set Name=@Name,em=@em,aff=@aff,pw=@pw where NIC ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());

            //cmd.Parameters.AddWithValue("@NIC", value.NIC);
            cmd.Parameters.AddWithValue("@Name", value.Name);
            //cmd.Parameters.AddWithValue("@prof", value.prof);
            cmd.Parameters.AddWithValue("@em", value.em);
            cmd.Parameters.AddWithValue("@aff", value.aff);
            //cmd.Parameters.AddWithValue("@tp", value.tp);
            cmd.Parameters.AddWithValue("@pw", value.pw);

            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}