using System.Collections.Generic;

namespace PD.Services.Common
{
    public abstract class ValidationModel
    {
        protected List<string> Errors { get; set; } = new List<string>();
        
        protected void AddValidationError(string message)
        {
            Errors.Add(message);
        }

        public abstract IEnumerable<string> GetErrors();
    }
}