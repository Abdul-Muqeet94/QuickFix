using System.Collections.Generic;
using Fixit.Models;
using static Fixit.Utils.Constant;

namespace Fixit.Request_and_Responses.Shifts
{
    public class ShiftRes
    {
    public ShiftRes()
    {
        day=new List<string>();
    }
     public int id {get;set;}
        public string name {get;set;}
        public string sTime {get;set;}
        public string eTime {get;set;}
        public string sDate {get;set;}
        public string eDate {get;set;}
        public List<string> day {get;set;}
        public bool enable {get;set;}  
    }
}