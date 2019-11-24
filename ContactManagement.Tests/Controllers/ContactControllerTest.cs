using BusinessAccessLayer;
using ContactManagement.Controllers;
using DataAccessLayer.Repository;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Web.Mvc;
using Assert = NUnit.Framework.Assert;

namespace ContactManagement.Tests.Controllers
{
    [TestFixture]
    public class ContactControllerTest
    {
        private ContactController contactController;
        private Mock<IContactRepository> repository;

        [SetUp]
        public void TestSetUp()
        {
            repository = new Mock<IContactRepository>();
            contactController = new ContactController(repository.Object);
        }

        [Test]
        public void GetAllContacts()
        {
            // Arrange
            repository.Setup(s => s.GetAllContacts()).Returns(new List<ContactEntity>
            {
                new ContactEntity
                {
                    ContactId = 1, FirstName = "Name1", LastName = "Name2", Email = "Name1@gmail.com",
                    PhoneNumber = "+917339394", Status = true
                },
                new ContactEntity
                {
                ContactId = 1, FirstName = "Name2", LastName = "Name3", Email = "Name2@gmail.com",
                PhoneNumber = "+91733939443", Status = true
            }
            });

            // Act
            var result = contactController.GetAllContacts() as ViewResult;
            var contacts = result.Model as List<ContactEntity>;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(contacts.Count, Is.EqualTo(2));
        }

        [Test]
        public void GetDetails()
        {
            // Arrange
            repository.Setup(s => s.GetDetail(It.Is<int>(x => x == 1))).Returns(
                new ContactEntity
                {
                    ContactId = 1,
                    FirstName = "Name1",
                    LastName = "Name2",
                    Email = "Name1@gmail.com",
                    PhoneNumber = "+917339394",
                    Status = true
                });

            // Act
            ViewResult result = contactController.GetDetails(1) as ViewResult;
            var contact = result.Model as ContactEntity;

            // Assert
            Assert.IsNotNull(result);
            Assert.That(contact.ContactId, Is.EqualTo(1));
        }

        [Test]
        public void CreateContact()
        {
            // Arrange
            var contact = new ContactEntity
            {
                ContactId = 3,
                FirstName = "Joe",
                LastName = "J",
                Email = "J.J@yahoo.com",
                PhoneNumber = "+91743948458439",
                Status = true
            };

            repository.Setup(s => s.AddContact(contact));
            // Act
            var result = contactController.CreateContact(contact) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void UpdateContact()
        {
            // Arrange
            var contact = new ContactEntity
            {
                ContactId = 3,
                FirstName = "Joe",
                LastName = "J",
                Email = "J.J@yahoo.com",
                PhoneNumber = "+91743948458439",
                Status = true
            };

            repository.Setup(s => s.UpdateContact(3, contact));
            // Act
            var result = contactController.EditContact(3, contact) as RedirectToRouteResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void DeleteContact()
        {
            // Arrange

            repository.Setup(s => s.RemoveContact(3));
            // Act
            var result = contactController.EditContact(3) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}

