using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public void Get()
        {
        }
    }
}
