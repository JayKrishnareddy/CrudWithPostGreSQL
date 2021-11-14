using CrudWithPostGreSQL.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudWithPostGreSQL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {       

        private readonly IConfiguration _configuration;
        private readonly string _conStr = "myconn";

        public WeatherForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(nameof(GetData))]
        public async Task<IActionResult> GetData()
        {
            List<Department> departmentList = new();
            string query = @"Select * from Department";
            string sqlDataSource = _configuration.GetConnectionString(_conStr);
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                departmentList = myCon.Query<Department>(query).ToList();
                myCon.Close();
            }
            return Ok(departmentList);
        }
        [HttpPost(nameof(PostData))]
        public async Task<IActionResult> PostData(string DepartmentName)
        {
            string query = @"Insert into Department (DepartmentName) values(@DepartmentName)";
            string sqlDataSource = _configuration.GetConnectionString(_conStr);
            using (NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                var res = await myCon.ExecuteAsync(query, new {DepartmentName = DepartmentName});
                myCon.Close();
            }
            return Ok("Data Inserted !");
        }
    }

    
}
