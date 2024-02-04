using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class AddProductStockTransactionDto
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateTime TransactionTime { get; set; }
}

public class UpdateProductStockTransactionDto
{
    public Guid Id { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}
