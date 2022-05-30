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
        public IActionResult GetActionResult(int limit = 10)
        {
            string query = limit == 10 ? "SELECT * FROM mqttdata ORDER BY time DESC LIMIT 10" : "SELECT * FROM mqttdata ORDER BY time DESC LIMIT 150";
            Database database = new Database();
            DataTable data1 = database.BuildQuery(query)
                .Select();
            database.Close();
            return Ok(JsonConvert.SerializeObject(data1));
        }
    }
}
