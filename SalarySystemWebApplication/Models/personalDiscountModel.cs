using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalarySystemWebApplication.Models
{
    public class personalDiscountModel
    {
        public int Id { get; set; }
        public int amountPercent { get; set; }
        public int amountSpousePercent { get; set; }
    }
}