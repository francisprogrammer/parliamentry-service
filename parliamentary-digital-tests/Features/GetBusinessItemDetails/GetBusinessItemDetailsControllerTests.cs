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
using PD.Services.Tasks.GetBusinessItemDetails;
using PD.Services.Tasks.GetBusinessItems;
using PD.WebApi.Features.GetBusinessItemDetails;

namespace PD.Tests.Features.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsControllerTests
    {
        private IGetParliamentEventDetails _stubGetParliamentEventDetails;
        private IOptions<GetParliamentEventDetailsSettings> _stubGetParliamentEventDetailsSettings;
        private string _dummyEventDetailsEndpoint;
        private DateTime _startDate;
        private DateTime _endDate;
        private int _eventId;

        [SetUp]
        public void Setup()
        {
            _stubGetParliamentEventDetails = Substitute.For<IGetParliamentEventDetails>();
            _stubGetParliamentEventDetailsSettings = Substitute.For<IOptions<GetParliamentEventDetailsSettings>>();
            
            _dummyEventDetailsEndpoint = "dummy event details endpoint";
            
            _eventId = 1;
            
            _stubGetParliamentEventDetailsSettings
                .Value
                .Returns(
                    new GetParliamentEventDetailsSettings
                    {
                        EndPoint = _dummyEventDetailsEndpoint
                    });
            
            _startDate = new DateTime(2019, 1, 1);
            _endDate = new DateTime(2019, 2, 1);
        }
        
        [Test]
        public async Task Return_business_item_details()
        {
            // arrange
            
            
            var dummyDescription = "dummy description";
            var dummyCategory = "dummy category";

            var memberId = 1;
            var dummyMemberName = "dummy member name";
            
            var members =
                new List<MemberItem>
                {
                    new MemberItem(memberId, dummyMemberName)
                };

            var startDateAndTime = new DateTime(2019, 1, 1, 10, 0, 0);
            var endDateAndTime = new DateTime(2019, 1, 1, 12, 0, 0);
            
            var model = new BusinessItemDetails(startDateAndTime, endDateAndTime, dummyDescription, dummyCategory, members);
            
            _stubGetParliamentEventDetails
                .GetParliamentEventDetails(
                    Arg.Is<GetParliamentEventDetailsRequest>(request =>
                        request.Url == _dummyEventDetailsEndpoint &&
                        request.StartDate == _startDate &&
                        request.EndDate == _endDate &&
                        request.Id == _eventId))
                .Returns(new GetParliamentEventDetailsResponse(model));
            
            var sut = new GetBusinessItemDetailsController(new GetBusinessItemDetailsService(_stubGetParliamentEventDetailsSettings, _stubGetParliamentEventDetails));

            // act
            var result = 
                await sut.GetDetails(
                    _eventId, 
                    new GetBusinessItemDetailsQuery
                    {
                        EndDate = _endDate,
                        StartDate = _startDate
                    });

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var response = (BusinessItemDetailsModel) ((OkObjectResult) result).Value;
            
            Assert.That(response.StartDateAndTime, Is.EqualTo(startDateAndTime));
            Assert.That(response.EndDateAndTime, Is.EqualTo(endDateAndTime));
            Assert.That(response.Description, Is.EqualTo(dummyDescription));
            Assert.That(response.Category, Is.EqualTo(dummyCategory));
            Assert.That(response.Members.ElementAt(0).Id, Is.EqualTo(memberId));
            Assert.That(response.Members.ElementAt(0).Name, Is.EqualTo(dummyMemberName));
        }
        
        [Test]
        public async Task Return_bad_request_when_start_date_is_missing()
        {
            // arrange
            var sut = new GetBusinessItemDetailsController(new GetBusinessItemDetailsService(_stubGetParliamentEventDetailsSettings, _stubGetParliamentEventDetails));
            
            // act
            var result = 
                await sut.GetDetails(
                    _eventId, 
                    new GetBusinessItemDetailsQuery
                    {
                        EndDate = _endDate
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
            // arrange
            var sut = new GetBusinessItemDetailsController(new GetBusinessItemDetailsService(_stubGetParliamentEventDetailsSettings, _stubGetParliamentEventDetails));
            
            // act
            var result = 
                await sut.GetDetails(
                    _eventId, 
                    new GetBusinessItemDetailsQuery
                    {
                        StartDate = _startDate
                    });

            // assert
            Assert.That(result, Is.TypeOf<BadRequestObjectResult>());
            
            var response = (IEnumerable<string>) ((BadRequestObjectResult) result).Value;
            
            Assert.That(response.Any, Is.EqualTo(true), "expected validation errors");
            Assert.That(response.ElementAt(0), Is.EqualTo("End date is required"));
        }
    }
}