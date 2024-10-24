using Api.Adapters.Glucometer.Interfaces;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/v1/glucometer")]
public class GlucometerController(IGlucometerUseCase glucometerUseCase) : MyBaseController
{
    private readonly IGlucometerUseCase _glucometerUseCase = glucometerUseCase;

    [Route("")]
    [HttpPost]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public ActionResult<object> PostAddTest([FromBody] IAddTestAdapter adapter)
    {
        try
        {
            if (!adapter.Validate())
                return BadRequest();
            _glucometerUseCase.AddTest(adapter.Time != DateTime.MinValue ? new(adapter.Value, adapter.Time) : new(adapter.Value));
            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("")]
    [HttpGet]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public ActionResult<object> GetTests()
    {
        try
        {
            return Ok(_glucometerUseCase.GetAllTests());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpPut]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public ActionResult<object> UpdateTest([FromRoute] string Id,
        [FromBody] IUpdateTestAdapter adapter)
    {
        try
        {
            if (!adapter.Validate())
                return BadRequest();

            var Test = new GlucoseTest
            {
                Value = adapter.Value,
                Time = adapter.Time,
                Id = Guid.Parse(Id)
            };

            _glucometerUseCase.UpdateTest(Test);
            return Ok("Atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpDelete]
    [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
    public ActionResult<object> DeleteTest([FromRoute] string Id)
    {
        try
        {
            _glucometerUseCase.DeleteTest(Guid.Parse(Id));
            return Ok("Deletado com sucesso!");

        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}