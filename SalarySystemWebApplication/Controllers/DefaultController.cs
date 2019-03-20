using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using SalarySystemWebApplication.Models;

namespace SalarySystemWebApplication.Controllers
{
    public class DefaultController : Controller
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

        // GET: Default
        public async Task<ActionResult> Index()
        {
            //companyModel companyInfo = new companyModel();
            defaultModel defaultInfo = new defaultModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/companyModels/1");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var companyResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    defaultInfo.Company = JsonConvert.DeserializeObject<companyModel>(companyResponse);

                }

                List<employeeModel> EmpInfo = new List<employeeModel>();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/employeeModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    EmpInfo = JsonConvert.DeserializeObject<List<employeeModel>>(EmpResponse);

                }

                List<launalidurModel> launalidurInfo = new List<launalidurModel>();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/launalidurModels?fradrattur=false&aSedli=true");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    launalidurInfo = JsonConvert.DeserializeObject<List<launalidurModel>>(EmpResponse);

                }
                defaultInfo.Launalidur = new launalidurModel();
                defaultInfo.Launalidur.launalidurList = new SelectList(launalidurInfo, "gildi", "heiti");

                List<launalidurModel> OtherPaymentsList = new List<launalidurModel>();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/launalidurModels?fradrattur=false&aSedli=false");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    OtherPaymentsList = JsonConvert.DeserializeObject<List<launalidurModel>>(EmpResponse);

                }

                defaultInfo.OtherPaymentsList = new SelectList(OtherPaymentsList, "gildi", "heiti");

                string idEmployee = Request["Employee.name"];
                defaultInfo.Employee = new employeeModel();

                if (idEmployee != null)
                {
                    Res = await client.GetAsync("api/employeeModels/" + idEmployee);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        defaultInfo.Employee = JsonConvert.DeserializeObject<employeeModel>(EmpResponse);
                    }

                    Res = await client.GetAsync("api/employeeSettingsModels/" + idEmployee);

                    defaultInfo.employeeSettings = new employeeSettingsModel();

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        defaultInfo.employeeSettings = JsonConvert.DeserializeObject<employeeSettingsModel>(EmpResponse);

                    }

                    Res = await client.GetAsync("api/employeeFees/" + idEmployee);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        defaultInfo.employeeFees = JsonConvert.DeserializeObject<employeeFeesModels>(EmpResponse);

                    }
                }

                defaultInfo.Employee.employeeList = new SelectList(EmpInfo, "Id", "name");

                //returning the employee list to view  
                return View(defaultInfo);
            }
        }

        public async Task<ActionResult> Details()
        {
            //companyModel companyInfo = new companyModel();
            /* defaultModel defaultInfo = new defaultModel();

             using (var client = new HttpClient())
             {
                 setClientSettings(client);
                 //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                 HttpResponseMessage Res = await client.GetAsync("api/companyModels/1");

                 //Checking the response is successful or not which is sent using HttpClient  
                 if (Res.IsSuccessStatusCode)
                 {
                     //Storing the response details recieved from web api   
                     var companyResponse = Res.Content.ReadAsStringAsync().Result;

                     //Deserializing the response recieved from web api and storing into the Employee list  
                     defaultInfo.Company = JsonConvert.DeserializeObject<companyModel>(companyResponse);

                 }
                 //returning the employee list to view  
                 return View(defaultInfo);
             }*/

            return View();
        }

        public ActionResult fyrirtaeki()
        {
            companyModel companyInfo = new companyModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                var Res = client.GetAsync("api/companyModels/1").Result;

                if (Res.IsSuccessStatusCode)
                {
                    var responseContent = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    companyInfo = JsonConvert.DeserializeObject<companyModel>(responseContent);

                }

                return PartialView(companyInfo);
            }
        }
    }
}