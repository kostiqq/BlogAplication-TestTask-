using System.Collections.Generic;

namespace BlogAplication.ViewModels.ProcedureViewModels
{
    public class ProcedureViewModel
    {
        public IEnumerable<object[]> Objects { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
