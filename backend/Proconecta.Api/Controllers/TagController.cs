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
    [Authorize]
    [Route("api/v1/[controller]")]
    public class TagController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly ITagBL _tagBL;
        #endregion

        #region Constructors
        public TagController(
            IMapper mapper,
            ITagBL tagBL)
        {
            _mapper = mapper;
            _tagBL = tagBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tags = await _tagBL.Get();
            return Ok(tags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var tag = await _tagBL.GetById(id);
            return Ok(tag);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tag viewModel)
        {
            var created = await _tagBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Tag viewModel)
        {
            var updated = await _tagBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _tagBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
