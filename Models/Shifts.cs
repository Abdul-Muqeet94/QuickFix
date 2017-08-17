using System;
using System.Collections.Generic;
using static Fixit.Utils.Constant;

namespace Fixit.Models
{
    public class Shifts:Identity
    {
        public Shifts()
        {
        }
        public string name {get;set;}
        public DateTime sTime {get;set;}
        public DateTime eTime {get;set;}
        public bool day1 {get;set;}
        public bool day2 {get;set;}
        public bool day3 {get;set;}
        public bool day4 {get;set;}
        public bool day5 {get;set;}
        public bool day6 {get;set;}
        public bool day7 {get;set;}
        public List<EmployeeShift> employee{get;set;}
        
    }
}