namespace HomeFinancialControl.Domain.Entities
{
    public class Concept
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
    }
}
