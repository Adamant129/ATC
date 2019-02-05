using NUnit.Framework;
using Atc;
using RestSharp;
using Newtonsoft.Json;
using System.Net;
using ApiTestsComponents.Models;
using FluentAssertions;
using System.Linq;
using ApiTests.Fixtures;

namespace ApiTests.Tests
{
    public class ApiTests : ApiTestsFixture
    {
        [Test]
        public void ApiGetFirstPostTitle()
        {
            var request = new RestRequest("posts/1", Method.GET);
            var response = AtcBuilder.RestClient.Get(request);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);

            var responseJson = JsonConvert.DeserializeObject<Post>(response.Content);

            responseJson.Title.Should().Contain("sunt aut facere repellat provident occaecati excepturi optio reprehenderit");
        }

        [Test]
        public void ApiGetPosts()
        {
            var request = new RestRequest("posts", Method.GET);
            var response = AtcBuilder.RestClient.Get(request);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.OK);

            var responseJson = JsonConvert.DeserializeObject<Post[]>(response.Content);
            responseJson.Count().Should().Equals(100);
        }

        [Test]
        public void ApiCreatePost()
        {
            var request = new RestRequest("posts", Method.POST);
            var postToCreate = new Post { Body = "fdfd", Title = "dfdfdfdfd", UserId = 1 };
            var requestBody = JsonConvert.SerializeObject(postToCreate);

            request.AddJsonBody(requestBody);
            request.AddHeader("Content-type", "application/json; charset=UTF-8");

            var response = AtcBuilder.RestClient.Post(request);

            response.StatusCode.Should().BeEquivalentTo(HttpStatusCode.Created);
        }
    }
}
