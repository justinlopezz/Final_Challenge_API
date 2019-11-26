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
    public class NBorrowedBooksController : ApiController
    {
        // GET: api/NBorrowedBooks
        public IEnumerable<BookModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BookModel> output = new List<BookModel>();

            try
            {
                conn.Open();


                query = "select * from Books where borrower is null ";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BookModel(Int32.Parse(rdr["isbn"].ToString()),
                        rdr["title"].ToString()));
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
                {
                    conn.Close();
                }
            }

            return output;
        }

        // GET: api/NBorrowedBooks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/NBorrowedBooks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/NBorrowedBooks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/NBorrowedBooks/5
        public void Delete(int id)
        {
        }
    }
}
