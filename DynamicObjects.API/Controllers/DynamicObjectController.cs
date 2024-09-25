using DynamicObjects.Application.Dtos;
using DynamicObjects.Application.UseCases;
using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DynamicObjects.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DynamicObjectController : ControllerBase
	{
		private readonly CreateDynamicObjectUseCase _createUseCase;
		private readonly DeleteDynamicObjectUseCase _deleteUseCase;
		private readonly UpdateDynamicObjectUseCase _updateUseCase;
		private readonly IDynamicObjectRepository _repository;

		public DynamicObjectController(CreateDynamicObjectUseCase createUseCase, DeleteDynamicObjectUseCase deleteUseCase, UpdateDynamicObjectUseCase updateUseCase, IDynamicObjectRepository repository)
		{
			_createUseCase = createUseCase;
			_deleteUseCase = deleteUseCase;
			_updateUseCase = updateUseCase;
			_repository = repository;
		}

		// POST endpoint to create a new dynamic object.
		[HttpPost("create")]
		public async Task<IActionResult> Create([FromBody] CreateDynamicObjectDto dto)
		{
			// Executes the create use case with the provided DTO.
			await _createUseCase.ExecuteAsync(dto);

			// Returns a success message.
			return Ok("Object created successfully.");
		}


		// GET endpoint to retrieve a dynamic object by type and ID.
		[HttpGet("{objectType}/{id}")]
		public async Task<IActionResult> Read(string objectType, Guid id)
		{
			// Retrieves the dynamic object from the repository using object type and ID.
			var dynamicObject = await _repository.ReadByIdAsync(objectType, id);

			if (dynamicObject == null)
				return NotFound(); // Returns 404 if the object is not found.

			return Ok(dynamicObject); // Returns the found dynamic object.
		}

		// PUT endpoint to update an existing dynamic object by ID.
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] UpdateDynamicObjectDto dto)
		{
			// Executes the update use case with the ID and provided DTO.
			await _updateUseCase.ExecuteAsync(id, dto);
			return Ok("Object updated successfully."); // Returns a success message.
		}


		// DELETE endpoint to remove a dynamic object by type and ID.
		[HttpDelete("delete/{objectType}/{id}")]
		public async Task<IActionResult> Delete(string objectType, Guid id)
		{
			// Creates a DTO for deleting the dynamic object.
			var dto = new DeleteDynamicObjectDto { ObjectType = objectType, Id = id };
			await _deleteUseCase.ExecuteAsync(dto); // Executes the delete use case.
			return Ok("Object deleted successfully."); // Returns a success message.
		}
	}
}
