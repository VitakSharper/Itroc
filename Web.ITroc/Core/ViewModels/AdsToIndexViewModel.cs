using System;

namespace Web.ITroc.Core.ViewModels
{
    public class AdsToIndexViewModel
    {
        public int Id { get; set; }
        public DateTime AdCreate { get; set; }
        public string AdTitle { get; set; }
        public string AdDescription { get; set; }
        public string PhotoAd { get; set; }
    }
}