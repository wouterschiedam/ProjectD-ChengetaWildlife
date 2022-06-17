using ProjectD_ChengetaWildlife.controllers.api;
using Xunit;
using System.Data;
using ProjectD_ChengetaWildlife;
using System;
using System.Diagnostics;

namespace Tests
{
    public class IntegratieTest
    {

        [Fact]
        public void isOauthValid_With_Valid_Token_Returns_True()
        {

            var controller = new ApiController();

            Database database = new Database();
            DataTable data = database.BuildQuery("SELECT * FROM admins").Select();
            database.Close();
            int rows = data.Rows.Count;
            int success = 0;

            foreach (DataRow row in data.Rows)
            {
                bool check = controller.isValidOauth(row["oauth_token"].ToString());
                Debug.WriteLine(check);
                if (check)
                {
                    success++;
                }     
            }
            Assert.True(rows == success);

        }
    }
}
