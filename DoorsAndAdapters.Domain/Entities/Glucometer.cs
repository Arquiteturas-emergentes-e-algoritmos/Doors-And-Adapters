﻿using DoorsAndAdapters.Domain.ValueObjects;

namespace DoorsAndAdapters.Domain.Entities;

public class Glucometer : Entity
{
    public List<GlucoseTest> GlucoseTests { get; set; } = [];
    public void AddTest(GlucoseTest test)
    {
        GlucoseTests.Add(test);
        _ = GlucoseTests.OrderBy(t => t.Time);
    }
    public void DeleteTest(Guid Id) => GlucoseTests.RemoveAll(x => x.Id == Id);

    public void UpdateTest(GlucoseTest test)
    {
        var testFound = GlucoseTests.Find(x => x.Id == test.Id);
        if (testFound == null) return;
        GlucoseTests.Remove(testFound);
        GlucoseTests.Add(test);
        _ = GlucoseTests.OrderBy(t => t.Time);
    }
}
