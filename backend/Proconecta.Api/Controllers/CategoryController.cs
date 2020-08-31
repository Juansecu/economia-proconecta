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
    public class CategoryController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly ICategoryBL _categoryBL;
        #endregion

        #region Constructors
        public CategoryController(
            IMapper mapper,
            ICategoryBL categoryBL)
        {
            _mapper = mapper;
            _categoryBL = categoryBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorys = await _categoryBL.Get();
            return Ok(categorys);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var category = await _categoryBL.GetById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category viewModel)
        {
            var created = await _categoryBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Category viewModel)
        {
            var updated = await _categoryBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _categoryBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
