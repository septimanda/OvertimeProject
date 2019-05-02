using OvertimeProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace OvertimeProject.Controllers
{
    public class OvertimeFileController : Controller
    {
        string urlApi = "http://localhost:57811/api/";
        HttpClient client;

        // GET: Item
        public IEnumerable<OvertimeFileVM> loadOvertimeFile()
        {
            IEnumerable<OvertimeFileVM> overtimeFileVM = null;
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.GetAsync("OvertimeFile");
            responses.Wait();
            var result = responses.Result;
            if (result.IsSuccessStatusCode)
            {
                var reads = result.Content.ReadAsAsync<IList<OvertimeFileVM>>();
                reads.Wait();
                overtimeFileVM = reads.Result;

            }
            else
            {
                overtimeFileVM = Enumerable.Empty<OvertimeFileVM>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return overtimeFileVM;
        }

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get(int id)
        {
            OvertimeFileVM overtimeFileVM = null;
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.GetAsync("OvertimeFile/" + id);
            responses.Wait();
            var result = responses.Result;
            if (result.IsSuccessStatusCode)
            {
                var reads = result.Content.ReadAsAsync<OvertimeFileVM>();
                reads.Wait();
                overtimeFileVM = reads.Result;
            }
            else
            {
                overtimeFileVM = null;
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return Json(overtimeFileVM, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Save(OvertimeFileVM overtimeFileVM)
        {
            //Short Version
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.PostAsJsonAsync("OvertimeFile", overtimeFileVM);
            responses.Wait();
            return Json(loadOvertimeFile(), JsonRequestBehavior.AllowGet);
        }


        public JsonResult Delete(int id)
        {
            //Short Version
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.DeleteAsync("OvertimeFile/" + id);
            responses.Wait();
            return Json(loadOvertimeFile(), JsonRequestBehavior.AllowGet);
            //return loadItem();
            //return JsonConvert.SerializeObject(loadItem());
        }

        public ActionResult LoadData()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data    
                var customerData = loadOvertimeFile();

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
                }
                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    customerData = customerData.Where(m => m.Name.Contains(searchValue));
                }

                //total number of rows count     
                recordsTotal = customerData.Count();
                //Paging     
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}