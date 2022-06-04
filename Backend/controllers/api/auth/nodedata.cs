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
        public string Get(int limit = 15, string order = "time")
        {   

            Database database = new Database();
            DataTable data = database.BuildQuery($"SELECT * FROM mqttdata ORDER BY @order DESC LIMIT @data")
                .AddParameter("order", order)
                .AddParameter("data", limit)
                .Select();
            database.Close();
            return JsonConvert.SerializeObject(data);
        }
    }
}
