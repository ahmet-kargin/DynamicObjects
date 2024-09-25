using DynamicObjects.Domain.Entities;
using DynamicObjects.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DynamicObjects.Infrastructure.Persistence;

public class DynamicDbContext : DbContext
{
	public DbSet<DynamicObject> DynamicObjects { get; set; }
	public DbSet<DynamicField> DynamicFields { get; set; }
	public DynamicDbContext(DbContextOptions<DynamicDbContext> options)
	: base(options) { }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
		modelBuilder.Entity<DynamicObject>()
			.OwnsMany(p => p.Fields, a =>
			{
				a.WithOwner().HasForeignKey("DynamicObjectId");
			});
	}
}
