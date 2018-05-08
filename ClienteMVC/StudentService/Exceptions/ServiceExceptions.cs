using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentService.ServiceLogic.Exceptions
{
    public class ServiceExceptions : Exception
    {
        public ServiceExceptions()
        {
        }

        public ServiceExceptions(string message) : base(message)
        {
        }

        public ServiceExceptions(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
