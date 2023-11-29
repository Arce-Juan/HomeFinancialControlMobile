using HomeFinancialControl.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeFinancialControl.Domain.Services.Concepts
{
    public interface IConceptService
    {
        Task<List<Concept>> GetAllConceptAsync();
        Task<Concept> GetConceptByIdAsync(int id);
        Task<Concept> GetConceptByNameAsync(string name);
        Task<List<Concept>> GetConceptsByNameAsync(string name);
        Task AddConceptAsync(Concept concept);
        Task ModifyConceptAsync(Concept concept);
        Task DeleteConceptAsync(int id);
        List<string> GetAllCategories();
        List<string> GetAllConceptTypes();
    }
}
