using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace HomeFinancialControl.Infraestructure.Context
{
    public interface IMyDbContext : IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}
