using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.Service;

public class MedicationPlanService(IUserRepository userRepository) : BaseService(userRepository), IMedicationPlanUseCase
{
    public void AddMedication(Medication Medication)
    {
        var user = GetUser();
        user.MedicationPlan.AddMedication(Medication);
        userRepository.PatchUser(user);
    }

    public void DeleteMedication(Guid Id)
    {
        var user = GetUser();
        var medication = user.MedicationPlan.Medications.Find(x => x.Id == Id);
        if (medication == null)
            return;
        user.MedicationPlan.RemoveMedication(medication.Id);
        userRepository.PatchUser(user);
    }

    public List<Medication> GetAllMedications() => GetUser().MedicationPlan.Medications;

    public void UpdateMedication(Medication Medication)
    {
        var user = GetUser();
        if (user.MedicationPlan.Medications.Count == 0)
            return;
        user.MedicationPlan.UpdateMedication(Medication);
        userRepository.PatchUser(user);
    }
}
