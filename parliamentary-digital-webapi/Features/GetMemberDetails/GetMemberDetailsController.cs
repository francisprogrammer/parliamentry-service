using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PD.Services.Tasks.GetMemberDetails;

namespace PD.WebApi.Features.GetMemberDetails
{
    public class GetMemberDetailsController : ControllerBase
    {
        private readonly IGetMemberDetails _getMemberDetails;

        public GetMemberDetailsController(IGetMemberDetails getMemberDetails)
        {
            _getMemberDetails = getMemberDetails;
        }

        [HttpGet]
        [Route("members/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var response = await _getMemberDetails.GetMemberDetails(new GetMemberDetailsRequest(id));
            return Ok(response.GetMemberDetailsModel);
        }
    }
}
