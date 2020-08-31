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
    public class PreOrderDetailController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IPreOrderDetailBL _preOrderDetailBL;
        #endregion

        #region Constructors
        public PreOrderDetailController(
            IMapper mapper,
            IPreOrderDetailBL preOrderDetailBL)
        {
            _mapper = mapper;
            _preOrderDetailBL = preOrderDetailBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var preOrderDetails = await _preOrderDetailBL.Get();
            return Ok(preOrderDetails);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var preOrderDetail = await _preOrderDetailBL.GetById(id);
            return Ok(preOrderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PreOrderDetail viewModel)
        {
            var created = await _preOrderDetailBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] PreOrderDetail viewModel)
        {
            var updated = await _preOrderDetailBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _preOrderDetailBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
