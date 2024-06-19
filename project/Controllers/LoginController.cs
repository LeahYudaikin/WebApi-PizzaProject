using pizza_project.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace pizza_project.project.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private IIdentity MyIdentity;
    public LoginController(IIdentity MyIdentity)
    {
        this.MyIdentity = MyIdentity;
    } 

    [HttpPost]
    public ActionResult<String> Login([FromBody] User user)
    {
        var token = MyIdentity.Login(user);
        if(token == null)
           throw new UnauthorizedAccessException("Unauthorized");
        return new OkObjectResult(new JwtSecurityTokenHandler().WriteToken(token));
    }

}
