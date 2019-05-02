using BusinessLogic.Application.Interface;
using Data.Models;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployeeApplication _employeeApplication;

        public EmployeeController(IEmployeeApplication employeeApplication)
        {
            _employeeApplication = employeeApplication;
        }

        // GET: api/Employee
        public HttpResponseMessage Get()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            List<Employee> get = _employeeApplication.Get();
            if (get.Count() != 0)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message;
        }

        // GET: api/Employee/5
        public HttpResponseMessage Get(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var get = _employeeApplication.Get(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message;
        }

        // POST: api/Employee
        public HttpResponseMessage Post([FromBody]EmployeeVM employeeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var inserted = _employeeApplication.Insert(employeeVM);
            if (inserted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, employeeVM);
            }
            return message;
        }

        // PUT: api/Employee/5
        public HttpResponseMessage Put(int id, [FromBody]EmployeeVM employeeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var updated = _employeeApplication.Update(id, employeeVM);
            if (updated)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, employeeVM);
            }
            return message;
        }

        // DELETE: api/Employee/5
        public HttpResponseMessage Delete(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var deleted = _employeeApplication.Delete(id);
            if (deleted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Data has been deleted.");
            }
            return message;
        }
    }
}
