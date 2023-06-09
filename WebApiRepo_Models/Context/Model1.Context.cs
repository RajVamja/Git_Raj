﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiRepo_Models.Context
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RajVamja_webapiEntities : DbContext
    {
        public RajVamja_webapiEntities()
            : base("name=RajVamja_webapiEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<teacher> teachers { get; set; }
        public virtual DbSet<student> students { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<SP_cityList_Result> SP_cityList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_cityList_Result>("SP_cityList");
        }
    
        public virtual ObjectResult<SP_stateList_Result> SP_stateList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_stateList_Result>("SP_stateList");
        }
    
        public virtual ObjectResult<SP_StudentsDet_Result> SP_StudentsDet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_StudentsDet_Result>("SP_StudentsDet");
        }
    
        public virtual ObjectResult<SP_studentsDetail_Result> SP_studentsDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_studentsDetail_Result>("SP_studentsDetail");
        }
    
        public virtual ObjectResult<SP_teachersDetail_Result> SP_teachersDetail()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_teachersDetail_Result>("SP_teachersDetail");
        }
    
        public virtual int sp_DeleteCity(Nullable<int> cityId)
        {
            var cityIdParameter = cityId.HasValue ?
                new ObjectParameter("cityId", cityId) :
                new ObjectParameter("cityId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCity", cityIdParameter);
        }
    
        public virtual int sp_DeleteStudent(Nullable<int> stdId)
        {
            var stdIdParameter = stdId.HasValue ?
                new ObjectParameter("stdId", stdId) :
                new ObjectParameter("stdId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteStudent", stdIdParameter);
        }
    
        public virtual int sp_DeleteCountry(Nullable<int> countryId)
        {
            var countryIdParameter = countryId.HasValue ?
                new ObjectParameter("countryId", countryId) :
                new ObjectParameter("countryId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCountry", countryIdParameter);
        }
    
        public virtual int sp_DeleteState(Nullable<int> stateId)
        {
            var stateIdParameter = stateId.HasValue ?
                new ObjectParameter("stateId", stateId) :
                new ObjectParameter("stateId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteState", stateIdParameter);
        }
    
        public virtual int sp_DeleteSubject(Nullable<int> subId)
        {
            var subIdParameter = subId.HasValue ?
                new ObjectParameter("subId", subId) :
                new ObjectParameter("subId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteSubject", subIdParameter);
        }
    }
}
