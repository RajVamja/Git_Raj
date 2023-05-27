using ApiProjrct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiProjrct.Controllers
{

    public class CrudAPIController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();
        //[Route("api/raj")]
        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStudents()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            //IList<student> list = rv.students.ToList();
            var list = rv.SP_StudentsDet().ToList();
            return Ok(list);
        }


        [System.Web.Http.HttpGet]
        public IHttpActionResult GetDetails(int stdId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var student = rv.students.Where(x => x.stdId == stdId).FirstOrDefault();
            return Ok(student);
        }



        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertStudents(student std)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.students.Add(std);
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateStudents(student std)
        {
            rv.Entry(std).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteStudent(int stdId)
        {
            var st = rv.students.Where(model => model.stdId == stdId).FirstOrDefault();
            rv.Entry(st).State = System.Data.Entity.EntityState.Deleted;
            rv.SaveChanges();
            return Ok();
        }
    }
}
