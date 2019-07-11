using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NSubstitute;
using NUnit.Framework;
using PD.Domain;
using PD.Services.Tasks.GetBusinessItems;
using PD.Services.Tasks.GetMemberDetails;
using PD.WebApi.Features.GetMemberDetails;

namespace PD.Tests.Features.GetMemberDetails
{
    public class GetMemberDetailsControllerTests
    {
        [Test]
        public async Task Returns_member_details()
        {
            // arrange
            var stubGetParliamentMemberDetails = Substitute.For<IGetParliamentMemberDetails>();
            var stubParliamentMemberDetailsEndPointSettings = Substitute.For<IOptions<ParliamentMemberDetailsEndPointSettings>>();

            var dummyMemberEndPoint = "dummy member end point";

            stubParliamentMemberDetailsEndPointSettings
                .Value
                .Returns(
                    new ParliamentMemberDetailsEndPointSettings
                    {
                        EndPoint = dummyMemberEndPoint
                    });

            var memberId = 1;

            var dummyParty = "dummy party";
            var dummyMemberFrom = "dummy member from";
            var dummyFullTitle = "dummy full title";

            stubGetParliamentMemberDetails
                .GetGetParliamentMemberDetails(Arg.Is<GetParliamentMemberDetailsRequest>(
                    request =>
                        request.Id == memberId &&
                        request.Url == dummyMemberEndPoint))
                .Returns(GetParliamentMemberDetailsResponse.Success(new MemberDetails
                {
                    Party = dummyParty,
                    FullTitle = dummyFullTitle,
                    MemberFrom = dummyMemberFrom
                }));

            var sut = new GetMemberDetailsController(new GetMemberDetailsService(stubParliamentMemberDetailsEndPointSettings, stubGetParliamentMemberDetails));

            // act
            var result = await sut.GetDetails(memberId);

            // assert
            Assert.That(result, Is.TypeOf<OkObjectResult>());

            var response = (GetMemberDetailsModel)((OkObjectResult)result).Value;

            Assert.That(response.Party, Is.EqualTo(dummyParty));
            Assert.That(response.FullTitle, Is.EqualTo(dummyFullTitle));
            Assert.That(response.MemberFrom, Is.EqualTo(dummyMemberFrom));
        }
    }
}