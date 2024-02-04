using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Core;
using Core.Entities;

namespace DataAccess.Concretes;

public class UserClaimRepository : Repository<UserClaim>, IUserClaimRepository
{
    public UserClaimRepository(BusinessDbContext context) : base(context)
    {

    }
}