using System.Dynamic;

public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    public Feature[] Features { get; set; }
}
public class Feature
{
    public Details Properties { get; set; }
}

public class Details
{
    public string Place { get; set; }
    public float Mag { get; set; }

}
