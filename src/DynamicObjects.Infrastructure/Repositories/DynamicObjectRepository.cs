using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.Repositories;
using DynamicObjects.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DynamicObjects.Infrastructure.Repositories;

public class DynamicObjectRepository : IDynamicObjectRepository
{
	// Dependency injection of the database context.
	private readonly DynamicDbContext _context;

	// Constructor that initializes the repository with a database context.
	public DynamicObjectRepository(DynamicDbContext context)
	{
		_context = context;
	}

	// Adds a new dynamic object to the database and saves the changes asynchronously.
	public async Task AddAsync(DynamicObject dynamicObject)
	{
		// Adds the dynamic object to the DbSet.
		await _context.DynamicObjects.AddAsync(dynamicObject);

		// Saves changes to the database.
		await _context.SaveChangesAsync();
	}

	// Retrieves a dynamic object from the database by its unique ID asynchronously.
	public async Task<DynamicObject> GetByIdAsync(Guid id)
	{
		// Uses the FindAsync method to find a dynamic object by its ID.
		return await _context.DynamicObjects.FindAsync(id);
	}

	// Retrieves a list of dynamic objects from the database filtered by their object type.
	public async Task<List<DynamicObject>> GetByObjectTypeAsync(string objectType)
	{
		// Queries the DbSet for objects with the specified object type.
		return await _context.DynamicObjects
			.Where(o => o.ObjectType == objectType) // Filters objects by object type.
			.ToListAsync(); // Converts the result to a list asynchronously.
	}

	// Updates an existing dynamic object in the database and saves changes.
	public async Task UpdateAsync(DynamicObject dynamicObject)
	{
		// Updates the dynamic object in the DbSet.
		_context.DynamicObjects.Update(dynamicObject);

		// Saves changes to the database.
		await _context.SaveChangesAsync();
	}

	// Deletes a dynamic object from the database by its ID.
	public async Task DeleteAsync(Guid id)
	{
		// Retrieves the dynamic object by its ID.
		var dynamicObject = await GetByIdAsync(id);

		// If the object exists, remove it from the DbSet.
		if (dynamicObject != null)
		{
			_context.DynamicObjects.Remove(dynamicObject);

			// Saves changes to the database.
			await _context.SaveChangesAsync();
		}
	}

	// Retrieves a dynamic object by its object type and ID asynchronously.
	public async Task<DynamicObject> ReadByIdAsync(string objectType, Guid id)
	{
		// Queries the DbSet for an object that matches both the object type and the ID.
		return await _context.DynamicObjects
			.FirstOrDefaultAsync(o => o.ObjectType == objectType && o.Id == id);
	}
}

