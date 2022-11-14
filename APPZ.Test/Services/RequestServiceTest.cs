using APPZ.Core.DTO;
using APPZ.Core.Entities;
using APPZ.Core.Exceptions;
using APPZ.Core.Interfaces;
using APPZ.Infrastructure.Implementations;
using APPZ.Infrastructure.Strategies;
using APPZ.Test.MockData;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace APPZ.Test.Services
{
    [TestClass]
    public class RequestServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMoq;
        private readonly Mock<INotificationService> _notificationService;
        private readonly Mock<IMapper> _mapperMock;
        private readonly RequestService _requestService;

        public RequestServiceTest()
        {
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            _notificationService = new Mock<INotificationService>();
            _mapperMock = new Mock<IMapper>();
            _requestService = new RequestService(_unitOfWorkMoq.Object, _mapperMock.Object, _notificationService.Object);
        }

        [TestMethod]
        public async Task GetAllRequests_OkTest()
        {
            // Arrange
            IEnumerable<RequestEntity> requestEntities = RequestData.GetRequestEntities();
            IEnumerable<RequestReadDTO> requestDTOs = RequestData.GetRequestDTOs().ToList();

            _unitOfWorkMoq.Setup(n => n.RequestRepository.GetAll(CancellationToken.None))
                .ReturnsAsync(requestEntities);

            _mapperMock.Setup(m => m.Map<IEnumerable<RequestReadDTO>>(It.IsAny<IEnumerable<RequestEntity>>())).Returns(requestDTOs);
            // Act
            var result = await _requestService.GetAllRequests(CancellationToken.None);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<RequestReadDTO>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 3);
        }

        [TestMethod]
        public async Task GetRequestById_OkTest()
        {
            // Arrange
            RequestEntity requestEntities = RequestData.GetRequestEntities().FirstOrDefault(n => n.Name == "Broken knee");
            RequestReadDTO requestDTOs = RequestData.GetRequestDTOs().FirstOrDefault(n => n.Name == "Broken knee");

            _unitOfWorkMoq.Setup(n => n.RequestRepository.GetById(It.IsAny<Guid>(), CancellationToken.None))
                .ReturnsAsync(requestEntities);

            _mapperMock.Setup(m => m.Map<RequestReadDTO>(It.IsAny<RequestEntity>())).Returns(requestDTOs);
            // Act
            var result = await _requestService.GetRequest(requestEntities.Id, CancellationToken.None);

            // Assert
            Assert.IsInstanceOfType(result, typeof(RequestReadDTO));
            Assert.IsNotNull(result);
            Assert.AreEqual(requestDTOs, result);
        }

        [TestMethod]
        public async Task AddNewRequest_OkTest()
        {
            // Arrange
            var requestEntities = RequestData.GetRequestEntities();
            var requestDTOs = RequestData.GetRequestDTOs();
            var requestDTO = new RequestCreateDTO()
            { Description = "Test description", Name = "Roman", Status = Core.Constants.Status.Completed };

            var requestEntity = new RequestEntity()
            { Description = requestDTO.Description, Status = requestDTO.Status, Name = requestDTO.Name };


            _unitOfWorkMoq.Setup(n => n.RequestRepository.Create(It.IsAny<RequestEntity>(), CancellationToken.None))
                     .Returns(Task.CompletedTask);


            _mapperMock.Setup(m => m.Map<RequestEntity>(It.IsAny<RequestCreateDTO>())).Returns(requestEntity);
            //// Act
            await _requestService.AddRequest(requestDTO, CancellationToken.None);

            // Assert
            // Assert
            _unitOfWorkMoq
                .Verify(n => n
                .RequestRepository.Create(It.IsAny<RequestEntity>(), CancellationToken.None), Times.Once);
        }
    }
}
