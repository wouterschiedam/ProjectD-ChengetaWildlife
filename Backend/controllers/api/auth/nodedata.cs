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
        public IActionResult GetActionResult()
        {
            Database database = new Database();
            DataTable data1 = database.BuildQuery("SELECT * FROM mqttdata LIMIT 10")
                .Select();
            database.Close();
            return Ok(JsonConvert.SerializeObject(data1));
        }
    }
}
