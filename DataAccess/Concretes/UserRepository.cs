using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Core;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes;
public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(BusinessDbContext context) : base(context)
    {

    }
}
