using System.Collections.Generic;
using Fixit.Request_and_Responses.Feature;

namespace Fixit.Request_and_Responses.Service
{
    public class ServiceReq
    {
      
        public int id {get;set;}
        public string name {get;set;}
        public string description {get;set;}
        public List<int> features=new List<int>();
    }
}