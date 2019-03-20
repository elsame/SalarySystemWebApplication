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
    public class EmployeeController : Controller
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

        // GET: Employee
        public async Task<ActionResult> Index()
        {
            employeeModel emp = new employeeModel();
            emp.status = true;
            List<groupModel> groupInfo = new List<groupModel>();

            emp.group = new groupModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/groupModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    groupInfo = JsonConvert.DeserializeObject<List<groupModel>>(EmpResponse);

                }

                emp.group.groupList = new SelectList(groupInfo, "Id", "name");

                emp.jobCatagory = new jobCatagoryModel();
                List<jobCatagoryModel> jobCatagoryInfo = new List<jobCatagoryModel>();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/jobCatagoryModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    jobCatagoryInfo = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(EmpResponse);

                }

                emp.jobCatagory.jobCatagoryList = new SelectList(jobCatagoryInfo, "Id", "name", 1);

                Res = await client.GetAsync("api/employeeModels");
                emp.employeeListNotSelect = new List<employeeModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    emp.employeeListNotSelect = JsonConvert.DeserializeObject<List<employeeModel>>(EmpResponse);

                }

            }


            return View(emp);
        }

        [HttpPost]
        public async Task<ActionResult> Index(employeeModel emp)
        {
            //employeeModel emp = new employeeModel();

            try
            {
                if (ModelState.IsValid)
                {
                    emp.status = true;

                    // TODO: Add update logic here
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(emp));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/employeeModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();
                       
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    emp.status = true;
                    List<groupModel> groupInfo = new List<groupModel>();

                    emp.group = new groupModel();

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.GetAsync("api/groupModels");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            groupInfo = JsonConvert.DeserializeObject<List<groupModel>>(EmpResponse);

                        }

                        emp.group.groupList = new SelectList(groupInfo, "Id", "name");

                        emp.jobCatagory = new jobCatagoryModel();
                        List<jobCatagoryModel> jobCatagoryInfo = new List<jobCatagoryModel>();

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        Res = await client.GetAsync("api/jobCatagoryModels");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            jobCatagoryInfo = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(EmpResponse);

                        }

                        emp.jobCatagory.jobCatagoryList = new SelectList(jobCatagoryInfo, "Id", "name", 1);

                        Res = await client.GetAsync("api/employeeModels");
                        emp.employeeListNotSelect = new List<employeeModel>();

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            emp.employeeListNotSelect = JsonConvert.DeserializeObject<List<employeeModel>>(EmpResponse);

                        }

                    }
                    return View(emp);
                }

                
            }

            catch
            {
                return RedirectToAction("Index");
            }
            
        }

        public async Task<ActionResult> Delete(int id)
        {

            try
            {
                // TODO: Add update logic here
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/employeeModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            employeeModel emp = new employeeModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/employeeModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    emp = JsonConvert.DeserializeObject<employeeModel>(EmpResponse);

                }

                List<groupModel> groupInfo = new List<groupModel>();

                emp.group = new groupModel();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/groupModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    groupInfo = JsonConvert.DeserializeObject<List<groupModel>>(EmpResponse);

                }

                emp.group.groupList = new SelectList(groupInfo, "Id", "name", emp.idGroup);

                emp.jobCatagory = new jobCatagoryModel();
                List<jobCatagoryModel> jobCatagoryInfo = new List<jobCatagoryModel>();

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                Res = await client.GetAsync("api/jobCatagoryModels");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    jobCatagoryInfo = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(EmpResponse);

                }

                emp.jobCatagory.jobCatagoryList = new SelectList(jobCatagoryInfo, "Id", "name", emp.IdJobCatagory);

                return View(emp);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, employeeModel emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);

                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(emp));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/employeeModels/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
                else
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                       
                        List<groupModel> groupInfo = new List<groupModel>();

                        emp.group = new groupModel();

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.GetAsync("api/groupModels");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            groupInfo = JsonConvert.DeserializeObject<List<groupModel>>(EmpResponse);

                        }

                        emp.group.groupList = new SelectList(groupInfo, "Id", "name", emp.idGroup);

                        emp.jobCatagory = new jobCatagoryModel();
                        List<jobCatagoryModel> jobCatagoryInfo = new List<jobCatagoryModel>();

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        Res = await client.GetAsync("api/jobCatagoryModels");

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                            //Deserializing the response recieved from web api and storing into the Employee list  
                            jobCatagoryInfo = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(EmpResponse);

                        }

                        emp.jobCatagory.jobCatagoryList = new SelectList(jobCatagoryInfo, "Id", "name", emp.IdJobCatagory);

                        return View(emp);
                    }
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }
    }
}