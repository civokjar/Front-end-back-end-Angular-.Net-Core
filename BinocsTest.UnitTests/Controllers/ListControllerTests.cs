using AutoMapper;
using BinocsTest.Api.Controllers;
using BinocsTest.Api.IO.Responses;
using BinocsTest.Api.Mappers;
using BinocsTest.Core.Handlers.RequestHandlers.Requests;
using BinocsTest.Core.Handlers.RequestHandlers.Results;
using BinocsTest.Core.Model.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinocsTest.UnitTests.Controllers
{
    [TestFixture]
    internal class ListControllerTests
    {
        private Mock<IMediator> _mediator = new Mock<IMediator>();
        private ListController _controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            _mediator.Setup(t => t.Send(It.IsAny<GetAllListsRequest>(), It.IsAny<CancellationToken>())).ReturnsAsync(GetAllListsCoreResult());

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {

                cfg.AddProfile(new BinocsTestApiProfile());


            });
            var _mapper = mapperConfiguration.CreateMapper();
            _controller = new ListController(_mediator.Object, _mapper);
        }
        private GetAllListsResult GetAllListsCoreResult()
        {


            return new GetAllListsResult { AllLists = new List<ListEntity> { new ListEntity { Id = Guid.Parse("b6b03eb4-3248-4480-99f5-264965334e43"), Name = "name 1" }, new ListEntity { Id = Guid.Parse("cc39f9f3-cdce-4b97-a9fd-8612cdac9e7e"), Name = "name 2" } } };

        }
        private GetAllListsResponse GetAllListsMappedApiResponse()
        {


            return new GetAllListsResponse { AllLists = new List<ListResponse> { new ListResponse { Id = Guid.Parse("b6b03eb4-3248-4480-99f5-264965334e43"), Name = "name 1" }, new ListResponse { Id = Guid.Parse("cc39f9f3-cdce-4b97-a9fd-8612cdac9e7e"), Name = "name 2" } } };

        }
        [Test]
        public async Task When_GetAllListsMethodIsCalled_Then_ShouldReturn200_AND_MappedList()
        {


            var response = await _controller.GetAll();



            var result = response as OkObjectResult;
            var apiResponseContent = result?.Value as GetAllListsResponse;
            var expectedApiResponseContent = GetAllListsMappedApiResponse();


            var apiResponseContentJson = JsonConvert.SerializeObject(apiResponseContent);
            var expectedApiResponseContentJson = JsonConvert.SerializeObject(expectedApiResponseContent);

            Assert.AreEqual(apiResponseContentJson, expectedApiResponseContentJson);
        }
    }
}
