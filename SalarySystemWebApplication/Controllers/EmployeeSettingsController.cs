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
    public class EmployeeSettingsController : Controller
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

        // GET: EmployeeSettings
        public async Task<ActionResult> Index(int? employeeModelId)
        {
            List<employeeModel> EmpInfo = new List<employeeModel>();
            employeeSettingsModel settings = new employeeSettingsModel();

            settings.worktimeTo = DateTime.Today;
            settings.worktimeFrom = DateTime.Today;
            settings.personalDiscountFrom = DateTime.Today;

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

                //string idEmployee = Request["EmployeeSettings"];

                if (employeeModelId != null)
                {
                    Res = await client.GetAsync("api/employeeSettingsModels/" + employeeModelId);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        settings = JsonConvert.DeserializeObject<employeeSettingsModel>(EmpResponse);

                    }
                }
            }

            settings.employeeList = new SelectList(EmpInfo, "Id", "name");

            return View(settings);
        }

        [HttpPost]
        public async Task<ActionResult> Index(int? employeeModelId, employeeSettingsModel settings)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (settings.Id != 0)
                    {
                        using (var client = new HttpClient())
                        {
                            setClientSettings(client);

                            //serialize object to Json and create the HttpContent
                            HttpContent content = new StringContent(JsonConvert.SerializeObject(settings));
                            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                            HttpResponseMessage Res = await client.PutAsync("api/employeeSettingsModels/" + settings.Id, content);

                            //Checking the response is successful or not which is sent using HttpClient  
                            if (Res.IsSuccessStatusCode)
                            {
                                //Storing the response details recieved from web api   
                                var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                            }
                        }
                    }
                    else
                    {
                        using (var client = new HttpClient())
                        {
                            setClientSettings(client);
                            //serialize object to Json and create the HttpContent
                            HttpContent content = new StringContent(JsonConvert.SerializeObject(settings));
                            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                            //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                            HttpResponseMessage Res = await client.PostAsync("api/employeeSettingsModels/", content);

                            //Checking the response is successful or not which is sent using HttpClient  
                            if (Res.IsSuccessStatusCode)
                            {
                                //Storing the response details recieved from web api   
                                var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                            }

                        }
                    }

                    //return RedirectToAction("Index");
                }

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

                    //string idEmployee = Request["EmployeeSettings"];

                    if (employeeModelId != null)
                    {
                        Res = await client.GetAsync("api/employeeSettingsModels/" + employeeModelId);

                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            settings = JsonConvert.DeserializeObject<employeeSettingsModel>(EmpResponse);

                        }
                    }
                }

                settings.employeeList = new SelectList(EmpInfo, "Id", "name");

                return View(settings);

            }

            catch
            {
                return View(settings);
            }
        }

        public async Task<ActionResult> EmployeeFees(int? employeeModelId)
        {
            employeeFeesModels employeeFees = new employeeFeesModels();

            List<employeeModel> EmpInfo = new List<employeeModel>();
            List<unionModel> unionInfo = new List<unionModel>();
            List<pensionFundModel> pensionInfo = new List<pensionFundModel>();

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

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/unionModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    unionInfo = JsonConvert.DeserializeObject<List<unionModel>>(EmpResponse);

                }

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/pensionFundModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pensionInfo = JsonConvert.DeserializeObject<List<pensionFundModel>>(EmpResponse);

                }

                if (employeeModelId != null)
                {
                    Res = await client.GetAsync("api/employeeFees/" + employeeModelId);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        employeeFees = JsonConvert.DeserializeObject<employeeFeesModels>(EmpResponse);

                    }
                }
            }

            employeeFees.employeeList = new SelectList(EmpInfo, "Id", "name");
            employeeFees.unionList = new SelectList(unionInfo, "Id", "name");
            employeeFees.pensionFundList = new SelectList(pensionInfo, "Id", "name");

            return View(employeeFees);
        }

        [HttpPost]
        public async Task<ActionResult> EmployeeFees(int? employeeModelId, employeeFeesModels employeeFees)
        {
            if (ModelState.IsValid)
            {
                if (employeeFees.Id != 0)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);

                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(employeeFees));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/employeeFees/" + employeeFees.Id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }
                    }
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(employeeFees));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/employeeFees/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }
                }

                //return RedirectToAction("EmployeeFees", employeeFees.employeeModelId);
            }

            List<employeeModel> EmpInfo = new List<employeeModel>();
            List<unionModel> unionInfo = new List<unionModel>();
            List<pensionFundModel> pensionInfo = new List<pensionFundModel>();

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

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/unionModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    unionInfo = JsonConvert.DeserializeObject<List<unionModel>>(EmpResponse);

                }

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/pensionFundModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pensionInfo = JsonConvert.DeserializeObject<List<pensionFundModel>>(EmpResponse);

                }

                if (employeeModelId != null)
                {
                    Res = await client.GetAsync("api/employeeFees/" + employeeModelId);

                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        employeeFees = JsonConvert.DeserializeObject<employeeFeesModels>(EmpResponse);

                    }
                }
            }

            employeeFees.employeeList = new SelectList(EmpInfo, "Id", "name");
            employeeFees.unionList = new SelectList(unionInfo, "Id", "name");
            employeeFees.pensionFundList = new SelectList(pensionInfo, "Id", "name");

            return View(employeeFees);
        }
    }
}