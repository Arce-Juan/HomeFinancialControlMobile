using HomeFinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinancialControl.Domain.Services.Movements
{
    public interface IMovementService
    {
        Task AddMovementAsync(Movement movement);
        Task<List<Movement>> GetAllMovementsAsync(DateTime startDate, DateTime endDate);
    }
}
