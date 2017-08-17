using Fixit.Models;
using Fixit.Request_and_Responses.Service;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses;
using Microsoft.EntityFrameworkCore;
using Fixit.Request_and_Responses.Feature;

namespace Fixit.BLL
{
    public class Service
    {
         private readonly FixitContext _db;
        public Service(FixitContext context)
        {
            _db=context;
        }
        public BaseResponse createService(ServiceReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            List<Features> featuresList=new List<Features>();
            foreach(var entity in req.features)
            {
            var features=db.Features.Where(c=>c.id.Equals(entity)).FirstOrDefault();
            featuresList.Add(features);
            }
           
               Models.Services serviceDb= new Models.Services();
                    serviceDb.name = req.name;
                    serviceDb.description = req.description;
                    serviceDb.features.AddRange(featuresList);
                    serviceDb.enable=true;  
                    db.services.Add(serviceDb);            
              
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Service Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to add Service";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public BaseResponse editService(ServiceReq req)
        {
            BaseResponse toReturn = NewMethod();
            var db = _db;
            var service = db.services.Where(c => c.id == req.id && c.enable == true).Include(m=>m.features).FirstOrDefault();
            service.name = req.name;
            service.description = req.description;
            int featureLength=service.features.Count;
            var toRemove=service.features;
            for (int i=featureLength-1;i>=0;i--)
            {
                service.features.Remove(toRemove[i]);
            }
            
            foreach (var entity in req.features)
            {
                var feature = db.Features.Where(m => m.enable == true && m.id == entity).FirstOrDefault();
                service.features.Add(feature);
            }
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Service edit successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "unable to edit Service";
                toReturn.status = -1;
            }
            return toReturn;
        }

        private static BaseResponse NewMethod()
        {
            return new BaseResponse();
        }

        public List<ServiceRes> getService (int id)
        {
            List<ServiceRes> toReturn=new List<ServiceRes>();
            List<Models.Services> getSer=new List<Models.Services>();
            var db=_db;
            if(id==0)
            {
                 getSer=db.services.Where(c=>c.enable==true).Include(c=>c.features).ToList();
                 
            }
            else
            {
                getSer=db.services.Where(c=>c.id==id && c.enable==true).Include(c=>c.features).ToList();
            }
            for (int i=0;i<getSer.Count;i++)
            {
                ServiceRes res=new ServiceRes();
                List<FeatureRes> featureList=new List<FeatureRes>();
                foreach(var entity in getSer[i].features)
                {
                    featureList.Add(new FeatureRes{
                        id=entity.id,
                        name=entity.name,
                        description=entity.description
                    });
                }
                res.id=getSer[i].id;
                res.name=getSer[i].name;
                res.description=getSer[i].description;
                res.enable=getSer[i].enable;
                res.feature=featureList;
                toReturn.Add(res);
                
            }
            return toReturn; 
        }
        
        public BaseResponse deleteService (int id)
        {
            BaseResponse toReturn =new BaseResponse ();
            var db=_db;
            var service=db.services.Find(id);
            service.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Service deleted successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to delete service";
                toReturn.status=-1;
            }
            return toReturn;
        }
    }
}