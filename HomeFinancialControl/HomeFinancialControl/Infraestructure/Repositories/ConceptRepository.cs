using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Infraestructure.Context;
using HomeFinancialControl.Infraestructure.Generics;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;

namespace HomeFinancialControl.Infraestructure.Repositories
{
    public class ConceptRepository : Repository<Concept>, IConceptRepository
    {
        private readonly IMyDbContext _context;

        public ConceptRepository(IMyDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
