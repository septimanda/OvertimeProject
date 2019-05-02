using Newtonsoft.Json;
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
    public class EmployeeController : Controller
    {
        string urlApi = "http://localhost:57811/api/";
        HttpClient client;

        public IEnumerable<EmployeeVM> loadEmployees()
        {
            IEnumerable<EmployeeVM> employeeVM = null;
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.GetAsync("Employee");
            responses.Wait();
            var result = responses.Result;
            if (result.IsSuccessStatusCode)
            {
                var reads = result.Content.ReadAsAsync<IList<EmployeeVM>>();
                reads.Wait();
                employeeVM = reads.Result;
            }
            else
            {
                employeeVM = Enumerable.Empty<EmployeeVM>();
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return employeeVM;
        }

        public ActionResult Index()
        {
            //IEnumerable<RoleVM> employeeVM = null;
            //client = new HttpClient();
            //client.BaseAddress = new Uri("https://192.168.132.49:10066/api/");
            //var responses = client.GetAsync("Roles");
            //responses.Wait();
            //var result = responses.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var reads = result.Content.ReadAsAsync<IList<RoleVM>>();
            //    reads.Wait();
            //    employeeVM = reads.Result;
            //}
            //return View(employeeVM);
            return View(loadEmployees());
        }

        public string loadSupplierJSON()
        {
            return JsonConvert.SerializeObject(loadEmployees());
        }

        public string Get(int id)
        {
            EmployeeVM employeeVM = null;
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.GetAsync("Employee/" + id);
            responses.Wait();
            var result = responses.Result;
            if (result.IsSuccessStatusCode)
            {
                var reads = result.Content.ReadAsAsync<EmployeeVM>();
                reads.Wait();
                employeeVM = reads.Result;
            }
            else
            {
                employeeVM = null;
                ModelState.AddModelError(string.Empty, "Server Error");
            }
            return JsonConvert.SerializeObject(employeeVM);
        }

        public string Save(EmployeeVM employeeVM)
        {
            //Short Version
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            if (employeeVM.Id == 0)
            {
                var responses = client.PostAsJsonAsync("Employee", employeeVM);
                responses.Wait();
            }
            else
            {
                var responses = client.PutAsJsonAsync("Employee/" + employeeVM.Id, employeeVM);
                responses.Wait();
            }
            return JsonConvert.SerializeObject(loadEmployees());
        }


        public string Delete(int id)
        {
            //Short Version
            client = new HttpClient();
            client.BaseAddress = new Uri(urlApi);
            var responses = client.DeleteAsync("Employee/" + id);
            responses.Wait();
            return JsonConvert.SerializeObject(loadEmployees());
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
                var customerData = loadEmployees();

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
