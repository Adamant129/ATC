using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using UiTestsComponents.Models;

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
        }

        [TearDown]
        public void TearDown()
        {
            AtcBuilder.Driver.Dispose();
        }
    }
}
