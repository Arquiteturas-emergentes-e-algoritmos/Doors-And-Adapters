using Api.Adapters.Glucometer;
using Api.Adapters.MedicationPlan;

namespace DoorsAndAdapters.Test.Adapters;

[TestClass]
public class AdaptersTest
{
    [DataTestMethod]
    [DataRow(120, "2023-10-01", true)]
    [DataRow(0, "2023-10-01", false)]
    [DataRow(120, "0001-01-01", false)]
    public void AddTestAdapter_Validate_ShouldReturnExpectedResult(int value, string timeStr, bool expected)
    {
        var adapter = new AddTestAdapter
        {
            Value = (ushort)value,
            Time = DateTime.Parse(timeStr)
        };
        var result = adapter.Validate();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow(100, "2023-10-01", true)]
    [DataRow(0, "2023-10-01", false)]
    [DataRow(120, "0001-01-01", false)]
    public void UpdateTestAdapter_Validate_ShouldReturnExpectedResult(int value, string timeStr, bool expected)
    {
        var adapter = new UpdateTestAdapter
        {
            Value = (ushort)value,
            Time = DateTime.Parse(timeStr)
        };
        var result = adapter.Validate();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("Insulina", "2023-10-01", true)]
    [DataRow("", "2023-10-01", false)]
    [DataRow("Insulina", "0001-01-01", false)]
    public void AddMedicationAdapter_Validate_ShouldReturnExpectedResult(string name, string takeAtStr, bool expected)
    {
        var adapter = new AddMedicationAdapter
        {
            Name = name,
            TakeAt = DateTime.Parse(takeAtStr)
        };
        var result = adapter.Validate();
        Assert.AreEqual(expected, result);
    }

    [DataTestMethod]
    [DataRow("Insulina", "2023-10-01", true)]
    [DataRow("", "2023-10-01", false)]
    [DataRow("Insulina", "0001-01-01", false)]
    public void UpdateMedicationAdapter_Validate_ShouldReturnExpectedResult(string name, string takeAtStr, bool expected)
    {
        var adapter = new UpdateMedicationAdapter
        {
            Name = name,
            TakeAt = DateTime.Parse(takeAtStr)
        };
        var result = adapter.Validate();
        Assert.AreEqual(expected, result);
    }
}
