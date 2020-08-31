namespace Proconecta.Api.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class ReadyController : ControllerBase
    {
        #region Attributes
        #endregion

        #region Constructors
        public ReadyController() { }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get() =>
            await Task.FromResult(Ok("Api server is running! :)"));
        #endregion

    }
}
