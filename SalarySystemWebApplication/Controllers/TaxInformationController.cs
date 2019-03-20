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
    public class TaxInformationController : Controller
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

        // GET: TaxInformations
        public async Task<ActionResult> Index()
        {
            taxOfficeModel taxOffice = new taxOfficeModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                //Get list of Unions
                HttpResponseMessage Res = await client.GetAsync("api/taxOfficeModels");
                taxOffice.taxOfficeList = new List<taxOfficeModel>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    taxOffice.taxOfficeList = JsonConvert.DeserializeObject<List<taxOfficeModel>>(UnionResponse);

                }
            }

            return View(taxOffice);
        } 

        [HttpPost]
        public async Task<ActionResult> Index(taxOfficeModel tax)
        {
            try
            {

                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        tax.active = true;
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(tax));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/taxOfficeModels/", content);

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
                    HttpResponseMessage Res = await client.GetAsync("api/taxOfficeModels");
                    tax.taxOfficeList = new List<taxOfficeModel>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var taxResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        tax.taxOfficeList = JsonConvert.DeserializeObject<List<taxOfficeModel>>(taxResponse);

                    }
                }

                return View(tax);
            }

            catch
            {
                return View(tax);
            }

        }

        public ActionResult TaxItem()
        {
            taxItems taxItem = new taxItems();

            taxItem.activeFrom = DateTime.Today;

            using (var client = new HttpClient())
            {
                setClientSettings(client);

                //Get list of Unions
                var Res = client.GetAsync("api/taxItems").Result;
                taxItem.taxItemList = new List<taxItems>();

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    taxItem.taxItemList = JsonConvert.DeserializeObject<List<taxItems>>(UnionResponse);

                }
            }

            return View(taxItem);
        }

        [HttpPost]
        public async Task<ActionResult> TaxItem(taxItems tax)
        {

            try
            {

                if (ModelState.IsValid)
                {

                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        tax.active = true;
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(tax));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PostAsync("api/taxItems/", content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                        ModelState.Clear();

                    }

                    return RedirectToAction("TaxItem");
                }

                using (var client = new HttpClient())
                {
                    setClientSettings(client);

                    //Get list of Unions
                    HttpResponseMessage Res = await client.GetAsync("api/taxItems");
                    tax.taxItemList = new List<taxItems>();

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var taxResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        tax.taxItemList = JsonConvert.DeserializeObject<List<taxItems>>(taxResponse);

                    }
                }

                return View(tax);
            }

            catch
            {
                return View(tax);
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
                    HttpResponseMessage Res = await client.DeleteAsync("api/taxOfficeModels/" + id);

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

        public async Task<ActionResult> DeleteTaxItem(int id)
        {

            try
            {
                using (var client = new HttpClient())
                {
                    setClientSettings(client);
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.DeleteAsync("api/taxItems/" + id);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                    }
                }

                return RedirectToAction("TaxItem");
            }
            catch
            {
                return RedirectToAction("TaxItem");
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            taxOfficeModel taxOffice = new taxOfficeModel();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/taxOfficeModels/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    taxOffice = JsonConvert.DeserializeObject<taxOfficeModel>(EmpResponse);

                }

                return View(taxOffice);

            }
        }

        public async Task<ActionResult> TaxItemEdit(int id)
        {
            taxItems tax = new taxItems();

            using (var client = new HttpClient())
            {
                setClientSettings(client);
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/taxItems/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    tax = JsonConvert.DeserializeObject<taxItems>(EmpResponse);

                }

                return View(tax);

            }
        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> TaxItemEdit(int id, taxItems tax)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(tax));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/taxItems/" + id, content);

                        //Checking the response is successful or not which is sent using HttpClient  
                        if (Res.IsSuccessStatusCode)
                        {
                            //Storing the response details recieved from web api   
                            var UnionResponse = Res.Content.ReadAsStringAsync().Result;

                        }

                    }

                    ModelState.Clear();
                    return RedirectToAction("TaxItem");
                }
                else
                {

                    return View(tax);
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }

        // POST: EmpModel/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, taxOfficeModel taxOffice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var client = new HttpClient())
                    {
                        setClientSettings(client);
                        //serialize object to Json and create the HttpContent
                        HttpContent content = new StringContent(JsonConvert.SerializeObject(taxOffice));
                        content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                        //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                        HttpResponseMessage Res = await client.PutAsync("api/taxOfficeModels/" + id, content);

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

                    return View(taxOffice);
                }

            }

            catch
            {
                return RedirectToAction("Index");
            }

        }
    }
}

       