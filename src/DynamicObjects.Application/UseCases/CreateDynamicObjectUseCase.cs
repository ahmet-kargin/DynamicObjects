using DynamicObjects.Application.Dtos;
using DynamicObjects.Domain.Services;

namespace DynamicObjects.Application.UseCases;

public class CreateDynamicObjectUseCase
{
	private readonly DynamicObjectService _dynamicObjectService;

	public CreateDynamicObjectUseCase(DynamicObjectService dynamicObjectService)
	{
		_dynamicObjectService = dynamicObjectService;
	}

	// Method to execute the create use case asynchronously.
	// It accepts a CreateDynamicObjectDto (Data Transfer Object) that contains the information needed to create a dynamic object.
	public async Task ExecuteAsync(CreateDynamicObjectDto dto)
	{
		// Calls the DynamicObjectService to create a new object.
		// The service takes the object type (like "product", "order") and the list of dynamic fields provided in the DTO.
		await _dynamicObjectService.CreateObjectAsync(dto.ObjectType, dto.Fields);
	}
}
