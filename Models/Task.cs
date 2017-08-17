using System;
using System.Collections.Generic;

namespace Fixit.Models
{
    public class Task:Identity
    {
        public Task()
        {
            services_employee=new List<TaskHasEmployee>();
        }
        public string name {get;set;}
        public string email {get;set;}
        public double callUpCharges {get;set;}
        public string landmark {get;set;}
        public string location {get;set;}
        public string house_no {get;set;}
        public string customer_contact {get;set;}
        public string shift{get;set;}
        public DateTime date {get;set;}
        public DateTime startTime {get;set;}
        public DateTime endTime {get;set;}
        public virtual List<TaskHasEmployee> services_employee {get;set;}
        public int paymentStatus {get;set;}
        public int complete {get;set;}
        public string comments {get;set;}
        public string image { get; set; }
    }
}