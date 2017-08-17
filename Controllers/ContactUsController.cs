using System.Collections.Generic;
using Fixit.Models;
using Fixit.Request_and_Responses;
using Fixit.Request_and_Responses.ContactUS;
using Microsoft.AspNetCore.Mvc;

namespace Fixit.Controllers
{
    public class ContactUsController:BaseController
    {
        public ContactUsController(FixitContext context):base(context)
        {}
        
         [Route("api/contactus/create"), HttpPost]

        public BaseResponse addContactUs ([FromBody] ContactUsReq req)
        {
            return new BLL.ContactUs.ContactUs(_db).create(req);
        }
        [Route("api/contactus/view"), HttpPost]

        public List<ContactUsRes> viewContactUs ([FromBody] int req)
        {
            return new BLL.ContactUs.ContactUs(_db).view(req);
        }
        [Route("api/contactus/delete"), HttpPost]
        public BaseResponse deleteContactUs ([FromBody] int req)
        {
            return new BLL.ContactUs.ContactUs(_db).delete(req);
        }
    }
}