using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using PD.Services.Common;
using PD.Services.Tasks.GetDateAndTime;
using PD.Services.Tasks.GetWeeks;
using PD.WebApi.Features.GetWeeks;

namespace PD.Tests.Features.GetWeeks
{
    public class GetWeeksControllerTests
    {
        private IDateTimeService _stubDatetimeService;
        private IOptions<GetWeekSettings> _stubGetWeeksSettings;

        [SetUp]
        public void Setup()
        {
            _stubGetWeeksSettings = Substitute.For<IOptions<GetWeekSettings>>();
            _stubDatetimeService = Substitute.For<IDateTimeService>();
            
            _stubDatetimeService
                .GetDate()
                .Returns(ParseDate("30/12/2018"));
            
            _stubGetWeeksSettings
                .Value
                .Returns(
                    new GetWeekSettings
                    {
                        NumberOfWeeksToInclude = 0
                    });
        }
        
        [TestCase("01/01/2019", 1, "30/12/2018", "05/01/2019")]
        [TestCase("09/01/2019", 2, "06/01/2019", "12/01/2019")]
        public void Returns_week_for_date(string currentDate, int weekNo, string startDate, string endDate)
        {
            // arrange
            _stubDatetimeService
                .GetDate()
                .Returns(ParseDate(currentDate));
            
            // act
            var sut = new GetWeeksController(new GetWeeksService(_stubDatetimeService, _stubGetWeeksSettings));
            var result = sut.GetWeeks();

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(((OkObjectResult) result).Value, Is.TypeOf<GetWeeksViewModel>());
            
            var response = (GetWeeksViewModel) ((OkObjectResult) result).Value;
            
            Assert.That(response.Weeks.Count(), Is.EqualTo(1), "expected only 1 weeks");
            
            Assert.That(response.Weeks.ElementAt(0).Year, Is.EqualTo(ParseDate(currentDate).Year));
            Assert.That(response.Weeks.ElementAt(0).WeekNo, Is.EqualTo(weekNo), $"expected week to be {weekNo}");
            Assert.That(response.Weeks.ElementAt(0).StartOfWeek.Date, Is.EqualTo(ParseDate(startDate).Date));
            Assert.That(response.Weeks.ElementAt(0).EndOfWeek.Date, Is.EqualTo(ParseDate(endDate).Date));
        }

        [TestCase(1, 2)]
        [TestCase(2, 3)]
        public void Returns_number_of_weeks_to_include_from_settings(int numberOfWeeksToInclude, int expected)
        {
            _stubDatetimeService
                .GetDate()
                .Returns(ParseDate("06/01/2019"));
            
            _stubGetWeeksSettings
                .Value
                .Returns(
                    new GetWeekSettings
                    {
                        NumberOfWeeksToInclude = numberOfWeeksToInclude
                    });
            
            // act
            var sut = new GetWeeksController(new GetWeeksService(_stubDatetimeService, _stubGetWeeksSettings));
            var result = sut.GetWeeks();

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(((OkObjectResult) result).Value, Is.TypeOf<GetWeeksViewModel>());
            
            var response = (GetWeeksViewModel) ((OkObjectResult) result).Value;
            
            Assert.That(response.Weeks.Count(), Is.EqualTo(expected), $"expected only {expected} weeks");
        }

        [Test]
        public void Return_current_week_selected()
        {
            _stubDatetimeService
                .GetDate()
                .Returns(ParseDate("06/01/2019"));
            
            _stubGetWeeksSettings
                .Value
                .Returns(
                    new GetWeekSettings
                    {
                        NumberOfWeeksToInclude = 1
                    });
            
            // act
            var sut = new GetWeeksController(new GetWeeksService(_stubDatetimeService, _stubGetWeeksSettings));
            var result = sut.GetWeeks();

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(((OkObjectResult) result).Value, Is.TypeOf<GetWeeksViewModel>());
            
            var response = (GetWeeksViewModel) ((OkObjectResult) result).Value;
            
            Assert.That(response.Weeks.ElementAt(0).IsCurrentWeek, Is.EqualTo(true), "expected to be current week");
            Assert.That(response.Weeks.ElementAt(0).WeekNo, Is.EqualTo(2), "expected week to be 2");
            Assert.That(response.Weeks.ElementAt(1).IsCurrentWeek, Is.EqualTo(false), "expected to be current week");
            Assert.That(response.Weeks.ElementAt(1).WeekNo, Is.EqualTo(3), "expected week to be 3");
        }

        private DateTime ParseDate(string date)
        {
            return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
    }
}