using Student.Business.Facade.Filters;
using Student.Business.Logic.BusinessLogic;
using Student.Common.Logic.Log;
using Student.Common.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace Student.Business.Facade.Controllers
{
    public class AlumnoController : ApiController
    {
        private readonly ILogger Log;
        private readonly IBusiness studentBl;
        public AlumnoController(ILogger Log , IBusiness business)
        {
            this.Log = Log;
            this.studentBl = business;
        }

        [ConnectionFilter]
        [HttpGet()]
        public IHttpActionResult SelectById(int id)
        {
            Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.SelectById(id));
        }

        [ConnectionFilter]
        [HttpGet()]
        public IHttpActionResult GetAll()
        {
             Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.GetAll());
        }

        [ConnectionFilter]
        [HttpPost()]
        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Create(Alumno entity)
        {
             Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Create(entity));
        }

        [ConnectionFilter]
        [HttpPut()]
        [ResponseType(typeof(Alumno))]
        public IHttpActionResult Update(int id , Alumno entity)
        {
             Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Update(id,entity));
        }

        [ConnectionFilter]
        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
             Log.Debug(""+ System.Reflection.MethodBase.GetCurrentMethod().Name);
            return Ok(studentBl.Delete(id));
        }

    }
}