using System.Collections.Generic;

namespace Fixit.Models
{
    public class Services : Identity
    {
        public Services()
        {
            features =new List<Features>();
            services_employee=new List<TaskHasEmployee>();
        }
        public string name { get; set; }
        public string description { get; set; }
        public virtual List<EmployeeService> employees {get;set;}
        public virtual List<Features> features {get;set;}
        public virtual List<TaskHasEmployee> services_employee {get;set;}

    }
}