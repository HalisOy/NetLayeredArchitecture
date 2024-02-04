using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class AddProductCommentDto
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public byte Rating { get; set; }
    public string Comment { get; set; }
}
