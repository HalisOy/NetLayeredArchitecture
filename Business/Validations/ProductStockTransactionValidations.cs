using Business.Tools.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations;

public class ProductStockTransactionValidations
{
    public DateTime CreatedTimeMustNotBeEmpty(DateTime date)
    {
        if (date == null)
            return DateTime.Now;
        return date;
    }

    public async Task ProductStockTransactionMustNotEmpty(ProductStockTransaction productStockTransaction)
    {
        if (productStockTransaction == null)
            throw new ValidationException("ProductStockTransaction must not be empty.",400);
        await Task.CompletedTask;
    }
}
