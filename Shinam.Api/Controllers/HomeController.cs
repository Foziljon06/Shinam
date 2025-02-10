//===============================
// bu Faylda file header yaratdim
// negaligini hozircha bilmayaman
//===============================


using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;

namespace Shinam.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : RESTFulController
    {
        [HttpGet]
        public ActionResult<string> Get() =>
            Ok("Hello How are you");
    }
}