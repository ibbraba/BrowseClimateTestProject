using BrowseClimate.Models;
using BrowseClimate.Repositories.CityRepositories;
using BrowseClimate.Services.CityServices;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowseClimateTestProject.CityServiceTests
{
    public class CityServiceTest
    {
        [Fact]
        public void CreateCity_ThrowsErrorIfInvalidField()
        {

            City city = ValidCity();
            city.Name = "";
            var repo = new Mock<ICityRepository>();
            repo.Setup(x => x.CreateCity(It.IsAny<City>())).Returns(Task.FromResult(default(object)));

            var _sut = new CityService(repo.Object);

            Assert.ThrowsAsync<ArgumentException>(() => _sut.CreateCity(city));


        }

        [Fact]
        public void CreateCity_SuccessfullyCreateCity()
        {

            City city = ValidCity();
            
            var repo = new Mock<ICityRepository>();
            repo.Setup(x => x.CreateCity(It.IsAny<City>())).Returns(Task.FromResult(default(object)));

            var _sut = new CityService(repo.Object);
            var exception = Record.ExceptionAsync(() => _sut.CreateCity(city));

            Assert.Null(exception.Exception);
        
        }


        public City ValidCity()
        {
            City city = new City();
            city.Id = 1;
            city.Country = "France";
            city.Name = "Bordeauw";
            city.Description = "Ville au bord de l'eau"; 
            

            return city;
        }


    }
}
