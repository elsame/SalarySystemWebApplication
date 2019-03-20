using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SalarySystemWebApplication.Models
{
    public class taxItems
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út heiti")]
        public string name { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út lykil.")]
        public string key { get; set; }
        public double value { get; set; }
        public bool percentage { get; set; }
        public bool onNote { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime activeFrom { get; set; }
        public bool active { get; set; }

        public IEnumerable<taxItems> taxItemList { get; set; }
    }
}