using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.UseCases;
using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Application.Service;

public class MedicationPlanService(IUserRepository userRepository) : IMedicationPlanUseCase
{
    public void AddMedication(Medication Medication)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
        {
            user = new();
            userRepository.AddUser(user);
        }
        user.MedicationPlan.AddMedication(Medication);
        userRepository.PatchUser(user);
    }

    public void DeleteMedication(Guid Id)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
            return;
        var medication = user.MedicationPlan.Medications.Find(x => x.Id == Id);
        if (medication == null)
            return;
        user.MedicationPlan.RemoveMedication(medication);
        userRepository.PatchUser(user);
    }

    public List<Medication> GetAllMedications()
    {
        User? user = userRepository.GetFirstUser();
        return user == null ? [] : user.MedicationPlan.Medications;
    }

    public void UpdateMedication(Medication Medication)
    {
        User? user = userRepository.GetFirstUser();
        if (user == null)
            return;
        user.MedicationPlan.UpdateMedication(Medication);
        userRepository.PatchUser(user);
    }
}
