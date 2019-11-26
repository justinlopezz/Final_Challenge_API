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
    public class AuthorsController : ApiController
    {
        // GET: api/Authors
        public IEnumerable<AuthorModel> Get()
        {

            SqlConnection conn = DBConnection.GetConnection();

            SqlCommand cmd;
            SqlDataReader rdr;
            string query;
            List<AuthorModel> output = new List<AuthorModel>();

            try
            {

                conn.Open();

                query = "select * from Author";
                cmd = new SqlCommand(query, conn);

                //read the data for that command
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    output.Add(new AuthorModel(Int32.Parse(rdr["ID"].ToString()),
                                                rdr["Surname"].ToString(),
                                                rdr["Firstname"].ToString()));
                }

            }
            catch (Exception e)
            {
                throw e;

                //throw e;
            }
            finally
            {
                if (conn.State == System.Data.ConnectionState.Open)
                    conn.Close();
            }
            return output;
        }


        // GET: api/Authors/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authors
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Authors/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Authors/5
        public void Delete(int id)
        {
        }
    }
}
