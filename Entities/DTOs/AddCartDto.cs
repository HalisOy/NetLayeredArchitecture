﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class AddCartDto
{
    public Guid UserId { get; set; }
    public DateTime TransactionDate { get; set; }
}
