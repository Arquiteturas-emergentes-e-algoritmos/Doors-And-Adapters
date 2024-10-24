using DoorsAndAdapters.Application.Repositories;
using DoorsAndAdapters.Application.Service;
using DoorsAndAdapters.Domain.Entities;
using DoorsAndAdapters.Domain.ValueObjects;
using Moq;

namespace DoorsAndAdapters.Test.Application;

[TestClass]
public class ServicesTest
{
    private Mock<IUserRepository> _userRepositoryMock;
    private User _mockUser;

    [TestInitialize]
    public void Setup()
    {
        _userRepositoryMock = new Mock<IUserRepository>();

        _mockUser = new User
        {
            Glucometer = new Glucometer(),
            MedicationPlan = new MedicationPlan()
        };

        _userRepositoryMock.Setup(repo => repo.GetFirstUser()).Returns(_mockUser);
    }

    [TestMethod]
    public void GlucometerService_AddTest_ShouldAddGlucoseTest()
    {
        var service = new GlucometerService(_userRepositoryMock.Object);
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };

        service.AddTest(test);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual(1, _mockUser.Glucometer.GlucoseTests.Count);
        Assert.AreEqual(test, _mockUser.Glucometer.GlucoseTests[0]);
    }

    [TestMethod]
    public void GlucometerService_DeleteTest_ShouldRemoveGlucoseTest()
    {
        var service = new GlucometerService(_userRepositoryMock.Object);
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };
        _mockUser.Glucometer.AddTest(test);

        service.DeleteTest(test.Id);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual(0, _mockUser.Glucometer.GlucoseTests.Count);
    }

    [TestMethod]
    public void GlucometerService_UpdateTest_ShouldUpdateGlucoseTest()
    {
        var service = new GlucometerService(_userRepositoryMock.Object);
        var test = new GlucoseTest
        {
            Id = Guid.NewGuid(),
            Time = DateTime.Now,
            Value = 100
        };
        _mockUser.Glucometer.AddTest(test);

        var updatedTest = new GlucoseTest
        {
            Id = test.Id,
            Time = DateTime.Now.AddMinutes(10),
            Value = 120
        };

        service.UpdateTest(updatedTest);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual(120, _mockUser.Glucometer.GlucoseTests[0].Value);
    }

    [TestMethod]
    public void MedicationPlanService_AddMedication_ShouldAddMedication()
    {
        var service = new MedicationPlanService(_userRepositoryMock.Object);
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };

        service.AddMedication(medication);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual(1, _mockUser.MedicationPlan.Medications.Count);
        Assert.AreEqual(medication, _mockUser.MedicationPlan.Medications[0]);
    }

    [TestMethod]
    public void MedicationPlanService_DeleteMedication_ShouldRemoveMedication()
    {
        var service = new MedicationPlanService(_userRepositoryMock.Object);
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };
        _mockUser.MedicationPlan.AddMedication(medication);

        service.DeleteMedication(medication.Id);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual(0, _mockUser.MedicationPlan.Medications.Count);
    }

    [TestMethod]
    public void MedicationPlanService_UpdateMedication_ShouldUpdateMedication()
    {
        var service = new MedicationPlanService(_userRepositoryMock.Object);
        var medication = new Medication
        {
            Id = Guid.NewGuid(),
            Name = "Insulin",
            TakeAt = DateTime.UtcNow.AddHours(1)
        };
        _mockUser.MedicationPlan.AddMedication(medication);

        var updatedMedication = new Medication
        {
            Id = medication.Id,
            Name = "Insulin Updated",
            TakeAt = DateTime.UtcNow.AddHours(2)
        };

        service.UpdateMedication(updatedMedication);

        _userRepositoryMock.Verify(repo => repo.PatchUser(It.IsAny<User>()), Times.Once);
        Assert.AreEqual("Insulin Updated", _mockUser.MedicationPlan.Medications[0].Name);
    }

}
