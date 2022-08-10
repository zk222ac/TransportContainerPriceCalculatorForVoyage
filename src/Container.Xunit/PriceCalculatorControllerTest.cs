using Container.Xunit.Fake_Repository;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
//using Microsoft.AspNetCore.Mvc;
using PriceCalculator.API.Controllers;
using PriceCalculator.API.Entities;
using PriceCalculator.API.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Container.Xunit
{
    // Arrange –  Prepare the scene for testing (creating the objects and setting them up as necessary)
    //Act – this is where the method we are testing is executed
    //Assert – this is the final part of the test where we compare what we expect to happen with the actual result of the test method execution

    public class PriceCalculatorControllerTest
    {
        //private readonly PriceCalculatorController _controller;
        //private readonly IVoyageRepository _service;
        //private readonly ILogger<PriceCalculatorController> _logger;


        //public PriceCalculatorControllerTest()
        //{
        //    _service = new VoyageRepository();
        //    _controller = new PriceCalculatorController(_service);
        //}

        // [Fact]

        // In this method we test following criteria
        // Whether the method returns the OkObjectResult which represents 200 HTTP code response
        // Whether returned object contains our list of all Voyages
        //public async Task GetWhenCalledReturnsOkResult()
        //{
        //    // Act
        //    var okResult =  await _controller.GetVoyages();
        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult.Result);
        //}

        //[Fact]
        //public void GetWhenCalledReturnsAllItems()
        //{
        //    // Act
        //    var okResult = _controller.GetVoyages();
        //    // Assert
        //    var items = Assert.IsType<List<Voyage>>(okResult);
        //    Assert.Equal(4, items.Count);
        //}
        //[Fact]
        //public void GetByVoyageCodeUnknownVoyageCodePassedReturnsNotFoundResult()
        //{
        //    // Act
        //    var notFoundResult = _controller.GetVoyageCode("DGFJFFJFJ");
        //    // Assert
        //    Assert.IsType<NotFoundResult>(notFoundResult);
        //}
        //[Fact]
        //public void GetById_ExistingGuidPassed_ReturnsOkResult()
        //{
        //    // Arrange
        //    var voyageCode = "451S";
        //    // Act
        //    var okResult = _controller.GetVoyageCode(voyageCode);
        //    // Assert
        //    Assert.IsType<OkObjectResult>(okResult);
        //}
        //[Fact]
        //public void UpdateInvalidObjectPassedReturnsBadRequest()
        //{
        //    // Arrange
        //    var nameMissingItem = new Voyage()
        //    {
        //        Id = 2,
        //        Price = 12.00M,
        //        TimeStamp = System.DateTimeOffset.UtcNow,
        //        VoyageCode = "SDKDKDDK"                
        //    };
        //    _controller.ModelState.AddModelError("Name", "Required");
        //    // Act
        //    var badResponse = _controller.UpdatePrice(nameMissingItem);
        //    // Assert
        //    Assert.IsType<BadRequestObjectResult>(badResponse);
        //}
        //[Fact]
        //public void UpdateValidObjectPassedReturnsCreatedResponse()
        //{
        //    // Arrange
        //    Voyage testItem = new Voyage()
        //    {
        //        Id = 2,
        //        Price = 12.00M,
        //        TimeStamp = System.DateTimeOffset.UtcNow,
        //        VoyageCode = "SDKDKDDK"
        //    };
        //    // Act
        //    var createdResponse = _controller.UpdatePrice(testItem);
        //    // Assert
        //    Assert.IsType<CreatedAtActionResult>(createdResponse);
        //}

        //[Fact]  
        //public void UpdateValidObjectPassedReturnedResponseHasCreatedItem()
        //{
        //    // Arrange
        //    Voyage testItem = new Voyage()
        //    {
        //        Id = 2,
        //        Price = 12.00M,
        //        TimeStamp = System.DateTimeOffset.UtcNow,
        //        VoyageCode = "SDKDKDDK"
        //    };
        //    // Act
        //    var createdResponse = _controller.UpdatePrice(testItem);
        //    var item = createdResponse;
        //    // Assert
        //    Assert.IsType<Voyage>(item);
        //    Assert.Equal("Guinness Original 6 Pack", (IEnumerable<char>)item);
        //}



        // In this method we test following criteria
        // Whether the method returns the OkObjectResult which represents 200 HTTP code response
        // Whether returned object contains our list of all Voyages


        [Fact]
        public async Task Get_Return_All_Voyages()
        {
            // fake Logger mock 
            var logger = Mock.Of<ILogger<PriceCalculatorController>>();          
            // I I use the 3A Pattern ( Arrange-Act-Assert) 
            // Arrange 
            // I add FakeitEasy DLL for adding fake IVoyage repository 
            // as our PriceCalculator Controller accept as a IVoyageRepository interface object "datasource"
            int count = 5;
            var dataStore = A.Fake<IVoyageRepository>();
            //var logger = A.Fake<ILogger>(PriceCalculatorController); 
            var fakeInventories = A.CollectionOfDummy<Voyage>(count).AsEnumerable();
            A.CallTo(() => dataStore.GetVoyages()).Returns(Task.FromResult(fakeInventories));
            var controller = new PriceCalculatorController(dataStore , logger);

            //Act
            var actionResult = await controller.GetVoyages();

            //Assert            
            Assert.IsType<OkObjectResult>(actionResult.Result);            
        }
    }
}
