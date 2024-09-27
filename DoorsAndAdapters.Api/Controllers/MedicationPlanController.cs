using Api.Adapters.MedicationPlan.Interfaces;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.ValueObjects;
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
    public ActionResult<object> PostAddMedication([FromBody] IAddMedicationAdapter adapter)
    {
        try
        {
            if (!adapter.Validate())
                return BadRequest();
            _medicationPlanUseCase.AddMedication(new(adapter.Name, adapter.TakeAt));
            return Ok("Adicionado com sucesso");
        }

        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("")]
    [HttpGet]
    public ActionResult<object> GetMedications()
    {
        try
        {
            return Ok(_medicationPlanUseCase.GetAllMedications());
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }

    [Route("{Id}")]
    [HttpPut]
    public ActionResult<object> UpdateMedication([FromRoute] string Id, [FromBody] IUpdateMedicationAdapter adapter)
    {
        try
        {
            if (!adapter.Validate())
                return BadRequest();

            var medication = new Medication()
            {
                Id = Guid.Parse(Id),
                Name = adapter.Name,
                TakeAt = adapter.TakeAt,
            };

            _medicationPlanUseCase.UpdateMedication(medication);
            return Ok("Atualizado com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
    [Route("{Id}")]
    [HttpDelete]
    public ActionResult<object> DeleteMedication([FromRoute] string Id)
    {
        try
        {
            _medicationPlanUseCase.DeleteMedication(Guid.Parse(Id));
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }
}