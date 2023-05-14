using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using IPTAPI.Models;

namespace IPTAPI.Controllers
{
    public class Student2Controller : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            DBConnect db = new DBConnect();

            db.OpenConnection();
            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            DataTable dt = new DataTable();
            string query = "select * from student where stID='" + id + "';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<Student> students = new List<Student>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    students.Add(new ReadStudent(stdRed));
                }
            }
            db.CloseConnection();
            return students;
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}