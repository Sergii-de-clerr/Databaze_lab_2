using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Databaze_lab_2
{
    public partial class Hotel
    {
        public Hotel()
        {
            Stages = new HashSet<Stage>();
        }

        public int HotelId { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        [Display(Name = "Назва готелю")]
        public string HotelName { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        [Display(Name = "Категорія сервісу")]
        public string CategoryOfTheService { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        [Display(Name = "Номер міста")]
        public int? CityId { get; set; }

        public virtual City City { get; set; }
        public virtual ICollection<Stage> Stages { get; set; }
    }
}
