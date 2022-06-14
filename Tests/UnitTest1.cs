using System;
using ProjectD_ChengetaWildlife.controllers;
using ProjectD_ChengetaWildlife.controllers.api;
using Xunit;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void isOauthValid_With_Valid_Token_Returns_True()
        {
            var controller = new ApiController();

            var result = controller.isValidOauth("Z4qGt8PiAZJAoqFnRqSto1PYIJmQ5QQGQkVV48ztQHo=");

            Assert.True(result);

        }
        
        [Fact]
        public void isOauthValid_With_inValid_Token_Returns_False()
        {
            var controller = new ApiController();

            var result = controller.isValidOauth("564fd5f64dfdf456dwe8wew4e6w4e8w561d4s");

            Assert.False(result);
        }

        [Fact]
        public void CheckValidResponse_WithParameters()
        {
            var controller = new Nodedata();

            var result = controller.Get(5,"time", "");
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckValidResponse_WithoutParameters()
        {
            var controller = new Nodedata();

            var result = controller.Get();
            Assert.NotNull(result);
        }



    }
}
