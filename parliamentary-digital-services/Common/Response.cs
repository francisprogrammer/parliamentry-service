using System.Collections.Generic;

namespace PD.Services.Common
{
    public abstract class Response
    {
        public bool IsSuccess { get; }
        public IEnumerable<string> ErrorMessageses { get; }

        protected Response(bool isSuccess, IEnumerable<string> errorMessageses)
        {
            IsSuccess = isSuccess;
            ErrorMessageses = errorMessageses;
        }
    }
}