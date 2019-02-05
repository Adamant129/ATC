using Atc;
using NUnit.Framework;

namespace ApiTests.Fixtures
{
    [SetUpFixture]
    public abstract class DefaultFixture
    {
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            AtcBuilder.AddJsonConfiguration();
            AtcBuilder.AddLogging();
            AtcBuilder.AddRestClient();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {            
        }
    }
}
