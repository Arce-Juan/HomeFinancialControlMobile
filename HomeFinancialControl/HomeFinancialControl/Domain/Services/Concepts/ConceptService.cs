namespace HomeFinancialControl.Domain.Services.Concepts
{
    public class ConceptService : IConceptService
    {
        private readonly IConceptService _conceptService;

        public ConceptService(IConceptService conceptService)
        {
            _conceptService = conceptService;
        }
    }
}
