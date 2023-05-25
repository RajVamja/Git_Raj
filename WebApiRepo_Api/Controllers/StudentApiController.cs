using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class StudentApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudent()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.SP_studentsDetail().ToList();
            return Ok(list);
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudentById(int stdId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.students.Where(x => x.stdId == stdId).FirstOrDefault();
            return Ok(list);
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult AddStudent(student stu)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.students.Add(stu);
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult EditStudent(student stu)
        {
            rv.Entry(stu).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteStudent(int stdId)
        {
            rv.sp_DeleteStudent(stdId);
            return Ok();
        }
    }
}
