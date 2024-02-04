﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;
public interface IUserService
{
    User? GetById(Guid id);
    Task<User?> GetByIdAsync(Guid id);
    IList<User> GetAll();
    Task<IList<User>> GetAllAsync();
    User? GetByUserNameWithClaims(string userName);
    Task<User?> GetByUserNameWithClaimsAsync(string userName);
    IList<User> GetAllByFirstName(string firstName);
    IList<User> GetAllByLastName(string lastName);
    IList<User> GetAllByBirthDate(short birthDate);
    IList<User> GetAllByBirthDateGratherThan(short birthDate);
    IList<User> GetAllByBirthDateLessThan(short birthDate);
    IList<User> GetAllByFirstNameContains(string firstName);
    User Add(User user);
    User Update(User user);
    void Delete(Guid id);
    Task< User> AddAsync(User user);
    Task <User> UpdateAsync(User user);
    Task DeleteAsync(Guid id);
}
