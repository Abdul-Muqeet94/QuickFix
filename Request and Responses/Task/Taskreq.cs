using System;
using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses.Service;

namespace Fixit.Request_and_Responses.Task
{
    public class TaskReq
    {      
    
        public int id {get;set;}
        public string name {get;set;}
        public string email {get;set;}
        public double callUpCharges {get;set;}
        public string landmark {get;set;}
        public string location {get;set;}
        public string house_no {get;set;}
        public string customer_contact {get;set;}
        public int selected_shift {get;set;}
        public DateTime date {get;set;}
        public string shift {get;set;}
        public List<ServiceReq> selected_services {get;set;}
        public int paymentStatus {get;set;}
        public int complete {get;set;}
        public string image {get;set;}
}

}