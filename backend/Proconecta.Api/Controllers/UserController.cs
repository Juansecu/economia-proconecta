namespace Proconecta.Api.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Proconecta.Core;
    using Proconecta.Data.Models;

    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IUserBL _userBL;
        #endregion

        #region Constructors
        public UserController(
            IMapper mapper,
            IUserBL userBL)
        {
            _mapper = mapper;
            _userBL = userBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userBL.Get();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var user = await _userBL.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User viewModel)
        {
            var created = await _userBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] User viewModel)
        {
            var updated = await _userBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _userBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
