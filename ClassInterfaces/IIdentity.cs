using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace pizza_project.Interfaces;

public interface IIdentity
{

    public SecurityToken GetToken(List<Claim> claims);
    public SecurityToken Login(User user);

}