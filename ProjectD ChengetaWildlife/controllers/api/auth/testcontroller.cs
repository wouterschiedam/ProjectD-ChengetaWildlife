using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace ProjectD_ChengetaWildlife.controllers.api.auth
{
    [Route("api/auth/test")]
    [ApiController]
    public class testcontroller : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Database database = new Database();
            DataTable data1 = database.BuildQuery("SELECT soundtype FROM mqttdata")
                .Select();

            return Ok(JsonConvert.SerializeObject(data1));
        }
    }
}
