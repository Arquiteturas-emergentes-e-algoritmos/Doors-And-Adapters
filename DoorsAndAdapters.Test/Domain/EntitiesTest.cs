using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Test.Domain;

[TestClass]
public class EntitiesTest
{
    [TestMethod]
    public void Glucometer_AddTest_ShouldAddGlucoseTest()
    {
        var glucometer = new Glucometer();
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };

        glucometer.AddTest(test);

        Assert.AreEqual(1, glucometer.GlucoseTests.Count);
        Assert.AreEqual(test, glucometer.GlucoseTests.First());
    }

    [TestMethod]
    public void Glucometer_DeleteTest_ShouldRemoveGlucoseTest()
    {
        var glucometer = new Glucometer();
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };
        glucometer.AddTest(test);

        glucometer.DeleteTest(test.Id);

        Assert.AreEqual(0, glucometer.GlucoseTests.Count);
    }

    [TestMethod]
    public void Glucometer_UpdateTest_ShouldUpdateExistingGlucoseTest()
    {
        var glucometer = new Glucometer();
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };
        glucometer.AddTest(test);

        var updatedTest = new GlucoseTest
        {
            Id = test.Id,
            Time = DateTime.Now.AddMinutes(5),
            Value = 120
        };

        glucometer.UpdateTest(updatedTest);

        var result = glucometer.GlucoseTests.First();
        Assert.AreEqual(120, result.Value);
        Assert.AreEqual(updatedTest.Time, result.Time);
    }

    [TestMethod]
    public void MedicationPlan_AddMedication_ShouldAddMedication()
    {
        var medicationPlan = new MedicationPlan();
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };

        medicationPlan.AddMedication(medication);

        Assert.AreEqual(1, medicationPlan.Medications.Count);
        Assert.AreEqual(medication, medicationPlan.Medications.First());
    }

    [TestMethod]
    public void MedicationPlan_RemoveMedication_ShouldRemoveMedication()
    {
        var medicationPlan = new MedicationPlan();
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };
        medicationPlan.AddMedication(medication);

        medicationPlan.RemoveMedication(medication.Id);

        Assert.AreEqual(0, medicationPlan.Medications.Count);
    }

    [TestMethod]
    public void MedicationPlan_UpdateMedication_ShouldUpdateExistingMedication()
    {
        var medicationPlan = new MedicationPlan();
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };
        medicationPlan.AddMedication(medication);

        var updatedMedication = new Medication
        {
            Id = medication.Id,
            Name = "Insulin Updated",
            TakeAt = DateTime.UtcNow.AddHours(2)
        };

        medicationPlan.UpdateMedication(updatedMedication);

        var result = medicationPlan.Medications.First();
        Assert.AreEqual("Insulin Updated", result.Name);
        Assert.AreEqual(updatedMedication.TakeAt, result.TakeAt);
    }
}
