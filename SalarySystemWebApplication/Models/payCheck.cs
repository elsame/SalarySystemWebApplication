using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalarySystemWebApplication.Models
{
    public class payCheck
    {
        public int Id { get; set; }
        public int IdLaunthegi { get; set; }
        public byte[] launasedillprent { get; set; }
        public DateTime timiFra { get; set; }
        public DateTime timiTil { get; set; }
        public int IdLaunagreidsla { get; set; }
        public int IdRskSkilagrein { get; set; }
        public int IdLifeyrirSkilagrein { get; set; }
        public int astand { get; set; }
    }
}