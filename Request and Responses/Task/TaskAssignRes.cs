using System.Collections.Generic;
using Fixit.Request_and_Responses.Employee;
using Fixit.Request_and_Responses.Service;

namespace Fixit.Request_and_Responses.Task
{
    public class TaskAssignRes
    {
        public TaskAssignRes()
{
    selected_features =new List<ViewServiceRes>();
}


        public int id {get;set;}
        public string name {get;set;}
        public string email{get;set;}
        public string date {get;set;}
        public double callUpCharges {get;set;}
        public string landmark {get;set;}
        public string lat {get;set;}
        public string longg{get;set;}
        public string house_no {get;set;}
        public string customer_contact {get;set;}
        public int shiftId {get;set;}
        public string shift{get;set;}
        public virtual List<ViewServiceRes> selected_features {get;set;}
        public string complete {get;set;}
        public string comments {get;set;}
        public string paymentStatus {get;set;}
        public string image {get;set;}
    }
}