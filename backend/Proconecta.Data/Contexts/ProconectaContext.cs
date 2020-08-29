namespace Proconecta.Data.Contexts
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Proconecta.Data.Interfaces;

    public class ProconectaContext : DbContext
    {
        #region Properties
        public DbSet<User> Users { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        #region Constructors
        public ProconectaContext(DbContextOptions<ProconectaContext> options)
            : base(options) { }
        #endregion

        #region Override Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Configure Entities
            ApplyUtcKind(modelBuilder);
            #endregion

            #region Global Query Filters
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Provider>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Project>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(p => !p.IsDeleted);
            #endregion
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            UpdateSoftDeleteStatuses();
            AuditUpsertDate();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            ChangeTracker.DetectChanges();
            UpdateSoftDeleteStatuses();
            AuditUpsertDate();
            SetDatesToUtc();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        #endregion

        #region Private Methods

        private void ApplyUtcKind(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(DateTime))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime>(property.Name)
                         .HasConversion(
                          v => v,
                          v => DateTime.SpecifyKind(v, DateTimeKind.Utc));
                    }
                    else if (property.ClrType == typeof(DateTime?))
                    {
                        modelBuilder.Entity(entityType.ClrType)
                         .Property<DateTime?>(property.Name)
                         .HasConversion(
                          v => v,
                          v => v.HasValue
                            ? DateTime.SpecifyKind(v.Value, DateTimeKind.Utc) : v);
                    }
                }
            }
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is IIsDeleted)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            item.CurrentValues["IsDeleted"] = false;
                            break;
                        case EntityState.Deleted:
                            item.State = EntityState.Modified;
                            item.CurrentValues["IsDeleted"] = true;
                            break;
                    }
                }

            }
        }

        private void AuditUpsertDate()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is IAduit)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            item.CurrentValues["Version"] = Convert
                                .ToInt32(item.CurrentValues["Version"]) + 1;
                            var now = DateTime.Now;
                            if (item.CurrentValues["UpdatedAt"] != null)
                            {
                                item.CurrentValues["UpdatedAt"] = now;
                            }
                            item.CurrentValues["CreatedAt"] = now;
                            break;
                        case EntityState.Modified:
                            var isDeleted = (bool?)item.CurrentValues["IsDeleted"];
                            if (!isDeleted.Value)
                            {
                                item.CurrentValues["Version"] = Convert
                                .ToInt32(item.CurrentValues["Version"]) + 1;
                            }
                            item.CurrentValues["UpdatedAt"] = DateTime.Now;
                            break;
                        case EntityState.Deleted:
                            item.CurrentValues["UpdatedAt"] = DateTime.Now;
                            break;
                    }
                }

            }
        }

        private void SetDatesToUtc()
        {
            var marked = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                    x.State == EntityState.Modified ||
                    x.State == EntityState.Deleted);

            foreach (var item in marked)
            {
                foreach (var property in item.CurrentValues.Properties)
                {
                    var type = property.PropertyInfo.PropertyType;

                    if (typeof(DateTime) == type)
                    {
                        var value = item.CurrentValues
                            .GetValue<DateTime>(property.PropertyInfo.Name);

                        if (value.Kind == DateTimeKind.Local ||
                            value.Kind == DateTimeKind.Unspecified)
                        {
                            item.CurrentValues[property.Name] = value
                                .ToUniversalTime();
                        }
                    }

                    if (typeof(DateTime?) == type)
                    {
                        var value = item.CurrentValues
                            .GetValue<DateTime?>(property.PropertyInfo.Name);

                        if (value != null)
                        {
                            if (value?.Kind == DateTimeKind.Local ||
                                value?.Kind == DateTimeKind.Unspecified)
                            {
                                item.CurrentValues[property.Name] = value.Value
                                    .ToUniversalTime();
                            }
                        }
                    }
                }
            }
        }

        #endregion
    }
}
