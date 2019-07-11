namespace PD.Services.Common
{
    public abstract class Response
    {
        public bool IsSuccess { get; }

        protected Response(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
    }
}