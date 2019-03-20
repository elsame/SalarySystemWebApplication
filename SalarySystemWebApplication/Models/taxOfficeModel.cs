using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class taxOfficeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út kennitölu.")]
        [RegularExpression("(\\d)*", ErrorMessage = "Kennitala þarf að vera tölustafir")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Kennitala verður að vera 10 tölustafir")]
        [DataType("PersonalId")]
        public string personalId { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út nafn.")]
        public string name { get; set; }
        public string address { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Póstnúmer þarf að vera tölustafir")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "Póstnúmer verður að vera 3 tölustafir")]
        public string postalCode { get; set; }
        public string city { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Símanúmer þarf að vera tölustafir")]
        public string phoneNumber { get; set; }
        public bool active { get; set; }

        public IEnumerable<taxOfficeModel> taxOfficeList { get; set; }
    }
}