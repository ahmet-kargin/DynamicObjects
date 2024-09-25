namespace DynamicObjects.Domain.ValueObjects;

public class DynamicField
{
	public string Key { get; private set; }
	public string Value { get; private set; }

	// Constructor
	public DynamicField(string key, string value)
	{
		Key = key;
		Value = value;
	}

	public void UpdateValue(string newValue)
	{
		Value = newValue;
	}
}
