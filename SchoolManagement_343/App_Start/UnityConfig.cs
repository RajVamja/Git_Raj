using SchoolManagement_343.Repository.Repository;
using SchoolManagement_343.Repository.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace SchoolManagement_343
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<Icountry, CountryServices>();
            container.RegisterType<IUser, UserServices>();
            container.RegisterType<Istate, StateServices>();
            container.RegisterType<Icity, CityServices>();
            container.RegisterType<Isubject, SubjectServices>();
            container.RegisterType<Iteacher, TeacherServices>();
            container.RegisterType<Istudent, StudentServices>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}