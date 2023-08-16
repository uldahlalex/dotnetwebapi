using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace dotnetwebapi.Controllers;

[ApiController]
public class Day2Solutions : ControllerBase
{
    
    [HttpPost]
    [Route("/sendDto")]
    public object GetStringFromBody([FromBody]MyDto dto)
    {
        return dto;
    }

    [HttpPost]
    [Route("/sendQueryParamDto")]
    public object DtoFromQueryParams([FromQuery]MyQueryParamDto dto)
    {
        return dto;
    }

    [HttpPost]
    [Route("/somethingiswrong")]
    public object SomethingIsWrong()
    {
        throw new Exception("Something went wrong");
    }
    
}

public class MyDto
{
    public string Property1 { get; set; }
    public string Property2 { get; set; }
}

public class MyQueryParamDto
{
    [MinLength(2)]
    public string Param1 { get; set; }
    [MaxLength(5)]
    public string Param2 { get; set; }
}