using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
public class SolutionController : ControllerBase
{
    
    //NOTICE: These solutions were made before I fixed some of exercises the night between
    //Wednesday and Thursday. So these are for those who attempted them Wednesday:
    
    // The link from today's lessons docs that show how to do this:
    // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0
    // See the section that says "explicit parameter binding". In the exercise I described which attribute to use
    [HttpGet]
    [Route("/entity/{id}")]
    public object GetId([FromRoute] int id)
    {
        return id;
    }

    // See same docs as the above exercise
    // This one also demonstrates usage: https://learn.microsoft.com/en-us/aspnet/core/web-api/?view=aspnetcore-8.0
    [HttpGet]
    [Route("/readQueryParam")]
    public object GetQueryParam([FromQuery] string somekey)
    {
        return somekey;
    }
    
    //Here: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0
    [HttpGet]
    [Route("/setHeaderWithParamterBinding")]
    public object SetHeaderWithParameterBinding([FromHeader]string somerandomvalue)
    {
        return "check the http request headers";
    }

    
    // The exercise says you must use HttpContext, and that you specifically have to set RESPONSE and HEADER
    [HttpGet]
    [Route("/setHeaderManuallyUsingContext")]
    public object SetHeader()
    {
       
        HttpContext.Response.Headers["RandomHeaderName"] = "RandomValue";
        return null;
    }

    
    // Can also be read using httpcontext
    [HttpGet]
    [Route("/readHeader")]
    public object ReadHeader([FromHeader] string headerName)
    {
        return HttpContext.Request.Headers[headerName][0];
    }



    // The exercise literally says just return a C# object, so just create one and return
    [HttpGet]
    [Route("/returnJson")]
    public object Json()
    {
        return new
        {
            Key = "Value"
        };
    }

    // The exercise says to modify response status code using HttpContext,
    // so just refer to this one and set a value
    [HttpGet]
    [Route("/statusCode")]
    public object StatusCode()
    {
        HttpContext.Response.StatusCode = 418;
        return null;
    }
    
    
}