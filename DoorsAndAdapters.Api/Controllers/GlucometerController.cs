using DoorsAndAdapters.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/v1/glucometer")]
public class GlucometerController : MyBaseController
{
    private readonly IGlucometerUseCase _glucometerUseCase;

    public GlucometerController(IGlucometerUseCase glucometerUseCase)
    {
        _glucometerUseCase = glucometerUseCase;
    }

    [Route("")]
    [HttpPost]
    public ActionResult<object> PostAddTest()
    {
        _glucometerUseCase.AddTest();
        return Ok();
    }
    [Route("")]
    [HttpGet]
    public ActionResult<object> GetTests()
    {
        _glucometerUseCase.GetAllTests();
        return Ok();
    }

    [Route("{Id}")]
    [HttpPost]
    public ActionResult<object> UpdateTest([FromRoute] int Id)
    {
        return Ok();
    }

    [Route("{Id}")]
    [HttpDelete]
    public ActionResult<object> DeleteTest([FromRoute] int Id)
    {
        return Ok();
    }
}