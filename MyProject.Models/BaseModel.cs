using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
   public class BaseModel
    {
        public BaseModel()
        {
            ValidationMessage = new ValidationMessage();
        }

        public string Message { get; set; }
        public ValidationMessage ValidationMessage { get; set; }
    }

    public class ValidationMessage
    {
        public string ErrorMessage { get; set; }
        public bool HasError => string.IsNullOrEmpty(ErrorMessage) ? false : true;
    }
}
