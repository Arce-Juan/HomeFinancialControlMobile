using HomeFinancialControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinancialControl.Domain.Services.Movements
{
    public interface IMovementService
    {
        Task AddMovement(Movement movement);
        Task<List<Movement>> GetAllMovementsAsync();
    }
}
