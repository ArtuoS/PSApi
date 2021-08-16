using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using PremierAPI.Models;
using PremierAPI.Models.Interfaces;
using PremierAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PremierAPI.Tests
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly IUtilities _utilities;
        public UserRepositoryTests()
        {
            _utilities = new Utilities();
        }

        [TestMethod]
        public void GetAll_CallingMethod_ReturnUsers()
        {
            // Arrange
            var helperMock = new Mock<IHelper>();
            helperMock.Setup(x => x.ReponseReaderAsString(It.IsAny<HttpClient>(), It.IsAny<string>()))
                .Returns(JsonConvert.SerializeObject(usersInMemory));

            var userRepository = new UserRepository(helperMock.Object, _utilities);

            // Act
            var users = userRepository.GetAll();

            // Assert
            Assert.IsTrue(users.Any());
        }

        [TestMethod]
        public void GetById_GivenValidId_ReturnUser()
        {
            // Arrange
            int id = 1;
            var helperMock = new Mock<IHelper>();
            helperMock.Setup(x => x.ReponseReaderAsString(It.IsAny<HttpClient>(), It.IsAny<string>()))
                .Returns(JsonConvert.SerializeObject(usersInMemory.FirstOrDefault(u => u.id == id.MyToString())));

            var userRepository = new UserRepository(helperMock.Object, _utilities);

            // Act
            var user = userRepository.GetById(id);

            // Assert
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void Create_GivenValidInstanceOfObject_CreateUser()
        {
            // Arrange
            var userInstance = new User()
            {
                id = "4",
                nome = "Guilherme",
                criadoEm = DateTime.Now
            };

            usersInMemory.Add(userInstance);
            var helperMock = new Mock<IHelper>();
            helperMock.Setup(x => x.ReponseReaderAsString(It.IsAny<HttpClient>(), It.IsAny<string>()))
                .Returns(JsonConvert.SerializeObject(usersInMemory));

            helperMock.Setup(x => x.ReponseCreateAsString(It.IsAny<HttpClient>(),
                                                          It.IsAny<string>(),
                                                          JsonConvert.SerializeObject(userInstance)))
                .Returns(JsonConvert.SerializeObject(userInstance));

            var userRepository = new UserRepository(helperMock.Object, _utilities);

            // Act
            userRepository.Create(userInstance);

            // Assert
            Assert.IsTrue(usersInMemory.Contains(userInstance));
        }

        [TestMethod]
        public void Update_GivenValidInstanceOfObject_UpdateUser()
        {
            // Arrange
            var userInstance = new User()
            {
                id = "1",
                nome = "Arthur Molinari",
                criadoEm = DateTime.Now
            };

            usersInMemory.Where(u => u.id == userInstance.id)
                         .ToList()
                         .ForEach(x => x.nome = userInstance.nome);

            var helperMock = new Mock<IHelper>();
            helperMock.Setup(x => x.ReponseUpdateAsString(It.IsAny<HttpClient>(),
                                                          It.IsAny<string>(),
                                                          JsonConvert.SerializeObject(userInstance)))
                .Returns(JsonConvert.SerializeObject(userInstance));

            var userRepository = new UserRepository(helperMock.Object, _utilities);

            // Act
            userRepository.Update(userInstance);

            // Assert
            Assert.IsTrue(usersInMemory.Any(u => u.nome == userInstance.nome));
        }

        readonly List<User> usersInMemory = UserGenerator();

        private static List<User> UserGenerator()
        {
            return new List<User>()
            {
                new User()
                {
                    id = "1",
                    nome = "Arthur",
                    criadoEm = DateTime.Now
                },
                new User()
                {
                    id = "2",
                    nome = "Joana",
                    criadoEm = DateTime.Now
                },
                new User()
                {
                    id = "3",
                    nome = "André",
                    criadoEm = DateTime.Now
                }
            };
        }
    }
}
