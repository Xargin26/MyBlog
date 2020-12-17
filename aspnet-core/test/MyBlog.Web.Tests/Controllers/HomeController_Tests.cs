using System.Threading.Tasks;
using MyBlog.Models.TokenAuth;
using MyBlog.Web.Controllers;
using Shouldly;
using Xunit;

namespace MyBlog.Web.Tests.Controllers
{
    public class HomeController_Tests: MyBlogWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}