using Business.Tools.Exceptions;
using Core.Entities;
using Core.Utilities.Security.Helper;
using Entities.DTOs;

namespace Business.Validations;

public class AuthValidations
{
    public async Task UserMustNotBeEmpty(User? user)
    {
        if (user == null)
        {
            throw new ValidationException("Username or password not match.");
        }
        await Task.CompletedTask;
    }
    public async Task UserClaimMustNotBeEmpty(User user)
    {
        if (user.UserClaims.Count == 0)
            throw new ValidationException("User has not any 'Claim'. Please contact to system manager.");
        await Task.CompletedTask;
    }
    public async Task PasswordValidate(User user, string password)
    {
        var result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
        if (!result)
            throw new ValidationException("Username or password not match.");
        await Task.CompletedTask;
    }

    public async Task RegisterNotNull(UserForRegisterDto userForRegisterDto)
    {
        if (userForRegisterDto.UserName == null)
            throw new ValidationException("UserName cannot be empty");
        if (userForRegisterDto.IdentificationNumber == null)
            throw new ValidationException("IdentificationNumber cannot be empty");
        if (userForRegisterDto.FirstName == null)
            throw new ValidationException("FirstName cannot be empty");
        if (userForRegisterDto.LastName == null)
            throw new ValidationException("LastName cannot be empty");
        if (userForRegisterDto.BirthYear == null)
            throw new ValidationException("BirthYear cannot be empty");
        if (userForRegisterDto.Password == null)
            throw new ValidationException("Password cannot be empty");
        await Task.CompletedTask;
    }
}
