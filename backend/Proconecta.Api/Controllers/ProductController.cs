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
    public class ProductController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IProductBL _productBL;
        #endregion

        #region Constructors
        public ProductController(
            IMapper mapper,
            IProductBL productBL)
        {
            _mapper = mapper;
            _productBL = productBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productBL.Get();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var product = await _productBL.GetById(id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product viewModel)
        {
            var created = await _productBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Product viewModel)
        {
            var updated = await _productBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _productBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
