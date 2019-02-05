using Atc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using UiTestsComponents.Models;
using UiTestsComponents.PageObjects;

namespace UiTests.Fixtures
{
    [TestFixture]
    public class UiTestsFixture : DefaultFixture
    {
        protected UserModel User { get; set; }

        protected static AppConfiguration Conf { get; set; }

        [SetUp]
        public void SetUp()
        {
            Conf = AtcBuilder
                .Configuration.GetSection(nameof(AppConfiguration)).Get<AppConfiguration>();

            new LoginPage(AtcBuilder.Driver)
                .Login(Conf.UserModel.UserName, Conf.UserModel.Password);
        }

        [TearDown]
        public void TearDown()
        {
            new MainPage(AtcBuilder.Driver).LogOut();
        }
    }
}
