using ProjectD_ChengetaWildlife.controllers.api;
using Xunit;
using System.Data;
using ProjectD_ChengetaWildlife;
using System;

namespace Tests
{
    public class IntegratieTest
    {
        [Fact]
        public void isOauthValid_With_Valid_Token_Returns_True()
        {
            var controller = new ApiController();

            Database database = new Database();
            DataTable data = database.BuildQuery("SELECT oauth_token FROM admins").Select();
            database.Close();
            var result = true;
            
            foreach (var aouth_token in data.Rows)
            {
                Console.WriteLine(aouth_token.ToString());
                if (!controller.isValidOauth(aouth_token.ToString()))
                    result = false;
            }

            Assert.True(result);
        }
    }
}
