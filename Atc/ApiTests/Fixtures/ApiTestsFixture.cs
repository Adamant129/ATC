using Atc;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;

namespace ApiTests.Fixtures
{
    [TestFixture]
    public class ApiTestsFixture : DefaultFixture
    {
        [SetUp]
        public void SetUp()
        {
            var baseUrl = AtcBuilder.Configuration.GetValue<string>("baseUrl");
            AtcBuilder.RestClient.BaseUrl = new Uri(baseUrl);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
