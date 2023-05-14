using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using IPTAPI.Models;
using System.Data.SqlClient;

namespace IPTAPI.Controllers
{
    public class CategoryController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Category> Get()
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from category;";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<Category> cat = new List<Category>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    cat.Add(new ReadCategory(stdRed));
                }
            }

            db.CloseConnection();
            return cat;
        }

        // GET api/<controller>/5
        public IEnumerable<Category> Get(int id)
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from category where cID='"+id+"';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<Category> cat = new List<Category>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    cat.Add(new ReadCategory(stdRed));
                }
            }

            db.CloseConnection();

            return cat;
        }
        public IEnumerable<StudentCategory> Get(string nm)
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from std_cat where cID='" + nm + "';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<StudentCategory> qu = new List<StudentCategory>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    qu.Add(new ReadStdCat(stdRed));
                }
            }

            db.CloseConnection();
            return qu;
        }
        public IEnumerable<StudentCategory> Get(int id, string s)
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from std_cat where cID='" + id + "';";
            SqlDataAdapter adapter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, db.ReturnSqlObj())
            };
            adapter.Fill(dt);
            List<StudentCategory> cat = new List<StudentCategory>(dt.Rows.Count);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow stdRed in dt.Rows)
                {
                    cat.Add(new ReadStdCat(stdRed));
                }
            }

            db.CloseConnection();

            return cat;
        } 


        // POST api/<controller>
        public string Post([FromBody]CreateStdCat value)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();
            string query = "insert into std_cat (sID,cID) values (@sID,@cID)";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
            cmd.Parameters.AddWithValue("@sID", value.sID);
            cmd.Parameters.AddWithValue("@cID", value.cID);


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

            string query = "delete from std_cat where sID ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());


            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";
        }
    }
}