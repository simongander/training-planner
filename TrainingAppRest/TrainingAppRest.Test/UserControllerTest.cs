using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Moq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TrainingAppBL.Interfaces;
using TrainingAppDAL.Model;

namespace TrainingAppRest.Test
{
    internal class UserControllerTest
    {
        private IUserRepository userRepository;
        private RestClient restClient;
        private Bearer token;

        [SetUp]
        public void Setup()
        {
            restClient = new RestClient("https://localhost:44344/api");
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.Setup(u => u.Authenticate(It.Is<string>(s => s == "VmFsaWRVc2VyOjEyMzQ="))).Returns("a1234");
            userRepositoryMock.Setup(u => u.Authenticate(It.Is<string>(s => s == "SW52YWxpZFVzZXI6MTIzNA=="))).Throws(new UnauthorizedAccessException("Unauthorized"));
            userRepository = userRepositoryMock.Object;
            token = new Bearer { Token = "a1234" };
        }

        [Test]
        public void Authenticate_Success()
        {
            RestRequest restRequest = new RestRequest("/user/authenticate", Method.Post);
            restRequest.AddHeader("Authorization", "Basic VmFsaWRVc2VyOjEyMzQ="); // ValidUser:1234

            var restResponse = restClient.Execute(restRequest);

            restResponse.Should().Be(token);
            restResponse.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Authenticate_Failure()
        {
            RestRequest restRequest = new RestRequest("/user/authenticate", Method.Post);
            restRequest.AddHeader("Authorization", "Basic SW52YWxpZFVzZXI6MTIzNA=="); // InvalidUser:1234

            var restResponse = restClient.Execute(restRequest);

            restResponse.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }
    }
}
