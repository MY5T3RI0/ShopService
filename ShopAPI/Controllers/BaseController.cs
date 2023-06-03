using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal int? UserId => !User.Identity.IsAuthenticated
            ? null 
            : int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
    }
}
