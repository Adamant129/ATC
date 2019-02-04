using NUnit.Framework;
using UiTests.Fixtures;
using UiTestsComponents.PageObjects;

namespace UiTests.Tests
{
    public class Tests : UiTestsFixture
    {
        [Test]
        public void Test1()
        {
            new LoginPage(AtcBuilder.Driver)
            {
                Password = Conf.UserModel.Password,
                UserName = Conf.UserModel.UserName
            }.Login().ManageCars();
            
        }
    }
}
