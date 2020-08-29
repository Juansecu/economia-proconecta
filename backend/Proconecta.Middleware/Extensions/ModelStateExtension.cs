﻿namespace Proconecta.Middleware.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public static class ModelStateExtension
    {
        public static IEnumerable<ValidationError> AllErrors(this ModelStateDictionary modelState)
        {
            return modelState.Keys
                .SelectMany(key => modelState[key].Errors
                    .Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();
        }
    }
}
