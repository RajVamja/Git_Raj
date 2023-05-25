using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class CountryApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCountry()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            IList<Country> list = rv.Countries.ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCountryById(int cId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.Countries.Where(x => x.cId == cId).FirstOrDefault();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult InsertCountry(Country c)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.Countries.Add(c);
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult UpdateCountry(Country c)
        {
            rv.Entry(c).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }


        [System.Web.Http.HttpDelete]
        public IHttpActionResult DelCountry(int cId)
        {
            rv.sp_DeleteCountry(cId);
            return Ok();
        }
    }
}
