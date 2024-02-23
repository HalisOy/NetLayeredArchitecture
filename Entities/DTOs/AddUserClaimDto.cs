using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class AddUserClaimDto
{
    public Guid UserId { get; set; }
    public Guid ClaimId { get; set; }
}
