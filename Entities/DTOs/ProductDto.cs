using Core.Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs;

public class AddProductDto
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}

public class UpdateProductDto
{
    public Guid Id { get; set; }
    public User User { get; set; }
    public Category Category { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}