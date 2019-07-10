using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using PD.WebApi.Common;
using PD.WebApi.Features.GetWeeks;

namespace PD.Tests.Features.GetWeeks
{
    public class GetWeeksControllerTests
    {
        [Test]
        public async Task Returns_weeks_for_year()
        {
            // arrange
            var stubGetWeeksSettings = Substitute.For<IOptions<GetWeekSettings>>();
            var stubDatetimeService = Substitute.For<IDateTimeService>();

            stubDatetimeService
                .GetDate()
                .Returns(new DateTime(2019, 1, 1));
            
            stubGetWeeksSettings
                .Value
                .Returns(
                    new GetWeekSettings
                    {
                        NumberOfWeeksToInclude = 1
                    });
            
            var sut = new GetWeeksController(stubDatetimeService, stubGetWeeksSettings);
            
            // act
            var result = await sut.GetWeeks();

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());
            Assert.That(((OkObjectResult) result).Value, Is.TypeOf<GetWeeksViewModel>());
            
            var response = (GetWeeksViewModel) ((OkObjectResult) result).Value;
            
            Assert.That(response.Weeks.Count(), Is.EqualTo(1), "expected only 1 weeks");
            
            Assert.That(response.Weeks.ElementAt(0).Year, Is.EqualTo(2019));
            Assert.That(response.Weeks.ElementAt(0).WeekNo, Is.EqualTo(1), "expected week to be 1");
            Assert.That(response.Weeks.ElementAt(0).StartOfWeek.Date, Is.EqualTo(new DateTime(2019, 1, 1).Date));
            Assert.That(response.Weeks.ElementAt(0).EndOfWeek.Date, Is.EqualTo(new DateTime(2019, 1, 7).Date));
        }
    }
}