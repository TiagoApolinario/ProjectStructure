using Microsoft.AspNetCore.Mvc;
using ProjectStructure.Utils;
using System;

namespace ProjectStructure.Api.Controllers
{
    public abstract class CustomControllerBase : ControllerBase
    {
        protected IActionResult FromResult(Result result)
        {
            if (result.IsSuccess)
                return base.Ok();
            else
                return base.BadRequest(result.ErrorMessage);
        }

        protected IActionResult FromResult<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return base.Ok(result.Value);
            else
                return base.BadRequest(result.ErrorMessage);
        }

        protected IActionResult FromResult<T>(Result<T> result, Func<T, object> fields)
        {
            if (result.IsSuccess)
                return base.Ok(fields(result.Value));
            else
                return base.BadRequest(result.ErrorMessage);
        }
    }
}
