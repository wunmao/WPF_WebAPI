using Microsoft.AspNetCore.Mvc;

namespace WPF_WebAPI.Controllers;

[Route(nameof(SayHi))]
public class SayHi : ControllerBase
{
    [HttpGet]
    [Route(nameof(Hello))]
    public IActionResult Hello(string name) => Ok($"Hello {name}");

    [HttpGet]
    [Route(nameof(Hi))]
    public IActionResult Hi(string name) => Ok($"Hi, {name}");
}
