using System;
using System.Collections.Generic;
using System.Linq;
using PD.Services.Common;

namespace PD.WebApi.Features.GetBusinessItems
{
    public class GetBusinessItemsQuery : ValidationModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public override IEnumerable<string> GetErrors()
        {
            if (EndDate == null)
                AddValidationError("End date is required");

            if (StartDate == null)
                AddValidationError("Start date is required");

            return Errors;
        }
    }
}