using Master_Card.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace Master_Card.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class MasterCardController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public MasterCardController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from
                                dbo.Master";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MasterCard");
            SqlDataReader myReader;
            using (SqlConnection data = new SqlConnection(sqlDataSource))
            {
               data.Open();
                using (SqlCommand myCommand = new SqlCommand(query, data))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    data.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpGet("{id}")]
        public JsonResult Get(long id)
        {
            string query = @"
                            select * from
                                dbo.Master where CreditCardNumber=" + id + @"
";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("MasterCard");
            SqlDataReader myReader;
            using (SqlConnection data = new SqlConnection(sqlDataSource))
            {
                data.Open();
                using (SqlCommand myCommand = new SqlCommand(query, data))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    data.Close();
                }
            }
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(MasterCard bd)
        {
            try
            {
                string query = @"
                            insert into dbo.Master values
                               ('" + bd.CreditCardNumber + @"'
                      ,'" + bd.CustomerName + @"'
                      ,'" + bd.CustomerEmail + @"'
                      ,'" + bd.MobileNumber + @"'
                      ,'" + bd.Amount + @"'
                         ,'" + bd.DueDate + @"'
                        ,'" + bd.Charges + @"'
                        ,'" + bd.DueAmount + @"'
                    ,'" + bd.Status + @"'
                      
)
";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("MasterCard");
                SqlDataReader myReader;
                using (SqlConnection data = new SqlConnection(sqlDataSource))
                {
                    data.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, data))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        data.Close();
                    }
                }
                return new JsonResult("Item Added In DAtaBase");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(MasterCard bd)
        {
            try
            {
                string query = @"
                    update dbo.Master set
               Amount='" + bd.Amount + @"'
                ,Charges='" + bd.Charges + @"'
                 ,DueAmount='" + bd.DueAmount + @"'
                ,Status='" + bd.Status + @"'
                    
                    
                    
                    where CreditCardNumber='" + bd.CreditCardNumber + @"'
         ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("MasterCard");
                SqlDataReader myReader;
                using (SqlConnection data = new SqlConnection(sqlDataSource))
                {
                    data.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, data))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        data.Close();
                    }
                }
                return new JsonResult("Card Details Updated");
            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpDelete("{id}")]
        public JsonResult Delate(long id)
        {
            try
            {
                string query = @"
                   delete from dbo.Master where CreditCardNumber=" + id + @"
                    
         ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("MasterCard");
                SqlDataReader myReader;
                using (SqlConnection data = new SqlConnection(sqlDataSource))
                {
                    data.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, data))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        data.Close();
                    }
                }
                return new JsonResult("Account Deleted");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }


        [HttpDelete]
        public JsonResult Delate()
        {
            try
            {
                string query = @"
                   delete from dbo.Master
                    
         ";
                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("MasterCard");
                SqlDataReader myReader;
                using (SqlConnection data = new SqlConnection(sqlDataSource))
                {
                    data.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, data))
                    {
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        data.Close();
                    }
                }
                return new JsonResult("Account Deleted");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }


    }
}

