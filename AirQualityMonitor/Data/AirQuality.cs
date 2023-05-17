namespace AirQualityMonitor.Data;

public class Identity
{
    public string Kind { get; set; }
    public string LocalId { get; set; }
    public string Email { get; set; }
    public string DisplayName { get; set; }
    public string IdToken { get; set; }
    public bool Registered { get; set; }
    public string RefreshToken { get; set; }
    public string ExpiresIn { get; set; }
}

public class AirQualityCollection
{
    public List<AirQualityDocument> Documents { get; set; }
    public string NextPageToken { get; set; }
}

public class AirQualityDocument
{
    public string Name { get; set; }
    public Fields Fields { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime UpdateTime { get; set; }
}

public class Fields
{
    public Temperature Temperature { get; set; }

    public CreatedDate CreatedDate { get; set; }
}

public class Temperature
{
    public double DoubleValue { get; set; }

    public string Celsius => DoubleValue.ToString("0.00°C");

    public string Fahrenheit => (32 + (DoubleValue / 0.5556)).ToString("0.00°F");

    public string Summary => new Dictionary<int, string>() { { 1, "Freezing" }, { 2, "Bracing" }, { 3, "Chilly" }, { 5, "Mild" }, { 6, "Warm" }, { 7, "Balmy" }, { 8, "Hot" }, { 9, "Sweltering" }, { 10, "Scorching" } }[Math.Max(1, Math.Min((int)(DoubleValue / 5), 10))];
}

public class CreatedDate
{
    public DateTime TimestampValue { get; set; }
}
