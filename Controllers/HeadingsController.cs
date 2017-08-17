using Fixit.Models;
using Fixit.Request_and_Responses;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Fixit.Request_and_Responses.Headings;

namespace Fixit.Controllers
{
    public class HeadingsController:BaseController
    {
        public HeadingsController(FixitContext context):base(context)
        {

        }

        [Route("api/pageHeadings/create"), HttpPost]
        public BaseResponse addHeadings ([FromBody] HeadingsReq Req)
        {
            return new BLL.Headings(_db).createHeading(Req);
        }
        [Route("api/pageHeadings/edit"), HttpPost]
        public BaseResponse editHeadings ([FromBody] HeadingsReq Req)
        {
            return new BLL.Headings(_db).editHeadings(Req);
        }
         [Route("api/pageHeadings/view"), HttpPost]
        public List<HeadingRes> viewHeadings ([FromBody] int id)
        {
            return new BLL.Headings(_db).getHeadings(id);
        }
        [Route("api/pageHeadings/delete"), HttpPost]
        public BaseResponse deleteHeading ([FromBody] int id)
        {
            return new BLL.Headings(_db).deleteHeadings(id);
        }
    }

}