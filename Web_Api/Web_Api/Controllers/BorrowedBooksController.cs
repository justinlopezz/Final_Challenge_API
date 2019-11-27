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


                query = "select * " +
                    "from Books " +
                    "inner join Borrower on Books.Borrower = Borrower.id " +
                    "where Books.Borrower is not null";
                cmd = new SqlCommand(query, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new BorrowedBookModel(Int32.Parse(rdr["ISBN"].ToString()),
                                                     rdr["Title"].ToString(),
                                                     Int32.Parse(rdr["ID"].ToString()),
                                                     rdr["Surname"].ToString(),
                                                     rdr["Firstname"].ToString(),
                                                     rdr["DOB"].ToString()));

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
        public string Get(int id)
        {
            //SqlConnection conn = DBConnection.GetConnection();
            //SqlCommand cmd;
            //SqlDataReader rdr;
            //String query;
            //List<BorrowedBookModel> output = new List<BorrowedBookModel>();

            //int output1 = 0;
            //string output2 = "";
            //int output3 = 0;

            //try
            //{
            //    conn.Open();


            //    query = "select * from Books where borrower =" + id;
            //    cmd = new SqlCommand(query, conn);

            //    rdr = cmd.ExecuteReader();

            //    while (rdr.Read())
            //    {
            //        output1 = Int32.Parse(rdr["ISBN"].ToString());
            //        output2 = rdr["Title"].ToString();
            //        output3 = Int32.Parse(rdr["Borrower"].ToString());

            //        output.Add(new BorrowedBookModel(output1, output2, output3));


            //    }

            //}
            //catch (Exception e)
            //{
            //    throw e;
            //}
            //finally
            //{
            //    if (conn.State == System.Data.ConnectionState.Open)
            //    {
            //        conn.Close();
            //    }
            //}

            return "value";
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
