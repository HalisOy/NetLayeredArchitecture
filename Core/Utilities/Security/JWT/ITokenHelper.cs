using Core.Entities;
using Core.Utilities.Security.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT;
public interface ITokenHelper
{
    TokenModel CreateToken(User user);
}
