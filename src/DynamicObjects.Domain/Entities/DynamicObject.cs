using DynamicObjects.Domain.ValueObjects;

namespace DynamicObjects.Domain.Entities;

public class DynamicObject
{
	public Guid Id { get; private set; }
	public string ObjectType { get; private set; }
	public List<DynamicField> Fields { get; private set; }
	public DateTime CreatedAt { get; private set; }
	public DateTime UpdatedAt { get; private set; }

	// Constructor
	public DynamicObject(string objectType)
	{
		Id = Guid.NewGuid();
		ObjectType = objectType;
		Fields = new List<DynamicField>();
		CreatedAt = DateTime.UtcNow;
		UpdatedAt = DateTime.UtcNow;
	}

	public void AddField(string key, string value)
	{
		Fields.Add(new DynamicField(key, value));
		UpdatedAt = DateTime.UtcNow;
	}

	public void UpdateField(string key, string value)
	{
		var field = Fields.FirstOrDefault(f => f.Key == key);
		if (field != null)
		{
			field.UpdateValue(value);
			UpdatedAt = DateTime.UtcNow;
		}
	}
}
