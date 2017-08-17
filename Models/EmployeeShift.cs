namespace Fixit.Models
{
    public class EmployeeShift
    {
         public int employeeId {get;set;}
        public Employee employee {get;set;}
        public int shiftsId {get;set;}
        public Shifts shifts {get;set;}
    }
}