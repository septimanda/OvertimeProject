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
    public class OvertimeFileController : ApiController
    {
        private readonly IOvertimeFileApplication _overtimeFileApplication;

        public OvertimeFileController(IOvertimeFileApplication overtimeFileApplication)
        {
            _overtimeFileApplication = overtimeFileApplication;
        }
        
        // GET: api/OvertimeFile
        public HttpResponseMessage Get()
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            List<OvertimeFile> get = _overtimeFileApplication.Get();
            if (get.Count() != 0)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message; 
        }

        // GET: api/OvertimeFile/5
        public HttpResponseMessage Get(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Data");
            var get = _overtimeFileApplication.Get(id);
            if (get != null)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, get);
            }
            return message;
        }

        // POST: api/OvertimeFile
        public HttpResponseMessage Post([FromBody]OvertimeFileVM overtimeFileVM)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var inserted = _overtimeFileApplication.Insert(overtimeFileVM);
            if (inserted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, overtimeFileVM);
            }
            return message;
        }

        // PUT: api/OvertimeFile/5
        //public HttpResponseMessage Put(int id, [FromBody]OvertimeFileVM overtimeFileVM)
        //{
        //    var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
        //    var updated = _overtimeFileApplication.Update(id, overtimeFileVM);
        //    if (updated)
        //    {
        //        message = Request.CreateResponse(HttpStatusCode.OK, overtimeFileVM);
        //    }
        //    return message;
        //}

        // DELETE: api/OvertimeFile/5
        public HttpResponseMessage Delete(int id)
        {
            var message = Request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id");
            var deleted = _overtimeFileApplication.Delete(id);
            if (deleted)
            {
                message = Request.CreateResponse(HttpStatusCode.OK, "Deleted Successfully");
            }
            return message;
        }
    }
}
