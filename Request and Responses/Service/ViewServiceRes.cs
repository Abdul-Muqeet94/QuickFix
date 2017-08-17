using System.Collections.Generic;
using Fixit.Request_and_Responses.Employee;
using Fixit.Request_and_Responses.Feature;

namespace Fixit.Request_and_Responses.Service
{
    public class ViewServiceRes
    {
        public ViewServiceRes()
        {
            feature =new List<FeatureRes>();
            assigned_employee=new List<EmployeeRes>();
            
        }
        public int id {get;set;}
        public string name {get;set;}
        public string description{get;set;}
        public bool enable {get;set;}
        public virtual List<EmployeeRes>  assigned_employee{get;set;}
        public virtual List<FeatureRes> feature {get;set;}
    }
}