using DynamicObjects.Domain.Entities;

namespace DynamicObjects.Domain.Repositories;

// Interface defining repository operations for DynamicObject entities.
public interface IDynamicObjectRepository
{
	// Retrieves a DynamicObject by its unique ID.
	Task<DynamicObject> GetByIdAsync(Guid id);

	// Retrieves a list of DynamicObjects based on the object type (e.g., products, orders).
	Task<List<DynamicObject>> GetByObjectTypeAsync(string objectType);

	// Adds a new DynamicObject to the repository.
	Task AddAsync(DynamicObject dynamicObject);

	// Updates an existing DynamicObject in the repository.
	Task UpdateAsync(DynamicObject dynamicObject);

	// Deletes a DynamicObject from the repository by its unique ID.
	Task DeleteAsync(Guid id);

	// Retrieves a DynamicObject by both its object type and unique ID.
	// This method is useful when you need to ensure the object type matches the ID.
	Task<DynamicObject> ReadByIdAsync(string objectType, Guid id);
}