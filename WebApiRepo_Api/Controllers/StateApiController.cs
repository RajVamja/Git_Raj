using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class StateApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetState()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.SP_stateList().ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetStateById(int sId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.States.Where(x => x.sId == sId).FirstOrDefault();
            return Ok(list);
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertState(State s)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.States.Add(s);
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateState(State s)
        {
            rv.Entry(s).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DeleteState(int sId)
        {
            rv.sp_DeleteState(sId);
            return Ok();
        }
    }
}
