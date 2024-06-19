using pizza_project.Interfaces;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace pizza_project.Services;

public class IdentityService:IIdentity
{
    private IWorker _IWorker;
    public IdentityService(IWorker worker)
    {
        _IWorker = worker;
    }

    private static SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
    private static string issuer = "https://my-pizza.com";
    public SecurityToken GetToken(List<Claim> claims) =>
    new JwtSecurityToken(
        issuer,
        issuer,
        claims,
        expires: DateTime.Now.AddDays(30.0),
        signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
    );

    public static TokenValidationParameters GetTokenValidationParameters() =>
    new TokenValidationParameters
    {
        ValidIssuer = issuer,
        ValidAudience = issuer,
        IssuerSigningKey = key,
        ClockSkew = TimeSpan.Zero // remove delay of token when expire
    };

    public SecurityToken Login(User user)
    {
        var workers = _IWorker.GetAll();
        var existWorker = workers.FirstOrDefault(Worker => ((Worker.Name.Equals(user.Name)) && (Worker.Password).Equals(user.Password)));
        if (existWorker == null)
            return null;
        List<Claim> Claims = new List<Claim>
        {
            new Claim("UserType", existWorker.Role.ToString()),
            new Claim("UserId", existWorker.Id.ToString())
        };
        var token = this.GetToken(Claims);
        return token;
    }
}