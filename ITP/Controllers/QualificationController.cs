using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IPTAPI.Models;
using System.Data.SqlClient;
using System.Data;

namespace IPTAPI.Controllers
{
    public class QualificationController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Qualification> Get()
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from qulifications;";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<Qualification> qu = new List<Qualification>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    qu.Add(new ReadQualification(stdRed));
                }
            }

            db.CloseConnection();
            return  qu;
        }

        // GET api/<controller>/5
        public IEnumerable<Qualification> Get(int id)
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from qulifications where qID='"+id+"';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<Qualification> qu = new List<Qualification>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    qu.Add(new ReadQualification(stdRed));
                }
            }

            db.CloseConnection();
            return qu;
        }
        public IEnumerable<StudentQualification> Get(string nm)
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from std_quli where qID='" + nm + "';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<StudentQualification> qu = new List<StudentQualification>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    qu.Add(new ReadStdQuli(stdRed));
                }
            }

            db.CloseConnection();
            return qu;
        }

        // POST api/<controller>
        public string Post([FromBody]CreateStdQuli value)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();
            string query = "insert into std_quli (sID,qID) values (@sID,@qID)";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
            cmd.Parameters.AddWithValue("@sID", value.sID);
            cmd.Parameters.AddWithValue("@qID", value.qID);


            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";

        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();

            string query = "delete from std_quli where sID ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());


            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";
        }
    }
}