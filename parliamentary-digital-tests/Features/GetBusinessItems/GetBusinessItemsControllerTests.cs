using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using PD.Domain;
using PD.Services.Common;
using PD.Services.Tasks.GetBusinessItems;
using PD.WebApi.Features.GetBusinessItems;

namespace PD.Tests.Features.GetBusinessItems
{
    public class GetBusinessItemsControllerTests
    {
        private IGetParliamentEvents _stubGetParliamentEvents;
        private IOptions<ParliamentEventsEndPointSettings> _stubParliamentEventsEndPointSettings;
        private GetBusinessItemsController _sut;
        private string _dummyEventEndPoint;

        [SetUp]
        public void Setup()
        {
            _stubGetParliamentEvents = Substitute.For<IGetParliamentEvents>();
            _stubParliamentEventsEndPointSettings = Substitute.For<IOptions<ParliamentEventsEndPointSettings>>();
            
            _dummyEventEndPoint = "dummy event end point";
            
            _stubParliamentEventsEndPointSettings
                .Value
                .Returns(
                    new ParliamentEventsEndPointSettings
                    {
                        EndPoint = _dummyEventEndPoint
                    });
            
            _sut = new GetBusinessItemsController(new GetBusinessItemsService(_stubParliamentEventsEndPointSettings, _stubGetParliamentEvents));
        }
        
        [Test]
        public async Task Returns_business_items_between_dates()
        {
            // arrange
            var startDateAndTime = new DateTime(2019, 1, 1, 10, 0, 0);
            var endDateAndTime = new DateTime(2019, 1, 1, 12, 0, 0);
            var dummyBusinessItemDescription = "any dummy business item description";
            
            var events =
                new List<Event>
                {
                    new Event(startDateAndTime, endDateAndTime, dummyBusinessItemDescription)
                };
            
            var startDate = new DateTime(2019, 1, 1);
            var endDate = new DateTime(2019, 2, 1);

            _stubGetParliamentEvents
                .GetEvents(Arg.Is<GetParliamentEventsRequest>(request => 
                    request.EndDate == endDate &&
                    request.StartDate == startDate &&
                    request.Url == _dummyEventEndPoint))
                .Returns(new GetParliamentEventResponse(true, events));

            // act
            var result =
                await _sut.GetBusinessItems(
                    new GetBusinessItemsQuery
                    {
                        StartDate = startDate,
                        EndDate = endDate
                    });
            
            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            
            var response = (IEnumerable<BusinessItemModel>) ((OkObjectResult) result).Value;
            
            Assert.That(response.ElementAt(0).StartDateAndTime, Is.EqualTo(startDateAndTime));
            Assert.That(response.ElementAt(0).EndDateAndTime, Is.EqualTo(endDateAndTime));
            Assert.That(response.ElementAt(0).Description, Is.EqualTo(dummyBusinessItemDescription));
        }

        [Test]
        public async Task Return_bad_request_when_start_date_is_missing()
        {
            // act
            var result =
                await _sut.GetBusinessItems(
                    new GetBusinessItemsQuery
                    {
                        EndDate = new DateTime(2019,1,1)
                    });
            
            // assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            
            var response = (IEnumerable<string>) ((BadRequestObjectResult) result).Value;
            
            Assert.That(response.Any, Is.EqualTo(true), "expected validation errors");
            Assert.That(response.ElementAt(0), Is.EqualTo("Start date is required"));
        }
        
        [Test]
        public async Task Return_bad_request_when_end_date_is_missing()
        {
            // act
            var result =
                await _sut.GetBusinessItems(
                    new GetBusinessItemsQuery
                    {
                        StartDate = new DateTime(2019,1,1)
                    });
            
            // assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            
            var response = (IEnumerable<string>) ((BadRequestObjectResult) result).Value;
            
            Assert.That(response.Any, Is.EqualTo(true), "expected validation errors");
            Assert.That(response.ElementAt(0), Is.EqualTo("End date is required"));
        }
    }
}