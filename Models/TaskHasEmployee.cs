using System.Collections.Generic;

namespace Fixit.Models
{
    public class TaskHasEmployee:Identity
    {
        public TaskHasEmployee()
        {
            selected_features=new List<SelectedFeatures>();
        }
   
        public int taskid {get;set;}
        public virtual Task task {get;set;}
        public int  selectedserviceid {get;set;}
        public virtual Services selectedservice {get;set;}
        public int employeeid {get;set;}
        public virtual Employee employee {get;set;}
        public virtual List<SelectedFeatures> selected_features {get;set;}
        public virtual Shifts selected_shift {get;set;}
    }
        
}