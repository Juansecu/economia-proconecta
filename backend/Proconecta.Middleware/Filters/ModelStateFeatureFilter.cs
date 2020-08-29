namespace Proconecta.Middleware.Filters
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public class ModelStateFeatureFilter : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var state = context.ModelState;
            context.HttpContext.Features.Set(new ModelStateFeature(state));
            return Task.CompletedTask;
        }
    }

    public class ModelStateFeature
    {
        public ModelStateDictionary ModelState { get; set; }

        public ModelStateFeature(ModelStateDictionary state)
            => ModelState = state;
    }
}
