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
    public class ReviewController : ControllerBase
    {
        #region Attributes
        private readonly IMapper _mapper;
        private readonly IReviewBL _reviewBL;
        #endregion

        #region Constructors
        public ReviewController(
            IMapper mapper,
            IReviewBL reviewBL)
        {
            _mapper = mapper;
            _reviewBL = reviewBL;
        }
        #endregion

        #region Public Methods
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var reviews = await _reviewBL.Get();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {
            var review = await _reviewBL.GetById(id);
            return Ok(review);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Review viewModel)
        {
            var created = await _reviewBL.Insert(viewModel);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> Patch([FromRoute] string id, [FromBody] Review viewModel)
        {
            var updated = await _reviewBL.Update(id, viewModel);
            return Accepted(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            var response = await _reviewBL.Delete(id);
            return Accepted(response);
        }

        #endregion
    }
}
