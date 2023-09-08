using HomeFinancialControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace HomeFinancialControl.Presentation.ViewModels
{
    public class MovementListViewModel
    {
        public List<MovementViewModel> Movements { get; set; }
        public string TotalRevenues { get; set; }
        public string TotalExpenses { get; set; }
        public string Total { get; set; }
    }
}
