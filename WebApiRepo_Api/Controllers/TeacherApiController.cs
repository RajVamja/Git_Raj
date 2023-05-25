using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class TeacherApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetTeacher()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.SP_teachersDetail().ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetTeacherByID(int tId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.teachers.Where(x => x.tId == tId).FirstOrDefault();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult insertTeacher(teacher teach)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.teachers.Add(teach);
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateTeacher(teacher teach)
        {
            rv.Entry(teach).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }
    }
}
