using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class employeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út kennitölu.")]
        [RegularExpression("(\\d)*", ErrorMessage = "Kennitala þarf að vera tölustafir")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Kennitala verður að vera 10 tölustafir")]
        [DataType("PersonalId")]
        public string personalId { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út nafn.")]
        public string name { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Póstnúmer þarf að vera tölustafir")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Póstnúmer verður að vera 3 tölustafir")]
        public string postalCode { get; set; }
        public string city { get; set; }
        public bool status { get; set; }
        public string jobName { get; set; }
        public int IdJobCatagory { get; set; }
        public int salaryTotal { get; set; }
        public string email { get; set; }
        public bool electronic { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Símanúmer þarf að vera tölustafir")]
        public string phonenumber { get; set; }
        public int idGroup { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Reikningsnúmer þarf að vera tölustafir")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Póstnúmer verður að vera 12 tölustafir")]
        [DataType("BankAccount")]
        public string salaryAccount { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Reikningsnúmer þarf að vera tölustafir")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Reikningsnúmer verður að vera 12 tölustafir")]
        [DataType("BankAccount")]
        public string vacationAccount { get; set; }

        public IEnumerable<employeeModel> employeeListNotSelect { get; set; }
        public IEnumerable<SelectListItem> employeeList { get; set; }
        //public virtual employeeSettingsModel employeeSettings { get; set; }
        public jobCatagoryModel jobCatagory { get; set; }
        public groupModel group { get; set; }
        //public virtual personalDiscountModel PersonalDiscount { get; set; }
        //public virtual employeeFeesModels EmployeeFees { get; set; }


    }
}