using DynamicObjects.Application.Dtos;
using DynamicObjects.Domain.Repositories;

namespace DynamicObjects.Application.UseCases;

public class DeleteDynamicObjectUseCase
{
	private readonly IDynamicObjectRepository _repository;

	public DeleteDynamicObjectUseCase(IDynamicObjectRepository repository)
	{
		_repository = repository;
	}

	public async Task ExecuteAsync(DeleteDynamicObjectDto dto)
	{
		await _repository.DeleteAsync(dto.Id);
	}
}

