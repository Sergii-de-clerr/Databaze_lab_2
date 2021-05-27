using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Databaze_lab_2
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int CountryId { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        [Display(Name = "Назва країни")]
        public string CountryName { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
