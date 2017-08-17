using System;
using System.Collections.Generic;
using Fixit.Models;
using static Fixit.Utils.Constant;

namespace Fixit.Request_and_Responses.Shifts
{
    public class ShiftReq
    {   
        public ShiftReq()
        {
            days=new List<int>();
        }   
        public int id {get;set;}
        public string name {get;set;}
        public DateTime sTime {get;set;}
        public DateTime eTime {get;set;}
        public List<int> days {get;set;}
        public bool enable {get;set;}      
    }
}