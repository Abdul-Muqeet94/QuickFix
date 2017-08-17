using Fixit.Models;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Headings;

namespace Fixit.BLL
{
    public class Headings
    {
         private readonly FixitContext _db;
        public Headings(FixitContext context)
        {
            _db=context;
        }
        public BaseResponse createHeading(HeadingsReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            db.page_heading.Add(
                new Models.PageHeading{
                    heading = req.heading,
                    description = req.description,
                    enable = true               
                }
            );
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Heading Added Successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to add Heading";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public BaseResponse editHeadings(HeadingsReq req)
        {
            BaseResponse toReturn=new BaseResponse();
            var db=_db;
            var heading=db.page_heading.Where(c=>c.id==req.id && c.enable==true).FirstOrDefault();
            heading.heading=req.heading;
            heading.description =req.description;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage= "Heading edited successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to edit Heading";
                toReturn.status=-1;
            }
            return toReturn;
        }

        public List<HeadingRes> getHeadings (int id)
        {
            List<HeadingRes> toReturn=new List<HeadingRes>();
            List<Models.PageHeading> gethed=new List<Models.PageHeading>();
            var db=_db;
            if(id==0)
            {
                 gethed=db.page_heading.Where(c=>c.enable==true).ToList();
                 
            }
            else
            {
                gethed=db.page_heading.Where(c=>c.id==id && c.enable==true).ToList();
            }
            for (int i=0;i<gethed.Count;i++)
            {
                HeadingRes res=new HeadingRes();
                res.id=gethed[i].id;
                res.heading=gethed[i].heading;
                res.description=gethed[i].description;
                toReturn.Add(res);              
            }
            return toReturn; 
        }
        
        public BaseResponse deleteHeadings (int id)
        {
            BaseResponse toReturn =new BaseResponse ();
            var db=_db;
            var heading=db.page_heading.Find(id);
            heading.enable=false;
            if(db.SaveChanges()>0)
            {
                toReturn.developerMessage="Heading deleted successfully";
                toReturn.status=1;
            }
            else
            {
                toReturn.developerMessage="unable to delete Heading";
                toReturn.status=-1;
            }
            return toReturn;
        }



    }
}