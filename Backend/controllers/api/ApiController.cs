using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using System.Text;
using System.Data;
using System.Security.Cryptography;

namespace ProjectD_ChengetaWildlife.controllers.api
{
	[Route("api/controller")]
	[ApiController]
	public class ApiController : ControllerBase
    {

		public bool isValidOauth(string token)
		{
			

			Database database = new Database();
			DataTable data = database.BuildQuery("SELECT * FROM admins WHERE oauth_token=@token")
				.AddParameter("token", token)
				.Select();

			database.Close();
			return data.Rows.Count == 1;
		}

		public bool CreateUser(string Name = null, string Email = null, string Password = null, string oauth = null, bool newsuperUser = false, bool superUser = false)
		{
			// Get a value called email & password from the Request 

			if (Name == null || Email == null || Password == null)
			{
				return false;
			}

			// generate a 128-bit salt using a cryptographically strong random sequence of nonzero values
			byte[] salt = new byte[128 / 8];
			using (var rngCsp = new RNGCryptoServiceProvider())
			{
				rngCsp.GetBytes(salt);
			}
			var newSalt = Convert.ToBase64String(salt);

			var newPassword = Password + newSalt;

			var crypt = new SHA256Managed();
			byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(newPassword));
			string hash = Encoding.ASCII.GetString(crypto);





			Database database = new Database();
			//Query to check if the logged in user is authorithized to create new accounts
			DataTable data1 = database.BuildQuery("select superuser from admins WHERE oauth_token = @oauth_token")
				.AddParameter("oauth_token", oauth)
				.Select();
			if (data1 == null || data1.Rows == null)
				return false;
			foreach (DataRow row in data1.Rows)
			{
				superUser = bool.Parse(row["superuser"].ToString());
			}
			//Query to insert the new users information into the database
			if (superUser)
			{
				DataTable data = database.BuildQuery($"SELECT (id) FROM admins").Select();
				database.BuildQuery($"INSERT INTO admins (id name, email, password, twofa, salt, superuser, loggedin) VALUES (@id, @name, @email, @password, @twofa, @salt, @superuser)")
					.AddParameter("id", (data.Rows.Count + 1))
					.AddParameter("name", Name)
					.AddParameter("email", Email)
					.AddParameter("twofa", false)
					.AddParameter("superuser", newsuperUser)
					.AddParameter("password", hash)
					.AddParameter("salt", newSalt)
					.AddParameter("loggedin", false)
					.Query();


				database.Close();
				return true;
			}
			database.Close();
			return false;
		}
	}
}
