using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PriceCalculator.API.Controllers;
using PriceCalculator.API.Entities;
using PriceCalculator.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace Container.Xunit
{
    // Arrange –  Prepare the scene for testing (creating the objects and setting them up as necessary)
    //Act – this is where the method we are testing is executed
    //Assert – this is the final part of the test where we compare what we expect to happen with the actual result of the test method execution

    public class PriceCalculatorControllerTest
    {
        // In this method we test following criteria
        // Whether the method returns the OkObjectResult which represents 200 HTTP code response
        // Whether returned object contains our list of all Voyages


        [Fact]
        public async Task GetWhenCalledReturnsOkResult()
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

        [Fact]
        public async Task GetWhenCalledReturnsAllVoyages()
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
            var controller = new PriceCalculatorController(dataStore, logger);

            //Act
            var actionResult = await controller.GetVoyages();

            //Assert            
            Assert.IsType<OkObjectResult>(actionResult.Result);
            var list = actionResult.Result as OkObjectResult;
            Assert.IsType<List<Voyage>>(list.Value);
            var listBooks = list.Value as List<Voyage>;
            Assert.Equal(5, listBooks.Count);
        }
        [Fact]
        public void GetByVoyageCodeUnknownVoyageCodePassedReturnsNotFoundResult()
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
            var controller = new PriceCalculatorController(dataStore, logger);
            // Act
            var notFoundResult = controller.GetVoyageCode("DGFJFFJFJ");
            // Assert
            Assert.IsType<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void GetByVoyageCodeExistingVoyageCodePassed_ReturnsOkResult()
        {
            // Arrange
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
            var controller = new PriceCalculatorController(dataStore, logger);
            var voyageCode = "451S";
            // Act
            var okResult = controller.GetVoyageCode(voyageCode);
            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        public void UpdateInvalidObjectPassedReturnsBadRequest()
        {
            // Arrange
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
            var controller = new PriceCalculatorController(dataStore, logger);

            // Arrange
            var nameMissingItem = new Voyage()
            {
                Id = 2,
                Price = 12.00M,
                TimeStamp = System.DateTimeOffset.UtcNow,
                VoyageCode = "SDKDKDDK"
            };


            controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = controller.UpdatePrice(nameMissingItem);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void UpdateValidObjectPassedReturnedResponseHasCreatedItem()
        {
            // Arrange
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
            var controller = new PriceCalculatorController(dataStore, logger);
            // Arrange
            Voyage testItem = new Voyage()
            {
                Id = 2,
                Price = 12.00M,
                TimeStamp = System.DateTimeOffset.UtcNow,
                VoyageCode = "SDKDKDDK"
            };
            // Act
            var createdResponse = controller.UpdatePrice(testItem);
            var item = createdResponse;
            // Assert
            Assert.IsType<Voyage>(item);
            Assert.Equal("Guinness Original 6 Pack", (IEnumerable<char>)item);
        }

        // Here I am using Load Testing 
        // RequestTime Method : Check application response time of the endpoint
        // running on the local https://localhost:5000

        [Fact]
        // The test is failed because machine actively refusing : Method would be works when we deployed in a server

        public void RequestTime()
        {
            DateTime start;
            DateTime end;
            using (var client = new HttpClient())
            {
                start = DateTime.Now;
                var response = client.GetAsync("http://localhost:5000/PriceCalculator/GetVoyages").Result;
                end = DateTime.Now;
            }
            var expected = 1;
            var actual = (int)(end - start).TotalMilliseconds;
            Assert.True(actual <= expected, $"Expected total milliseconds of less than or equal to {expected} but was {actual}.");
        }

        [Fact]
       
        public void AverageResponseTime_100Requests()
        {
            var allResponseTimes = new List<(DateTime Start, DateTime End)>();

            for (var i = 0; i < 100; i++)
            {
                using (var client = new HttpClient())
                {
                    var start = DateTime.Now;
                    var response = client.GetAsync("http://localhost:5000/api/cookbook").Result;
                    var end = DateTime.Now;

                    allResponseTimes.Add((start, end));
                }
            }

            var expected = 1;
            var actual = (int)allResponseTimes.Select(r => (r.End - r.Start).TotalMilliseconds).Average();
            Assert.True(actual <= expected, $"Expected average response time of less than or equal to {expected} ms but was {actual} ms.");
        }

        [Fact]
        public void AverageResponseTime_1000Requests()
        {
            var allResponseTimes = new List<(DateTime Start, DateTime End)>();

            for (var i = 0; i < 1000; i++)
            {
                using (var client = new HttpClient())
                {
                    var start = DateTime.Now;
                    var response = client.GetAsync("http://localhost:5000/api/cookbook").Result;
                    var end = DateTime.Now;

                    allResponseTimes.Add((start, end));
                }
            }

            var expected = 1;
            var actual = (int)allResponseTimes.Select(r => (r.End - r.Start).TotalMilliseconds).Average();
            Assert.True(actual <= expected, $"Expected average response time of less than or equal to {expected} ms but was {actual} ms.");
        }



    }
}
