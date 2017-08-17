using System;
using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses.Service;

namespace Fixit.Request_and_Responses.Task
{
    public class TaskRes
    {

        public TaskRes()
        {
            selected_features = new List<ServiceRes>();
            selected_shift = new Models.Shifts();
            assigned_employee = new List<string>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string email {get;set;}
        public string date { get; set; }
       public String shift{get;set;}
        public double callUpCharges { get; set; }
        public string landmark { get; set; }
        public string lat { get; set; }
        public string longg { get; set; }
        public string house_no { get; set; }
        public string customer_contact { get; set; }
        public Models.Shifts selected_shift { get; set; }
        public virtual List<ServiceRes> selected_features { get; set; }
        public virtual List<string> assigned_employee { get; set; }
        public string paymentStatus { get; set; }
        public string complete {get;set;}
        public string comments {get;set;}
        public string image {get;set;}
    }

}