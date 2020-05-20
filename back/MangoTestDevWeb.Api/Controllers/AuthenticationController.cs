using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MangoTestDevWeb.Domain;
using MangoTestDevWeb.Domain.DataContract;
using MangoTestDevWeb.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MangoTestDevWeb.Api.Controllers
{
  [AllowAnonymous]
  [Consumes("application/json")]
  [Route("api/[controller]")]
  [ApiController]
  public class AuthenticationController : ControllerBase
  {
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
    private readonly ILogger<AuthenticationController> _log;

    public AuthenticationController(
      IAuthenticationService authenticationService,
      IMapper mapper,
      ILogger<AuthenticationController> logger)
    {
      _authenticationService = authenticationService;
      _mapper = mapper;
      _log = logger;
    }

    [HttpPost]
    [Route("login")]
    [Produces(typeof(ResponseDto<JwtResult>))]
    public async Task<IActionResult> Login([FromBody, Required] AuthDto auth)
    {
      _log.LogDebug("Trying to Login as {0}...", auth.Username);
      var tokenResponse = await _authenticationService.LoginAsync(auth.Username, auth.Password);
      if (!tokenResponse.Success)
      {
        _log.LogWarning("Logging failed as {0}", auth.Username);
        return Unauthorized();
      }

      _log.LogDebug("Login successful as {0}...", auth.Username);

      var result = _mapper.Map<ResponseDto<JwtResultDto>>(tokenResponse);
      return Ok(result);
    }
  }
}
