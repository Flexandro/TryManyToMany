using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppTest1.Models
{
    public class Men
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Metti Nome")]
        [Display(Name = "Nome uomo")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Metti Cognome")]
        [Display(Name = "Cognome uomo")]
        public string LastName { get; set; }

        public ICollection<MormonsPartner> Partners { get; set; }

    }
}
