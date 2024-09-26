using DoorsAndAdapters.Domain.Entities;

namespace DoorsAndAdapters.Application.UseCases;

public interface IMedicationPlanUseCase
{
    void AddMedication(Medication Medication);
    void UpdateMedication(Medication Medication);
    void DeleteMedication(Medication Medication);
    List<Medication> GetAllMedication();
}
