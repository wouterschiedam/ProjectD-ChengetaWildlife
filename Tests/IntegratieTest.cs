using ProjectD_ChengetaWildlife.controllers.api;
using Xunit;
using System.Data;
using ProjectD_ChengetaWildlife;
using System;
using ProjectD_ChengetaWildlife.controllers;
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
                
                if (check)
                {
                    success++;
                }     
            }
            Assert.True(rows == success);

        }
        [Fact]
        public void CheckValidResponse_WithParameters_Database_Sounds()
        {
            var controller = new Nodedata();

            var result = controller.Get(5, "time", "");
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckValidResponse_WithoutParameters_Database_Sounds()
        {
            var controller = new Nodedata();
            var result = controller.Get();
            Assert.NotNull(result);
        }
    }
}
