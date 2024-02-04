using Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities;
public class User : Entity<Guid>
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public short BirthYear { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public string IdentificationNumber { get; set; }
    public virtual ICollection<UserClaim> UserClaims { get; set; }
    public User()
    {
        UserClaims = new HashSet<UserClaim>();
    }
}
