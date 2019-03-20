using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class groupModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út heiti.")]
        public string name { get; set; }
        public int status { get; set; }

        public IEnumerable<SelectListItem> groupList { get; set; }
        public IEnumerable<groupModel> salaryGroupList { get; set; }
    }
}