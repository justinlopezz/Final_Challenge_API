﻿using System;
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
    public class BorrowersController : ApiController
    {
        // GET: api/Borrowers
        public class BorrowerController : ApiController
        {
            // GET: api/Borrower
            public IEnumerable<BorrowerModel> Get()
            {
                SqlConnection conn = DBConnection.GetConnection();
                SqlCommand cmd;
                SqlDataReader rdr;
                string query;
                List<BorrowerModel> output = new List<BorrowerModel>();
                try
                {
                    conn.Open();
                    query = "select * from Borrower";
                    cmd = new SqlCommand(query, conn);
                    //read the data for that command
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        output.Add(new BorrowerModel(Int32.Parse(rdr["ID"].ToString()),
                                                    rdr["Surname"].ToString(),
                                                    rdr["Firstname"].ToString(),
                                                    rdr["DOB"].ToString()));
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
                finally
                {
                    if (conn.State == System.Data.ConnectionState.Open)
                        conn.Close();
                }
                return output;
            }

            // GET: api/Borrowers/5
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


                    query = "select * from Borrower where id =" + id;
                    cmd = new SqlCommand(query, conn);

                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        output = output + "{PK: " + rdr.GetValue(0)
                                     + ", surname: " + rdr.GetValue(1) + ""
                                     + ", firstname: " + rdr.GetValue(2) + ""
                                     + ", DOB: " + rdr.GetValue(3) + "}";
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

            // POST: api/Borrowers
            public void Post([FromBody]string value)
            {
            }

            // PUT: api/Borrowers/5
            public void Put(int id, [FromBody]string value)
            {
            }

            // DELETE: api/Borrowers/5
            public void Delete(int id)
            {
            }
        }
    }
}
