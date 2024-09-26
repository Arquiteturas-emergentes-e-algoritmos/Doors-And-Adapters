using DoorsAndAdapters.Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("/v1/medication")]
public class MedicationPlanController : MyBaseController
{
    private readonly IMedicationPlanUseCase _medicationPlanUseCase;

    public MedicationPlanController(IMedicationPlanUseCase medicationPlanUseCase)
    {
        this._medicationPlanUseCase = medicationPlanUseCase;
    }

    [Route("")]
    [HttpPost]
    public ActionResult<object> PostAddMedication()
    {
        _medicationPlanUseCase.AddMedication();
        return Ok();
    }
    [Route("")]
    [HttpGet]
    public ActionResult<object> GetMedications()
    {
        _medicationPlanUseCase.GetAllMedications();
        return Ok();
    }

    [Route("{Id}")]
    [HttpPost]
    public ActionResult<object> UpdateMedication([FromRoute] int Id)
    {
        return Ok();
    }
    [Route("{Id}")]
    [HttpDelete]
    public ActionResult<object> DeleteMedication([FromRoute] int Id)
    {
        return Ok();
    }
}