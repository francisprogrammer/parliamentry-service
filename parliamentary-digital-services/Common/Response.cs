namespace PD.Services.Common
{
    public abstract class Response
    {
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }

        protected Response(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }
    }
}