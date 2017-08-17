using Fixit.Models;
using Fixit.Request_and_Responses.Service;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Feature;

namespace Fixit.BLL
{
    public class Feature
    {
         private readonly FixitContext _db;
        public Feature(FixitContext context)
        {
            _db=context;
        }
        public BaseResponse createFeature(FeatureReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            db.Features.Add(
                new Models.Features{
                    name = req.name,
                    description = req.description,
                    enable = true               
                }
            );
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Feature Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to add Feature";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public BaseResponse editFeature(FeatureReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var feature=db.Features.Where(c=>c.id==req.id && c.enable==true).FirstOrDefault();
            feature.name=req.name;
            feature.description =req.description;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage= "Feature edit successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to edit Feature";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public List<FeatureRes> getFeature (int id)
        {
            List<FeatureRes> toReturn=new List<FeatureRes>();
            List<Models.Features> getFea=new List<Models.Features>();
            var db=_db;
            if(id==0)
            {
                 getFea=db.Features.Where(c=>c.enable==true).ToList();
                 
            }
            else
            {
                getFea=db.Features.Where(c=>c.id==id && c.enable==true).ToList();
            }
            for (int i=0;i<getFea.Count;i++)
            {
                FeatureRes res=new FeatureRes();
                res.id=getFea[i].id;
                res.name=getFea[i].name;
                res.description=getFea[i].description;
                toReturn.Add(res);              
            }
            return toReturn; 
        }
        
        public BaseResponse deleteFeature (int id)
        {
            BaseResponse toReturn =new BaseResponse ();
            var db=_db;
            var feature=db.Features.Find(id);
            feature.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Feature deleted successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to delete Feature";
                toReturn.status=-1;
            }
            return toReturn;
        }
    }
}