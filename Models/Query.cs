using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Databaze_lab_2.Models
{
    public class Query
    {
        public string QueryId { get; set; }

        public string Error { get; set; }
        public int ErrorFlag { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        public int Seredne { get; set; }
        public string TourName { get; set; }
        public string TouristName { get; set; }
        public string HotelName { get; set; }
        public string CountryName { get; set; }
        public string TransportName { get; set; }

        public List<string> ToursNames { get; set; }
        public List<string> TouristsNames { get; set; }
        public List<string> HotelsNames { get; set; }
        public List<string> CountriesNames { get; set; }
        public List<string> TransportsNames { get; set; }
    }
}
