using Bunit;
using Bunit.TestDoubles;
using Microsoft.AspNetCore.Components.RenderTree;
using Softwaresikkerhed_test_day1.Components.Pages;
using Softwaresikkerhed_test_day1.Data;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace Softwaresikkerhed_test_day1.tests
{
    public class UnitTest1 : TestContext
    {

        [Fact]
        public void Home_IsNotAuthorized()
        {

            // Arrange

            this.AddTestAuthorization();


            // Act

            var cut = RenderComponent<Home>();

            // Assert

            cut.MarkupMatches(@"<h1>Hello, world!</h1><p>Welcome NotAuthorized user to your new app.</p>");

        }

        [Fact]
        public void Home_IsAuthorized()
        {
            // Arrange
            var authcontext =  this.AddTestAuthorization();
            
            authcontext.SetAuthorized("Test",AuthorizationState.Authorized);

            // Act

            var cut = RenderComponent<Home>();

            // Assert

            cut.MarkupMatches(@"<h1>Hello, world!</h1><p>Welcome user to your new app.</p>");
        }



        [Fact]
        public void Home_IsAuthorizedAndAdmin()
        {
            // Arrange
            var authcontext = this.AddTestAuthorization();

            authcontext.SetAuthorized("Test", AuthorizationState.Authorized);
            authcontext.SetRoles("Admin");

            // Act

            var cut = RenderComponent<Home>();
            
            // Assert

            cut.MarkupMatches(@"<h1>Hello, world!</h1><p>Welcome user to your new app.</p><p>You are Admin.</p>");
        }
    }
}
