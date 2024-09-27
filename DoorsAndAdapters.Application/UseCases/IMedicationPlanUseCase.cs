using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.UseCases;

public interface IMedicationPlanUseCase
{
    void AddMedication(Medication Medication);
    void UpdateMedication(Medication Medication);
    void DeleteMedication(Guid Id);
    List<Medication> GetAllMedications();
}
