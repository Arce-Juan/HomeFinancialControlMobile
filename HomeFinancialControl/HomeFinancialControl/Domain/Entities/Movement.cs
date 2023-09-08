using System;

namespace HomeFinancialControl.Domain.Entities
{
    public class Movement
    {
        public int Id { get; set; }
        public int ConceptId { get; set; }
        public Concept Concept { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}
