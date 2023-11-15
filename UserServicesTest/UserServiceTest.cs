using BrowseClimate.Models;
using BrowseClimate.Repositories.UserRepositories;
using BrowseClimate.Services.UserServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseClimateTestProject.UserServicesTest
{
    
    public class UserServiceTest
    {

        [Fact]
        public void CreateUser_ThrowsErrorIfInvalidPseudo()
        {

            User user = new User
            {
                Id = 3,
                Name = "Test",
                FirstName = "User",
                Email = "testuser@mail.com",
                Pseudo = "JohnDoe",
                Password = "passwordlong",
                Role = "User"

            };
            var repo = new Mock<IUserRepository>();



            repo.Setup(x => x.CreateUser(It.IsAny<User>())).Returns(Task.FromResult(default(object)));
            repo.Setup(x => x.GetAll()).Returns(Task.FromResult(GetUsers()));
            var _sut = new UserService(repo.Object);



            Assert.ThrowsAsync<ArgumentException>(() => _sut.CreateUser(user));


        }

        [Fact]
        public void CreateUser_ThrowsErrorIfInvalidPassword()
        {

            User user = new User
            {
                Id = 3,
                Name = "Test",
                FirstName = "User",
                Email = "testuser@mail.com",
                Pseudo = "NouveaauPseudo",
                Password = "mdp",
                Role = "User"

            };
            var repo = new Mock<IUserRepository>();



            repo.Setup(x => x.CreateUser(It.IsAny<User>())).Returns(Task.FromResult(default(object)));
            repo.Setup(x => x.GetAll()).Returns(Task.FromResult(GetUsers()));
            var _sut = new UserService(repo.Object);

            Assert.ThrowsAsync<ArgumentException>(() => _sut.CreateUser(user));

        }


        [Fact]
        public void CreateUser_SuccessfullyCreateUser()
        {

            User user = new User
            {
                Id = 3,
                Name = "Test",
                FirstName = "User",
                Email = "testuser@mail.com",
                Pseudo = "Testuser",
                Password = "passwordlong",
                Role = "User"

            };
            var repo = new Mock<IUserRepository>();

            

            repo.Setup(x => x.CreateUser(It.IsAny<User>())).Returns(Task.FromResult(default(object)));
            repo.Setup(x => x.GetAll()).Returns(Task.FromResult(GetUsers())); 
            var _sut = new UserService(repo.Object);

            var exception = Record.ExceptionAsync(() => _sut.CreateUser(user));


            Assert.Null(exception.Exception);



        }


        public List<User> GetUsers()
        {
            List<User> users = new();
            users.Add(ValidUser());
            users.Add(ValidUser2());


            return users;
        }


        public User ValidUser()
        {

            User user = new User
            {
                Id = 1,
                Name = "Ibra",
                FirstName = "Ba",
                Email = "valid@mail.com",
                Pseudo = "Ibra",
                Password = "pass",
                Role = "User"

            };

            return user; 


        }


        public User ValidUser2()
        {

            User user = new User
            {
                Id = 2,
                Name = "John",
                FirstName = "Doe",
                Email = "jdoe@mail.com",
                Pseudo = "JohnDoe",
                Password = "pass",
                Role = "User"

            };

            return user;


        }
    }
}
