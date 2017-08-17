using System.Collections.Generic;

namespace Fixit.Models
{
    public class Features:Identity
    {
        public Features()
        {
           selected_features= new List<SelectedFeatures>();
        }
        public string name {get;set;}
        public string description {get;set;}
        public List<SelectedFeatures> selected_features {get;set;}
    }
}