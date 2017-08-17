using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Cms;

namespace Fixit.Controllers
{
    public class PagesController:BaseController
    {
        public PagesController(FixitContext context):base(context)
        {

        }

        [Route("api/cms/create"), HttpPost]
        public BaseResponse addfeature ([FromBody] CmsReq Req)
        {
            return new BLL.Cms(_db).createPage(Req);
        }
        [Route("api/cms/edit"), HttpPost]
        public BaseResponse editPage ([FromBody] CmsReq Req)
        {
            return new BLL.Cms(_db).editPages(Req);
        }
         [Route("api/cms/view"), HttpPost]
        public List<CmsRes> viewFeature ([FromBody] int id)
        {
            return new BLL.Cms(_db).getCms(id);
        }
        
        [Route("api/cms/delete"), HttpPost]
        public BaseResponse deletePage ([FromBody] int id)
        {
            return new BLL.Cms(_db).deleteCms(id);
        }
        [Route("api/cms/viewbypage"), HttpPost]
        public List<CmsRes> viewByPage ([FromBody] string name)
        {
            return new BLL.Cms(_db).getPage(name);
        }
    }

}