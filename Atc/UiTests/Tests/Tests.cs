using System;
using Atc;
using NUnit.Framework;
using Serilog;
using UiTests.Fixtures;
using UiTestsComponents.PageObjects;
using UiTestsComponents.PageObjects.CarsPages;

namespace UiTests.Tests
{
    public class Tests : UiTestsFixture
    {
        [Test]
        public void CreateNewCar()
        {
            var newCarName = "Toyota Forza x6";

            try
            {
                new MainPage(AtcBuilder.Driver)
                .ManageCars()
                .AddNewCar()
                .CreateNewCar(newCarName)
                .CheckCarCreated(newCarName);
            }
            catch (Exception ex)
            {
                AtcBuilder.Log.Error(ex.Message);
            }
        }
    }
}
