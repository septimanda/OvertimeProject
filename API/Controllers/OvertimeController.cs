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
    public class OvertimeController : ApiController
    {
        private readonly IOvertimeApplication _overtimeApplication;

        public OvertimeController(IOvertimeApplication overtimeApplication)
        {
            _overtimeApplication = overtimeApplication;
        }

        // GET: api/Overtime
        public HttpResponseMessage Get()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            List<Overtime> get = _overtimeApplication.Get();
            if (get.Count() != 0)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message;
        }

        // GET: api/Overtime/5
        public HttpResponseMessage Get(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var get = _overtimeApplication.Get(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message;
        }

        // POST: api/Overtime
        public HttpResponseMessage Post([FromBody]OvertimeVM overtimeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var inserted = _overtimeApplication.Insert(overtimeVM);
            if (inserted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, overtimeVM);
            }
            return message;
        }

        // PUT: api/Overtime/5
        public HttpResponseMessage Put(int id, [FromBody]OvertimeVM overtimeVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var updated = _overtimeApplication.Update(id, overtimeVM);
            if (updated)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, overtimeVM);
            }
            return message;
        }

        // DELETE: api/Overtime/5
        public HttpResponseMessage Delete(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var deleted = _overtimeApplication.Delete(id);
            if (deleted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            }
            return message;
        }
    }
}
