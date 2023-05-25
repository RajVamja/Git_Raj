using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRepo_Models.Context;

namespace WebApiRepo_Api.Controllers
{
    public class CityApiController : ApiController
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCity()
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.SP_cityList().ToList();
            return Ok(list);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult GetCityById(int cityId)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            var list = rv.Cities.Where(x => x.cityId == cityId).FirstOrDefault();
            return Ok(list);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult AddCity(City city)
        {
            rv.Configuration.ProxyCreationEnabled = false;
            rv.Cities.Add(city);
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpPut]
        public IHttpActionResult EditCity(City city)
        {
            rv.Entry(city).State = System.Data.Entity.EntityState.Modified;
            rv.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public IHttpActionResult DelCity(int cityId)
        {
            rv.sp_DeleteCity(cityId);
            return Ok();
        }


        //[System.Web.Http.HttpDelete]
        //public IHttpActionResult DeleteStudent(int stdId)
        //{
        //    var st = rv.students.Where(model => model.stdId == stdId).FirstOrDefault();
        //    rv.Entry(st).State = System.Data.Entity.EntityState.Deleted;
        //    rv.SaveChanges();
        //    return Ok();
        //}
    }
}

