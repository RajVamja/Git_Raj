using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using WebApiRepo_Repository.Repository;
using WebApiRepo_Repository.Service;

namespace WebApiRepo
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ICountry, CountryService>();
            container.RegisterType<IState, StateService>();
            container.RegisterType<ICity, CityService>();
            container.RegisterType<ICity, CityService>();
            container.RegisterType<ISubject, SubjectService>();
            container.RegisterType<ITeacher, TeacherService>();
            container.RegisterType<IUser, UserService>();

            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}