using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class jobCatagoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út heiti.")]
        public string name { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út lykil.")]
        public string key { get; set; }
        public int status { get; set; }

        public IEnumerable<SelectListItem> jobCatagoryList { get; set; }
        public IEnumerable<jobCatagoryModel> salaryCatagoryList { get; set; }
    }
}