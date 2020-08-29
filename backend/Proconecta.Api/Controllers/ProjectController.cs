namespace Proconecta.Api.Controllers
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json.Linq;
    using Proconecta.Core;
    using Proconecta.Data.Models;

    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IProjectBL _projectBL;
        #endregion

        #region Constructors
        public ProjectController(
            IMapper mapper,
            IProjectBL projectBL)
        {
            _mapper = mapper;
            _projectBL = projectBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ;
            var projects = await _projectBL.Get();
            return Ok(projects);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var project = await _projectBL.GetById(id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project viewModel)
        {
            var created = await _projectBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Project viewModel)
        {
            var updated = await _projectBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _projectBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
