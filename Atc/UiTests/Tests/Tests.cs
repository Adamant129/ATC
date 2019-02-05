using System;
using Atc;
using NUnit.Framework;
using UiTests.Fixtures;
using UiTestsComponents.PageObjects;

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

        [Test]
        public void CheckHotelsPagination()
        {
            try
            {
                new MainPage(AtcBuilder.Driver)
                    .ManageHotels()
                    .PaginateHotels(25);
            }
            catch (Exception ex)
            {
                AtcBuilder.Log.Error(ex.Message);
            }
        }
    }
}
