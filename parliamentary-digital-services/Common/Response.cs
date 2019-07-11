using System.Collections.Generic;

namespace PD.Services.Common
{
    public abstract class Response
    {
        public bool IsSuccess { get; }
        public IEnumerable<string> ErrorMessages { get; }

        protected Response(bool isSuccess, IEnumerable<string> errorMessages)
        {
            IsSuccess = isSuccess;
            ErrorMessages = errorMessages;
        }
    }
}