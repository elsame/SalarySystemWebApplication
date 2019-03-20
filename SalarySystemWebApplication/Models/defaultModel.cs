using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalarySystemWebApplication.Models
{
    public class defaultModel
    {
        public companyModel Company { get; set; }
        public employeeModel Employee { get; set; }
        public launalidurModel Launalidur { get; set; }
        public employeeSettingsModel employeeSettings { get; set; }
        public IEnumerable<SelectListItem> OtherPaymentsList { get; set; }
        public employeeFeesModels employeeFees { get; set; }
        public int otherPayments1 { get; set; }
        public int otherPayments2 { get; set; }
    }
}