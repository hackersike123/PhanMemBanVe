// Minimal stubs to allow project to compile without EntityFramework NuGet package.
// Temporary only. Replace with real EF package.
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Resources;

namespace System.Data.Entity
{
    public class DbContext : IDisposable
    {
        public DbContext(string nameOrConnectionString) { Database = new Database(); }
        public void Dispose() { }
        public Database Database { get; }
        public virtual int SaveChanges() => 0;
        public DbSet<T> Set<T>() where T : class => new DbSet<T>();
        protected virtual void OnModelCreating(DbModelBuilder modelBuilder) { }
    }

    public class Database { public void Initialize(bool force) { } }

    public class DbSet<T> : IQueryable<T>, IEnumerable<T> where T : class
    {
        private readonly List<T> _data = new List<T>();
        public T Add(T entity) { _data.Add(entity); return entity; }
        public void AddRange(IEnumerable<T> entities) { _data.AddRange(entities); }
        public IEnumerator<T> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
        public Type ElementType => typeof(T);
        public Expression Expression => _data.AsQueryable().Expression;
        public IQueryProvider Provider => _data.AsQueryable().Provider;
    }

    public static class QueryableExtensions
    {
        public static IQueryable<T> Include<T, TProp>(this IQueryable<T> source, Expression<Func<T, TProp>> path) => source;
        public static IQueryable<T> AsNoTracking<T>(this IQueryable<T> source) => source;
    }

    public class DbModelBuilder { public ConventionCollection Conventions { get; } = new ConventionCollection(); }
    public class ConventionCollection { public void Remove<TConvention>() { } }
}

namespace System.Data.Entity.ModelConfiguration.Conventions
{ public class PluralizingTableNameConvention { } }

namespace System.Data.Entity.Migrations
{
    public abstract class DbMigration
    {
        protected void CreateTable(string name, Func<ColumnsBuilder, object> columns) { }
        protected void DropTable(string name) { }
        public virtual void Up() { }
        public virtual void Down() { }
    }
    public class ColumnsBuilder { }

    public abstract class DbMigrationsConfiguration<TContext>
    {
        public bool AutomaticMigrationsEnabled { get; set; }
        public virtual void Seed(TContext context) { }
    }
}

namespace System.Data.Entity.Migrations.Infrastructure
{
    public interface IMigrationMetadata
    {
        string Id { get; }
        string Source { get; }
        string Target { get; }
    }
}

namespace System.ComponentModel.DataAnnotations.Schema
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class, AllowMultiple = true)]
    public sealed class IndexAttribute : Attribute
    {
        public IndexAttribute(string name) { Name = name; }
        public string Name { get; }
        public int Order { get; set; }
        public bool IsUnique { get; set; }
    }
}
