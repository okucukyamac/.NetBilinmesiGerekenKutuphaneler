using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ErrorHanding.Filter
{
    public class CustomHandlerExceptionFilterAttribute : ExceptionFilterAttribute
    {

        public override void OnException(ExceptionContext context)
        {

            var result = new ViewResult() { ViewName = "Hata1" };

            result.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), context.ModelState);

            result.ViewData.Add("Exception", context.Exception);

            context.Result = result;
        }

    }
}
