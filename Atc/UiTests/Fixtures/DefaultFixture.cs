using Atc;
using NUnit.Framework;

namespace UiTests.Fixtures
{
    [SetUpFixture]
    public abstract class DefaultFixture
    {
        protected static AtcBuilder AtcBuilder { get; set; } 

        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            AtcBuilder = new AtcBuilder()
                .AddJsonConfiguration()
                .AddDriver()
                .AddLogging();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {          
        }
    }
}
