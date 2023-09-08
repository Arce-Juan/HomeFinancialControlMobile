using HomeFinancialControl.Domain.Entities;
using HomeFinancialControl.Infraestructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeFinancialControl.Domain.Services.Concepts
{
    public class ConceptService : IConceptService
    {
        private readonly IConceptRepository _conceptRepository;

        public ConceptService(IConceptRepository conceptRepository)
        {
            _conceptRepository = conceptRepository;
        }

        public async Task<List<Concept>> GetAllConceptAsync()
        {
            var concepts = await _conceptRepository.GetAllAsync();
            return concepts.OrderBy(c => c.Name).ToList();
        }

        public async Task<Concept> GetConceptByIdAsync(int id)
        {
            var concept = await _conceptRepository.GetByIdAsync(id);
            return concept;
        }

        public async Task AddConceptAsync(Concept concept)
        {
            await _conceptRepository.AddAsync(concept);
        }

        public async Task ModifyConceptAsync(Concept concept)
        {
            await _conceptRepository.AddAsync(concept);
        }

        public async Task DeleteConceptAsync(int id)
        {
            var concept = await _conceptRepository.GetByIdAsync(id);
            await _conceptRepository.DeleteAsync(concept);
        }

        public List<string> GetAllCategories()
        {
            var categories = Enum.GetValues(typeof(Category))
                    .Cast<Category>()
                    .OrderBy(x => x.ToString())
                    .Select(x => x.ToString())
                    .ToList();
            return categories;
        }

        public List<string> GetAllConceptTypes()
        {
            var conceptTypes = Enum.GetValues(typeof(ConceptType))
                           .Cast<ConceptType>()
                           .OrderBy(ct => ct.ToString())
                           .Select(ct => ct.ToString())
                           .ToList();
            return conceptTypes;
        }
    }
}
