using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogAplication.Models;

namespace BlogAplication.ViewModels.NewsViewModels
{
    public class NewsFilterViewModel
    {
        public NewsFilterViewModel(string request, DateTime FirstDate, DateTime SecondDate)
        {
            InputRequest = request;
            SelectedFirstDate = FirstDate;
            SelectedSecondDate = SecondDate;
        }
        public string InputRequest { get; private set; }
        public DateTime SelectedFirstDate { get; private set; }
        public DateTime SelectedSecondDate { get; private set; }
    }
}
