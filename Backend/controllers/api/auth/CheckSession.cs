using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectD_ChengetaWildlife.controllers;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectD_ChengetaWildlife.controllers {

	[Route("api/auth/session")]
	[ApiController]
	public class CheckSession : ControllerBase {

        [HttpPost]
        public string Post() {
            
            string oauth_token = HttpContext.Request.Form["oauth"].ToString();
            Database database = new Database();

            DataTable data = database.BuildQuery($"SELECT * FROM admins WHERE oauth_token = @oauth_token")
                .AddParameter("oauth_token", oauth_token)
                .Select();
            if(data.Rows.Count == 1){
                database.Close();
                return JsonSerializer.Serialize(new{
                    success = true,
                    message = "De sessie is nog actief."
                });
            }
            database.Close();
            return JsonSerializer.Serialize(new{  
                    success = false,
                    message = "De sessie is verlopen."      
            });
        }
    }
}