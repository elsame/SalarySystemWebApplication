using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SalarySystemWebApplication.Models
{
    public class settings
    {

        public static string address()
        {

            //return "http://launakerfirestservice20190310080633.azurewebsites.net/";

            return ConfigurationManager.AppSettings["ServiceUrl"];

            //return "http://localhost:52949";
        }
    }
}