using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Databaze_lab_2
{
    public partial class Transport
    {
        public Transport()
        {
            Stages = new HashSet<Stage>();
        }

        public int TransportId { get; set; }

        [Required(ErrorMessage = "Це поле повинно бути заповнене")]
        [Display(Name = "Назва транспорту")]
        public string TransportName { get; set; }

        public virtual ICollection<Stage> Stages { get; set; }
    }
}
