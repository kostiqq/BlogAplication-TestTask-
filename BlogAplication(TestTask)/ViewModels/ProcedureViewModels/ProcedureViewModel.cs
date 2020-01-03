using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAplication.ViewModels.ProcedureViewModels;

namespace BlogAplication.ViewModels.ProcedureViewModels
{
    public class ProcedureViewModel
    {
        public IEnumerable<object[]> Objects { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
    }
}
