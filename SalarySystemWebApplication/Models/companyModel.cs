using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class companyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út kennitölu.")]
        [RegularExpression("(\\d)*", ErrorMessage = "Kennitala þarf að vera tölustafir")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Kennitala verður að vera 10 tölustafir")]
        [DataType("PersonalId")]
        public string personalId { get; set; }
        [Required(ErrorMessage = "Vinsamlegast fyllið út nafn.")]
        public string name { get; set; }
        public string home { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Póstnúmer þarf að vera tölustafir")]
        public string postalCode { get; set; }
        public string city { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Símanúmer þarf að vera tölustafir")]
        public string phoneNumber { get; set; }
        public string job { get; set; }
        public string sectorCodes { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Bankanúmer þarf að vera tölustafir")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Bankanúmer verður að vera 12 tölustafir")]
        public string bankNumber { get; set; }
    }
}