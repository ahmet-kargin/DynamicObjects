using DynamicObjects.Application.Dtos;
using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.Repositories;

namespace DynamicObjects.Application.UseCases;

public class ReadDynamicObjectUseCase
{
	private readonly IDynamicObjectRepository _repository;

	public ReadDynamicObjectUseCase(IDynamicObjectRepository repository)
	{
		_repository = repository;
	}

	public async Task<DynamicObject> ExecuteAsync(ReadDynamicObjectDto dto)
	{
		// objectType ile birlikte id kullanarak nesneyi al
		return await _repository.ReadByIdAsync(dto.ObjectType, dto.Id);
	}
}
