using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Infraestructure.Context;
using HomeFinancialControl.Infraestructure.Generics;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;

namespace HomeFinancialControl.Infraestructure.Repositories
{
    public class MovementRepository : Repository<Movement>, IMovementRepository
    {
        private readonly IMyDbContext _context;

        public MovementRepository(IMyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
