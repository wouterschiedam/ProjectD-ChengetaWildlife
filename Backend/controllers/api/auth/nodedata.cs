using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ProjectD_ChengetaWildlife.controllers
{
    
    [Route("api/auth/mqttdata")]
    [ApiController]
    public class Nodedata : Controller
    {

        [HttpGet]
        public IActionResult GetActionResult(int limit = 15, string order = "ORDER BY time DESC")
        {
            string query = $"SELECT * FROM mqttdata {order} LIMIT {limit}";

            Database database = new Database();
            DataTable data1 = database.BuildQuery(query)
                .Select();
            database.Close();
            return Ok(JsonConvert.SerializeObject(data1));
        }
    }
}
