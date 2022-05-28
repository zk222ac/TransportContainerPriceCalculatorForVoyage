using System;
using Xunit;
using Moq;
using PriceCalculator.API.Repositories;
using PriceCalculator.API.Entities;
using Microsoft.Extensions.Logging;
using PriceCalculator.API.Controllers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;

namespace Container.UnitTest
{
    public class PriceCalculatorControllerUnitTest
    {
        private readonly Mock<IVoyageRepository> repositoryStub = new();
        private readonly Mock<ILogger<PriceCalculatorController>> loggerStub = new();
        private readonly Random ran = new();

        [Fact]
        public async Task GetVoyageCode_WithUnexistingItem_ReturnNotFound()
        {
            // triple AAA Design pattern
            // https://developers.mews.com/aaa-pattern-a-functional-approach/#:~:text=The%20AAA%20pattern%20is%20a,the%20primary%20function%20being%20tested.
           
            // Arrange 
            repositoryStub.Setup(repo => repo.GetVoyageCode(It.IsAny<Guid>().ToString()))
            .ReturnsAsync((Voyage)null);            
            var controller = new PriceCalculatorController(repositoryStub.Object, loggerStub.Object);

            // Act            
            var result = await controller.GetVoyageCode(Guid.NewGuid().ToString());

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);

        }
      

        [Fact]
        public async Task GetVoyageAsync_WithExistingVoyage_ReturnAllVoyages() 
        {
            // Arrange 

            var expectedVoyages = new[] { CreateRandomVoyageItems(), CreateRandomVoyageItems(),CreateRandomVoyageItems() };

            repositoryStub.Setup(repo => repo.GetVoyages()).ReturnsAsync(expectedVoyages);
            var controller = new PriceCalculatorController(repositoryStub.Object, loggerStub.Object);

            // Act
            var actualVoyages = await controller.GetVoyages();

            //Assert
            actualVoyages.Should().BeEquivalentTo(
                expectedVoyages,
                options => options.ComparingByMembers<Voyage>());
        }

        private Voyage CreateRandomVoyageItems() 
        {
            return new()
            {
                Id = 1,
                Container = "Container Name:" + ran.Next(1,1000),
                Price = ran.Next(1000),
                TimeStamp = DateTimeOffset.UtcNow,
                Currency = Currency.US,              
            };       
         
        }


    }
}
