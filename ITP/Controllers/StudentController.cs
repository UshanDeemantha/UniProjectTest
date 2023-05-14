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
    public class StudentController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            DBConnect db = new DBConnect();

            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            db.OpenConnection();
            DataTable dt = new DataTable();
            string query = "select * from student;";
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

        // GET api/<controller>/5
        public IEnumerable<Student> Get(int id)
        {
            DBConnect db = new DBConnect();

            db.OpenConnection();
            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            DataTable dt = new DataTable();
            string query = "select * from student where NIC='" + id + "';";
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
        public IEnumerable<Student> Get(string prof)
        {
            DBConnect db = new DBConnect();

            db.OpenConnection();
            // SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=IPTDB;Integrated Security=True");
            DataTable dt = new DataTable();
            string query = "select * from student where prof='" + prof + "';";
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
        //public string Post([FromBody]string value)
        //{
        //    DBConnect db = new DBConnect();
        //    db.OpenConnection();
        //    CreateStudent cs = new CreateStudent();

        //    //int pk = 150;
        //    //cs.fName = "Paai123";
        //    //cs.lName = "Nenarath";
        //    //cs.batch = "12.1";
        //    //cs.pw = "aaa";
        //    //cs.em = "p@gmail.com";

        //    string query = "insert into student (fName,lName,batch,pw,em) values ('" + cs.fName + "','" + cs.lName + "','" + cs.batch + "','" + cs.pw + "','" + cs.em + "');";
        //    SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
        //    cmd.ExecuteNonQuery();

        //    if (cmd.ExecuteNonQuery() > 0)
        //        return "true";
        //    else
        //        return "false";

        //    db.CloseConnection();
        //}

        public string Post([FromBody]CreateStudent value)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();

            string query = "insert into student (NIC,Name,prof,em,aff,ty,pw) values (@NIC,@Name,@prof,@em,@aff,@ty,@pw)";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
            cmd.Parameters.AddWithValue("@NIC",value.NIC);
            cmd.Parameters.AddWithValue("@Name",value.Name);
            cmd.Parameters.AddWithValue("@prof",value.prof);
            cmd.Parameters.AddWithValue("@em",value.em);
            cmd.Parameters.AddWithValue("@aff",value.aff);
            cmd.Parameters.AddWithValue("@ty", value.ty);
            cmd.Parameters.AddWithValue("@pw", value.pw);

            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";

        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody]CreateStudent value)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();

            string query = "update student set prof=@prof where NIC ='"+id+"'";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
            //cmd.Parameters.AddWithValue("@NIC", value.NIC);
            //cmd.Parameters.AddWithValue("@Name", value.Name);
            cmd.Parameters.AddWithValue("@prof", value.prof);
            //cmd.Parameters.AddWithValue("@em", value.em);
            //cmd.Parameters.AddWithValue("@aff", value.aff);
            //cmd.Parameters.AddWithValue("@tp", value.tp);
            //cmd.Parameters.AddWithValue("@pw", value.pw);

            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";
        }

        // DELETE api/<controller>/5
        public string Delete(int id)
        {
            DBConnect db = new DBConnect();
            db.OpenConnection();

            string query = "delete from student where NIC ='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, db.ReturnSqlObj());
            

            if (cmd.ExecuteNonQuery() > 0)
                return "true";
            else
                return "false";
        }
    }
}