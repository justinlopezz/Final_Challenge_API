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
    public class BorrowedBooksController : ApiController
    {
        // GET: api/BorrowedBooks
        public IEnumerable<BorrowedBookModel> Get()
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BorrowedBookModel> output = new List<BorrowedBookModel>();

            try
            {
                conn.Open();


                query = "select isbn, title, borrower from Books where borrower is not null";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BorrowedBookModel(Int32.Parse(rdr["isbn"].ToString()),
                        rdr["title"].ToString(),
                        Int32.Parse(rdr["borrower"].ToString())));
                }

            }
            catch (Exception e)
            {
                output.Clear();
                throw e;
                //output.Add(e.Message);

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

        // GET: api/BorrowedBooks/5
        public IEnumerable<BorrowedBookModel> Get(int id)
        {
            SqlConnection conn = DBConnection.GetConnection();
            SqlCommand cmd;
            SqlDataReader rdr;
            String query;
            List<BorrowedBookModel> output = new List<BorrowedBookModel>();

            int output1 = 0;
            string output2 = "";
            int output3 = 0;

            try
            {
                conn.Open();


                query = "select * from Books where borrower =" + id;
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output1 = Int32.Parse(rdr["isbn"].ToString());
                    output2 = rdr["title"].ToString();
                    output3 = Int32.Parse(rdr["borrower"].ToString());

                    output.Add(new BorrowedBookModel(output1, output2, output3));


                }

            }
            catch (Exception e)
            {
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

        // POST: api/BorrowedBooks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/BorrowedBooks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BorrowedBooks/5
        public void Delete(int id)
        {
        }
    }
}
