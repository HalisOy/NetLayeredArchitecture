using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Business.Tools.Exceptions;
public class ValidationException : Exception
{
    public short StatusCode;
    public ValidationException(string message,short statusCode=400):base(message)
    {
        StatusCode = statusCode;
    }
}
