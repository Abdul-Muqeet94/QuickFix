using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses.Service;
using Fixit.Request_and_Responses.Shifts;

namespace Fixit.Request_and_Responses.Employee
{
    public class EmployeeRes
    {
        public EmployeeRes()
        {
            task=new List<TaskHasEmployee>();
            typeId=new List<ServiceRes>();
            shift=new List<ShiftRes>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string email{get;set;}
         public string code {get;set;}
        public string contactNo {get;set;}
        public string emiratesId {get;set;}
        public string address {get;set;}
        public string nationality {get;set;}
        public bool status {get;set;}
        public bool enable {get;set;}
        public string skill{get;set;}
        public List<ServiceRes> typeId=new List<ServiceRes>();
        public virtual List<TaskHasEmployee> task {get;set;}
        public virtual List<ShiftRes> shift{get;set;}
    }
}