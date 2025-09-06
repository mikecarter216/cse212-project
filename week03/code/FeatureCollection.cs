public class FeatureCollection
{
    public List<Feature> Features { get; set; }
}

// Represents one earthquake event
public class Feature
{
    public Properties Properties { get; set; }
}

// Represents details (place, magnitude, etc.)
public class Properties
{
    public string Place { get; set; }
    public double? Mag { get; set; }
}
