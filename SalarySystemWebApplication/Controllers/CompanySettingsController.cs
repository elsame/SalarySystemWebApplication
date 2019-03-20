using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using SalarySystemWebApplication.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace SalarySystemWebApplication.Controllers
{
    public class CompanySettingsController : Controller
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

        // GET: CompanySettings
        public async Task<ActionResult> Index()
        {
            companyModel company = new companyModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                //Get list of Unions
                HttpResponseMessage Res = await client.GetAsync("api/companyModels/1");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var companyResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    company = JsonConvert.DeserializeObject<companyModel>(companyResponse);

                }

            }

            return View(company);
        }

        [HttpPost]
        public async Task<ActionResult> Index(companyModel company)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(company));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/companyModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }
                }

                return View(company);

            }

            catch
            {
                return View(company);
            }
        }

        // GET: CompanySettings
        public async Task<ActionResult> salaryCategory()
        {
            jobCatagoryModel job = new jobCatagoryModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                HttpResponseMessage Res = await client.GetAsync("api/jobCatagoryModels");
                job.salaryCatagoryList = new List<jobCatagoryModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job.salaryCatagoryList = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(UnionResponse);

                }

            }

            return View(job);
        }

        [HttpPost]
        public async Task<ActionResult> salaryCategory(jobCatagoryModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/jobCatagoryModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("salaryCategory");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/jobCatagoryModels");
                    job.salaryCatagoryList = new List<jobCatagoryModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        job.salaryCatagoryList = JsonConvert.DeserializeObject<List<jobCatagoryModel>>(UnionResponse);

                    }

                }
                return View(job);

            }

            catch
            {
                return View(job);
            }

        }

        public async Task<ActionResult> DeleteSalaryCategory(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/jobCatagoryModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("salaryCategory");
            }
            catch
            {
                return RedirectToAction("salaryCategory");
            }
        }

        public async Task<ActionResult> EditSalaryCategory(int id)
        {
            jobCatagoryModel job = new jobCatagoryModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/jobCatagoryModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job = JsonConvert.DeserializeObject<jobCatagoryModel>(EmpResponse);

                }

                return View(job);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditSalaryCategory(int id, jobCatagoryModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/jobCatagoryModels/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("SalaryCategory");
                }
                else
                {

                    return View(job);
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }

        // GET: CompanySettings
        public async Task<ActionResult> salaryGroup()
        {
            groupModel job = new groupModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                HttpResponseMessage Res = await client.GetAsync("api/groupModels");
                job.salaryGroupList = new List<groupModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job.salaryGroupList = JsonConvert.DeserializeObject<List<groupModel>>(UnionResponse);

                }
            }
            return View(job);
        }

        [HttpPost]
        public async Task<ActionResult> salaryGroup(groupModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/groupModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("salaryGroup");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/groupModels");
                    job.salaryGroupList = new List<groupModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        job.salaryGroupList = JsonConvert.DeserializeObject<List<groupModel>>(UnionResponse);

                    }

                }
                return View(job);

            }

            catch
            {
                return View(job);
            }

        }

        public async Task<ActionResult> DeleteSalaryGroup(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/groupModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("salaryGroup");
            }
            catch
            {
                return RedirectToAction("salaryGroup");
            }
        }

        public async Task<ActionResult> EditSalaryGroup(int id)
        {
            groupModel job = new groupModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/groupModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job = JsonConvert.DeserializeObject<groupModel>(EmpResponse);

                }

                return View(job);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditSalaryGroup(int id, groupModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/groupModels/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("SalaryGroup");
                }
                else
                {

                    return View(job);
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }

        // GET: CompanySettings
        public async Task<ActionResult> salaryItem()
        {
            launalidurModel launalidur = new launalidurModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                HttpResponseMessage Res = await client.GetAsync("api/launalidurModels?fradrattur=false");
                launalidur.salaryItemList = new List<launalidurModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    launalidur.salaryItemList = JsonConvert.DeserializeObject<List<launalidurModel>>(UnionResponse);

                }
            }
            return View(launalidur);
        }

        [HttpPost]
        public async Task<ActionResult> salaryItem(launalidurModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        job.fradrattur = false;
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/launalidurModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("salaryItem");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/launalidurModels?fradrattur=false");
                    job.salaryItemList = new List<launalidurModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        job.salaryItemList = JsonConvert.DeserializeObject<List<launalidurModel>>(UnionResponse);

                    }

                }
                return View(job);

            }

            catch
            {
                return View(job);
            }

        }

        public async Task<ActionResult> DeleteSalaryItem(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/launalidurModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("salaryItem");
            }
            catch
            {
                return RedirectToAction("salaryItem");
            }
        }

        public async Task<ActionResult> EditSalaryItem(int id)
        {
            launalidurModel job = new launalidurModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/launalidurModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job = JsonConvert.DeserializeObject<launalidurModel>(EmpResponse);

                }

                return View(job);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditSalaryItem(int id, launalidurModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/launalidurModels/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("SalaryItem");
                }
                else
                {

                    return View(job);
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }

        // GET: CompanySettings
        public async Task<ActionResult> deductionItem()
        {
            launalidurModel launalidur = new launalidurModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                HttpResponseMessage Res = await client.GetAsync("api/launalidurModels?fradrattur=true");
                launalidur.salaryItemList = new List<launalidurModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    launalidur.salaryItemList = JsonConvert.DeserializeObject<List<launalidurModel>>(UnionResponse);

                }
            }
            return View(launalidur);
        }

        [HttpPost]
        public async Task<ActionResult> deductionItem(launalidurModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        job.fradrattur = true;
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/launalidurModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("deductionItem");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/launalidurModels?fradrattur=true");
                    job.salaryItemList = new List<launalidurModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        job.salaryItemList = JsonConvert.DeserializeObject<List<launalidurModel>>(UnionResponse);

                    }

                }
                return View(job);

            }

            catch
            {
                return View(job);
            }

        }

        public async Task<ActionResult> DeleteDeductionItem(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/launalidurModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("deductionItem");
            }
            catch
            {
                return RedirectToAction("deductionItem");
            }
        }

        public async Task<ActionResult> EditDeductionItem(int id)
        {
            launalidurModel job = new launalidurModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/launalidurModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    job = JsonConvert.DeserializeObject<launalidurModel>(EmpResponse);

                }

                return View(job);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> EditDeductionItem(int id, launalidurModel job)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        job.fradrattur = true;
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(job));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/launalidurModels/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("DeductionItem");
                }
                else
                {

                    return View(job);
                }

            }

            catch
            {
                return RedirectToAction("DeductionItem");
            }

        }
    }
}