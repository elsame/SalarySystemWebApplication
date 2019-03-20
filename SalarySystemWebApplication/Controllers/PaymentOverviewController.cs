using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SalarySystemWebApplication.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;

namespace SalarySystemWebApplication.Controllers
{
    public class PaymentOverviewController : Controller
    {
        // GET: Default
        //Hosted web API REST Service base url  
        string Baseurl = settings.address();

        private void setClientSettings(HttpClient client)
        {
            //Passing service base url  
            client.BaseAddress = new Uri(Baseurl);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<ActionResult> Index()
        {
            employeeModel emp = new employeeModel();
            List<employeeModel> EmpInfo = new List<employeeModel>();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/employeeModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<employeeModel>>(EmpResponse);

                }
            }

            emp.employeeList = new SelectList(EmpInfo, "Id", "name");
            return View(emp);
        }
    }
}