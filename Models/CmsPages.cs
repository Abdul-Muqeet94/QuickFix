using System.Collections.Generic;


namespace Fixit.Models
{
    public class CmsPages:Identity
    {
        
        public string page_name {get;set;}
        public string page_heading {get;set;}
        public string page_content {get;set;}
    }
}