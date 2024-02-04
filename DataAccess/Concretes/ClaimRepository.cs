using DataAccess.Abstracts;
using DataAccess.Contexts;
using DataAccess.Core;
using Core.Entities;

namespace DataAccess.Concretes;

public class ClaimRepository : Repository<Claim>, IClaimRepository
{
    public ClaimRepository(BusinessDbContext context) : base(context)
    {

    }
}
