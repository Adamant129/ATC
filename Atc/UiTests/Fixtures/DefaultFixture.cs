using Atc;
using NUnit.Framework;

namespace UiTests.Fixtures
{
    [SetUpFixture]
    public abstract class DefaultFixture
    {
        [OneTimeSetUp]
        public virtual void OneTimeSetUp()
        {
            AtcBuilder.AddJsonConfiguration();
            AtcBuilder.AddDriver();
            AtcBuilder.AddLogging();
        }

        [OneTimeTearDown]
        public virtual void OneTimeTearDown()
        {          
        }
    }
}
