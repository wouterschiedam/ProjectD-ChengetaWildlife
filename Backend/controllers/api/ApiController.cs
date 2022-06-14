using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProjectD_ChengetaWildlife.controllers.api
{
	[Route("api/controller")]
	[ApiController]
	public class ApiController : ControllerBase
    {

		public bool isValidOauth(string token)
		{
			if (token == null) return false;

			Database database = new Database();
			DataTable data = database.BuildQuery("SELECT * FROM admins WHERE oauth_token=@token")
				.AddParameter("token", token)
				.Select();

			database.Close();
			return data.Rows.Count == 1;
		}

	}
}
