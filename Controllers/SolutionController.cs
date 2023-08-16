using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
public class SolutionController : ControllerBase
{
    
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

    // Link to docs that show how to find header
    // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/parameter-binding?view=aspnetcore-8.0
    // The exercise describes what attribute to use
    [HttpGet]
    [Route("/readHeader")]
    public object ReadHeader([FromHeader] string headerName)
    {
        //Input User-Agent in the field in Swagger to get the browser name back.
        //This method will send that as response body
        return Request.Headers[headerName][0];
    }

    
    // The exercise says you must use HttpContext, and that you specifically have to set RESPONSE and HEADER
    [HttpGet]
    [Route("/setHeader")]
    public object SetHeader()
    {
        //Check in brower developer tools you get the response
        HttpContext.Response.Headers["RandomHeaderName"] = "RandomValue";
        return null;
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