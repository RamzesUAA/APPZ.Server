using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using APPZ.Infrastructure.Implementations;
using APPZ.Infrastructure.Strategies;
using APPZ.Test.MockData;
using APPZ.Test.Utilities;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Test.Services
{
    [TestClass]
    public class NotificationServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMoq;
        private readonly Mock<IConfiguration> _configuration;
        private readonly INotificationService _notificationService;

        public NotificationServiceTest()
        {
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            _configuration = new Mock<IConfiguration>();
            _notificationService = new NotificationService(_unitOfWorkMoq.Object, _configuration.Object);
        }

        [TestMethod]
        public async Task GetAllNotifications_OkTest()
        {
            // Arrange
            IEnumerable<NotificationEntity> notificationEntities = NotificationData.GetNotificationData();

            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetAll(CancellationToken.None))
                .ReturnsAsync(notificationEntities);

            // Act
            var result = await _notificationService.GetNotifications();

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<NotificationEntity>));
            Assert.IsNotNull(result);
            Assert.IsTrue(Enumerable.SequenceEqual(notificationEntities, result));
        }

        [TestMethod]
        public async Task GetAllNotificationById_OkTest()
        {
            // Arrange
            NotificationEntity notificationEntity =
                NotificationData.GetNotificationData().FirstOrDefault(x => x.Name.Contains("Bohdan Hmelnickij"));

            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetById(notificationEntity.Id, CancellationToken.None))
                .ReturnsAsync(notificationEntity);

            // Act
            var result = await _notificationService.GetNotification(notificationEntity.Id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotificationEntity));
            Assert.IsNotNull(result);
            Assert.AreEqual(notificationEntity.Id, result.Id);
            Assert.AreEqual(notificationEntity.Name, result.Name);
        }

        [TestMethod]
        public async Task NotificateByMail_OkTest()
        {
            // Arrange
            Mock<MailNotifier> mailNotifierMoq = new Mock<MailNotifier>();
            mailNotifierMoq
                .Setup(x => x.SendNotification
                (It.IsAny<OrganisationDetails>(), It.IsAny<string>(), _configuration.Object, CancellationToken.None)).Returns(Task.CompletedTask);

            _notificationService.Strategy = mailNotifierMoq.Object;

            // Act
            await _notificationService.NotificateOrganisation(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None);

            // Assert
            mailNotifierMoq
                .Verify(n => n
                .SendNotification(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), _configuration.Object, CancellationToken.None), Times.Once);
        }
    }
}
