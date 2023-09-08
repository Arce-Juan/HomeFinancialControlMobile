using HomeFinancialControl.Domain.Entities;
using System.Collections.Generic;

namespace HomeFinancialControl.Presentation.ViewModels
{
    public class AddMovementViewModel
    {
        public List<Concept> Concepts { get; set; }
        public List<string> ConceptNames { get; set; }
    }
}
