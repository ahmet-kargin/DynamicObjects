using DynamicObjects.Application.Dtos;
using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.Repositories;

namespace DynamicObjects.Application.UseCases;

public class UpdateDynamicObjectUseCase
{
	private readonly IDynamicObjectRepository _repository;

	public UpdateDynamicObjectUseCase(IDynamicObjectRepository repository)
	{
		_repository = repository;
	}

	public async Task ExecuteAsync(Guid id, UpdateDynamicObjectDto dto)
	{
		// Mevcut dynamic object'ı veritabanından al
		var existingObject = await _repository.GetByIdAsync(id);
		if (existingObject == null)
		{
			throw new Exception("Dynamic object not found.");
		}

		// Güncelleme işlemi
		existingObject.Fields.Clear(); // Mevcut alanları temizle
		foreach (var field in dto.Fields)
		{
			existingObject.AddField(field.Key, field.Value); // Yeni alanları ekle
		}

		// Güncellemeyi yap
		await _repository.UpdateAsync(existingObject);
	}
}

