using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAplication.ViewModels.ProcedureViewModels
{
    public class FilterViewModel
    {
        public SelectList News { get; private set; }
        public SelectList Objects { get; private set; }
        public int? SelectedNews { get; private set; }

        public string FirstDate { get; private set; }
        public string SecondDate { get; private set; }

        public FilterViewModel(List <object[]> objects, string d0, string d)
        {
            objects.Insert(0, new object[] { "", "" });
            Objects = new SelectList(objects);
            FirstDate = d0;
            SecondDate = d;
        }
    }
}
