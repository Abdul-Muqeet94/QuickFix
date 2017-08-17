using System.Collections.Generic;
using Fixit.Request_and_Responses.Service;

namespace Fixit.Request_and_Responses.Employee
{
    public class EmployeeReq
    {
        public EmployeeReq()
        {
            typeId=new List<int>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string email {get;set;}
         public string code {get;set;}
        public string contactNo {get;set;}
        public string emiratesId {get;set;}
        public string address {get;set;}
        public string nationality {get;set;}
        public List<int> typeId {get;set;}
        public List<int> shifts {get;set;}
        public bool status {get;set;}
  
    }
}