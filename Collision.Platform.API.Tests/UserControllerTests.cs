using Collision.Platform.API.Controllers;
using Collision.Platform.Domain;
using Collision.Platform.Infrastructure.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NuGet.Frameworks;
using System.Collections.Generic;
using System.Linq;

namespace Collision.Platform.API.Tests
{
    [TestClass]
    public class UserControllerTests
    {
        private UserController _classInTest;
        private readonly Mock<IRepository<User>> _userRepository;

        public UserControllerTests()
        {
            _userRepository = new Mock<IRepository<User>>();
            _classInTest = new UserController(_userRepository.Object);
        }

        [TestMethod]
        public void UserController_Get_Users_ReturnsAllUsers()
        {
            var expectedUsers = new List<User>
            {
                new User {Id = 1, Username = "JohnWick"},
                new User {Id = 2, Username = "JasonBourne"}
            };

            _userRepository.Setup(x => x.All()).Returns(expectedUsers);

            var actualUsers = _classInTest.Get();

            Assert.AreEqual(actualUsers.ToList().Count, 2);
        }

        [TestMethod]
        public void UserController_Get_ExistingUser_ReturnsUserWithId()
        {
            var expectedUser = new User { Id = 10, Username = "JohnWick" };

            _userRepository.Setup(x => x.Get(expectedUser.Id)).Returns(expectedUser);

            var actualUser = _classInTest.Get(expectedUser.Id);

            Assert.AreEqual(actualUser.Id, 10);
        }

        [TestMethod]
        public void UserController_Get_ExistingUser_ReturnsNotFound()
        {

        }

        [TestMethod]
        public void UserController_Post_User_ReturnsAddedUser()
        {

        }

        [TestMethod]
        public void UserController_Post_UsernameExist_ReturnsBadRequest()
        {

        }


        [TestMethod]
        public void UserController_Put_User_ReturnsUpdatedUser()
        {

        }

        [TestMethod]
        public void UserController_Put_Username_Exist_ReturnsBadRequest()
        {

        }

        [TestMethod]
        public void UserController_Delete_User_RemoveUserWithId()
        {

        }

        private void setUpUserRepositoryData()
        {

        }
    }
}
