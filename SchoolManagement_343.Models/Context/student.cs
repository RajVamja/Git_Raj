//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SchoolManagement_343.Models.Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        public int stdId { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public System.DateTime DOB { get; set; }
        public string sPhone { get; set; }
        public string sEmail { get; set; }
        public string Gender { get; set; }
        public string sAddress { get; set; }
        public string teacher { get; set; }
        public int city { get; set; }
        public int state { get; set; }
        public int country { get; set; }
        public int studentType { get; set; }
    
        public virtual City City1 { get; set; }
        public virtual Country Country1 { get; set; }
        public virtual State State1 { get; set; }
    }
}
