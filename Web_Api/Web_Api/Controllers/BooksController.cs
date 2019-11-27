using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using Web_Api.Models;
using System.Data;

namespace Web_Api.Controllers
{
    public class BooksController : ApiController
    {
        // GET: api/Books
        public IEnumerable<BookModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<BookModel> output = new List<BookModel>();
            try
            {
                conn.Open();
                query = "select ISBN, Title from Books";
                cmd = new SqlCommand(query, conn);
                //read the data for that command
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    output.Add(new BookModel(Int32.Parse(rdr["ISBN"].ToString()),
                                                rdr["Title"].ToString()));

                }
            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }

        // GET: api/Books/5
        public string Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            String output = "";

            try
            {
                conn.Open();


                query = "select * from Books where borrower =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output = output + ("{ISBN: " + rdr.GetValue(0)
                                 + ", Surname: " + rdr.GetValue(1) + "\""
                                 + ", Firstname: " + rdr.GetValue(2) + ""
                                 + ", Title: " + rdr.GetValue(1) + "}");
                }

            }
            catch (Exception e)
            {
                output = "";
                output = output + e.Message;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
            }

            return output;
        }

        // POST: api/Books
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Books/5
        public void Delete(int id)
        {
        }
    }
}
