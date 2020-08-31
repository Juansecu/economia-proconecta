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
    public class ProviderController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IProviderBL _providerBL;
        #endregion

        #region Constructors
        public ProviderController(
            IMapper mapper,
            IProviderBL providerBL)
        {
            _mapper = mapper;
            _providerBL = providerBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var providers = await _providerBL.Get();
            return Ok(providers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var provider = await _providerBL.GetById(id);
            return Ok(provider);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Provider viewModel)
        {
            var created = await _providerBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Provider viewModel)
        {
            var updated = await _providerBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _providerBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
