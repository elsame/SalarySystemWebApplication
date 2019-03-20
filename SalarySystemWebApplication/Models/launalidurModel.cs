using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class launalidurModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út heiti.")]
        public string heiti { get; set; }
        public int gildi { get; set; }
        public string skyring { get; set; }
        public bool prosenta { get; set; }
        public bool fradrattur { get; set; }
        public bool asedli { get; set; }
        public int idAstand { get; set; }

        public IEnumerable<SelectListItem> launalidurList { get; set; }
        public IEnumerable<launalidurModel> salaryItemList { get; set; }
    }
}