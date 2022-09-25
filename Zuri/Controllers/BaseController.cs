using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zuri.Controllers
{
    [Authorize]
    public class BaseController : ControllerBase
    {

    }
}
