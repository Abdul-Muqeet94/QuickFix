using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses.Feature;

namespace Fixit.Request_and_Responses.Service
{
    public class ServiceRes
    {
        public ServiceRes()
        {
            feature =new List<FeatureRes>();
        }
        public int id {get;set;}
        public string name {get;set;}
        public string description{get;set;}
        public bool enable {get;set;}
        public virtual List<FeatureRes> feature {get;set;}
    }
}