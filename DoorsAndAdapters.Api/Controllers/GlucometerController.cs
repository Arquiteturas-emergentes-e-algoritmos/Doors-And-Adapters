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
}