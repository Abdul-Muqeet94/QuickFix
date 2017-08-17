using System;
using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses.Employee;

namespace Fixit.Request_and_Responses.Task
{
    public class AssignReq
    {      
        public int task_id {get;set;}
        public List<int> service_employee {get;set;}
        public string comments {get;set;}
      //  public List<AssignEmployee> service_employee {get;set;}
}

}