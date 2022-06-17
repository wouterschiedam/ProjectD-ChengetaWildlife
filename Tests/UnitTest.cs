using ProjectD_ChengetaWildlife.controllers;
using ProjectD_ChengetaWildlife.controllers.api;
using Xunit;

namespace Tests
{
    public class UnitTest
    {
        [Fact]
        public void isOauthValid_With_Valid_Token_Returns_True()
        {
            var controller = new ApiController();

            var result = controller.isValidOauth("oY8ow49sM7LMq70sWY2qk+vSf04xVXrfNUT7yVKe1RM=");

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
        public void CheckValidResponse_WithParameters_Database_Sounds()
        {
            var controller = new Nodedata();

            var result = controller.Get(5,"time", "");
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckValidResponse_WithoutParameters_Database_Sounds()
        {
            var controller = new Nodedata();
            var result = controller.Get();
            Assert.NotNull(result);
        }
        [Fact]
        public void CheckValidResponse_CreateUser()
        {
            var controller = new ApiController();
            var result = controller.CreateUser("Arian", "0992392@hr.nl", "test", "/MY/omr+b6xGuEN/6MLsfhzw0AjNVC7+4XtXXIBfgCs=", false, true);
            Assert.True(result);
        }
        [Fact]
        public void CheckValidResponse_With_inValid_Params_CreateUser()
        {
            var controller = new ApiController();
            var result = controller.CreateUser("Arian", "0992392@hr.nl", "ariansjonnie", "", false, false);
            Assert.False(result);
        }
        [Fact]
        public void CheckValidResponse_Without_Params_CreateUser()
        {
            var controller = new ApiController();
            var result = controller.CreateUser();
            Assert.False(result);
        }
    }
}
