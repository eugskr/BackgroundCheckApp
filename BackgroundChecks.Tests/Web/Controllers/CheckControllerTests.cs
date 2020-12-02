using BackgroundChecks.Data.Models;
using BackgroundChecks.Services.CheckRepo;
using BackgroundChecks.Services.Models;
using BackgroundChecks.Web.Controllers;
using Moq;
using NUnit.Framework;

namespace BackgroundChecks.Tests.Web.Controllers
{
    public class CheckControllerTests
    {
        CheckController _controller;
        Mock<ICheckService> _checkServiceMock;

        [SetUp]
        public void Setup()
        {
            // init and set up mocks
            _checkServiceMock = new Mock<ICheckService>();
            var checkRequest = GetCheckRequest();
            var checkModel = new CheckModel(checkRequest);
            checkModel.SSN = SSN.FromString(checkRequest.SSN);
            _checkServiceMock
                .Setup(x => x.ProcceedBackgroundCheck(It.IsAny<CheckRequest>()))
                .Returns(checkModel);

            _controller = new CheckController(_checkServiceMock.Object);
        }

        [Test]
        public void Post_Success()
        {
            var model = GetCheckRequest();

            var result =_controller.Post(model);

            Assert.NotNull(result);

            _checkServiceMock
                .Verify(x => x.ProcceedBackgroundCheck(model), Times.Once);
        }

        private CheckRequest GetCheckRequest()
        {
            return new CheckRequest
            {
                SSN = "123456789"
            };
        }
    }
}
