using Business.Abstracts;
using Business.Validations;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Core.Aspects.Autofac.Logging;
using Entities.DTOs;

namespace Business.Concretes;
public class UserManager : IUserService
{
    public readonly IUserRepository _userRepository;
    private readonly IUserClaimRepository _userClaimRepository;
    private readonly UserValidations _userValidations;
    private readonly ClaimManager _claimManager;
    public UserManager(IUserRepository userRepository, UserValidations userValidations, ClaimManager claimManager, IUserClaimRepository userClaimRepository)
    {
        _userRepository = userRepository;
        _userClaimRepository = userClaimRepository;
        _userValidations = userValidations;
        _claimManager = claimManager;
    }

    public User Add(User user)
    {
        return _userRepository.Add(user);
    }

    public async Task<User> AddAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void Delete(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        _userValidations.UserMustNotBeEmpty(user).Wait();
        _userRepository.Delete(user);
    }

    public async Task DeleteAsync(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        await _userValidations.UserMustNotBeEmpty(user);
        await _userRepository.DeleteAsync(user);
    }

    public IList<User> GetAll()
    {
        return _userRepository.GetAll().ToList();
    }

    [LogAspect()]
    public async Task<IList<User>> GetAllAsync()
    {
        var result = await _userRepository.GetAllAsync();
        return result.ToList();
    }

    public IList<User> GetAllByBirthDate(short birthDate)
    {
        return _userRepository.GetAll(u => u.BirthYear == birthDate).ToList();
    }

    public IList<User> GetAllByBirthDateGratherThan(short birthDate)
    {
        return _userRepository.GetAll(u => u.BirthYear > birthDate).ToList();
    }

    public IList<User> GetAllByBirthDateLessThan(short birthDate)
    {
        return _userRepository.GetAll(u => u.BirthYear < birthDate).ToList();
    }

    public IList<User> GetAllByFirstName(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName == firstName).ToList();

    }

    public IList<User> GetAllByFirstNameContains(string firstName)
    {
        return _userRepository.GetAll(u => u.FirstName.Contains(firstName)).ToList();
    }

    public IList<User> GetAllByLastName(string lastName)
    {
        return _userRepository.GetAll(u => u.LastName == lastName).ToList();
    }

    public User? GetByUserNameWithClaims(string userName)
    {
        return _userRepository.Get(
            predicate: u => u.UserName == userName,
            include: user => user.Include(u => u.UserClaims).ThenInclude(uc => uc.Claim));
    }
    public async Task<User?> GetByUserNameWithClaimsAsync(string userName)
    {
        return await _userRepository.GetAsync(
            predicate: u => u.UserName == userName,
            include: user => user.Include(u => u.UserClaims).ThenInclude(uc => uc.Claim));
    }

    public User GetById(Guid id)
    {
        var user = _userRepository.Get(u => u.Id == id);
        _userValidations.UserMustNotBeEmpty(user).Wait();
        return user;
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        var user = await _userRepository.GetAsync(u => u.Id == id);
        await _userValidations.UserMustNotBeEmpty(user);
        return user;
    }

    public User Update(User user)
    {
        return _userRepository.Add(user);
    }

    public async Task<User> UpdateAsync(User user)
    {
        return await _userRepository.AddAsync(user);
    }

    public void AddUserClaim(AddUserClaimDto addUserClaimDto)
    {
        var user = GetById(addUserClaimDto.UserId);
        var claim = _claimManager.GetById(addUserClaimDto.ClaimId);
        _userValidations.UserHaveClaim(user,claim).Wait();
        _userClaimRepository.Add(new()
        {
            UserId=user.Id,
            ClaimId=claim.Id
        });
    }

    public async Task AddUserClaimAsync(AddUserClaimDto addUserClaimDto)
    {
        var user = await GetByIdAsync(addUserClaimDto.UserId);
        var claim = await _claimManager.GetByIdAsync(addUserClaimDto.ClaimId);
        await _userValidations.UserHaveClaim(user, claim);
        await _userClaimRepository.AddAsync(new()
        {
            UserId = user.Id,
            ClaimId = claim.Id
        });
    }
}
