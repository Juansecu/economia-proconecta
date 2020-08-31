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
    public class PreOrderController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IPreOrderBL _preOrderBL;
        #endregion

        #region Constructors
        public PreOrderController(
            IMapper mapper,
            IPreOrderBL preOrderBL)
        {
            _mapper = mapper;
            _preOrderBL = preOrderBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var preOrders = await _preOrderBL.Get();
            return Ok(preOrders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var preOrder = await _preOrderBL.GetById(id);
            return Ok(preOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PreOrder viewModel)
        {
            var created = await _preOrderBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] PreOrder viewModel)
        {
            var updated = await _preOrderBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _preOrderBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
