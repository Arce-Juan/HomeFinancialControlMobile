using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;
using System.Collections.Generic;
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

        public async Task AddMovement(Movement movement)
        {
            await _movementRepository.AddAsync(movement);
        }

        public async Task<List<Movement>> GetAllMovementsAsync()
        {
            var movements = await _movementRepository.GetAllAsyncWhitInclude(m => m.Concept);
            return movements;
        }
    }
}
