namespace Fixit.Models
{
    public class SelectedFeatures:Identity
    {
        public int taskhasemployeeid {get;set;}
        public virtual TaskHasEmployee taskhasemployee {get;set;}
        public int featuresid {get;set;}
        public virtual Features features {get;set;}
    }
}