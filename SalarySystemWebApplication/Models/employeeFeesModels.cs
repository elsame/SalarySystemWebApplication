using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class employeeFeesModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út félagsgjald")]
        public double membershipFee { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út iðgjald")]
        public double premium { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út séreign")]
        public double privateProperty { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út orlofssjóð")]
        public double vacationFund { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út starfsmenntun")]
        public double training { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út sjukrasjóð")]
        public double nationalHealth { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út mótframlag lífeyris")]
        public double matchingFounds { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út mótframlag séreign")]
        public double privateMatchingFounds { get; set; }
        public int employeeModelId { get; set; }
        public int unionModelId { get; set; }
        public int pensionFundModelId { get; set; }
        public int privatePensionFundModelId { get; set; }

        public IEnumerable<SelectListItem> unionList { get; set; }
        public IEnumerable<SelectListItem> pensionFundList { get; set; }
        public IEnumerable<SelectListItem> employeeList { get; set; }
    }
}