using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalarySystemWebApplication.Models
{
    public class pensionFundModel
    {
        public int Id { get; set; }
        public string number { get; set; }
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
        [RegularExpression("(\\d)*", ErrorMessage = "Iðgjald þarf að vera tölustafir")]
        public double premium { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Séreign þarf að vera tölustafir")]
        public double privateProperty { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Orlofssjóður þarf að vera tölustafir")]
        public double vacationFund { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Starfsmenntun þarf að vera tölustafir")]
        public double training { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Sjúkrasjóður þarf að vera tölustafir")]
        public double nationalHealth { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Mótframlag þarf að vera tölustafir")]
        public double matchingFounds { get; set; }
        [RegularExpression("(\\d)*", ErrorMessage = "Mótframl. sér. þarf að vera tölustafir")]
        public double privateMatchingFounds { get; set; }
        public bool active { get; set; }

        public IEnumerable<pensionFundModel> pensionList { get; set; }
    }
}