using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PD.Services.Tasks.GetBusinessItems;

namespace PD.WebApi.Features.GetBusinessItems
{
    public class GetBusinessItemsController : ControllerBase
    {
        private readonly IGetBusinessItemBetweenDates _getBusinessItemBetweenDates;

        public GetBusinessItemsController(IGetBusinessItemBetweenDates getBusinessItemBetweenDates)
        {
            _getBusinessItemBetweenDates = getBusinessItemBetweenDates;
        }

        [HttpGet]
        [Route("events")]
        public async Task<IActionResult> GetBusinessItems([FromQuery] GetBusinessItemsQuery businessItemsQuery)
        {
            if (businessItemsQuery.HasErrors()) return BadRequest(businessItemsQuery.GetErrors());

            var response =
                await _getBusinessItemBetweenDates
                    .GetBusinessItemBetweenDates(new GetBusinessItemBetweenDatesRequest(businessItemsQuery.StartDate.Value,
                        businessItemsQuery.EndDate.Value));

            return !response.IsSuccess
                ? (IActionResult)BadRequest(response.ErrorMessages)
                : Ok(response.BusinessItems);
        }
    }
}