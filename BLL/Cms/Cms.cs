using Fixit.Models;
using System.Collections.Generic;
using System.Linq;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.Cms;

namespace Fixit.BLL
{
    public class Cms
    {
        private readonly FixitContext _db;
        public Cms(FixitContext context)
        {
            _db = context;
        }
        public BaseResponse createPage(CmsReq req)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;

            db.cms_pages.Add(
                new Models.CmsPages
                {
                    page_name = req.name,
                    page_heading = req.heading,
                    page_content = req.content,
                    enable=true
                }
            );
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Page Added Successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "unable to add Page";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public BaseResponse editPages(CmsReq req)
        {
            BaseResponse toReturn = new BaseResponse();

            var db = _db;
            var page = db.cms_pages.Where(c => c.id == req.id && c.enable == true).FirstOrDefault();
            page.page_name = req.name;
            page.page_heading = req.heading;
            page.page_content=req.content;
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Page edited Successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to Edit Page";
                toReturn.status = -1;
            }
            return toReturn;
        }

        public List<CmsRes> getCms(int id)
        {
            List<CmsRes> toReturn = new List<CmsRes>();
            List<Models.CmsPages> getcms = new List<Models.CmsPages>();
            var db = _db;
            if (id == 0)
            {
                getcms = db.cms_pages.Where(c => c.enable == true).ToList();
            }
            else
            {
                getcms = db.cms_pages.Where(c => c.id == id && c.enable == true).ToList();
            }
            for (int i = 0; i < getcms.Count; i++)
            {
                CmsRes res = new CmsRes();
                res.id = getcms[i].id;
                res.name = getcms[i].page_name;
                res.heading = getcms[i].page_heading;
                res.content=getcms[i].page_content;
                toReturn.Add(res);
            }
            return toReturn;
        }

         public List<CmsRes> getPage(string name)
        {
            List<CmsRes> toReturn = new List<CmsRes>();
            List<Models.CmsPages> getcms = new List<Models.CmsPages>();
            var db = _db;
            
                getcms = db.cms_pages.Where(c => c.enable == true && c.page_name==name).ToList();
            
            for (int i = 0; i < getcms.Count; i++)
            {
                CmsRes res = new CmsRes();
                res.id = getcms[i].id;
                res.name = getcms[i].page_name;
                res.heading = getcms[i].page_heading;
                res.content=getcms[i].page_content;
                toReturn.Add(res);
            }
            return toReturn;
        }

        

        public BaseResponse deleteCms(int id)
        {
            BaseResponse toReturn = new BaseResponse();
            var db = _db;
            var cms = db.cms_pages.Find(id);
            cms.enable = false;
            if (db.SaveChanges() > 0)
            {
                toReturn.developerMessage = "Cms page deleted successfully";
                toReturn.status = 1;
            }
            else
            {
                toReturn.developerMessage = "Unable to delete Cms Page";
                toReturn.status = -1;
            }
            return toReturn;
        }



    }
}