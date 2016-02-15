using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using PhoneList.Models.IdentityModels;
using PhoneList.Services;
using PhoneList.Repository;
using PhoneList.Models.ViewModels;
using System.Web.Mvc;
using PhoneList.Models.DataModel;

namespace PhoneList.Tests
{
    [TestFixture]
    class UserServiceTests
    {
        private Mock<EntityRepository> _personRepository;
        private UserService _service;

        public UserServiceTests()
        {
            _personRepository = new Mock<EntityRepository>();
            _service = new UserService(_personRepository.Object);
        }

        [Test]
        public void GetAllUsers()
        {
            var testList = new List<DataUser>();
            testList.Add(new DataUser { Id = 1, FirstName = "Anton", LastName = "Reznyk", Age = 25 });

            //Arrange
            _personRepository.Setup(p => p.GetAll()).Returns(testList);

            //Act
            List<UserViewModel> actual = _service.GetAllUsers() as List<UserViewModel>;

            //Assert           
            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count);
        }
    }
}
