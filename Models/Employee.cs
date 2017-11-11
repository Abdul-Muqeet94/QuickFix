using System.Collections.Generic;
using System.Linq;

namespace Fixit.Models
{
    public class Employee:Identity
    {
        public Employee ()
        {
            service=new List<EmployeeService>();
            task=new List<TaskHasEmployee> ();
        }
        public string name {get;set;}
        public string email {get;set;}
        public string code {get;set;}
        public string contactNo {get;set;}
        public string emiratesId {get;set;}
        public string address {get;set;}
        public string nationality {get;set;}
        public bool status {get;set;}
        public string skill {get;set;}
        public virtual List<EmployeeService> service {get;set;}
        public virtual List<TaskHasEmployee> task {get;set;}
        public virtual List<EmployeeShift> employee_shift {get;set;}
    }
}