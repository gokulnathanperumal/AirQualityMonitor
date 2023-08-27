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
    public long DocumentId => Int64.Parse(Name?.Split('/').Last());
}

public class Fields
{
    public ParticulateMatter1 ParticulateMatter1 { get; set; }
	public ParticulateMatter2p5 ParticulateMatter2p5 { get; set; }
	public ParticulateMatter4 ParticulateMatter4 { get; set; }
	public ParticulateMatter10 ParticulateMatter10 { get; set; }
	public Humidity Humidity { get; set; }
	public Temperature Temperature { get; set; }
	public VolatileOrganicCompounds VolatileOrganicCompounds { get; set; }
	public NitrogenOxides NitrogenOxides { get; set; }
    public CreatedDate CreatedDate { get; set; }
}

public class ParticulateMatter1
{
    public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class ParticulateMatter2p5
{
	public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class ParticulateMatter4
{
	public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class ParticulateMatter10
{
	public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class Humidity
{
    public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class Temperature
{
    public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
	public string Celsius => DoubleValue.ToString("0.00°C");
    public string Fahrenheit => (32 + (DoubleValue / 0.5556)).ToString("0.00°F");
    public string Summary => new Dictionary<int, string>() { { 1, "Freezing" }, { 2, "Bracing" }, { 3, "Chilly" }, { 4, "Cool" }, { 5, "Mild" }, { 6, "Warm" }, { 7, "Balmy" }, { 8, "Hot" }, { 9, "Sweltering" }, { 10, "Scorching" } }[(DoubleValue < 5) ? 1 : (DoubleValue > 50) ? 10 : (int)(DoubleValue / 5)];
}

public class VolatileOrganicCompounds
{
	public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class NitrogenOxides
{
	public double DoubleValue { get; set; }
	public string Value => DoubleValue.ToString("0.00");
}

public class CreatedDate
{
    public DateTime TimestampValue { get; set; }
}
