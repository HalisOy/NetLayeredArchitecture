using Core.Entities;
using Core.Utilities.Security.Helper;
using Core.Utilities.Security.Models;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace Core.Utilities.Security.JWT;

public class JWTTokenHelper : ITokenHelper
{
    private IConfiguration Configuration { get; }

    public JWTTokenHelper(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public TokenModel CreateToken(User user)
    {
        var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        var claimNames = user.UserClaims.Select(uc => $"{uc.Claim.Group}.{uc.Claim.Name}").Select(name => CreateClaimWithName(name)).ToList();
        claimNames.Add(new System.Security.Claims.Claim("userId", user.Id.ToString()));
        claimNames.Add(new System.Security.Claims.Claim("fullName", user.FirstName + " " + user.LastName.ToString()));
        var securityKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey);
        var credentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
        var expirationDate = DateTime.Now.AddDays(tokenOptions.ExpirationDays);
        var jwt = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Audience,
            notBefore: DateTime.Now,
            expires: expirationDate,
            claims: claimNames,
            signingCredentials:credentials
            );
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
        var token = jwtSecurityTokenHandler.WriteToken(jwt);
        return new TokenModel() 
        { 
            Token = token, 
            ExpirationDate = DateTime.Now.AddDays(tokenOptions.ExpirationDays) 
        };
    }

    public System.Security.Claims.Claim CreateClaimWithName(string name)
    {
        return new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, name);
    }
}
