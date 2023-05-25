using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class SubjectApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSubject()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            IList<Subject> list = rv.Subjects.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetSubjectById(int subId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.Subjects.Where(x => x.subId == subId).FirstOrDefault();
            return Ok(list);
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertSubject(Subject sub)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.Subjects.Add(sub);
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateSubject(Subject sub)
        {
            rv.Entry(sub).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpDelete]
        public IHttpActionResult DelSubject(int subId)
        {
            rv.sp_DeleteSubject(subId);
            return Ok();
        }
    }
}
