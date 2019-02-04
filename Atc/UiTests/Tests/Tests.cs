using NUnit.Framework;
using UiTests;
using UiTestsComponents.PageObjects;

namespace UITests
{
    public class Tests : UiTestsFixture
    {
        [Test]
        public void Test1()
        {
            var loginPage = new LoginPage(AtcBuilder.Driver)
            {
                Password = Conf.UserModel.Password,
                UserName = Conf.UserModel.UserName
            }.Login();
        }
    }
}
