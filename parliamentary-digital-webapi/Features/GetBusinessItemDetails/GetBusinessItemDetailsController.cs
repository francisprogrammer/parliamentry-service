using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PD.Services.Tasks.GetBusinessItemDetails;

namespace PD.WebApi.Features.GetBusinessItemDetails
{
    public class GetBusinessItemDetailsController : ControllerBase
    {
        private readonly IGetBusinessItemDetails _getBusinessItemDetails;

        public GetBusinessItemDetailsController(IGetBusinessItemDetails getBusinessItemDetails)
        {
            _getBusinessItemDetails = getBusinessItemDetails;
        }

        [HttpGet]
        [Route("events/{id}")]
        public async Task<IActionResult> GetDetails(int id, [FromQuery] GetBusinessItemDetailsQuery getBusinessItemDetailsQuery)
        {
            if (getBusinessItemDetailsQuery.GetErrors().Any()) return BadRequest(getBusinessItemDetailsQuery.GetErrors());

            var response =
                await _getBusinessItemDetails
                    .GetBusinessItemDetails(new GetBusinessItemDetailsRequest(id, getBusinessItemDetailsQuery.StartDate.Value,
                        getBusinessItemDetailsQuery.EndDate.Value));

            return !response.IsSuccess
                ? (IActionResult)BadRequest(response.ErrorMessageses)
                : Ok(response.BusinessItemDetailsModel);
        }
    }
}