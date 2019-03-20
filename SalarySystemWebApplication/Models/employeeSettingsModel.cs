using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SalarySystemWebApplication.Models
{
    public class employeeSettingsModel
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime worktimeFrom { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime worktimeTo { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út starfshlutfall")]
        public int jobPercentage { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út föst laun")]
        public int fixedSalary { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út tímakaup")]
        public int hourly { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út bílastyrk")]
        public int carBenefits { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út dagpeninga")]
        public int dailyallowance { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út yfirvinnu")]
        public int overtime { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út vaktaálag")]
        public int shiftWork { get; set; }
        public bool remuneration { get; set; }
        public bool calculateVehicleTax { get; set; }
        public bool calculatePaymentOfDailyAllowance { get; set; }
        public bool salaryOnAccount { get; set; }
        public bool vacationOnAccount { get; set; }
        public bool idStatus { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime personalDiscountFrom { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út önnur laun")]
        public int otherWages { get; set; }
        public int employeeModelId { get; set; }
        public int amountPercent { get; set; }
        public int amountSpousePercent { get; set; }

        // public virtual employeeModel employeeModel { get; set; }

        public IEnumerable<SelectListItem> employeeList { get; set; }
        public virtual personalDiscountModel personalDiscountModel { get; set; }

    }
}