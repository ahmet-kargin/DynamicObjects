using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.Repositories;

namespace DynamicObjects.Domain.Services;

// This service class handles the business logic for dynamic objects.
public class DynamicObjectService
{
	// A repository instance is injected to perform CRUD operations on dynamic objects.
	private readonly IDynamicObjectRepository _repository;

	// Constructor that initializes the repository through dependency injection.
	public DynamicObjectService(IDynamicObjectRepository repository)
	{
		_repository = repository;
	}

	// Creates a new dynamic object with the specified object type and fields.
	public async Task CreateObjectAsync(string objectType, Dictionary<string, string> fields)
	{
		// Create a new DynamicObject instance using the provided object type.
		var dynamicObject = new DynamicObject(objectType);

		// Iterate through each field and add it to the DynamicObject.
		foreach (var field in fields)
		{
			dynamicObject.AddField(field.Key, field.Value);
		}

		// Save the newly created object to the repository asynchronously.
		await _repository.AddAsync(dynamicObject);
	}

	// Updates an existing dynamic object identified by its ID, modifying its fields.
	public async Task UpdateObjectAsync(Guid id, Dictionary<string, string> updatedFields)
	{
		// Retrieve the dynamic object by its unique ID from the repository.
		var dynamicObject = await _repository.GetByIdAsync(id);

		// If the object is not found, throw an exception.
		if (dynamicObject == null)
		{
			throw new Exception("Object not found.");
		}

		// Iterate through the updated fields and update the corresponding fields in the object.
		foreach (var field in updatedFields)
		{
			dynamicObject.UpdateField(field.Key, field.Value);
		}

		// Save the updated dynamic object to the repository asynchronously.
		await _repository.UpdateAsync(dynamicObject);
	}
}
