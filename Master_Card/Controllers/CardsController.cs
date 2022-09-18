using Microsoft.AspNetCore.Http;
using Master_Card.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Master_Card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public CardsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        
        public JsonResult Get()
        {
            string query = @" select * from dbo.Cards ";

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
        public JsonResult Post(Cards bd)
        {
            try
            {
                string query = @"
                            insert into dbo.Cards values
                               ('" + bd.CreditCardNumber + @"'
                      ,'" + bd.CustomerName + @"'
                      ,'" + bd.CustomerEmail + @"'
                      ,'" + bd.MobileNumber + @"'
                      ,'" + bd.Amount + @"'
                     
                         ,'" + bd.DueDate + @"'
                      
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
                return new JsonResult("Item Added In DataBase");
            }
            catch (Exception)
            {
                return new JsonResult("Failed");
            }

        }
        [HttpPut]
        public JsonResult Put(Cards bd)
        {
            try
            {
                string query = @"
                    update dbo.Cards set
               Amount='" + bd.Amount + @"'
                    
                    
                    
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
    }
}

