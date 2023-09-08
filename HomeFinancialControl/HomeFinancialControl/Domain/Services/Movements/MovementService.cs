using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinancialControl.Domain.Services.Movements
{
    public class MovementService: IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task AddMovementAsync(Movement movement)
        {
            await _movementRepository.AddAsync(movement);
        }

        public async Task<List<Movement>> GetAllMovementsAsync(DateTime startDate, DateTime endDate)
        {
            var movements = await _movementRepository.GetAllAsyncWhitInclude(m => m.Concept);
            movements = movements.Where(m => startDate.Date <= m.Date.Date && m.Date.Date <= endDate.Date).ToList();
            return movements;
        }
    }
}
