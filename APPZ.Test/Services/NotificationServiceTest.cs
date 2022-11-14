using APPZ.Core;
using APPZ.Core.Entities;
using APPZ.Core.Exceptions;
using APPZ.Core.Interfaces;
using APPZ.Infrastructure.Implementations;
using APPZ.Infrastructure.Strategies;
using APPZ.Test.MockData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Configuration;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Test.Services
{
    [TestClass]
    public class NotificationServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMoq;
        private readonly INotificationService _notificationService;

        public NotificationServiceTest()
        {
            _unitOfWorkMoq = new Mock<IUnitOfWork>();
            _notificationService = new NotificationService(_unitOfWorkMoq.Object);
        }

        [TestMethod]
        public async Task GetAllNotifications_OkTest()
        {
            // Arrange
            IEnumerable<NotificationEntity> notificationEntities = NotificationData.GetNotificationData();

            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetAll(CancellationToken.None))
                .ReturnsAsync(notificationEntities);

            // Act
            var result = await _notificationService.GetNotifications(CancellationToken.None);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<NotificationEntity>));
            Assert.IsNotNull(result);
            Assert.IsTrue(Enumerable.SequenceEqual(notificationEntities, result));
        }

        [TestMethod]
        public async Task GetNotificationById_OkTest()
        {
            // Arrange
            NotificationEntity notificationEntity =
                NotificationData.GetNotificationData().FirstOrDefault(x => x.Name.Contains("Bohdan Hmelnickij"));

            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetById(notificationEntity.Id, CancellationToken.None))
                .ReturnsAsync(notificationEntity);

            // Act
            var result = await _notificationService.GetNotification(notificationEntity.Id, CancellationToken.None);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotificationEntity));
            Assert.IsNotNull(result);
            Assert.AreEqual(notificationEntity.Id, result.Id);
            Assert.AreEqual(notificationEntity.Name, result.Name);
        }

        [TestMethod]
        public async Task GetNotificationByNotExistingId_NotFoundTest()
        {
            // Arrange
            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetById(It.IsAny<Guid>(), CancellationToken.None)).Throws(new HttpCodeException(HttpStatusCode.NotFound));
            // Act
            await Assert.ThrowsExceptionAsync<HttpCodeException>(() => _notificationService.GetNotification(Guid.NewGuid(), CancellationToken.None));
        }

        [TestMethod]
        public async Task NotificateByMail_OkTest()
        {
            // Arrange
            Mock<MailNotifier> mailNotifierMoq = new Mock<MailNotifier>();
            mailNotifierMoq
                .Setup(x => x.SendNotification
                (It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None)).Returns(Task.CompletedTask);

            _notificationService.Strategy = mailNotifierMoq.Object;

            // Act
            await _notificationService.NotificateOrganisation(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None);

            // Assert
            mailNotifierMoq
                .Verify(n => n
                .SendNotification(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task NotificateBySlack_OkTest()
        {
            // Arrange
            Mock<SlackNotifier> slackNotifier = new Mock<SlackNotifier>();
            slackNotifier
                .Setup(x => x.SendNotification
                (It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None)).Returns(Task.CompletedTask);

            _notificationService.Strategy = slackNotifier.Object;

            // Act
            await _notificationService.NotificateOrganisation(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None);

            // Assert
            slackNotifier
                .Verify(n => n
                .SendNotification(It.IsAny<OrganisationDetails>(), It.IsAny<string>(), CancellationToken.None), Times.Once);
        }

        [TestMethod]
        public async Task NotificationsForUser_OkTest()
        {
            // Arrange
            var notificationEntity = NotificationData.GetNotificationData();
            var userEntity = NotificationData.userEntity;

            await Assert.ThrowsExceptionAsync<NullReferenceException>(() => _notificationService.GetNotificationsForUser(It.IsAny<Guid>(), CancellationToken.None));
        }


        [TestMethod]
        public async Task GetEmptyNotifications_OkTest()
        {
            // Arrange
            IEnumerable<NotificationEntity> notificationEntities = new List<NotificationEntity>();

            _unitOfWorkMoq.Setup(n => n.NotifcationsRepository.GetAll(CancellationToken.None))
                .ReturnsAsync(notificationEntities);

            // Act
            var result = await _notificationService.GetNotifications(CancellationToken.None);

            // Assert
            Assert.IsInstanceOfType(result, typeof(IEnumerable<NotificationEntity>));
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count() == 0);
        }
    }
}
