using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalarySystemWebApplication.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace SalarySystemWebApplication.Controllers
{
    public class PensionsInfoController : Controller
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

        // GET: PensionsInfo
        public async Task<ActionResult> Index()
        {
            pensionFundModel pension = new pensionFundModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                //Get list of Unions
                HttpResponseMessage Res = await client.GetAsync("api/pensionFundModels/");
                pension.pensionList = new List<pensionFundModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var pensionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pension.pensionList = JsonConvert.DeserializeObject<List<pensionFundModel>>(pensionResponse);

                }

            }

            return View(pension);
        }

        [HttpPost]
        public async Task<ActionResult> Index(pensionFundModel pension)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        pension.active = true;
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(pension));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/pensionFundModels/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("Index");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/pensionFundModels");
                    pension.pensionList = new List<pensionFundModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var pensionResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        pension.pensionList = JsonConvert.DeserializeObject<List<pensionFundModel>>(pensionResponse);

                    }

                }
                return View(pension);

            }

            catch
            {
                return View(pension);
            }

        }

        public async Task<ActionResult> Edit(int id)
        {
            pensionFundModel pensionInfo = new pensionFundModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/pensionFundModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    pensionInfo = JsonConvert.DeserializeObject<pensionFundModel>(EmpResponse);

                }

                return View(pensionInfo);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, pensionFundModel pension)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(pension));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/pensionFundModels/" + id, content);

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

                    return View(pension);
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
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/pensionFundModels/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
    }
}

