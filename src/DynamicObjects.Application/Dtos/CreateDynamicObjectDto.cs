namespace DynamicObjects.Application.Dtos;

public class CreateDynamicObjectDto
{
	public string ObjectType { get; set; }
	public Dictionary<string, string> Fields { get; set; }
}
